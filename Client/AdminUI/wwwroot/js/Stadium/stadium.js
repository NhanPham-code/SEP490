// API Configuration
const API_BASE_URL = '/api'; // Thay đổi theo cấu hình của bạn
let allStadiums = [];
let filteredStadiums = [];
let currentPage = 1;
let itemsPerPage = 12;
let detailModal, imageModal;

// Initialize on document ready
$(document).ready(function () {
    detailModal = new bootstrap.Modal(document.getElementById('stadiumDetailModal'));
    imageModal = new bootstrap.Modal(document.getElementById('imageModal'));

    loadStadiums();
    setupEventListeners();
});

// Setup Event Listeners
function setupEventListeners() {
    // Real-time search
    let searchTimeout;
    $('#searchInput').on('keyup', function () {
        clearTimeout(searchTimeout);
        searchTimeout = setTimeout(applyFilters, 300);
    });
}

// Show/Hide Loading
function showLoading() {
    $('#loadingOverlay').addClass('show');
}

function hideLoading() {
    $('#loadingOverlay').removeClass('show');
}

// Load Stadiums from API
async function loadStadiums() {
    showLoading();
    try {
        const response = await $.ajax({
            url: `${API_BASE_URL}/stadiums`,
            method: 'GET',
            dataType: 'json'
        });

        allStadiums = response;
        filteredStadiums = allStadiums;
        updateStatistics();
        applyFilters();

        Swal.fire({
            icon: 'success',
            title: 'Tải dữ liệu thành công',
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 2000
        });
    } catch (error) {
        console.error('Error loading stadiums:', error);

        // Load mock data for demo
        loadMockData();
    } finally {
        hideLoading();
    }
}

