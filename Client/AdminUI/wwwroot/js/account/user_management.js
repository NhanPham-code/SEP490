// ===== GLOBAL VARIABLES =====
let currentPage = 1;
let pageSize = 10;
let currentUserId = null;
let totalPages = 0;
let _renderedUsers = []; // Cache for quick profile viewing
let profileModalInstance, banModalInstance; // Bootstrap Modal instances

$(document).ready(function () {
    // SỬA LỖI: Khởi tạo Bootstrap Modals
    profileModalInstance = new bootstrap.Modal(document.getElementById('profileModal'));
    banModalInstance = new bootstrap.Modal(document.getElementById('banModal'));

    initializePage();
    setupEventListeners();
    loadUsers();
    loadStats();
});

// ===== PAGE INIT & EVENTS =====
function initializePage() {
    const now = new Date();
    const currentMonth = now.getFullYear() + '-' + String(now.getMonth() + 1).padStart(2, '0');
    $('#monthFilter').val(currentMonth);
}

function setupEventListeners() {
    $('#filterForm').on('submit', function (e) {
        e.preventDefault();
        searchUsers();
    });

    $('#refreshDataBtn').on('click', refreshData);
    $('#exportExcelBtn').on('click', exportToExcel);
    $('#confirmBanBtn').on('click', confirmBanUser);
}

// ===== LOAD DATA =====
function loadUsers(page = 1) {
    currentPage = page;
    showLoading(true);
    const searchData = {
        page: currentPage,
        pageSize: pageSize,
        searchTerm: $('#searchInput').val(),
        month: $('#monthFilter').val(),
        status: $('#statusFilter').val(),
        role: $('#roleFilter').val()
    };
    $.ajax({
        url: '/Account/GetUsers', // Đảm bảo URL này chính xác
        type: 'GET',
        data: searchData,
        success: function (response) {
            if (response.success) {
                _renderedUsers = response.data;
                renderUsersTable(response.data);
                renderPagination(response.totalPages, response.totalRecords);
                updatePaginationInfo(response.totalRecords);
            } else {
                showError('Không thể tải danh sách người dùng: ' + response.message);
            }
        },
        error: function (xhr, status, error) {
            showError('Lỗi kết nối: ' + error);
        },
        complete: function () {
            showLoading(false);
        }
    });
}

function loadStats() {
    $.ajax({
        url: '/Account/GetUserStats', // Đảm bảo URL này chính xác
        type: 'GET',
        success: function (response) {
            if (response.success) {
                animateCounter('#totalUsers', response.data.totalUsers);
                animateCounter('#activeUsers', response.data.activeUsers);
                animateCounter('#bannedUsers', response.data.bannedUsers);
                animateCounter('#newUsersThisMonth', response.data.newUsersThisMonth);
            }
        }
    });
}

// ===== RENDER & ACTIONS =====
function renderUsersTable(users) {
    const tbody = $('#usersTableBody');
    tbody.empty();
    if (!users || users.length === 0) {
        $('#emptyState').show();
        tbody.closest('table').hide();
        return;
    }
    $('#emptyState').hide();
    tbody.closest('table').show();

    users.forEach(user => {
        const row = `
            <tr data-user-id="${user.userId}">
                <td>
                    <div class="user-info">
                        <img src="${user.avatarUrl || '/images/default-avatar.png'}" alt="${user.fullName}" class="user-avatar" onerror="this.onerror=null;this.src='/images/default-avatar.png';">
                        <div class="user-details">
                            <h4>${user.fullName || 'N/A'}</h4>
                            <p>ID: ${user.userId}</p>
                        </div>
                    </div>
                </td>
                <td>
                    <div>${user.email}</div>
                    <div class="text-muted">${user.phoneNumber || ''}</div>
                </td>
                <td>${formatDate(user.createdDate)}</td>
                <td><span class="role-badge">${user.role || 'N/A'}</span></td>
                <td><span class="status-badge ${getStatusClass(user.isActive)}">${getStatusText(user.isActive)}</span></td>
                <td>
                    <div class="d-flex gap-2">
                        <button class="btn btn-sm btn-outline btn-view" title="Xem chi tiết"><i class="ri-eye-line"></i></button>
                        ${user.isActive
                ? `<button class="btn btn-sm btn-danger btn-ban" title="Khóa"><i class="ri-forbid-line"></i></button>`
                : `<button class="btn btn-sm btn-success btn-unban" title="Mở khóa"><i class="ri-check-line"></i></button>`
            }
                    </div>
                </td>
            </tr>`;
        tbody.append(row);
    });

    tbody.find('.btn-view').on('click', function (e) {
        e.stopPropagation();
        showUserProfile($(this).closest('tr').data('user-id'));
    });
    tbody.find('.btn-ban').on('click', function (e) {
        e.stopPropagation();
        const user = _renderedUsers.find(u => u.userId === $(this).closest('tr').data('user-id'));
        if (user) showBanModal(user);
    });
    tbody.find('.btn-unban').on('click', function (e) {
        e.stopPropagation();
        unbanUser($(this).closest('tr').data('user-id'));
    });
}

