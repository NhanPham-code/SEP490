class StadiumFavoriteManager {
    constructor() {
        this.favorites = new Set(JSON.parse(localStorage.getItem('stadium-favorites')) || []);
        this.initializeEventListeners();
    }

    syncWithServer(favoriteStadiumIds) {
        const serverFavorites = new Set(favoriteStadiumIds.map(id => String(id)));
        this.favorites = serverFavorites;
        this.saveFavorites();
        this.reinitialize(); // Cập nhật trạng thái nút ở cả 2 view
        this.updateFavoriteCount();
    }

    toggleFavorite(stadiumId, stadiumName, button) {
        const idAsString = String(stadiumId);
        const isCurrentlyFavorited = this.favorites.has(idAsString);

        if (isCurrentlyFavorited) {
            this.callDeleteFavoriteAPI(idAsString, button, stadiumName);
        } else {
            this.callAddFavoriteAPI(idAsString, button, stadiumName);
        }
    }

    callAddFavoriteAPI(stadiumId, button, stadiumName) {
        const heartIcon = button.querySelector('.heart-icon');
        $.ajax({
            url: '/FavoriteStadium/AddFavorite',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ StadiumId: parseInt(stadiumId) }),
            success: (response) => {
                this.favorites.add(stadiumId);
                this.saveFavorites(); // Lưu và kích hoạt storage event
                this.updateAllButtonsForStadium(stadiumId, true); // Đồng bộ các nút
                this.updateFavoriteCount();
                this.showNotification(`Đã thêm "${stadiumName}" vào yêu thích`, 'added');
                this.createFloatingHearts(button);
                heartIcon.classList.add('heart-beat');
                setTimeout(() => heartIcon.classList.remove('heart-beat'), 600);

                // Nếu đang xem tab yêu thích, tải lại danh sách
                if ($('#favorite-container').is(':visible')) {
                    displayMyFavorites();
                }
            },
            error: (xhr) => {
                const errorMessage = xhr.responseJSON?.message || 'Có lỗi xảy ra, vui lòng thử lại.';
                this.showNotification(errorMessage, 'removed');
                console.error("Lỗi khi thêm yêu thích:", xhr.responseText);
            }
        });
    }

    callDeleteFavoriteAPI(stadiumId, button, stadiumName) {
        $.ajax({
            url: `/FavoriteStadium/DeleteFavorite`,
            type: 'DELETE',
            data: { stadiumId: stadiumId },
            success: (response) => {
                this.favorites.delete(stadiumId);
                this.saveFavorites(); // Lưu và kích hoạt storage event
                this.updateAllButtonsForStadium(stadiumId, false); // Đồng bộ các nút
                this.updateFavoriteCount();
                this.showNotification(`Đã bỏ yêu thích "${stadiumName}"`, 'removed');

                // 1. Cập nhật TẤT CẢ các icon trái tim cho sân này về trạng thái mặc định
                this.updateAllButtonsForStadium(stadiumId, false);

                // 2. Tìm thẻ card của sân này BÊN TRONG danh sách yêu thích (#favorite-list)
                const cardInFavoriteList = $(`#favorite-list .favorite-btn[data-stadium-id='${stadiumId}']`).closest('.card-content');

                // 3. Nếu tìm thấy, thực hiện hiệu ứng và xóa nó đi
                if (cardInFavoriteList.length > 0) {
                    cardInFavoriteList.css({
                        'transition': 'opacity 0.5s, transform 0.5s',
                        'opacity': '0',
                        'transform': 'scale(0.9)'
                    });
                    setTimeout(() => {
                        cardInFavoriteList.remove();
                        if ($('#favorite-list .card-content').length === 0) {
                            $('#favorite-list').html('<p class="text-center text-gray-500 py-10 col-span-full">Bạn chưa có sân vận động yêu thích nào.</p>');
                        }
                    }, 500);
                }
            },
            error: (xhr) => {
                const errorMessage = xhr.responseJSON?.message || 'Có lỗi xảy ra, vui lòng thử lại.';
                this.showNotification(errorMessage, 'removed');
                console.error("Lỗi khi xóa yêu thích:", xhr.responseText);
            }
        });
    }

    /**
     * Cập nhật trạng thái (yêu thích/không yêu thích) cho TẤT CẢ các nút 
     * có cùng data-stadium-id trên trang.
     * Điều này đảm bảo đồng bộ giữa #stadium-grid và #favorite-list.
     */
    updateAllButtonsForStadium(stadiumId, isFavorited) {
        const buttons = document.querySelectorAll(`.favorite-btn[data-stadium-id='${stadiumId}']`);
        buttons.forEach(btn => {
            if (isFavorited) {
                this.setFavoritedState(btn);
            } else {
                this.setUnfavoritedState(btn);
            }
        });
    }

    initializeEventListeners() {
        document.addEventListener('click', (e) => {
            const favoriteButton = e.target.closest('.favorite-btn');
            if (favoriteButton) {
                e.preventDefault();
                e.stopPropagation();
                this.toggleFavorite(favoriteButton.dataset.stadiumId, favoriteButton.dataset.stadiumName, favoriteButton);
            }
        });
    }

    initializeExistingButtons() {
        document.querySelectorAll('.favorite-btn').forEach(btn => {
            const stadiumId = String(btn.dataset.stadiumId);
            if (stadiumId && this.favorites.has(stadiumId)) {
                this.setFavoritedState(btn);
            } else {
                this.setUnfavoritedState(btn);
            }
        });
    }

    setFavoritedState(button) {
        const heartIcon = button.querySelector('.heart-icon');
        heartIcon.className = 'heart-icon fas fa-heart text-lg text-red-500';
        button.classList.add('favorited');
    }

    setUnfavoritedState(button) {
        const heartIcon = button.querySelector('.heart-icon');
        heartIcon.className = 'heart-icon far fa-heart text-lg';
        button.classList.remove('favorited');
    }

    saveFavorites() {
        localStorage.setItem('stadium-favorites', JSON.stringify([...this.favorites]));
    }

    updateFavoriteCount() {
        const countElement = document.querySelector('.favorite-count');
        if (countElement) {
            countElement.textContent = this.favorites.size;
        }
    }

    reinitialize() {
        this.initializeExistingButtons();
    }

    // Các hàm hiệu ứng không thay đổi
    createFloatingHearts(button) { /* ... */ }
    showNotification(message, type) { /* ... */ }
}