// Load Mock Data for Demo
function loadMockData() {
    allStadiums = [
        {
            id: 1,
            name: "Sân Vận Động Thống Nhất",
            nameUnsigned: "San Van Dong Thong Nhat",
            address: "138 Đào Duy Anh, Phường 9, Quận Phú Nhuận, TP.HCM",
            addressUnsigned: "138 Dao Duy Anh, Phuong 9, Quan Phu Nhuan, TP.HCM",
            description: "Sân vận động lịch sử với cơ sở vật chất hiện đại, phục vụ các trận đấu bóng đá chuyên nghiệp. Có đầy đủ tiện nghi như phòng thay đồ, khu vực khán giả, hệ thống đèn chiếu sáng chất lượng cao.",
            openTime: "06:00:00",
            closeTime: "22:00:00",
            latitude: 10.7993,
            longitude: 106.6766,
            isApproved: true,
            createdBy: 1,
            createdAt: "2025-09-15T08:30:00",
            updatedAt: "2025-09-28T14:20:00",
            isLocked: false,
            courts: [
                { id: 1, name: "Sân 1", courtType: "Bóng đá 11 người" },
                { id: 2, name: "Sân 2", courtType: "Bóng đá 7 người" }
            ],
            stadiumImages: [
                { id: 1, imageUrl: "https://picsum.photos/800/600?random=1" },
                { id: 2, imageUrl: "https://picsum.photos/800/600?random=2" }
            ]
        },
        {
            id: 2,
            name: "Sân Bóng Mini Quận 1",
            nameUnsigned: "San Bong Mini Quan 1",
            address: "45 Nguyễn Huệ, Quận 1, TP.HCM",
            addressUnsigned: "45 Nguyen Hue, Quan 1, TP.HCM",
            description: "Sân bóng mini chất lượng cao, phù hợp cho các trận đấu giao hữu",
            openTime: "07:00:00",
            closeTime: "23:00:00",
            latitude: 10.7769,
            longitude: 106.7009,
            isApproved: true,
            createdBy: 2,
            createdAt: "2025-09-20T10:15:00",
            updatedAt: "2025-09-25T16:45:00",
            isLocked: false,
            courts: [
                { id: 3, name: "Sân A", courtType: "Bóng đá 5 người" },
                { id: 4, name: "Sân B", courtType: "Bóng đá 5 người" },
                { id: 5, name: "Sân C", courtType: "Bóng đá 7 người" }
            ],
            stadiumImages: [
                { id: 3, imageUrl: "https://picsum.photos/800/600?random=3" }
            ]
        },
        {
            id: 3,
            name: "Sân Cỏ Nhân Tạo Bình Thạnh",
            nameUnsigned: "San Co Nhan Tao Binh Thanh",
            address: "123 Xô Viết Nghệ Tĩnh, Quận Bình Thạnh, TP.HCM",
            addressUnsigned: "123 Xo Viet Nghe Tinh, Quan Binh Thanh, TP.HCM",
            description: "Sân cỏ nhân tạo chất lượng, đèn chiếu sáng hiện đại",
            openTime: "05:30:00",
            closeTime: "23:30:00",
            latitude: 10.8142,
            longitude: 106.7072,
            isApproved: true,
            createdBy: 3,
            createdAt: "2025-09-25T09:00:00",
            updatedAt: "2025-09-26T11:30:00",
            isLocked: true,
            courts: [
                { id: 6, name: "Sân 1", courtType: "Bóng đá 7 người" }
            ],
            stadiumImages: [
                { id: 4, imageUrl: "https://picsum.photos/800/600?random=4" },
                { id: 5, imageUrl: "https://picsum.photos/800/600?random=5" }
            ]
        },
        {
            id: 4,
            name: "Sân Vận Động Quân Khu 7",
            nameUnsigned: "San Van Dong Quan Khu 7",
            address: "45 Hoàng Văn Thụ, Quận Tân Bình, TP.HCM",
            addressUnsigned: "45 Hoang Van Thu, Quan Tan Binh, TP.HCM",
            description: "Sân vận động lớn với nhiều tiện ích phục vụ",
            openTime: "06:00:00",
            closeTime: "21:00:00",
            latitude: 10.8006,
            longitude: 106.6553,
            isApproved: true,
            createdBy: 1,
            createdAt: "2025-09-10T07:20:00",
            updatedAt: "2025-09-22T13:10:00",
            isLocked: false,
            courts: [
                { id: 7, name: "Sân chính", courtType: "Bóng đá 11 người" }
            ],
            stadiumImages: [
                { id: 6, imageUrl: "https://picsum.photos/800/600?random=6" }
            ]
        },
        {
            id: 5,
            name: "Sân Bóng Đá Phú Nhuận",
            nameUnsigned: "San Bong Da Phu Nhuan",
            address: "78 Phan Đăng Lưu, Quận Phú Nhuận, TP.HCM",
            addressUnsigned: "78 Phan Dang Luu, Quan Phu Nhuan, TP.HCM",
            description: "Sân bóng đá tiêu chuẩn với không gian thoáng mát",
            openTime: "06:30:00",
            closeTime: "22:30:00",
            latitude: 10.7967,
            longitude: 106.6789,
            isApproved: true,
            createdBy: 2,
            createdAt: "2025-09-18T11:45:00",
            updatedAt: "2025-09-27T09:15:00",
            isLocked: false,
            courts: [
                { id: 8, name: "Sân 1", courtType: "Bóng đá 5 người" },
                { id: 9, name: "Sân 2", courtType: "Bóng đá 5 người" }
            ],
            stadiumImages: [
                { id: 7, imageUrl: "https://picsum.photos/800/600?random=7" },
                { id: 8, imageUrl: "https://picsum.photos/800/600?random=8" },
                { id: 9, imageUrl: "https://picsum.photos/800/600?random=9" }
            ]
        },
        {
            id: 6,
            name: "Sân Thể Thao Gò Vấp",
            nameUnsigned: "San The Thao Go Vap",
            address: "234 Quang Trung, Quận Gò Vấp, TP.HCM",
            addressUnsigned: "234 Quang Trung, Quan Go Vap, TP.HCM",
            description: "Sân thể thao đa năng, phục vụ nhiều môn thể thao",
            openTime: "05:00:00",
            closeTime: "23:00:00",
            latitude: 10.8376,
            longitude: 106.6761,
            isApproved: true,
            createdBy: 3,
            createdAt: "2025-09-28T14:30:00",
            updatedAt: "2025-09-29T10:00:00",
            isLocked: true,
            courts: [
                { id: 10, name: "Sân A", courtType: "Bóng đá 7 người" },
                { id: 11, name: "Sân B", courtType: "Bóng đá 7 người" },
                { id: 12, name: "Sân C", courtType: "Bóng đá 5 người" }
            ],
            stadiumImages: [
                { id: 10, imageUrl: "https://picsum.photos/800/600?random=10" }
            ]
        }
    ];

    filteredStadiums = allStadiums;
    updateStatistics();
    applyFilters();
}