function showUserProfile(userId) {
    const user = _renderedUsers.find(u => u.userId === userId);
    if (!user) return;
    $('#profileModalContent').html(`
        <div class="modal-header">
            <h5 class="modal-title"> <strong> Thông tin: ${user.fullName || 'N/A'} </strong></h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
        </div>
        <div class="modal-body">
            <div class="text-center mb-4">
                <img src="${user.avatarUrl || '/images/default-avatar.png'}" alt="${user.fullName}" class="profile-avatar-large" onerror="this.onerror=null;this.src='/images/default-avatar.png';">
                <h3><strong>${user.fullName || 'N/A'}</strong></h3>
                <span class="status-badge ${getStatusClass(user.isActive)}">${getStatusText(user.isActive)}</span>
            </div>
            <div class="profile-grid">
                <div class="profile-item"><span class="label">Email: </span><span class="value">${user.email}</span></div>
                <div class="profile-item"><span class="label">SĐT: </span><span class="value">${user.phoneNumber || 'Chưa có'}</span></div>
                <div class="profile-item"><span class="label">Vai trò: </span><span class="value">${user.role || 'N/A'}</span></div>
                <div class="profile-item"><span class="label">Ngày đăng ký: </span><span class="value">${formatDate(user.createdDate)}</span></div>
            </div>
        </div>
    `);
    profileModalInstance.show();
}

function showBanModal(user) {
    currentUserId = user.userId;
    $('#banUserName').text(user.fullName);
    $('#banReason').val('');
    banModalInstance.show();
}

function confirmBanUser() {
    if (!currentUserId) return;
    const user = _renderedUsers.find(u => u.userId === currentUserId);
    $.ajax({
        url: `/Account/BanUser`,
        type: 'POST',
        data: { userId: currentUserId, email: user?.email, reason: $('#banReason').val() },
        success: function (response) {
            if (response.success) {
                banModalInstance.hide();
                loadUsers(currentPage);
                loadStats();
                showToast('Đã khóa người dùng thành công.', 'success');
            } else { alert('Lỗi: ' + response.message); }
        },
        error: function () { alert('Lỗi kết nối khi khóa người dùng.'); }
    });
}

function unbanUser(userId) {
    if (!confirm('Bạn có chắc chắn muốn mở khóa người dùng này?')) return;
    const user = _renderedUsers.find(u => u.userId === userId);
    $.ajax({
        url: `/Account/UnbanUser`,
        type: 'POST',
        data: { userId: userId, email: user?.email },
        success: function (response) {
            if (response.success) {
                loadUsers(currentPage);
                loadStats();
                showToast('Đã mở khóa người dùng thành công.', 'success');
            } else { alert('Lỗi: ' + response.message); }
        },
        error: function () { alert('Lỗi kết nối khi mở khóa.'); }
    });
}

// ===== UTILITY & PAGINATION =====
function renderPagination(totalPagesCount, totalRecords) {
    totalPages = totalPagesCount;
    const container = $('#paginationContainer');
    container.empty();

    if (totalPages <= 1) return;

    if (currentPage > 1) {
        container.append(`<a href="#" class="page-btn" onclick="loadUsers(${currentPage - 1})">←</a>`);
    }

    const startPage = Math.max(1, currentPage - 2);
    const endPage = Math.min(totalPages, currentPage + 2);

    if (startPage > 1) {
        container.append(`<a href="#" class="page-btn" onclick="loadUsers(1)">1</a>`);
        if (startPage > 2) container.append(`<span class="page-btn">...</span>`);
    }

    for (let i = startPage; i <= endPage; i++) {
        const activeClass = i === currentPage ? 'active' : '';
        container.append(`<a href="#" class="page-btn ${activeClass}" onclick="loadUsers(${i})">${i}</a>`);
    }

    if (endPage < totalPages) {
        if (endPage < totalPages - 1) container.append(`<span class="page-btn">...</span>`);
        container.append(`<a href="#" class="page-btn" onclick="loadUsers(${totalPages})">${totalPages}</a>`);
    }

    if (currentPage < totalPages) {
        container.append(`<a href="#" class="page-btn" onclick="loadUsers(${currentPage + 1})">→</a>`);
    }
}

function updatePaginationInfo(totalRecords) {
    const from = totalRecords === 0 ? 0 : (currentPage - 1) * pageSize + 1;
    const to = Math.min(currentPage * pageSize, totalRecords);
    $('#showingFrom').text(from);
    $('#showingTo').text(to);
    $('#totalRecords').text(totalRecords);
}

function searchUsers() { currentPage = 1; loadUsers(currentPage); }

