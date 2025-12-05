document.addEventListener('DOMContentLoaded', function () {
    // === CẤU HÌNH ===
    const GATEWAY_URL = "https://localhost:7136";

    // === DOM ELEMENTS ===
    const elements = {
        feePeriodInput: document.getElementById('feePeriodInput'),
        filterForm: document.getElementById('filterForm'),
        feeTableBody: document.getElementById('feeTableBody'),
        tableTitle: document.getElementById('tableTitle'),
        refreshDataBtn: document.getElementById('refreshDataBtn'),
        kpi: {
            total: document.getElementById('totalFeeValue'),
            paid: document.getElementById('paidFeeValue'),
            unpaid: document.getElementById('unpaidFeeValue'),
        },
        uploadModal: {
            instance: new bootstrap.Modal(document.getElementById('uploadBillModal')),
            form: document.getElementById('uploadBillForm'),
            feeIdInput: document.getElementById('modalFeeId'),
            stadiumNameInput: document.getElementById('modalHiddenStadiumName'),
            stadiumNameDisplay: document.getElementById('modalStadiumName'),
            errorDiv: document.getElementById('uploadError'),
            submitBtn: document.getElementById('submitUploadBtn'),
        },
        viewBillModal: {
            instance: new bootstrap.Modal(document.getElementById('viewBillModal')),
            imageView: document.getElementById('billImageView'),
        }
    };

    if (!elements.filterForm) {
        console.error("JS Error: Filter form not found.");
        return;
    }

    // === STATE ===
    let allFeesData = [];

    // === FORMATTERS ===
    // Sửa đổi: Bỏ currencyFormatter, chỉ dùng numberFormatter để dễ dàng thêm "VNĐ"
    const numberFormatter = new Intl.NumberFormat('vi-VN');
    const dateFormatter = new Intl.DateTimeFormat('vi-VN', { day: '2-digit', month: '2-digit', year: 'numeric' });

    // === DATA HANDLING ===
    async function fetchData(year, month) {
        showTableLoading();
        try {
            const response = await fetch(`/Fee/GetMyFeesData?year=${year}&month=${month}`);
            if (!response.ok) throw new Error('Không thể tải dữ liệu.');

            allFeesData = await response.json();
            updateUI();
            if (elements.tableTitle) elements.tableTitle.textContent = `Chi tiết cước phí tháng ${month}/${year}`;
        } catch (error) {
            showTableError(error.message);
        }
    }

    async function handleUploadSubmit(event) {
        event.preventDefault();
        const form = event.target;

        const fileInput = document.getElementById('billImageInput');
        const file = fileInput.files[0];

        // Kiểm tra nếu có file
        if (file) {
            // Kiểm tra loại file (MIME type)
            const validImageTypes = ['image/gif', 'image/jpeg', 'image/png', 'image/jpg', 'image/webp'];
            if (!validImageTypes.includes(file.type)) {
                elements.uploadModal.errorDiv.textContent = 'Vui lòng chỉ chọn file ảnh (jpg, png, jpeg).';
                return;
            }

            // Kiểm tra kích thước file nếu muốn
            const maxSizeInBytes = 5 * 1024 * 1024; // 5MB
            if (file.size > maxSizeInBytes) {
                elements.uploadModal.errorDiv.textContent = 'File ảnh quá lớn. Vui lòng chọn ảnh dưới 5MB.';
                return;
            }
        }

        const formData = new FormData(form);
        const originalBtnText = elements.uploadModal.submitBtn.innerHTML;

        elements.uploadModal.submitBtn.disabled = true;
        elements.uploadModal.submitBtn.innerHTML = `<span class="spinner-border spinner-border-sm"></span> Đang tải lên...`;
        elements.uploadModal.errorDiv.textContent = '';

        try {
            const response = await fetch('/Fee/UploadBill', {
                method: 'PUT',
                body: formData,
            });

            if (!response.ok) {
                const errorData = await response.json().catch(() => ({ message: 'Tải lên thất bại.' }));
                throw new Error(errorData.message);
            }

            const updatedFeeDto = await response.json();
            const index = allFeesData.findIndex(item => item.fee.id === updatedFeeDto.id);
            if (index !== -1) {
                allFeesData[index].fee.billUrl = updatedFeeDto.billUrl;
            }

            updateUI();
            elements.uploadModal.instance.hide();
            showToast('Tải lên hóa đơn thành công!');

        } catch (error) {
            elements.uploadModal.errorDiv.textContent = error.message;
        } finally {
            elements.uploadModal.submitBtn.disabled = false;
            elements.uploadModal.submitBtn.innerHTML = originalBtnText;
        }
    }

    // === UI RENDERING ===
    function updateUI() {
        renderTable(allFeesData);
        updateKPIs(allFeesData);
    }

    function renderTable(items) {
        if (!items || items.length === 0) {
            showTableError("Không có dữ liệu cước phí cho kỳ này.");
            return;
        }

        items.sort((a, b) => b.fee.feeAmount - a.fee.feeAmount);

        elements.feeTableBody.innerHTML = items.map(item => {
            const fee = item.fee;
            const isOverdue = !fee.isPaid && new Date(fee.dueDate) < new Date();
            let status = fee.isPaid ? 'paid' : (isOverdue ? 'overdue' : 'unpaid');

            if (!fee.isPaid && fee.billUrl) {
                status = 'pending';
            }

            const statusText = { paid: 'Đã thanh toán', unpaid: 'Chưa thanh toán', overdue: 'Quá hạn', pending: 'Chờ xác nhận' };

            let billActionHtml = '';
            if (fee.feeAmount > 0) {
                if (fee.billUrl) {
                    billActionHtml += `<button class="action-btn btn-view-bill" data-bill-url="${fee.billUrl}" title="Xem hóa đơn"><i class="fas fa-eye"></i></button>`;
                    if (!fee.isPaid) {
                        billActionHtml += `<button class="action-btn btn-upload ms-2" data-fee-id="${fee.id}" data-stadium-name="${item.stadiumName}" title="Cập nhật hóa đơn"><i class="fas fa-upload"></i></button>`;
                    }
                } else if (!fee.isPaid) {
                    billActionHtml = `<button class="action-btn btn-upload" data-fee-id="${fee.id}" data-stadium-name="${item.stadiumName}" title="Tải lên hóa đơn"><i class="fas fa-upload"></i></button>`;
                }
            }

            return `
                <tr>
                    <td><strong>${item.stadiumName || 'N/A'}</strong></td>
                    <td>${numberFormatter.format(fee.feeAmount)}</td>
                    <td>${dateFormatter.format(new Date(fee.dueDate))}</td>
                    <td><span class="status-tag status-${status}">${statusText[status]}</span></td>
                    <td>${billActionHtml}</td>
                </tr>`;
        }).join('');
    }

    function updateKPIs(items) {
        const kpiData = (items || []).reduce((acc, item) => {
            const fee = item.fee;
            acc.total += fee.feeAmount;
            if (fee.isPaid) acc.paid += fee.feeAmount;
            else acc.unpaid += fee.feeAmount;
            return acc;
        }, { total: 0, paid: 0, unpaid: 0 });

        // SỬA ĐỔI: Thêm " VNĐ" vào tất cả các thẻ KPI
        if (elements.kpi.total) elements.kpi.total.textContent = `${numberFormatter.format(kpiData.total)} VNĐ`;
        if (elements.kpi.paid) elements.kpi.paid.textContent = `${numberFormatter.format(kpiData.paid)} VNĐ`;
        if (elements.kpi.unpaid) elements.kpi.unpaid.textContent = `${numberFormatter.format(kpiData.unpaid)} VNĐ`;
    }

    // === UTILITIES ===
    function showTableLoading() { elements.feeTableBody.innerHTML = `<tr><td colspan="5" class="empty-state">Đang tải dữ liệu...</td></tr>`; }
    function showTableError(message) { elements.feeTableBody.innerHTML = `<tr><td colspan="5" class="empty-state">${message}</td></tr>`; }

    function showToast(message, type = 'success') {
        const toastContainer = document.createElement('div');
        toastContainer.className = `toast align-items-center text-white bg-${type} border-0 position-fixed top-0 end-0 m-3`;
        toastContainer.style.zIndex = 1100;
        toastContainer.setAttribute('role', 'alert');
        toastContainer.setAttribute('aria-live', 'assertive');
        toastContainer.setAttribute('aria-atomic', 'true');
        toastContainer.innerHTML = `<div class="d-flex"><div class="toast-body">${message}</div><button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button></div>`;
        document.body.appendChild(toastContainer);
        const toast = new bootstrap.Toast(toastContainer, { delay: 3000 });
        toast.show();
        toastContainer.addEventListener('hidden.bs.toast', () => toastContainer.remove());
    }

    // === EVENT BINDING & INITIALIZATION ===
    function initialize() {
        const now = new Date();
        now.setMonth(now.getMonth() - 1);
        elements.feePeriodInput.value = `${now.getFullYear()}-${(now.getMonth() + 1).toString().padStart(2, '0')}`;

        elements.filterForm.addEventListener('submit', (e) => {
            e.preventDefault();
            const [year, month] = elements.feePeriodInput.value.split('-');
            if (year && month) fetchData(year, month);
        });

        if (elements.refreshDataBtn) {
            elements.refreshDataBtn.addEventListener('click', () => {
                const [year, month] = elements.feePeriodInput.value.split('-');
                if (year && month) fetchData(year, month);
            });
        }

        elements.feeTableBody.addEventListener('click', (e) => {
            const uploadBtn = e.target.closest('.btn-upload');
            const viewBtn = e.target.closest('.btn-view-bill');

            if (uploadBtn) {
                elements.uploadModal.feeIdInput.value = uploadBtn.dataset.feeId;
                elements.uploadModal.stadiumNameInput.value = uploadBtn.dataset.stadiumName;
                elements.uploadModal.stadiumNameDisplay.textContent = uploadBtn.dataset.stadiumName;
                elements.uploadModal.errorDiv.textContent = '';
                elements.uploadModal.form.reset();
                elements.uploadModal.instance.show();
            }

            if (viewBtn) {
                const billUrl = viewBtn.dataset.billUrl;
                const correctedUrl = billUrl.startsWith('/') ? billUrl : `/${billUrl}`;
                elements.viewBillModal.imageView.src = `${GATEWAY_URL}/bill${correctedUrl}`;
                elements.viewBillModal.instance.show();
            }
        });

        elements.uploadModal.form.addEventListener('submit', handleUploadSubmit);

        const [year, month] = elements.feePeriodInput.value.split('-');
        if (year && month) fetchData(year, month);
    }

    initialize();
});