// Update Statistics
function updateStatistics() {
    const total = allStadiums.length;
    const active = allStadiums.filter(s => !s.isLocked).length;
    const locked = allStadiums.filter(s => s.isLocked).length;

    $('#totalStadiums').text(total);
    $('#activeStadiums').text(active);
    $('#lockedStadiums').text(locked);
}

// Apply Filters
function applyFilters() {
    const searchTerm = $('#searchInput').val().toLowerCase();
    const lockStatus = $('#lockFilter').val();
    const sortBy = $('#sortFilter').val();
    itemsPerPage = parseInt($('#itemsPerPage').val());

    // Filter stadiums
    filteredStadiums = allStadiums.filter(stadium => {
        const matchesSearch = !searchTerm ||
            stadium.name.toLowerCase().includes(searchTerm) ||
            stadium.address.toLowerCase().includes(searchTerm) ||
            stadium.nameUnsigned.toLowerCase().includes(searchTerm);

        const matchesLock = !lockStatus ||
            (lockStatus === 'locked' && stadium.isLocked) ||
            (lockStatus === 'active' && !stadium.isLocked);

        return matchesSearch && matchesLock;
    });

    // Sort stadiums
    filteredStadiums.sort((a, b) => {
        switch (sortBy) {
            case 'newest':
                return new Date(b.createdAt) - new Date(a.createdAt);
            case 'oldest':
                return new Date(a.createdAt) - new Date(b.createdAt);
            case 'name-asc':
                return a.name.localeCompare(b.name);
            case 'name-desc':
                return b.name.localeCompare(a.name);
            default:
                return 0;
        }
    });

    currentPage = 1;
    renderStadiums();
}

// Reset Filters
function resetFilters() {
    $('#searchInput').val('');
    $('#lockFilter').val('');
    $('#sortFilter').val('newest');
    $('#itemsPerPage').val('12');
    applyFilters();
}

// Render Stadium Cards
function renderStadiums() {
    const startIndex = (currentPage - 1) * itemsPerPage;
    const endIndex = startIndex + itemsPerPage;
    const stadiumsToShow = filteredStadiums.slice(startIndex, endIndex);

    $('#totalCount').text(filteredStadiums.length);
    $('#showingCount').text(stadiumsToShow.length);

    const gridHtml = stadiumsToShow.length > 0
        ? stadiumsToShow.map(stadium => createStadiumCard(stadium)).join('')
        : `<div class="col-12">
               <div class="no-results">
                   <i class="bi bi-inbox"></i>
                   <h4>Không tìm thấy sân nào</h4>
                   <p class="text-muted">Thử điều chỉnh bộ lọc hoặc tìm kiếm khác</p>
               </div>
           </div>`;

    $('#stadiumGrid').html(gridHtml);
    renderPagination();
}

