document.addEventListener('DOMContentLoaded', function () {

    const GATEWAY_URL = "https://localhost:7136"; 

    // === DOM ELEMENTS ===
    const elements = {
        filterForm: document.getElementById('filterForm'),
        feePeriodInput: document.getElementById('feePeriodInput'),
        stadiumNameInput: document.getElementById('stadiumNameInput'),
        feeStatusSelect: document.getElementById('feeStatusSelect'),
        feeTableBody: document.getElementById('feeTableBody'),
        tableTitle: document.getElementById('tableTitle'),
        refreshDataBtn: document.getElementById('refreshDataBtn'),
        exportExcelBtn: document.getElementById('exportExcelBtn'),
        kpi: {
            total: document.getElementById('totalFeeValue'),
            paid: document.getElementById('paidFeeValue'),
            unpaid: document.getElementById('unpaidFeeValue'),
            overdue: document.getElementById('overdueCount'),
        },
        confirmModal: { // Đổi tên để rõ ràng hơn
            instance: new bootstrap.Modal(document.getElementById('confirmModal')),
            stadiumName: document.getElementById('modalStadiumName'),
            feeAmount: document.getElementById('modalFeeAmount'),
            confirmBtn: document.getElementById('modalConfirmBtn'),
        },
        // THÊM MỚI: Element cho modal xem hóa đơn
        viewBillModal: {
            instance: new bootstrap.Modal(document.getElementById('viewBillModal')),
            imageView: document.getElementById('billImageView'),
        }
    };

    // === STATE & CHARTS ===
    let allFeesData = [];
    let currentFeeId = null;
    let charts = { status: null, topStadiums: null };

    // === FORMATTERS ===
    const currencyFormatter = new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' });
    const numberFormatter = new Intl.NumberFormat('vi-VN');
    const dateFormatter = new Intl.DateTimeFormat('vi-VN', { day: '2-digit', month: '2-digit', year: 'numeric' });

    // === DATA HANDLING ===
    async function fetchData(year, month) {
        showTableLoading();
        try {
            const response = await fetch(`/Fee/GetFeesData?year=${year}&month=${month}`);
            if (!response.ok) throw new Error(`Network response was not ok (${response.status})`);
            allFeesData = await response.json();
            console.log('Dữ liệu cước phí nhận được:', allFeesData);
            updateUI();
        } catch (error) {
            console.error('Lỗi khi tải dữ liệu:', error);
            showTableError();
        }
    }

    async function handleConfirmPayment() {
        if (!currentFeeId) return;
        const originalBtnText = elements.confirmModal.confirmBtn.innerHTML;
        elements.confirmModal.confirmBtn.disabled = true;
        elements.confirmModal.confirmBtn.innerHTML = '<i class="fas fa-spinner fa-spin me-2"></i>Đang xử lý...';

        try {
            const response = await fetch(`/Fee/ConfirmPayment?feeId=${currentFeeId}`, { method: 'PUT' });
            if (!response.ok) throw new Error('Xác nhận thất bại từ server.');

            const updatedItem = await response.json();
            const index = allFeesData.findIndex(item => item.fee.id === currentFeeId);
            if (index !== -1) {
                allFeesData[index].fee.isPaid = updatedItem.isPaid;
                allFeesData[index].fee.paidDate = updatedItem.paidDate;
            }

            updateUI();
            elements.confirmModal.instance.hide();
        } catch (error) {
            console.error('Lỗi khi xác nhận thanh toán:', error);
        } finally {
            elements.confirmModal.confirmBtn.disabled = false;
            elements.confirmModal.confirmBtn.innerHTML = originalBtnText;
            currentFeeId = null;
        }
    }

    // === UI RENDERING ===
    function updateUI() {
        const filteredData = getFilteredData();
        renderTable(filteredData);
        updateKPIs(allFeesData);
        updateCharts(allFeesData);
        const [year, month] = elements.feePeriodInput.value.split('-');
        elements.tableTitle.textContent = `Danh sách cước phí tháng ${month}/${year}`;
    }

    function getFilteredData() {
        const searchTerm = elements.stadiumNameInput.value.toLowerCase();
        const statusFilter = elements.feeStatusSelect.value;

        // BẮT ĐẦU THAY ĐỔI: Sắp xếp dữ liệu
        let filtered = allFeesData
            .filter(item => {
                const fee = item.fee;
                const stadiumMatch = !searchTerm || (item.stadiumName && item.stadiumName.toLowerCase().includes(searchTerm));
                if (!stadiumMatch) return false;

                if (statusFilter) {
                    const isOverdue = !fee.isPaid && new Date(fee.dueDate) < new Date();
                    if (statusFilter === 'paid') return fee.isPaid;
                    if (statusFilter === 'unpaid') return !fee.isPaid && !isOverdue;
                    if (statusFilter === 'overdue') return isOverdue;
                }
                return true;
            })
            // Sắp xếp các khoản phí từ cao xuống thấp
            .sort((a, b) => b.fee.feeAmount - a.fee.feeAmount);

        return filtered;
    }

    function renderTable(data) {
        if (!data.length) {
            showTableError();
            return;
        }
        elements.feeTableBody.innerHTML = data.map(item => {
            const fee = item.fee;
            const isOverdue = !fee.isPaid && new Date(fee.dueDate) < new Date();
            let status = fee.isPaid ? 'paid' : (isOverdue ? 'overdue' : 'unpaid');
            if (!fee.isPaid && fee.billUrl) {
                status = 'pending'; // Trạng thái chờ xác nhận
            }

            const statusText = { paid: 'Đã thanh toán', unpaid: 'Chưa thanh toán', overdue: 'Quá hạn', pending: 'Chờ xác nhận' };
            const statusIcon = { paid: 'check-circle', unpaid: 'clock', overdue: 'exclamation-triangle', pending: 'hourglass-half' };

            let actionHtml = '';

            // 1. Thêm nút xem hóa đơn nếu có
            if (fee.billUrl) {
                actionHtml += `<button class="btn btn-sm btn-info btn-view-bill me-2" data-bill-url="${fee.billUrl}" title="Xem hóa đơn"><i class="fas fa-eye"></i></button>`;
            }

            // 2. Thêm nút xác nhận thanh toán
            if (fee.feeAmount > 0 && !fee.isPaid) {
                actionHtml += `<button class="btn btn-sm btn-success btn-confirm-payment" data-id="${fee.id}" data-name="${item.stadiumName || 'N/A'}" data-amount="${fee.feeAmount}" title="Xác nhận đã thu tiền"><i class="fas fa-check"></i></button>`;
            } else if (fee.isPaid) {
                actionHtml += `<button class="btn btn-sm btn-secondary" disabled>Đã xác nhận</button>`;
            }

            return `
            <tr>
                <td><strong>${item.stadiumName || 'N/A'}</strong></td>
                <td>${item.ownerName || 'N/A'}</td>
                <td><span class="fee-amount">${numberFormatter.format(fee.feeAmount)} VNĐ</span></td>
                <td>${dateFormatter.format(new Date(fee.dueDate))}</td>
                <td><span class="status-tag status-${status}"><i class="fas fa-${statusIcon[status]}"></i> ${statusText[status]}</span></td>
                <td><div class="d-flex">${actionHtml}</div></td>
            </tr>`;
        }).join('');
    }

    function updateKPIs(data) {
        const kpiData = data.reduce((acc, item) => {
            const fee = item.fee;
            acc.total += fee.feeAmount;
            if (fee.isPaid) acc.paid += fee.feeAmount;
            else {
                acc.unpaid += fee.feeAmount;
                if (new Date(fee.dueDate) < new Date()) acc.overdueCount++;
            }
            return acc;
        }, { total: 0, paid: 0, unpaid: 0, overdueCount: 0 });

        animateCountUp(elements.kpi.total, kpiData.total, true);
        animateCountUp(elements.kpi.paid, kpiData.paid, true);
        animateCountUp(elements.kpi.unpaid, kpiData.unpaid, true);
        animateCountUp(elements.kpi.overdue, kpiData.overdueCount, false);
    }

    // === CHARTS ===
    function updateCharts(data) {
        const statusData = data.reduce((acc, item) => {
            const fee = item.fee;
            if (fee.isPaid) acc.paid++;
            else if (new Date(fee.dueDate) < new Date()) acc.overdue++;
            else acc.unpaid++;
            return acc;
        }, { paid: 0, unpaid: 0, overdue: 0 });
        initOrUpdateChart(charts, 'status', initStatusChart, [statusData.paid, statusData.unpaid, statusData.overdue]);

        const topStadiumsData = [...data].sort((a, b) => b.fee.feeAmount - a.fee.feeAmount).slice(0, 5);
        initOrUpdateChart(charts, 'topStadiums', initTopStadiumsChart, topStadiumsData);
    }

    function initOrUpdateChart(chartCache, chartName, initFn, data) {
        if (chartCache[chartName]) {
            updateChartData(chartCache[chartName], data);
        } else {
            chartCache[chartName] = initFn(data);
        }
    }

    function updateChartData(chart, data) {
        if (chart.config.type === 'doughnut') {
            chart.data.datasets[0].data = data;
        } else if (chart.config.type === 'bar') {
            chart.data.labels = data.map(d => d.stadiumName || `Sân #${d.fee.stadiumId}`);
            chart.data.datasets[0].data = data.map(d => d.fee.feeAmount);
        }
        chart.update();
    }

    function initStatusChart(data) {
        const ctx = document.getElementById('statusChart').getContext('2d');
        return new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: ['Đã thanh toán', 'Chưa thanh toán', 'Quá hạn'],
                datasets: [{ data, backgroundColor: ['#10b981', '#f59e0b', '#ef4444'], borderWidth: 0 }]
            },
            options: { responsive: true, maintainAspectRatio: false, plugins: { legend: { position: 'bottom' } }, cutout: '70%' }
        });
    }

    function initTopStadiumsChart(data) {
        const ctx = document.getElementById('topStadiumsChart').getContext('2d');
        return new Chart(ctx, {
            type: 'bar',
            data: {
                labels: data.map(d => d.stadiumName || `Sân #${d.fee.stadiumId}`),
                datasets: [{
                    label: 'Phí phải trả',
                    data: data.map(d => d.fee.feeAmount),
                    backgroundColor: 'rgba(79, 70, 229, 0.8)',
                    borderColor: 'rgba(79, 70, 229, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                indexAxis: 'y', responsive: true, maintainAspectRatio: false,
                scales: { x: { beginAtZero: true, ticks: { callback: value => numberFormatter.format(value) } } },
                plugins: { legend: { display: false } }
            }
        });
    }

    // === UTILITIES ===
    function showTableLoading() { elements.feeTableBody.innerHTML = `<tr><td colspan="7" class="text-center p-5"><div class="spinner-border text-primary" role="status"></div></td></tr>`; }
    function showTableError() { elements.feeTableBody.innerHTML = `<tr><td colspan="7"><div class="empty-state"><svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" d="M11.25 11.25l.041-.02a.75.75 0 011.063.852l-.708 2.836a.75.75 0 001.063.853l.041-.021M21 12a9 9 0 11-18 0 9 9 0 0118 0zm-9-3.75h.008v.008H12V8.25z" /></svg><h5>Không có dữ liệu</h5><p>Không tìm thấy cước phí nào cho kỳ bạn đã chọn.</p></div></td></tr>`; }

    function animateCountUp(el, target, isCurrency) {
        let start = 0; const duration = 1000; const frameRate = 1000 / 60;
        const totalFrames = Math.round(duration / frameRate);
        const increment = target / totalFrames;
        function updateNumber() {
            start += increment;
            if (start >= target) {
                el.textContent = isCurrency ? currencyFormatter.format(target).replace('₫', 'VNĐ') : numberFormatter.format(target);
                return;
            }
            el.textContent = isCurrency ? currencyFormatter.format(start).replace('₫', 'VNĐ') : numberFormatter.format(start);
            requestAnimationFrame(updateNumber);
        }
        updateNumber();
    }

    async function exportToExcel() {
        const data = getFilteredData();
        if (data.length === 0) {
            alert("Không có dữ liệu để xuất.");
            return;
        }

        const workbook = new ExcelJS.Workbook();
        const worksheet = workbook.addWorksheet('BaoCaoCuocPhi');

        // --- Định nghĩa các style ---
        const titleStyle = { font: { name: 'Arial', size: 16, bold: true }, alignment: { horizontal: 'center', vertical: 'middle' } };
        const headerStyle = { font: { name: 'Arial', size: 12, bold: true, color: { argb: 'FFFFFFFF' } }, fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: 'FF4F81BD' } }, alignment: { horizontal: 'center', vertical: 'middle' }, border: { top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } } };
        const totalLabelStyle = { font: { name: 'Arial', size: 12, bold: true }, fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: 'FFF2F2F2' } }, alignment: { horizontal: 'right' }, border: { top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } } };
        const totalValueStyle = { font: { name: 'Arial', size: 12, bold: true }, fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: 'FFF2F2F2' } }, alignment: { horizontal: 'right' }, border: { top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } }, numFmt: '#,##0' };

        // --- Thêm tiêu đề ---
        const [year, month] = elements.feePeriodInput.value.split('-');
        const titleRow = worksheet.addRow([`BÁO CÁO CƯỚC PHÍ THÁNG ${month}/${year}`]);
        titleRow.getCell(1).style = titleStyle;
        worksheet.mergeCells('A1:F1');
        titleRow.height = 30;
        worksheet.addRow([]); // Dòng trống

        // --- Thêm header ---
        const headerRow = worksheet.addRow(["STT", "Tên Sân", "Chủ Sân", "Phí Phải Trả (VNĐ)", "Hạn Trả", "Trạng Thái"]);
        headerRow.eachCell((cell) => {
            cell.style = headerStyle;
        });
        headerRow.height = 25;

        // --- Thêm dữ liệu ---
        data.forEach((item, index) => {
            const row = worksheet.addRow([
                index + 1,
                item.stadiumName || "N/A",
                item.ownerName || "N/A",
                item.fee.feeAmount,
                dateFormatter.format(new Date(item.fee.dueDate)),
                item.fee.isPaid ? "Đã thanh toán" : (!item.fee.isPaid && new Date(item.fee.dueDate) < new Date() ? "Quá hạn" : "Chờ xác nhận")
            ]);

            const isEven = index % 2 === 0;
            const rowFill = isEven ? { type: 'pattern', pattern: 'solid', fgColor: { argb: 'FFF2F2F2' } } : null;

            row.eachCell({ includeEmpty: true }, (cell, colNumber) => {
                cell.border = { top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } };
                if (rowFill) cell.fill = rowFill;

                // Căn chỉnh và định dạng
                if (colNumber === 1 || colNumber === 5 || colNumber === 6) { // STT, Hạn trả, Trạng thái
                    cell.alignment = { vertical: 'middle', horizontal: 'center' };
                } else if (colNumber === 4) { // Phí
                    cell.alignment = { vertical: 'middle', horizontal: 'right' };
                    cell.numFmt = '#,##0';
                } else {
                    cell.alignment = { vertical: 'middle', horizontal: 'left' };
                }
            });
        });

        // --- Thêm dòng tổng cộng ---
        const totalFee = data.reduce((sum, item) => sum + item.fee.feeAmount, 0);
        const totalRow = worksheet.addRow(["", "TỔNG CỘNG", "", totalFee, "", ""]);
        totalRow.getCell(2).style = totalLabelStyle;
        totalRow.getCell(4).style = totalValueStyle;

        // --- Thiết lập độ rộng cột ---
        worksheet.columns = [
            { key: 'A', width: 5 },
            { key: 'B', width: 35 },
            { key: 'C', width: 25 },
            { key: 'D', width: 20 },
            { key: 'E', width: 15 },
            { key: 'F', width: 20 }
        ];

        // --- Xuất file ---
        const buffer = await workbook.xlsx.writeBuffer();
        const blob = new Blob([buffer], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = `BaoCaoCuocPhi_${month}-${year}.xlsx`;
        a.click();
        window.URL.revokeObjectURL(url);
    }

    // === EVENT BINDING & INITIALIZATION ===
    function initialize() {
        const now = new Date();
        now.setMonth(now.getMonth() - 1);
        elements.feePeriodInput.value = `${now.getFullYear()}-${(now.getMonth() + 1).toString().padStart(2, '0')}`;

        elements.filterForm.addEventListener('submit', (e) => {
            e.preventDefault();
            const [year, month] = elements.feePeriodInput.value.split('-');
            fetchData(year, month);
        });

        elements.refreshDataBtn.addEventListener('click', () => fetchData(...elements.feePeriodInput.value.split('-')));
        elements.exportExcelBtn.addEventListener('click', exportToExcel);
        elements.confirmModal.confirmBtn.addEventListener('click', handleConfirmPayment);

        // Cập nhật event listener cho table body
        elements.feeTableBody.addEventListener('click', e => {
            const confirmBtn = e.target.closest('.btn-confirm-payment');
            const viewBillBtn = e.target.closest('.btn-view-bill');

            if (confirmBtn) {
                currentFeeId = parseInt(confirmBtn.dataset.id);
                elements.confirmModal.stadiumName.textContent = confirmBtn.dataset.name;
                elements.confirmModal.feeAmount.textContent = `${numberFormatter.format(parseFloat(confirmBtn.dataset.amount))} VNĐ`;
                elements.confirmModal.instance.show();
            }

            if (viewBillBtn) {
                const billUrl = viewBillBtn.dataset.billUrl;
                const correctedUrl = billUrl.startsWith('/') ? billUrl : `/${billUrl}`;
                // Sử dụng route /bill/ mà bạn đã cấu hình ở Gateway
                elements.viewBillModal.imageView.src = `${GATEWAY_URL}/bill${correctedUrl}`;
                elements.viewBillModal.instance.show();
            }
        });

        const [year, month] = elements.feePeriodInput.value.split('-');
        fetchData(year, month);
    }

    initialize();
});