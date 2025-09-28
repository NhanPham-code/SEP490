// This function will be called from the .cshtml file, passing in the server-rendered data.
function initializeBookingManager(viewModel, stadiums) {
    const container = document.querySelector('.bm-container');
    if (!container) {
        console.error("Booking Manager container (.bm-container) not found. Scripts will not run.");
        return;
    }

    // --- Element Selections ---
    const stadiumFilter = container.querySelector('#bm-stadiumFilter');
    const bookingTypeFilter = container.querySelector('#bm-bookingTypeFilter');
    const statusFilter = container.querySelector('#bm-statusFilter'); // Thêm bộ lọc trạng thái
    const dateFilter = container.querySelector('#bm-dateFilter');
    const clearDateBtn = container.querySelector('.bm-clear-date-btn');
    const dailySection = container.querySelector('#bm-daily-booking-section');
    const monthlySection = container.querySelector('#bm-monthly-booking-section');
    const modal = document.getElementById('bm-bookingDetailModal');

    // --- Helper Functions ---
    const getStatusClass = (status) => {
        if (!status) return 'bm-status-default';
        switch (status.toLowerCase()) {
            case "pending": return "bm-status-pending";
            case "accepted": return "bm-status-accepted";
            case "completed": return "bm-status-completed";
            case "cancelled":
            case "denied":
            case "payfail": return "bm-status-cancelled";
            case "waiting": return "bm-status-waiting";
            default: return "bm-status-default";
        }
    };

    const translateStatus = (status) => {
        if (!status) return 'Không xác định';
        switch (status.toLowerCase()) {
            case "pending": return "Chờ xử lý";
            case "accepted": return "Đã nhận";
            case "completed": return "Đã hoàn thành";
            case "cancelled": return "Đã hủy";
            case "denied": return "Đã từ chối";
            case "waiting": return "Chờ thanh toán";
            case "payfail": return "Lỗi thanh toán";
            default: return status;
        }
    };

    const formatTimeSpan = (timespanString) => {
        if (!timespanString || typeof timespanString !== 'string') return '';
        const parts = timespanString.split(':');
        return `${parts[0]}:${parts[1]}`;
    };

    // --- Core Functions ---
    function applyFilters() {
        const selectedStadiumId = stadiumFilter.value;
        const selectedBookingType = bookingTypeFilter.value;
        const selectedStatus = statusFilter.value; // Lấy giá trị từ bộ lọc trạng thái
        const selectedDate = dateFilter.value;

        const cancelledStatuses = ['cancelled', 'denied', 'payfail'];

        // Lọc hiển thị các section chính
        dailySection.style.display = (selectedBookingType === 'all' || selectedBookingType === 'daily') ? 'block' : 'none';
        monthlySection.style.display = (selectedBookingType === 'all' || selectedBookingType === 'monthly') ? 'block' : 'none';

        // Lọc các dòng trong bảng Lịch Đặt Hằng Ngày
        container.querySelectorAll('#bm-daily-booking-section .bm-booking-table tbody tr').forEach(row => {
            if (!row.dataset.stadiumId) return; // Bỏ qua các dòng không có dữ liệu (vd: no-data row)

            const stadiumMatch = selectedStadiumId === 'all' || row.dataset.stadiumId === selectedStadiumId;
            const dateMatch = !selectedDate || row.dataset.playDate === selectedDate;

            const rowStatus = row.dataset.status;
            let statusMatch = false;
            if (selectedStatus === 'all') {
                statusMatch = true;
            } else if (selectedStatus === 'cancelled-group') {
                statusMatch = cancelledStatuses.includes(rowStatus);
            } else {
                statusMatch = rowStatus === selectedStatus;
            }

            // Kết hợp tất cả điều kiện
            row.style.display = (stadiumMatch && dateMatch && statusMatch) ? '' : 'none';
        });

        // Lọc các dòng trong bảng Lịch Đặt Hằng Tháng
        container.querySelectorAll('#bm-monthly-booking-section .bm-booking-table > tbody > tr.bm-monthly-parent-row').forEach(row => {
            if (!row.dataset.stadiumId) return;

            const stadiumMatch = selectedStadiumId === 'all' || row.dataset.stadiumId === selectedStadiumId;

            const rowStatus = row.dataset.status;
            let statusMatch = false;
            if (selectedStatus === 'all') {
                statusMatch = true;
            } else if (selectedStatus === 'cancelled-group') {
                statusMatch = cancelledStatuses.includes(rowStatus);
            } else {
                statusMatch = rowStatus === selectedStatus;
            }

            // Kết hợp điều kiện
            row.style.display = (stadiumMatch && statusMatch) ? '' : 'none';

            // Ẩn các dòng con khi lọc
            const monthlyId = row.dataset.monthlyId;
            const childRow = container.querySelector(`.bm-child-bookings-row[data-parent-monthly-id="${monthlyId}"]`);
            if (childRow) { childRow.style.display = 'none'; }
            row.classList.remove('bm-expanded');
        });
    }

    function openModal() { modal.style.display = 'flex'; }
    function closeModal() { modal.style.display = 'none'; }

    function populateModal(bookingVm, type) {
        const modalHeader = modal.querySelector('.bm-modal-header');
        const modalBody = modal.querySelector('.bm-modal-body');

        const isMonthly = type === 'monthly';
        const bookingData = isMonthly ? bookingVm.monthlyBooking : bookingVm.booking;
        const userData = bookingVm.user;
        const stadium = stadiums.find(s => s.id === bookingData.stadiumId);

        modalHeader.innerHTML = `<h3><i class="fas fa-receipt"></i> Chi tiết Lịch đặt ${isMonthly ? 'Tháng' : 'Ngày'} #${bookingData.id}</h3><button class="bm-modal-close-btn">&times;</button>`;

        const originalPrice = (bookingData.originalPrice ?? 0);
        const totalPrice = (bookingData.totalPrice ?? 0);

        let detailsHtml = `
            <div class="bm-modal-section">
                <h4 class="bm-modal-section-title"><i class="fas fa-info-circle"></i> Thông tin chung</h4>
                <div class="bm-modal-grid">
                    <div class="bm-modal-detail-item"><span class="label"><i class="fas fa-user"></i> Khách hàng</span><span class="value">${userData.fullName}</span></div>
                    <div class="bm-modal-detail-item"><span class="label"><i class="fas fa-futbol"></i> Sân vận động</span><span class="value">${stadium?.name ?? 'N/A'}</span></div>
                    <div class="bm-modal-detail-item"><span class="label"><i class="fas fa-calendar-plus"></i> Ngày tạo</span><span class="value">${new Date(bookingData.createdAt).toLocaleString('vi-VN')}</span></div>
                    <div class="bm-modal-detail-item"><span class="label"><i class="fas fa-flag"></i> Trạng thái</span><span class="value"><span class="bm-status-badge ${getStatusClass(bookingData.status)}">${translateStatus(bookingData.status)}</span></span></div>
                    <div class="bm-modal-detail-item"><span class="label"><i class="fas fa-credit-card"></i> Thanh toán</span><span class="value">${bookingData.paymentMethod || 'Chưa có'}</span></div>
                    <div class="bm-modal-detail-item"><span class="label"><i class="fas fa-sticky-note"></i> Ghi chú</span><span class="value">${bookingData.note || 'Không có'}</span></div>
                </div>
            </div>`;

        if (isMonthly) {
            detailsHtml += `
                <div class="bm-modal-section">
                    <h4 class="bm-modal-section-title"><i class="fas fa-calendar-alt"></i> Chi tiết Lịch đặt Tháng ${bookingData.month}/${bookingData.year}</h4>
                     <div class="bm-modal-grid">
                        <div class="bm-modal-detail-item"><span class="label"><i class="fas fa-clock"></i> Khung giờ</span><span class="value">${formatTimeSpan(bookingData.startTime)} - ${formatTimeSpan(bookingData.endTime)}</span></div>
                        <div class="bm-modal-detail-item"><span class="label"><i class="fas fa-hourglass-half"></i> Tổng giờ</span><span class="value">${bookingData.totalHour} giờ</span></div>
                    </div>
                    <h5 style="margin-top: 1.5rem; margin-bottom: 0.5rem; font-weight:600;">Danh sách các ngày đặt:</h5>
                    <div id="bm-monthly-bookings-list">
                        ${bookingVm.bookings.length > 0 ? bookingVm.bookings.map(b => `
                            <div class="bm-list-item">
                                <span><i class="fas fa-check-circle" style="color: #34d399;"></i> ${new Date(b.date).toLocaleDateString('vi-VN')}</span>
                                <span class="bm-status-badge ${getStatusClass(b.status)}">${translateStatus(b.status)}</span>
                            </div>
                        `).join('') : '<p style="text-align:center; padding: 1rem;">Không có lịch đặt chi tiết.</p>'}
                    </div>
                </div>`;
        } else {
            detailsHtml += `
                <div class="bm-modal-section">
                    <h4 class="bm-modal-section-title"><i class="fas fa-calendar-day"></i> Chi tiết Lịch đặt Ngày</h4>
                    <div class="bm-modal-grid">
                        <div class="bm-modal-detail-item"><span class="label"><i class="fas fa-calendar-alt"></i> Ngày chơi</span><span class="value">${new Date(bookingData.date).toLocaleDateString('vi-VN')}</span></div>
                    </div>
                    <h5 style="margin-top: 1.5rem; margin-bottom: 0.5rem; font-weight:600;">Danh sách sân con:</h5>
                    <div id="bm-monthly-bookings-list">
                        ${bookingData.bookingDetails.map(d => `
                        <div class="bm-list-item">
                            <span>Sân con ID: ${d.courtId}</span>
                            <span>${new Date(d.startTime).toLocaleTimeString('vi-VN', { hour: '2-digit', minute: '2-digit' })} - ${new Date(d.endTime).toLocaleTimeString('vi-VN', { hour: '2-digit', minute: '2-digit' })}</span>
                        </div>
                    `).join('')}
                    </div>
                </div>`;
        }

        detailsHtml += `
             <div class="bm-modal-section">
                <h4 class="bm-modal-section-title"><i class="fas fa-dollar-sign"></i> Chi tiết Thanh toán</h4>
                <div class="bm-modal-pricing-grid">
                    <div class="bm-modal-pricing-item"><div class="label">Giá gốc</div><div class="value" style="text-decoration: line-through;">${originalPrice.toLocaleString('vi-VN')}₫</div></div>
                    <div class="bm-modal-pricing-item"><div class="label">Giảm giá</div><div class="value">${(originalPrice - totalPrice).toLocaleString('vi-VN')}₫</div></div>
                </div>
                <div class="bm-modal-pricing-item bm-total" style="margin-top: 1rem;"><div class="label">Thành tiền</div><div class="value">${totalPrice.toLocaleString('vi-VN')}₫</div></div>
            </div>`;

        modalBody.innerHTML = detailsHtml;
        openModal();
    }

    function updateBookingStatus(id, type, newStatus, confirmText) {
        Swal.fire({
            title: confirmText, text: "Hành động này có thể không thể hoàn tác!", icon: 'warning',
            showCancelButton: true, confirmButtonColor: '#3085d6', cancelButtonColor: '#d33',
            confirmButtonText: 'Đồng ý', cancelButtonText: 'Hủy bỏ'
        }).then((result) => {
            if (result.isConfirmed) {
                const collection = type === 'daily' ? viewModel.dailyBookings : viewModel.monthlyBookings;
                const bookingData = (type === 'daily')
                    ? collection.find(vm => vm.booking.id == id)?.booking
                    : collection.find(vm => vm.monthlyBooking.id == id)?.monthlyBooking;

                if (!bookingData) { Swal.fire('Lỗi!', 'Không tìm thấy booking!', 'error'); return; }

                let dto = { ...bookingData, status: newStatus };
                const url = type === 'daily' ? `/Booking/UpdateBooking/${id}` : `/Booking/UpdateMonthlyBooking/${id}`;

                fetch(url, { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(dto) })
                    .then(response => {
                        if (!response.ok) { return response.json().then(err => { throw new Error(err.message || 'Cập nhật thất bại') }); }
                        return response.json();
                    })
                    .then(data => {
                        // 🔑 BƯỚC KHẮC PHỤC: Ưu tiên kiểm tra URL VNPay và chuyển hướng
                        if (data.paymentRequired && data.paymentUrl) {
                            // Chuyển hướng trình duyệt sang VNPay ngay lập tức
                            window.location.href = data.paymentUrl;
                            return; // Ngăn không cho code phía dưới chạy
                        }

                        if (data.success) {
                            Swal.fire('Thành công!', 'Trạng thái đã được cập nhật.', 'success').then(() => location.reload());
                        }
                        else {
                            throw new Error(data.message || 'Lỗi từ server');
                        }
                    })
            }
        });
    }

    // --- Event Listeners ---
    stadiumFilter.addEventListener('change', applyFilters);
    bookingTypeFilter.addEventListener('change', applyFilters);
    statusFilter.addEventListener('change', applyFilters); // Thêm event listener cho bộ lọc mới
    dateFilter.addEventListener('change', applyFilters);
    dateFilter.addEventListener('input', applyFilters);
    clearDateBtn.addEventListener('click', () => {
        dateFilter.value = '';
        applyFilters();
    });

    container.querySelectorAll('.bm-expand-toggle').forEach(toggle => {
        toggle.addEventListener('click', function () {
            const parentRow = this.closest('.bm-monthly-parent-row');
            const monthlyId = parentRow.dataset.monthlyId;
            const childRow = container.querySelector(`.bm-child-bookings-row[data-parent-monthly-id="${monthlyId}"]`);
            if (childRow) {
                parentRow.classList.toggle('bm-expanded');
                childRow.style.display = parentRow.classList.contains('bm-expanded') ? 'table-row' : 'none';
            }
        });
    });

    modal.addEventListener('click', (e) => {
        if (e.target === modal || e.target.closest('.bm-modal-close-btn')) closeModal();
    });

    container.addEventListener('click', function (e) {
        const button = e.target.closest('.bm-action-btn');
        if (!button) return;
        const bookingId = button.dataset.bookingId;
        const bookingType = button.dataset.bookingType;

        if (button.classList.contains('details')) {
            const collection = bookingType === 'daily' ? viewModel.dailyBookings : viewModel.monthlyBookings;
            const bookingVm = collection.find(vm => (bookingType === 'daily' ? vm.booking.id : vm.monthlyBooking.id) == bookingId);
            if (bookingVm) { populateModal(bookingVm, bookingType); }
        }
        else if (button.classList.contains('accept')) { updateBookingStatus(bookingId, bookingType, 'accepted', 'Chấp nhận lịch đặt?'); }
        else if (button.classList.contains('deny')) { updateBookingStatus(bookingId, bookingType, 'denied', 'Từ chối lịch đặt này?'); }
        else if (button.classList.contains('cancel')) { updateBookingStatus(bookingId, bookingType, 'cancelled', 'Bạn có chắc muốn hủy lịch đặt này?'); }
    });
}