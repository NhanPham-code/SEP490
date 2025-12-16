// API Configuration
const API_BASE_URL = '/api'; // Thay đổi theo cấu hình của bạn
let allStadiums = [];
let filteredStadiums;
let currentPage = 1;
let itemsPerPage = 3;
let detailModal, imageModal;
let totalItems = 0; // Biến toàn cục để lưu tổng số mục

// Initialize on document ready
$(document).ready(function () {
    console.log('Document is ready');

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
    let skip = (currentPage - 1) * itemsPerPage;
    let query = `&$filter=IsApproved eq false&$top=${itemsPerPage}&$skip=${skip}`;
   
    $.ajax({
        url: CONFIG.API_ENDPOINTS.SEARCH,
        type: 'POST',
        data: { url: query },
        success: function (data) {
            if (!data.value || data.value.length === 0) {
                $("#unapprove-stadium").hide();
                return;
            }
            console.log('Data IsApproved:', data.value);
            filteredStadiums = data.value || [];
            
            $("#total-count_unapprove").html(data["@odata.count"] || 0);
            $('#pending-count').text(data["@odata.count"] || 0);
            console.log("Cout Stadium Unapprove: ", data["@odata.count"] || 0);
            totalItems = data["@odata.count"] || 0;
            updatePaginationUnapprove();
            if (totalItems <= 3) {
                $("#pagination-container-unapprove").hide();
            } else {
                $("#pagination-container-unapprove").show();
            }
            renderStadiumGridUnAppprove(data.value);
            
        }, 
        error: function (xhr, status, error) {
            console.error('Error loading data:', error);
            $("#unapprove-stadium").hide();
            showErrorState(error);
        }
    });
}
function renderStadiumGridUnAppprove(stadiums) {
    if (!stadiums || stadiums.length === 0) {
        $('#stadium-grid').html('');
        return;
    }

    const html = stadiums.map(stadium => `
                        <div class="stadium-card animate-fade-in">
                            <div class="stadium-image">
                                <img src="${getUrlImage(stadium.StadiumImages)}"
                                     alt="${stadium.Name}"
                                     loading="lazy">
                                <div class="image-overlay"></div>
                                <div class="status-badge status-${stadium.IsApproved}">
                                    <i class="ri-${stadium.IsApproved ? 'checkbox-circle' : 'error-warning'}-line"></i>
                                    ${getStatusText(stadium.IsApproved)}
                                </div>
                                <h3 class="stadium-title">${stadium.Name}</h3>
                            </div>
                            <div class="card-content">
                                <div class="location-info">
                                    <i class="ri-map-pin-2-line"></i>
                                    ${stadium.Address || 'Chưa cập nhật địa chỉ'}
                                </div>
                                
                                <div class="pb-4">
                                    <div class="flex items-center text-sm mb-3">
                                        <i class="ri-star-fill text-yellow-400 mr-1"></i>
                                        <span class="font-semibold text-gray-800 rating">0.0</span>
                                        <span class="text-gray-500 ml-1 feedback-count">(0 đánh giá)</span>
                                    </div>
                                </div>
                                <a href="#" class="link">Xem chi tiết đánh giá</a>
                            </div>
                            
                            <div class="card-actions bottom-content">
                                                           <div class="card-detail">
                                                                   <button onclick="openViewModal(${stadium.Id})" class="details-btn loading" title="Xem chi tiết">
                        <i class="ri-information-line"></i> Chi tiết
                    </button>
                                                             <button onclick="goToDetail(${stadium.Id})" class="court-btn loading">
                    ${setIcon(stadium.Courts)} Xem sân
                </button>

                                                           </div>

                                            <div class="action-buttons">

                    
                    ${stadium.IsApproved == false ?
            `
                          <button onclick="confirmApprove(${stadium.Id})" class="action-btn isApproved-btn" title="Chấp nhận sân">
                                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor"><path d="M10.0072 2.10365C8.60556 1.64993 7.08193 2.28104 6.41168 3.59294L5.6059 5.17011C5.51016 5.35751 5.35775 5.50992 5.17036 5.60566L3.59318 6.41144C2.28128 7.08169 1.65018 8.60532 2.10389 10.0069L2.64935 11.6919C2.71416 11.8921 2.71416 12.1077 2.64935 12.3079L2.10389 13.9929C1.65018 15.3945 2.28129 16.9181 3.59318 17.5883L5.17036 18.3941C5.35775 18.4899 5.51016 18.6423 5.6059 18.8297L6.41169 20.4068C7.08194 21.7187 8.60556 22.3498 10.0072 21.8961L11.6922 21.3507C11.8924 21.2859 12.1079 21.2859 12.3081 21.3507L13.9931 21.8961C15.3947 22.3498 16.9183 21.7187 17.5886 20.4068L18.3944 18.8297C18.4901 18.6423 18.6425 18.4899 18.8299 18.3941L20.4071 17.5883C21.719 16.9181 22.3501 15.3945 21.8964 13.9929L21.3509 12.3079C21.2861 12.1077 21.2861 11.8921 21.3509 11.6919L21.8964 10.0069C22.3501 8.60531 21.719 7.08169 20.4071 6.41144L18.8299 5.60566C18.6425 5.50992 18.4901 5.3575 18.3944 5.17011L17.5886 3.59294C16.9183 2.28104 15.3947 1.64993 13.9931 2.10365L12.3081 2.6491C12.1079 2.71391 11.8924 2.71391 11.6922 2.6491L10.0072 2.10365ZM8.19271 4.50286C8.41612 4.06556 8.924 3.8552 9.39119 4.00643L11.0762 4.55189C11.6768 4.74632 12.3235 4.74632 12.9241 4.55189L14.6091 4.00643C15.0763 3.8552 15.5841 4.06556 15.8076 4.50286L16.6133 6.08004C16.9006 6.64222 17.3578 7.09946 17.92 7.38668L19.4972 8.19246C19.9345 8.41588 20.1448 8.92375 19.9936 9.39095L19.4481 11.076C19.2537 11.6766 19.2537 12.3232 19.4481 12.9238L19.9936 14.6088C20.1448 15.076 19.9345 15.5839 19.4972 15.8073L17.92 16.6131C17.3578 16.9003 16.9006 17.3576 16.6133 17.9197L15.8076 19.4969C15.5841 19.9342 15.0763 20.1446 14.6091 19.9933L12.9241 19.4479C12.3235 19.2535 11.6768 19.2535 11.0762 19.4479L9.3912 19.9933C8.924 20.1446 8.41612 19.9342 8.19271 19.4969L7.38692 17.9197C7.09971 17.3576 6.64246 16.9003 6.08028 16.6131L4.50311 15.8073C4.06581 15.5839 3.85544 15.076 4.00668 14.6088L4.55213 12.9238C4.74656 12.3232 4.74656 11.6766 4.55213 11.076L4.00668 9.39095C3.85544 8.92375 4.06581 8.41588 4.50311 8.19246L6.08028 7.38668C6.64246 7.09946 7.09971 6.64222 7.38692 6.08004L8.19271 4.50286ZM6.75972 11.7573L11.0023 15.9999L18.0734 8.92885L16.6592 7.51464L11.0023 13.1715L8.17394 10.343L6.75972 11.7573Z"></path></svg>
                        </button>
                       ` :
            `
                      

                         
                                ${stadium.IsLocked ?
                `<button onclick="confirmUnlock(${stadium.Id})" class="action-btn unlock-btn" title="Mở khóa">
                                    <i class="ri-lock-unlock-line"></i>
                                </button>` :
                `<button onclick="confirmLock(${stadium.Id})" class="action-btn lock-btn" title="Khóa">
                                    <i class="ri-lock-line"></i>
                                </button>`
            }
                        `
        }
                </div>
                                </div>
                        </div>
                    `).join('');

    $('#unApproveStadium').html(html);
}




/**
 * HÀM ĐƯỢC CẬP NHẬT
 * (Sửa lỗi typo, sửa lỗi ID, bỏ 'state' để dùng biến toàn cục)
 */
function updatePaginationUnapprove() {
    // SỬA Ở ĐÂY: Sửa lại console.log cho đúng
    console.log("Update Pagination Unapprove - Total Items:", totalItems);
    console.log("Items Per Page:", itemsPerPage); // Sửa label
    console.log("Current Page:", currentPage);

    const totalPages = Math.ceil(totalItems / itemsPerPage);
    console.log("Total Pages Calculated:", totalPages);

    const start = (currentPage - 1) * itemsPerPage + 1;
    const end = Math.min(start + itemsPerPage - 1, totalItems);

    console.log(`Showing items from ${start} to ${end} of ${totalItems}`);

    $('#showing-range-unapprove').text(totalItems > 0 ? `${start}-${end}` : '0');
    $('#total-count_unapprove').text(totalItems);

    // Logic này đã đúng. Nếu totalPages = 1, nó sẽ ẩn đi.
    if (totalItems === 0 || totalPages <= 1) {
        console.log("Hiding pagination (Total Pages <= 1)");
        $('.pagination-section').hide();
        return;
    } else {
        console.log("Showing pagination");
        $('.pagination-section').show();
    }
    let paginationHtml = '';
    if (totalItems > 3) {
        

        // Nút Previous
        paginationHtml += `
        <button class="pagination-btn ${currentPage === 1 ? 'disabled' : ''}"
                onclick="changeUnapprovedPage(${currentPage - 1})" 
                ${currentPage === 1 ? 'disabled' : ''}>
            <i class="ri-arrow-left-s-line"></i>
        </button>
    `;

        // Calculate page range
        let startPage = Math.max(1, currentPage - 2);
        let endPage = Math.min(totalPages, startPage + 4);

        if (endPage - startPage < 4) {
            startPage = Math.max(1, endPage - 4);
        }

        // First page and ellipsis
        if (startPage > 1) {
            paginationHtml += `<button class="pagination-btn" onclick="changeUnapprovedPage(1)">1</button>`;
            if (startPage > 2) {
                paginationHtml += `<span class="pagination-ellipsis">...</span>`;
            }
        }

        // Page numbers
        for (let i = startPage; i <= endPage; i++) {
            paginationHtml += `
            <button class="pagination-btn ${i === currentPage ? 'active' : ''}"
                    onclick="changeUnapprovedPage(${i})"> 
                ${i}
            </button>
        `;
        }

        // Last page and ellipsis
        if (endPage < totalPages) {
            if (endPage < totalPages - 1) {
                paginationHtml += `<span class="pagination-ellipsis">...</span>`;
            }
            paginationHtml += `<button class="pagination-btn" onclick="changeUnapprovedPage(${totalPages})">${totalPages}</button>`;
        }

        // Next button
        paginationHtml += `
        <button class="pagination-btn ${currentPage === totalPages ? 'disabled' : ''}"
                onclick="changeUnapprovedPage(${currentPage + 1})" 
                ${currentPage === totalPages ? 'disabled' : ''}>
            <i class="ri-arrow-right-s-line"></i>
        </button>
    `;
    }

    $('#pagination-container-unapprove').html(paginationHtml);
}


/**
 * HÀM MỚI (Đã đổi tên từ changePage)
 * (Sửa logic để gọi loadUnapprovedStadiums)
 */
function changeUnapprovedPage(page) {
    const totalPages = Math.ceil(totalItems / itemsPerPage);

    if (page < 1 || page > totalPages || page === currentPage) {
        return;
    }

    currentPage = page;

    // SỬA Ở ĐÂY: Gọi đúng hàm loadUnapprovedStadiums
    loadStadiums();

    // Cuộn lên đầu lưới
    $('html, body').animate({
        scrollTop: $('#unApproveStadium').offset().top - 100
    }, 500);
}



// View Stadium Detail

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

function updateSportChart() {
    const sports = [
        { countId: 'football-count', barClass: 'football-bar' },
        { countId: 'basketball-count', barClass: 'basketball-bar' },
        { countId: 'volleyball-count', barClass: 'volleyball-bar' },
        { countId: 'badminton-count', barClass: 'badminton-bar' },
        { countId: 'tennis-count', barClass: 'tennis-bar' },
        { countId: 'pickleballCount', barClass: 'pickleball-bar' }
    ];

    // Lấy giá trị
    const values = sports.map(sport => {
        const countEl = document.getElementById(sport.countId);
        return parseInt(countEl?.textContent) || 0;
    });

    const maxValue = Math.max(...values, 1);

    // Cập nhật thanh bar
    sports.forEach((sport, index) => {
        const bar = document.querySelector('.' + sport.barClass);
        if (bar) {
            const percentage = (values[index] / maxValue) * 100;
            bar.style.width = percentage + '%';
        }
    });
}

// TỰ ĐỘNG CHẠY khi DOM load xong
document.addEventListener('DOMContentLoaded', function () {
    // Đợi một chút để data load vào các element
    setTimeout(updateSportChart, 2500);
});