// Create Stadium Card HTML
function createStadiumCard(stadium) {
    const mainImage = stadium.stadiumImages && stadium.stadiumImages.length > 0
        ? stadium.stadiumImages[0].imageUrl
        : '';

    const openTime = formatTime(stadium.openTime);
    const closeTime = formatTime(stadium.closeTime);
    const courtsCount = stadium.courts ? stadium.courts.length : 0;
    const imagesCount = stadium.stadiumImages ? stadium.stadiumImages.length : 0;

    return `
        <div class="col-lg-4 col-md-6 mb-4">
            <div class="card stadium-card">
                <div class="stadium-image-container">
                    ${mainImage
            ? `<img src="${mainImage}" alt="${stadium.name}" class="stadium-image" 
                               onclick="viewStadiumDetail(${stadium.id})" style="cursor: pointer;">`
            : `<div class="stadium-image-placeholder">
                               <i class="bi bi-building"></i>
                           </div>`
        }
                    ${stadium.isLocked
            ? '<span class="stadium-lock-badge"><i class="bi bi-lock-fill"></i> Đã Khóa</span>'
            : ''
        }
                </div>
                
                <div class="stadium-info">
                    <h5 class="stadium-title" title="${stadium.name}">${stadium.name}</h5>
                    <div class="stadium-address">
                        <i class="bi bi-geo-alt-fill text-danger me-2 mt-1"></i>
                        <span>${stadium.address}</span>
                    </div>
                    
                    <div class="stadium-meta">
                        <div class="meta-item">
                            <i class="bi bi-clock text-primary"></i>
                            <small>${openTime} - ${closeTime}</small>
                        </div>
                    </div>
                    
                    <div class="stadium-meta">
                        <div class="meta-item">
                            <i class="bi bi-grid-3x3-gap text-success"></i>
                            <small>${courtsCount} sân con</small>
                        </div>
                        <div class="meta-item">
                            <i class="bi bi-images text-info"></i>
                            <small>${imagesCount} hình</small>
                        </div>
                    </div>
                </div>
                
                <div class="action-buttons">
                    <button class="btn btn-primary" onclick="viewStadiumDetail(${stadium.id})">
                        <i class="bi bi-eye"></i> Xem Chi Tiết
                    </button>
                    ${stadium.isLocked
            ? `<button class="btn btn-success" onclick="toggleLock(${stadium.id}, false)">
                               <i class="bi bi-unlock-fill"></i> Mở Khóa
                           </button>`
            : `<button class="btn btn-danger" onclick="toggleLock(${stadium.id}, true)">
                               <i class="bi bi-lock-fill"></i> Khóa Sân
                           </button>`
        }
                </div>
            </div>
        </div>
    `;
}

// Render Pagination
function renderPagination() {
    const totalPages = Math.ceil(filteredStadiums.length / itemsPerPage);

    if (totalPages <= 1) {
        $('#paginationContainer').html('');
        return;
    }

    let paginationHtml = '<nav><ul class="pagination">';

    // Previous button
    paginationHtml += `
        <li class="page-item ${currentPage === 1 ? 'disabled' : ''}">
            <a class="page-link" href="#" onclick="changePage(${currentPage - 1}); return false;">
                <i class="bi bi-chevron-left"></i> Trước
            </a>
        </li>
    `;

    // Page numbers
    const maxPagesToShow = 5;
    let startPage = Math.max(1, currentPage - Math.floor(maxPagesToShow / 2));
    let endPage = Math.min(totalPages, startPage + maxPagesToShow - 1);

    if (endPage - startPage + 1 < maxPagesToShow) {
        startPage = Math.max(1, endPage - maxPagesToShow + 1);
    }

    if (startPage > 1) {
        paginationHtml += `
            <li class="page-item">
                <a class="page-link" href="#" onclick="changePage(1); return false;">1</a>
            </li>
        `;
        if (startPage > 2) {
            paginationHtml += '<li class="page-item disabled"><span class="page-link">...</span></li>';
        }
    }

    for (let i = startPage; i <= endPage; i++) {
        paginationHtml += `
            <li class="page-item ${i === currentPage ? 'active' : ''}">
                <a class="page-link" href="#" onclick="changePage(${i}); return false;">${i}</a>
            </li>
        `;
    }

    if (endPage < totalPages) {
        if (endPage < totalPages - 1) {
            paginationHtml += '<li class="page-item disabled"><span class="page-link">...</span></li>';
        }
        paginationHtml += `
            <li class="page-item">
                <a class="page-link" href="#" onclick="changePage(${totalPages}); return false;">${totalPages}</a>
            </li>
        `;
    }

    // Next button
    paginationHtml += `
        <li class="page-item ${currentPage === totalPages ? 'disabled' : ''}">
            <a class="page-link" href="#" onclick="changePage(${currentPage + 1}); return false;">
                Sau <i class="bi bi-chevron-right"></i>
            </a>
        </li>
    `;

    paginationHtml += '</ul></nav>';
    $('#paginationContainer').html(paginationHtml);
}

