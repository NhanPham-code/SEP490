document.addEventListener('DOMContentLoaded', function () {
    const container = document.querySelector('.bm-container');
    if (!container) {
        console.error("Booking Manager container (.bm-container) not found. Scripts will not run.");
        return;
    }

    // --- Lấy các phần tử DOM chính ---
    const filterForm = container.querySelector('#bm-main-filter-form');
    const applyFilterBtn = container.querySelector('#bm-apply-filter-btn');
    const bookingTypeFilter = container.querySelector('#bm-bookingTypeFilter');
    const tablesContainer = container.querySelector('#booking-tables-container');
    const modal = document.getElementById('bm-bookingDetailModal');

    // --- Helper Functions (đã được dọn dẹp) ---
    const getStatusClass = (status) => {
        if (!status) return 'bm-status-default';
        switch (status.toLowerCase()) {
            case "accepted": return "bm-status-accepted";
            case "completed": return "bm-status-completed";
            case "cancelled":
            case "payfail": return "bm-status-cancelled";
            case "waiting": return "bm-status-waiting";
            default: return "bm-status-default";
        }
    };

    const translateStatus = (status) => {
        if (!status) return 'Không xác định';
        switch (status.toLowerCase()) {
            case "accepted": return "Đã nhận";
            case "completed": return "Đã hoàn thành";
            case "cancelled": return "Đã hủy";
            case "waiting": return "Chờ thanh toán";
            case "payfail": return "Lỗi thanh toán";
            default: return status;
        }
    };

    const formatCurrency = (value) => new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(value);

    // --- Các hàm cốt lõi ---

    /**
     * Gắn lại tất cả các event listener cần thiết cho nội dung mới được tải qua AJAX.
     * Cần được gọi mỗi khi tablesContainer.innerHTML được cập nhật.
     */
    function rebindAllEventListeners() {
        // 1. Gắn sự kiện cho các link phân trang
        tablesContainer.querySelectorAll('.bm-pagination a[data-page]').forEach(link => {
            link.addEventListener('click', function (e) {
                e.preventDefault();
                const page = this.dataset.page;
                const paramName = this.dataset.param;
                loadFilteredBookings(page, paramName);
            });
        });

        // 2. Gắn sự kiện cho các nút hành động (Chi tiết, Hủy)
        tablesContainer.querySelectorAll('.bm-action-btn').forEach(button => {
            button.addEventListener('click', handleActionButtonClick);
        });

        // 3. Gắn sự kiện cho toggle mở rộng của lịch tháng
        tablesContainer.querySelectorAll('.bm-expand-toggle').forEach(toggle => {
            toggle.addEventListener('click', function () {
                const parentRow = this.closest('.bm-monthly-parent-row');
                const childRow = parentRow.nextElementSibling;
                if (parentRow && childRow) {
                    parentRow.classList.toggle('bm-expanded');
                    childRow.style.display = parentRow.classList.contains('bm-expanded') ? 'table-row' : 'none';
                }
            });
        });

        // 4. Gắn lại logic cho việc hủy các lịch con của lịch tháng (nếu có)
        tablesContainer.querySelectorAll('.bm-confirm-child-cancel-btn').forEach(button => {
            // ... Dán logic xử lý hủy lịch con từ file JS cũ của bạn vào đây nếu cần ...
        });
    }

    /**
     * Xử lý sự kiện click trên các nút hành động trong bảng.
     * @param {Event} e - Sự kiện click.
     */
    function handleActionButtonClick(e) {
        const button = e.currentTarget;
        const bookingId = button.dataset.bookingId;
        const bookingType = button.dataset.bookingType;

        if (button.classList.contains('details')) {
            // TODO: Để xem chi tiết sau khi lọc AJAX, cách tốt nhất là fetch dữ liệu
            // chi tiết từ một API endpoint riêng rồi mới hiển thị modal.
            console.warn(`Hiển thị chi tiết cho ${bookingType} ID ${bookingId}. Cần có API để lấy dữ liệu mới nhất.`);
            Swal.fire('Tính năng đang phát triển', 'Chức năng xem chi tiết sau khi lọc cần được nâng cấp để lấy dữ liệu mới nhất.', 'info');
        }
        else if (button.classList.contains('cancel')) {
            updateBookingStatus(bookingId, bookingType, 'cancelled', 'Bạn có chắc muốn hủy lịch đặt này?');
        }
    }

    /**
     * Gửi yêu cầu cập nhật trạng thái lịch đặt đến server.
     * @param {string} id - ID của lịch đặt.
     * @param {string} type - 'daily' hoặc 'monthly'.
     * @param {string} newStatus - Trạng thái mới.
     * @param {string} confirmText - Tin nhắn xác nhận.
     */
    function updateBookingStatus(id, type, newStatus, confirmText) {
        Swal.fire({
            title: confirmText,
            text: "Hành động này có thể không thể hoàn tác!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#6b7280',
            confirmButtonText: 'Đồng ý',
            cancelButtonText: 'Hủy bỏ'
        }).then((result) => {
            if (result.isConfirmed) {
                // TODO: Tạo một API endpoint chuyên để cập nhật trạng thái sẽ tốt hơn.
                // Tạm thời vẫn dùng URL cũ nhưng sẽ tải lại bảng bằng AJAX thay vì reload trang.
                const url = type === 'daily' ? `/Booking/UpdateBooking/${id}` : `/Booking/UpdateMonthlyBooking/${id}`;
                const payload = { status: newStatus }; // Gửi một payload tối giản

                fetch(url, {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(payload)
                })
                    .then(response => {
                        if (!response.ok) return response.json().then(err => { throw new Error(err.message || 'Cập nhật thất bại') });
                        return response.json();
                    })
                    .then(data => {
                        if (data.success) {
                            Swal.fire('Thành công!', 'Trạng thái đã được cập nhật.', 'success');
                            loadFilteredBookings(); // Tải lại bảng với filter hiện tại
                        } else {
                            throw new Error(data.message || 'Lỗi từ server');
                        }
                    })
                    .catch(error => Swal.fire('Lỗi!', error.message, 'error'));
            }
        });
    }

    /**
     * Hàm chính: Gửi yêu cầu lọc đến server và cập nhật lại nội dung bảng.
     * @param {number} page - Số trang cần tải.
     * @param {string} pageParam - Tên tham số của trang ('dailyPage' hoặc 'monthlyPage').
     */
    function loadFilteredBookings(page = 1, pageParam = "dailyPage") {
        const formData = new FormData(filterForm);
        const url = new URL(filterForm.action || window.location.href);

        formData.forEach((value, key) => {
            if (value) url.searchParams.set(key, value);
        });

        const dailyPage = pageParam === 'dailyPage' ? page : 1;
        const monthlyPage = pageParam === 'monthlyPage' ? page : 1;
        url.searchParams.set('dailyPage', dailyPage);
        url.searchParams.set('monthlyPage', monthlyPage);

        tablesContainer.style.opacity = '0.5';
        tablesContainer.style.pointerEvents = 'none';

        fetch(url.toString(), {
            method: 'GET',
            headers: { 'X-Requested-With': 'XMLHttpRequest' }
        })
            .then(response => response.text())
            .then(html => {
                tablesContainer.innerHTML = html;
                toggleTableVisibility();
                rebindAllEventListeners();
            })
            .catch(error => {
                console.error('Lỗi khi lọc lịch đặt:', error);
                Swal.fire('Lỗi!', 'Không thể tải dữ liệu. Vui lòng thử lại.', 'error');
            })
            .finally(() => {
                tablesContainer.style.opacity = '1';
                tablesContainer.style.pointerEvents = 'auto';
            });
    }

    /**
     * Ẩn/hiện các bảng lịch đặt dựa trên giá trị của dropdown "Loại lịch đặt".
     * ĐÃ CẬP NHẬT: Không còn xử lý trường hợp "all".
     */
    function toggleTableVisibility() {
        const selectedType = bookingTypeFilter.value;
        const dailySection = tablesContainer.querySelector('#bm-daily-booking-section');
        const monthlySection = tablesContainer.querySelector('#bm-monthly-booking-section');

        if (dailySection) {
            dailySection.style.display = (selectedType === 'daily') ? 'block' : 'none';
        }
        if (monthlySection) {
            monthlySection.style.display = (selectedType === 'monthly') ? 'block' : 'none';
        }
    }


    // --- GẮN CÁC EVENT LISTENER BAN ĐẦU ---

    // 1. Sự kiện submit của form lọc
    filterForm.addEventListener('submit', (e) => {
        e.preventDefault(); // Ngăn trình duyệt submit và tải lại trang
        loadFilteredBookings(); // Thay vào đó, gọi hàm AJAX của chúng ta
    });

    // 2. Sự kiện thay đổi dropdown "Loại lịch đặt"
    bookingTypeFilter.addEventListener('change', toggleTableVisibility);

    // 3. Sự kiện đóng modal
    modal.addEventListener('click', (e) => {
        if (e.target === modal || e.target.closest('.bm-modal-close-btn')) {
            modal.style.display = 'none';
        }
    });

    // 4. Gắn các event cho nội dung được tải lần đầu tiên
    rebindAllEventListeners();
    toggleTableVisibility();
});