// =================================================================
// KHỞI TẠO VÀ ĐỒNG BỘ HÓA
// =================================================================

document.addEventListener('DOMContentLoaded', () => {
    window.stadiumFavoriteManager = new StadiumFavoriteManager();

    // Chỉ gọi displayMyFavorites nếu đây là trang có chứa container cho danh sách yêu thích
    if (document.getElementById('favorite-container')) {
        displayMyFavorites();
    } else {
        // Nếu là trang khác (ví dụ trang danh sách sân), hãy đồng bộ trạng thái các nút trái tim
        // bằng cách gọi API GetMyFavorites ở chế độ "im lặng"
        syncFavoriteStatusSilently();
    }
});

// Lắng nghe sự thay đổi trên localStorage từ các tab khác
window.addEventListener('storage', (event) => {
    if (event.key === 'stadium-favorites') {
        console.log('Phát hiện thay đổi từ tab khác, đang đồng bộ hóa...');
        const newFavorites = new Set(JSON.parse(event.newValue) || []);
        window.stadiumFavoriteManager.favorites = newFavorites;

        if (document.getElementById('favorite-container')) {
            displayMyFavorites();
        } else {
            window.stadiumFavoriteManager.reinitialize();
            window.stadiumFavoriteManager.updateFavoriteCount();
        }
    }
});

// =================================================================
// CÁC HÀM TRỢ GIÚP
// =================================================================

/**
 * Hàm này chỉ gọi API để lấy danh sách ID yêu thích và cập nhật trạng thái các nút
 * mà không render lại toàn bộ trang. Dùng cho trang danh sách sân.
 */
function syncFavoriteStatusSilently() {
    $.ajax({
        url: '/FavoriteStadium/GetMyFavorites',
        type: 'GET',
        success: function (data) {
            if (data.value) {
                const favoriteIdsFromServer = data.value.map(item => item.Id);
                if (window.stadiumFavoriteManager) {
                    window.stadiumFavoriteManager.syncWithServer(favoriteIdsFromServer);
                }
            }
        },
        error: function (xhr) {
            console.error("Không thể đồng bộ trạng thái yêu thích:", xhr.responseText);
        }
    });
}

/**
 * Hàm này render toàn bộ danh sách sân yêu thích. Chỉ dùng cho trang yêu thích.
 */