// Change Page
function changePage(page) {
    const totalPages = Math.ceil(filteredStadiums.length / itemsPerPage);
    if (page < 1 || page > totalPages) return;

    currentPage = page;
    renderStadiums();

    // Scroll to top of grid
    $('html, body').animate({
        scrollTop: $('#stadiumGrid').offset().top - 100
    }, 500);
}

// View Stadium Detail
function viewStadiumDetail(id) {
    const stadium = allStadiums.find(s => s.id === id);
    if (!stadium) return;

    const detailHtml = `
        <div class="row">
            <div class="col-md-8">
                <h4 class="mb-3">${stadium.name}</h4>
                
                <div class="detail-row">
                    <div class="detail-label"><i class="bi bi-geo-alt-fill text-danger"></i> Địa chỉ</div>
                    <div class="detail-value">${stadium.address}</div>
                </div>
                
                <div class="detail-row">
                    <div class="detail-label"><i class="bi bi-card-text"></i> Mô tả</div>
                    <div class="detail-value">${stadium.description || 'Chưa có mô tả'}</div>
                </div>
                
                <div class="row">
                    <div class="col-md-6">
                        <div class="detail-row">
                            <div class="detail-label"><i class="bi bi-clock"></i> Giờ mở cửa</div>
                            <div class="detail-value">${formatTime(stadium.openTime)}</div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="detail-row">
                            <div class="detail-label"><i class="bi bi-clock-fill"></i> Giờ đóng cửa</div>
                            <div class="detail-value">${formatTime(stadium.closeTime)}</div>
                        </div>
                    </div>
                </div>
                
                ${stadium.latitude && stadium.longitude ? `
                <div class="detail-row">
                    <div class="detail-label"><i class="bi bi-pin-map"></i> Tọa độ</div>
                    <div class="detail-value">
                        Vĩ độ: ${stadium.latitude}, Kinh độ: ${stadium.longitude}
                        <a href="https://www.google.com/maps?q=${stadium.latitude},${stadium.longitude}" 
                           target="_blank" class="ms-2">
                            <i class="bi bi-box-arrow-up-right"></i> Xem trên bản đồ
                        </a>
                    </div>
                </div>
                ` : ''}
                
                <div class="detail-row">
                    <div class="detail-label"><i class="bi bi-calendar-plus"></i> Ngày tạo</div>
                    <div class="detail-value">${formatDate(stadium.createdAt)}</div>
                </div>
                
                <div class="detail-row">
                    <div class="detail-label"><i class="bi bi-calendar-check"></i> Cập nhật lần cuối</div>
                    <div class="detail-value">${formatDate(stadium.updatedAt)}</div>
                </div>
                
                <div class="detail-row">
                    <div class="detail-label"><i class="bi bi-grid-3x3-gap"></i> Danh sách sân con</div>
                    <div class="detail-value">
                        ${stadium.courts && stadium.courts.length > 0
            ? stadium.courts.map(court => `
                                <span class="badge bg-primary me-2 mb-2">
                                    ${court.name} - ${court.courtType}
                                </span>
                            `).join('')
            : '<span class="text-muted">Chưa có sân con</span>'
        }
                    </div>
                </div>
            </div>
            
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <h6 class="card-title mb-3"><i class="bi bi-info-circle"></i> Trạng thái</h6>
                        <div class="mb-3">
                            <div class="d-flex justify-content-between align-items-center mb-2">
                                <span>Tình trạng:</span>
                                ${stadium.isLocked
            ? '<span class="badge bg-danger"><i class="bi bi-lock-fill"></i> Đã khóa</span>'
            : '<span class="badge bg-success"><i class="bi bi-unlock-fill"></i> Hoạt động</span>'
        }
                            </div>
                        </div>
                        
                        <div class="d-grid gap-2">
                            ${stadium.isLocked
            ? `<button class="btn btn-success" onclick="toggleLockFromDetail(${stadium.id}, false)">
                                       <i class="bi bi-unlock-fill"></i> Mở Khóa Sân
                                   </button>`
            : `<button class="btn btn-danger" onclick="toggleLockFromDetail(${stadium.id}, true)">
                                       <i class="bi bi-lock-fill"></i> Khóa Sân
                                   </button>`
        }
                        </div>
                    </div>
                </div>
                
                ${stadium.stadiumImages && stadium.stadiumImages.length > 0 ? `
                <div class="card mt-3">
                    <div class="card-body">
                        <h6 class="card-title mb-3"><i class="bi bi-images"></i> Hình ảnh (${stadium.stadiumImages.length})</h6>
                        <div class="image-gallery">
                            ${stadium.stadiumImages.map(img => `
                                <img src="${img.imageUrl}" alt="Stadium" class="gallery-image" 
                                     onclick="showImage('${img.imageUrl}')">
                            `).join('')}
                        </div>
                    </div>
                </div>
                ` : ''}
            </div>
        </div>
    `;

    $('#stadiumDetailContent').html(detailHtml);
    detailModal.show();
}

