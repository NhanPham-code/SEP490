document.addEventListener('DOMContentLoaded', function () {
    // --- KHỞI TẠO VÀ KIỂM TRA ---
    const container = document.querySelector('.bm-container');
    if (!container) {
        console.error("Lỗi: Container .bm-container không tìm thấy. Script sẽ không chạy.");
        return;
    }

    // --- LẤY CÁC PHẦN TỬ DOM CHÍNH ---
    const filterForm = container.querySelector('#bm-main-filter-form');
    const bookingTypeFilter = container.querySelector('#bm-bookingTypeFilter');
    const tablesContainer = container.querySelector('#booking-tables-container');
    const modal = document.getElementById('bm-bookingDetailModal');

    // --- CÁC HÀM HỖ TRỢ (HELPER FUNCTIONS) ---
    // (Đã dọn dẹp, không còn pending/denied)
    const getStatusClass = (status) => {
        if (!status) return 'bm-status-default';
        switch (status.toLowerCase()) {
            case "accepted": return "bm-status-accepted";
            case "completed": return "bm-status-completed";
            case "cancelled": case "payfail": return "bm-status-cancelled";
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
    const formatCurrency = (value) => new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(value || 0);
    const formatTimeSpan = (ts) => ts ? ts.substring(0, 5) : '';

    // =================================================================
    // ===== PHẦN 1: LỌC VÀ PHÂN TRANG (THEO "CÁCH MỚI") ================
    // =================================================================

    /**
     * Gắn lại tất cả các event listener cần thiết cho nội dung mới được tải qua AJAX.
     * Cần được gọi mỗi khi `tablesContainer.innerHTML` được cập nhật.
     */
    function rebindAllEventListeners() {
        // 1. Gắn sự kiện cho các link phân trang
        tablesContainer.querySelectorAll('.bm-pagination a[data-page]').forEach(link => {
            link.addEventListener('click', function (e) {
                e.preventDefault();
                loadFilteredBookings(this.dataset.page, this.dataset.param);
            });
        });

        // 2. Gắn sự kiện cho tất cả các nút hành động
        tablesContainer.querySelectorAll('.bm-action-btn').forEach(button => {
            button.addEventListener('click', handleActionButtonClick);
        });

        // 3. Gắn lại logic cho lịch tháng (nếu có)
        rebindMonthlyBookingLogic();
    }

    /**
     * [ĐÃ SỬA LỖI] Ẩn/hiện các bảng lịch đặt dựa trên giá trị của dropdown "Loại lịch đặt".
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

    /**
     * Hàm chính: Gửi yêu cầu lọc đến server và cập nhật lại nội dung bảng bằng AJAX.
     */
    function loadFilteredBookings(page = 1, pageParam = null) {
        const url = new URL(window.location.origin + '/Booking/BookingManager');

        const currentParams = new URLSearchParams(window.location.search);
        let dailyPage = parseInt(currentParams.get('dailyPage') || '1');
        let monthlyPage = parseInt(currentParams.get('monthlyPage') || '1');

        if (pageParam === 'dailyPage') { dailyPage = page; }
        else if (pageParam === 'monthlyPage') { monthlyPage = page; }
        else if (pageParam === null) {
            // Là một hành động lọc mới, reset về trang 1
            dailyPage = 1;
            monthlyPage = 1;
        }

        // Lấy giá trị từ form và chỉ thêm vào URL nếu có giá trị thực
        const type = filterForm.querySelector('#bm-bookingTypeFilter')?.value;
        const stadiumId = filterForm.querySelector('#bm-stadiumFilter')?.value;
        const status = filterForm.querySelector('#bm-statusFilter')?.value;
        const filterMonth = filterForm.querySelector('#bm-monthFilter')?.value;
        const filterYear = filterForm.querySelector('#bm-yearFilter')?.value;

        // Luôn thêm type
        if (type) url.searchParams.set('type', type);

        // Chỉ thêm stadiumId nếu có giá trị (không rỗng)
        if (stadiumId && stadiumId !== '') {
            url.searchParams.set('stadiumId', stadiumId);
        }

        // Chỉ thêm status nếu không phải "all"
        if (status && status !== 'all') {
            url.searchParams.set('status', status);
        }

        // Chỉ thêm filterMonth nếu không phải 0
        if (filterMonth && filterMonth !== '0') {
            url.searchParams.set('filterMonth', filterMonth);
        }

        // Chỉ thêm filterYear nếu không phải 0
        if (filterYear && filterYear !== '0') {
            url.searchParams.set('filterYear', filterYear);
        }

        url.searchParams.set('dailyPage', dailyPage);
        url.searchParams.set('monthlyPage', monthlyPage);

        tablesContainer.style.opacity = '0.5';
        tablesContainer.style.pointerEvents = 'none';

        fetch(url.toString(), { method: 'GET', headers: { 'X-Requested-With': 'XMLHttpRequest' } })
            .then(response => response.text())
            .then(html => {
                tablesContainer.innerHTML = html;
                toggleTableVisibility();
                rebindAllEventListeners();
                window.history.pushState({}, '', url.toString());
            })
            .catch(error => console.error('Lỗi khi lọc lịch đặt:', error))
            .finally(() => {
                tablesContainer.style.opacity = '1';
                tablesContainer.style.pointerEvents = 'auto';
            });
    }


    // =====================================================================
    // ===== PHẦN 2: XEM CHI TIẾT & CẬP NHẬT (THEO "CÁCH CŨ") ===============
    // =====================================================================

    /**
     * Xử lý các nút hành động (Chi tiết, Hủy).
     */
    function handleActionButtonClick(e) {
        const button = e.currentTarget;
        const bookingId = button.dataset.bookingId;
        const bookingType = button.dataset.bookingType;
        const row = button.closest('tr');
        if (!row) return;

        const stadiumNameFromRow = row.dataset.stadiumName;

        const bookingJson = row.dataset.bookingJson;
        if (!bookingJson) {
            console.error('Lỗi: không tìm thấy thuộc tính data-booking-json trên hàng này.');
            return;
        }
        const bookingVm = JSON.parse(bookingJson);
        const bookingData = bookingType === 'daily' ? bookingVm.booking : bookingVm.monthlyBooking;

        if (button.classList.contains('details')) {
            populateModal(bookingVm, bookingType, stadiumNameFromRow);
        } else if (button.classList.contains('cancel')) {
            updateBookingStatus(bookingId, bookingType, 'cancelled', 'Bạn có chắc muốn hủy lịch đặt này?', bookingData);
        }
    }

    /**
     * [ĐÃ SỬA LỖI] Hiển thị popup chi tiết, đầy đủ như phiên bản gốc.
     * Hàm này đọc dữ liệu từ `bookingVm` (được parse từ `data-booking-json`) để xây dựng modal.
     */
    function populateModal(bookingVm, type, stadiumNameOverride) {
        const modalHeader = document.getElementById('bm-modalHeader');
        const modalBody = document.getElementById('bm-modalBodyContent');
        const isMonthly = type === 'monthly';
        const bookingData = isMonthly ? bookingVm.monthlyBooking : bookingVm.booking;
        const userData = bookingVm.user;
        const stadiumName = stadiumNameOverride || bookingData.stadiumName || 'N/A';

        modalHeader.innerHTML = `<h3><i class="fas fa-receipt"></i> Chi tiết Lịch đặt ${isMonthly ? 'Tháng' : 'Ngày'} #${bookingData.id}</h3><button class="bm-modal-close-btn">&times;</button>`;

        let detailsHtml = `
            <div class="bm-modal-section">
                <h4 class="bm-modal-section-title"><i class="fas fa-info-circle"></i> Thông tin chung</h4>
                <div class="bm-modal-grid">
                    <div class="bm-modal-detail-item"><span class="label"><i class="fas fa-user"></i> Khách hàng</span><span class="value">${userData.fullName}</span></div>
                    <div class="bm-modal-detail-item"><span class="label"><i class="fas fa-futbol"></i> Sân vận động</span><span class="value">${stadiumName}</span></div>
                    <div class="bm-modal-detail-item"><span class="label"><i class="fas fa-calendar-plus"></i> Ngày tạo</span><span class="value">${new Date(bookingData.createdAt).toLocaleString('vi-VN')}</span></div>
                    <div class="bm-modal-detail-item"><span class="label"><i class="fas fa-flag"></i> Trạng thái</span><span class="value"><span class="bm-status-badge ${getStatusClass(bookingData.status)}">${translateStatus(bookingData.status)}</span></span></div>
                    <div class="bm-modal-detail-item"><span class="label"><i class="fas fa-credit-card"></i> Thanh toán</span><span class="value">${bookingData.paymentMethod || 'Chưa có'}</span></div>
                    <div class="bm-modal-detail-item bm-full-width"><span class="label"><i class="fas fa-sticky-note"></i> Ghi chú</span><span class="value">${[bookingData.note || null,userData.email || null,userData.phone || null].filter(item => item !== null && item !== '' && item !== undefined).join(' - ')}</span></div>
                </div>
            </div>`;

        let pricingHtml = '';
        if (isMonthly) {
            detailsHtml += `<div class="bm-modal-section"><h4 class="bm-modal-section-title"><i class="fas fa-calendar-alt"></i> Chi tiết Lịch đặt Tháng ${bookingData.month}/${bookingData.year}</h4><div class="bm-modal-grid"><div class="bm-modal-detail-item"><span class="label"><i class="fas fa-clock"></i> Khung giờ</span><span class="value">${formatTimeSpan(bookingData.startTime)} - ${formatTimeSpan(bookingData.endTime)}</span></div></div><h5 style="margin-top: 1.5rem; margin-bottom: 0.5rem; font-weight:600;">Danh sách các ngày đặt:</h5><div id="bm-monthly-bookings-list">${(bookingVm.bookings || []).map(b => `<div class="bm-list-item"><span>${new Date(b.date).toLocaleDateString('vi-VN')}</span><span class="bm-status-badge ${getStatusClass(b.status)}">${translateStatus(b.status)}</span></div>`).join('')}</div></div>`;
            const sumOfChildBookings = (bookingVm.bookings || []).reduce((sum, child) => sum + (child.totalPrice ?? 0), 0);
            pricingHtml = `<div class="bm-pricing-line bm-total" style="margin-top: 1rem;"><div class="label">Tổng tiền</div><div class="value">${formatCurrency(sumOfChildBookings)}</div></div>`;
        } else {
            detailsHtml += `<div class="bm-modal-section"><h4 class="bm-modal-section-title"><i class="fas fa-calendar-day"></i> Chi tiết Lịch đặt Ngày</h4><div class="bm-modal-grid"><div class="bm-modal-detail-item"><span class="label"><i class="fas fa-calendar-alt"></i> Ngày chơi</span><span class="value">${new Date(bookingData.date).toLocaleDateString('vi-VN')}</span></div></div><h5 style="margin-top: 1.5rem; margin-bottom: 0.5rem; font-weight:600;">Danh sách sân con:</h5><div id="bm-monthly-bookings-list">${(bookingData.bookingDetails || []).map(d => `<div class="bm-list-item"><span>${d.courtName || `Sân ID: ${d.courtId}`}</span><span>${new Date(d.startTime).toLocaleTimeString('vi-VN', { hour: '2-digit', minute: '2-digit' })} - ${new Date(d.endTime).toLocaleTimeString('vi-VN', { hour: '2-digit', minute: '2-digit' })}</span></div>`).join('')}</div></div>`;
            pricingHtml = `<div class="bm-pricing-line bm-total" style="margin-top: 1rem;"><div class="label">Thành tiền</div><div class="value">${formatCurrency(bookingData.totalPrice)}</div></div>`;
        }
        detailsHtml += `<div class="bm-modal-section"><h4 class="bm-modal-section-title"><i class="fas fa-dollar-sign"></i> Chi tiết Thanh toán</h4>${pricingHtml}</div>`;

        modalBody.innerHTML = detailsHtml;
        modal.style.display = 'flex';
    }

    /**
     * Gọi API để cập nhật trạng thái, sau đó tải lại toàn bộ trang.
     */
    function updateBookingStatus(id, type, newStatus, confirmText, bookingDataForPayload = null) {
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
                // Nếu không có payload, dùng payload mặc định. Nếu có, dùng nó (cho trường hợp hủy)
                let dto = bookingDataForPayload ? { ...bookingDataForPayload, status: newStatus } : { status: newStatus };

                const url = type === 'daily' ? `/Booking/UpdateBooking/${id}` : `/Booking/UpdateMonthlyBooking/${id}`;

                fetch(url, {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(dto)
                })
                    .then(response => response.json())
                    .then(data => {
                        if (data.paymentRequired && data.paymentUrl) {
                            window.location.href = data.paymentUrl; // Chuyển hướng thanh toán
                            return;
                        }
                        if (data.success || data.redirectUrl) {
                            Swal.fire('Thành công!', 'Trạng thái đã được cập nhật.', 'success')
                                .then(() => location.reload()); // Tải lại trang sau khi thành công
                        } else {
                            throw new Error(data.message || 'Lỗi không xác định từ server');
                        }
                    })
                    .catch(error => Swal.fire('Lỗi!', error.message, 'error'));
            }
        });
    }

    /**
     * Gắn lại logic cho việc hủy lịch con và mở rộng lịch tháng.
     */
    function rebindMonthlyBookingLogic() {
        // Logic mở rộng/thu gọn
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

        rebindChildCancellationLogic();
    }

    function rebindChildCancellationLogic() {
        const CANCELLATION_FEE_PERCENTAGE = 100; // Phí hủy 100% giá tiền

        function handleCheckboxChange(childContainer) {
            const checkBoxes = childContainer.querySelectorAll('.bm-child-booking-checkbox:checked');
            const confirmButton = childContainer.querySelector('.bm-confirm-child-cancel-btn');
            const countSpans = childContainer.querySelectorAll('.selected-count');
            const feeSpan = childContainer.querySelector('.cancellation-fee');

            let totalSelectedPrice = 0;
            checkBoxes.forEach(cb => totalSelectedPrice += parseFloat(cb.dataset.price || 0));
            const fee = totalSelectedPrice * (CANCELLATION_FEE_PERCENTAGE / 100);

            countSpans.forEach(s => s.textContent = checkBoxes.length);
            if (feeSpan) feeSpan.textContent = formatCurrency(fee);
            if (confirmButton) {
                confirmButton.disabled = checkBoxes.length === 0;
                confirmButton.innerHTML = `Hủy ${checkBoxes.length} mục đã chọn`;
            }
        }

        // Gắn event cho từng container lịch con
        tablesContainer.querySelectorAll('.bm-child-table-container').forEach(childContainer => {
            const selectAll = childContainer.querySelector('.bm-select-all-children');
            const checkBoxes = childContainer.querySelectorAll('.bm-child-booking-checkbox');

            // Event cho checkbox "Chọn tất cả"
            if (selectAll) {
                selectAll.addEventListener('change', () => {
                    checkBoxes.forEach(cb => {
                        if (!cb.disabled) cb.checked = selectAll.checked;
                    });
                    handleCheckboxChange(childContainer);
                });
            }

            // Event cho từng checkbox lịch con
            checkBoxes.forEach(cb => {
                cb.addEventListener('change', () => {
                    handleCheckboxChange(childContainer);

                    // Cập nhật trạng thái checkbox "Chọn tất cả"
                    if (selectAll) {
                        const allEnabled = childContainer.querySelectorAll('.bm-child-booking-checkbox:not(:disabled)');
                        const allChecked = childContainer.querySelectorAll('.bm-child-booking-checkbox:not(:disabled):checked');
                        selectAll.checked = allEnabled.length > 0 && allEnabled.length === allChecked.length;
                        selectAll.indeterminate = allChecked.length > 0 && allChecked.length < allEnabled.length;
                    }
                });
            });
        });

        // Gắn event cho nút hủy
        tablesContainer.querySelectorAll('.bm-confirm-child-cancel-btn').forEach(button => {
            button.addEventListener('click', function () {
                const childRow = this.closest('.bm-child-bookings-row');
                const monthlyId = childRow.dataset.parentMonthlyId;

                const childContainer = this.closest('.bm-child-table-container');
                const selectedIds = Array.from(childContainer.querySelectorAll('.bm-child-booking-checkbox:checked')).map(cb => parseInt(cb.value));
                const feeText = childContainer.querySelector('.cancellation-fee')?.textContent || '0₫';

                if (selectedIds.length === 0) {
                    Swal.fire('Thông báo', 'Vui lòng chọn ít nhất một lịch đặt để hủy. ', 'info');
                    return;
                }

                Swal.fire({
                    title: 'Xác nhận Hủy',
                    html: `Bạn sẽ hủy <b>${selectedIds.length}</b> lịch đặt. <br>Phí hủy dự kiến: <b>${feeText}</b>`,
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#dc2626',
                    cancelButtonColor: '#6b7280',
                    confirmButtonText: 'Đồng ý & Hủy',
                    cancelButtonText: 'Xem lại'
                }).then((result) => {
                    if (result.isConfirmed) {
                        Swal.fire({
                            title: 'Đang xử lý...',
                            text: 'Vui lòng đợi trong giây lát',
                            allowOutsideClick: false,
                            allowEscapeKey: false,
                            didOpen: () => { Swal.showLoading(); }
                        });

                        const dto = { status: 'cancelled', childBookingIdsToCancel: selectedIds };

                        fetch(`/Booking/UpdateMonthlyBooking/${monthlyId}`, {
                            method: 'POST',
                            headers: { 'Content-Type': 'application/json' },
                            body: JSON.stringify(dto)
                        })
                            .then(response => response.json())
                            .then(data => {
                                if (data.paymentRequired && data.paymentUrl) {
                                    window.location.href = data.paymentUrl;
                                    return;
                                }
                                if (data.success || data.redirectUrl) {
                                    Swal.fire({
                                        icon: 'success',
                                        title: 'Thành công!',
                                        text: data.message || 'Đã hủy các lịch đặt được chọn.',
                                        confirmButtonColor: '#22c55e'
                                    }).then(() => location.reload());
                                } else {
                                    throw new Error(data.message || 'Lỗi không xác định từ server');
                                }
                            })
                            .catch(error => {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Lỗi!',
                                    text: error.message,
                                    confirmButtonColor: '#d33'
                                });
                            });
                    }
                });
            });
        });
    }


    // --- GẮN CÁC SỰ KIỆN BAN ĐẦU ---
    filterForm.addEventListener('submit', (e) => {
        e.preventDefault();
        loadFilteredBookings();
    });

    bookingTypeFilter.addEventListener('change', toggleTableVisibility);

    modal.addEventListener('click', (e) => {
        if (e.target === modal || e.target.closest('.bm-modal-close-btn')) {
            modal.style.display = 'none';
        }
    });

    // Gọi lần đầu để thiết lập trạng thái ban đầu
    toggleTableVisibility();
    rebindAllEventListeners();
});