function displayMyFavorites() {
    const favoriteListContainer = $('#favorite-list');
    if (favoriteListContainer.length === 0) return;

    $.ajax({
        url: '/FavoriteStadium/GetMyFavorites',
        type: 'GET',
        success: function (data) {
            let html = '';
            if (data.value && data.value.length > 0) {
                const favoriteIdsFromServer = data.value.map(item => item.Id);
                if (window.stadiumFavoriteManager) {
                    window.stadiumFavoriteManager.syncWithServer(favoriteIdsFromServer);
                }

                data.value.forEach(function (item) {
                    // --- GIỮ NGUYÊN HTML CARD CỦA BẠN ---
                    let imageUrl = item.StadiumImages && item.StadiumImages.length > 0 ? item.StadiumImages[0].ImageUrl : 'images/default-stadium.png';
                    let price = item.Courts && item.Courts.length > 0 ? item.Courts[0].PricePerHour : 0;
                    let sportType = item.Courts && item.Courts.length > 0 ? item.Courts[0].SportType : 'N/A';
                    let formattedPrice = new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(price);
                    let address = item.Address ?? 'Chưa cập nhật địa chỉ';

                    html += `<div class="card-content bg-white rounded-2xl shadow-sm overflow-hidden hover:shadow-lg transition-shadow duration-300">
                        <div class="relative h-48">
                            <img src="https://localhost:7280/${imageUrl}" alt="Stadium" class="w-full h-full object-cover">
                            <div class="absolute top-3 right-3 bg-gradient-to-r from-red-500 to-red-600 text-white px-2 py-1 rounded-full text-xs font-bold z-10 pulse-animation shadow-lg">
                                🔥 Hot
                            </div>
                            <div class="absolute top-3 left-3 z-20">
                                <button class="favorite-btn bg-white/90 backdrop-blur-sm hover:bg-white border border-white/20 text-gray-600 hover:text-red-500 p-2.5 circle transition-all duration-300 shadow-lg hover:shadow-xl transform hover:scale-110"
                                        data-stadium-id="${item.Id}"
                                        data-stadium-name="${item.Name}">
                                    <i class="heart-icon far fa-heart text-lg"></i>
                                </button>
                            </div>
                            <div class="absolute bottom-3 left-3 bg-white/90 backdrop-blur-sm px-3 py-1.5 rounded-full text-sm font-medium text-gray-800">
                                ${sportType}
                            </div>
                        </div>
                        <div class="p-4">
                            <h3 class="font-bold text-lg text-gray-900 mb-1">${item.Name}</h3>
                            <div class="flex items-center text-gray-500 text-sm mb-2">
                                <i class="ri-map-pin-line text-gray-400 mr-1"></i>
                                <span>${address}</span>
                            </div>
                            <div class="flex items-center text-sm mb-3">
                                <i class="ri-star-fill text-yellow-400 mr-1"></i>
                                <span class="font-semibold text-gray-800">4.7</span>
                                <span class="text-gray-500 ml-1">(124 đánh giá)</span>
                            </div>
                            <div class="mb-4">
                                <div class="flex items-center text-sm text-gray-600 mb-2">
                                    <i class="ri-time-line mr-1"></i>
                                    <span>Khung giờ trống hôm nay:</span>
                                </div>
                                 <div class="grid grid-cols-3 gap-1">
                                        <span class="px-3 py-1 bg-green-100 text-green-700 text-xs rounded-md font-medium time">${formatTimeForDisplay(item.OpenTime)}</span>
                                        <span class="px-3 py-1 bg-green-100 text-green-700 text-xs rounded-md font-medium time"><i class="ri-arrow-right-line" style="transform: scaleX(1.3);"></i></span>
                                        <span class="px-3 py-1 bg-green-100 text-green-700 text-xs rounded-md font-medium time">${formatTimeForDisplay(item.CloseTime)}</span>
                                </div>
                            </div>
                            <div class="items-center justify-end">
                                <div class="text-2xl font-bold text-blue-600">
                                    ${formattedPrice}<span class="text-sm font-normal text-gray-500">/giờ</span>
                                </div>
                                <button class="w-full mt-2 bg-blue-600 text-white px-6 py-2 rounded-lg text-sm font-semibold hover:bg-blue-700 transition-colors"
                                        onclick="redirectToBooking('${item.Id}')">
                                    Đặt ngay
                                </button>
                            </div>
                        </div>
                    </div>`;
                });
                favoriteListContainer.html(html).show();
                if (window.stadiumFavoriteManager) {
                    window.stadiumFavoriteManager.reinitialize();
                }
            } else {
                favoriteListContainer.html('<p class="text-center text-gray-500 py-10 col-span-full">Bạn chưa có sân vận động yêu thích nào.</p>').show();
                if (window.stadiumFavoriteManager) {
                    window.stadiumFavoriteManager.syncWithServer([]);
                }
            }
        },
        error: function (xhr) {
            favoriteListContainer.html('<p class="text-center text-red-500 py-10 col-span-full">Đã có lỗi xảy ra khi tải danh sách yêu thích.</p>').show();
            console.error('Error fetching favorite stadiums:', xhr.responseText);
        }
    });
}

function formatTimeForDisplay(timeString) {
    if (!timeString) return '';
    const parts = timeString.split(':');
    return `${parts[0]}:${parts[1]}`;
}

function redirectToBooking(stadiumId) {
    window.location.href = `/Stadium/StadiumDetail?stadiumId=${stadiumId}`;
}