// Show Image in Modal
function showImage(imageUrl) {
    $('#modalImage').attr('src', imageUrl);
    imageModal.show();
}

// Toggle Lock from Detail Modal
function toggleLockFromDetail(id, isLocked) {
    detailModal.hide();
    setTimeout(() => {
        toggleLock(id, isLocked);
    }, 300);
}

// Toggle Lock
async function toggleLock(id, isLocked) {
    const stadium = allStadiums.find(s => s.id === id);
    if (!stadium) return;

    const action = isLocked ? 'khóa' : 'mở khóa';

    const result = await Swal.fire({
        title: `Xác nhận ${action} sân?`,
        html: `
            <p>Bạn có chắc chắn muốn ${action} sân:</p>
            <p class="fw-bold">"${stadium.name}"</p>
            ${isLocked
                ? '<p class="text-danger"><i class="bi bi-exclamation-triangle"></i> Sân sẽ không thể được đặt sau khi khóa!</p>'
                : '<p class="text-success"><i class="bi bi-info-circle"></i> Sân sẽ có thể được đặt lại sau khi mở khóa!</p>'
            }
        `,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: isLocked ? '#e74a3b' : '#1cc88a',
        cancelButtonColor: '#858796',
        confirmButtonText: action.charAt(0).toUpperCase() + action.slice(1),
        cancelButtonText: 'Hủy'
    });

    if (!result.isConfirmed) return;

    showLoading();
    try {
        await $.ajax({
            url: `${API_BASE_URL}/stadiums/${id}/lock`,
            method: 'PATCH',
            data: JSON.stringify({ isLocked }),
            contentType: 'application/json'
        });

        // Update local data
        stadium.isLocked = isLocked;
        updateStatistics();
        renderStadiums();

        Swal.fire({
            icon: 'success',
            title: 'Thành công!',
            text: `Đã ${action} sân "${stadium.name}" thành công!`,
            confirmButtonText: 'OK'
        });
    } catch (error) {
        console.error('Error toggling lock:', error);
        Swal.fire({
            icon: 'error',
            title: 'Lỗi!',
            text: `Không thể ${action} sân. Vui lòng thử lại.`,
            confirmButtonText: 'OK'
        });
    } finally {
        hideLoading();
    }
}

// Format Time
function formatTime(timeString) {
    if (!timeString) return '';
    const parts = timeString.split(':');
    return `${parts[0]}:${parts[1]}`;
}

// Format Date
function formatDate(dateString) {
    if (!dateString) return '';
    const date = new Date(dateString);
    return date.toLocaleDateString('vi-VN', {
        day: '2-digit',
        month: '2-digit',
        year: 'numeric',
        hour: '2-digit',
        minute: '2-digit'
    });
}