function refreshData() {
    $('#searchInput, #statusFilter, #roleFilter').val('');
    const now = new Date();
    $('#monthFilter').val(`${now.getFullYear()}-${String(now.getMonth() + 1).padStart(2, '0')}`);
    searchUsers();
    loadStats();
    showSuccess('Đã làm mới dữ liệu!');
}

function showLoading(show) {
    if (show) {
        $('#usersTableBody').html(`<tr><td colspan="7" class="text-center p-5"><div class="spinner-border text-primary"></div></td></tr>`);
        $('#emptyState').hide();
        $('#usersTableBody').closest('table').show();
    }
}

function formatDate(dateString) { if (!dateString) return 'N/A'; return new Date(dateString).toLocaleDateString('vi-VN'); }
function getStatusText(isActive) { return isActive ? 'Hoạt động' : 'Bị khóa'; }
function getStatusClass(isActive) { return isActive ? 'status-active' : 'status-banned'; }
function animateCounter(selector, targetValue) {
    $({ value: 0 }).animate({ value: targetValue }, {
        duration: 1000,
        step: function () { $(selector).text(Math.floor(this.value).toLocaleString('vi-VN')); },
        complete: function () { $(selector).text(targetValue.toLocaleString('vi-VN')); }
    });
}

function showToast(message, type = 'info') { console.log(`${type.toUpperCase()}: ${message}`); }
function showSuccess(message) { showToast(message, 'success'); }
function showError(message) { showToast(message, 'error', 5000); }


async function exportToExcel() {
    showToast('Đang chuẩn bị file Excel, vui lòng chờ...', 'info');

    // SỬA ĐỔI: Tạo một đối tượng searchData mới và không lấy giá trị từ các bộ lọc.
    // Điều này đảm bảo chúng ta sẽ lấy TẤT CẢ người dùng.
    const searchData = {
        page: 1,
        pageSize: 99999, // Lấy một số lượng rất lớn để đảm bảo lấy hết dữ liệu
        searchTerm: '',   // Bỏ qua từ khóa tìm kiếm
        month: '',        // Bỏ qua bộ lọc tháng
        status: '',       // Bỏ qua bộ lọc trạng thái
        role: ''          // Bỏ qua bộ lọc vai trò
    };

    $.ajax({
        url: '/Account/GetUsers',
        type: 'GET',
        data: searchData,
        success: async function (response) {
            if (!response.success || response.data.length === 0) {
                showError("Không có dữ liệu để xuất.");
                return;
            }

            const data = response.data;
            const workbook = new ExcelJS.Workbook();
            const worksheet = workbook.addWorksheet('DanhSachNguoiDung');

            // Styles
            const titleStyle = { font: { name: 'Arial', size: 16, bold: true }, alignment: { horizontal: 'center' } };
            const headerStyle = { font: { name: 'Arial', size: 12, bold: true, color: { argb: 'FFFFFFFF' } }, fill: { type: 'pattern', pattern: 'solid', fgColor: { argb: 'FF4F81BD' } }, border: { top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } } };

            // Title
            worksheet.addRow(['DANH SÁCH TOÀN BỘ NGƯỜI DÙNG']).getCell(1).style = titleStyle; // Cập nhật tiêu đề
            worksheet.mergeCells('A1:G1');
            worksheet.addRow([]);

            // Headers
            const headerRow = worksheet.addRow(["STT", "Họ và Tên", "Email", "Số điện thoại", "Ngày đăng ký", "Vai trò", "Trạng thái"]);
            headerRow.eachCell((cell) => cell.style = headerStyle);
            headerRow.height = 25;

            // Body
            data.forEach((user, index) => {
                const row = worksheet.addRow([
                    index + 1, user.fullName, user.email, user.phoneNumber || '',
                    formatDate(user.createdDate), user.role, user.isActive ? 'Hoạt động' : 'Bị khóa'
                ]);
                const isEven = index % 2 === 0;
                if (isEven) {
                    row.eachCell({ includeEmpty: true }, (cell) => {
                        cell.fill = { type: 'pattern', pattern: 'solid', fgColor: { argb: 'FFF2F2F2' } };
                    });
                }
                // Thêm border cho tất cả các ô
                row.eachCell({ includeEmpty: true }, (cell) => {
                    cell.border = { top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } };
                });
            });

            // Column Widths
            worksheet.columns = [
                { width: 5 }, { width: 25 }, { width: 30 }, { width: 15 },
                { width: 20 }, { width: 15 }, { width: 15 }
            ];

            // Export
            const buffer = await workbook.xlsx.writeBuffer();
            const blob = new Blob([buffer], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
            const link = document.createElement('a');
            link.href = URL.createObjectURL(blob);
            link.download = `DanhSachNguoiDung_TatCa_${new Date().toISOString().slice(0, 10)}.xlsx`;
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
            URL.revokeObjectURL(link.href);
            showToast('Xuất file Excel thành công!', 'success');
        },
        error: function () { showError("Lỗi khi lấy dữ liệu để xuất file."); }
    });
}