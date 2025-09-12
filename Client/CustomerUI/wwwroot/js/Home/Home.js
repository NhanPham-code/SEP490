class StadiumFavoriteManager {
    constructor() {
        this.favorites = new Set(JSON.parse(localStorage.getItem('stadium-favorites')) || []);
        this.initializeEventListeners();
        this.initializeExistingButtons();
    }

    initializeEventListeners() {
        // Sử dụng event delegation để handle dynamic content
        document.addEventListener('click', (e) => {
            if (e.target.closest('.favorite-btn')) {
                e.preventDefault();
                e.stopPropagation();
                const btn = e.target.closest('.favorite-btn');
                const stadiumId = btn.dataset.stadiumId;
                const stadiumName = btn.dataset.stadiumName;
                this.toggleFavorite(stadiumId, stadiumName, btn);
            }
        });
    }

    initializeExistingButtons() {
        // Initialize trạng thái cho các button đã có
        document.querySelectorAll('.favorite-btn').forEach(btn => {
            const stadiumId = btn.dataset.stadiumId;
            if (stadiumId && this.favorites.has(stadiumId)) {
                this.setFavoritedState(btn);
            }
        });
    }

    toggleFavorite(stadiumId, stadiumName, button) {
        const heartIcon = button.querySelector('.heart-icon');
        const isCurrentlyFavorited = this.favorites.has(stadiumId);

        if (isCurrentlyFavorited) {
            this.removeFavorite(stadiumId, button, heartIcon);
            this.showNotification(`Đã bỏ yêu thích "${stadiumName}"`, 'removed');
        } else {
            this.addFavorite(stadiumId, button, heartIcon);
            this.showNotification(`Đã thêm "${stadiumName}" vào yêu thích`, 'added');
            this.createFloatingHearts(button);
        }

        this.saveFavorites();
        this.updateFavoriteCount();
    }

    addFavorite(stadiumId, button, heartIcon) {
        this.favorites.add(stadiumId);
        this.setFavoritedState(button);

        // Add heart beat animation
        heartIcon.classList.add('heart-beat');
        setTimeout(() => heartIcon.classList.remove('heart-beat'), 600);
    }

    removeFavorite(stadiumId, button, heartIcon) {
        this.favorites.delete(stadiumId);
        this.setUnfavoritedState(button);
    }

    setFavoritedState(button) {
        const heartIcon = button.querySelector('.heart-icon');
        heartIcon.className = 'heart-icon fas fa-heart text-lg';
        button.classList.add('favorited');
    }

    setUnfavoritedState(button) {
        const heartIcon = button.querySelector('.heart-icon');
        heartIcon.className = 'heart-icon far fa-heart text-lg';
        button.classList.remove('favorited');
    }

    createFloatingHearts(button) {
        const rect = button.getBoundingClientRect();

        for (let i = 0; i < 4; i++) {
            setTimeout(() => {
                const heart = document.createElement('div');
                heart.innerHTML = '❤️';
                heart.className = 'floating-heart';
                heart.style.left = (rect.left + rect.width / 2 - 8 + Math.random() * 16) + 'px';
                heart.style.top = (rect.top + rect.height / 2 - 8 + Math.random() * 16) + 'px';

                document.body.appendChild(heart);

                setTimeout(() => {
                    if (heart.parentNode) {
                        heart.parentNode.removeChild(heart);
                    }
                }, 1500);
            }, i * 150);
        }
    }

    showNotification(message, type) {
        // Tạo notification toast
        const notification = document.createElement('div');
        notification.className = `fixed top-4 right-4 z-50 px-4 py-3 rounded-lg shadow-lg transition-all duration-300 transform translate-x-full ${type === 'added'
                ? 'bg-green-500 text-white'
                : 'bg-red-500 text-white'
            }`;
        notification.innerHTML = `
            <div class="flex items-center">
                <i class="fas fa-heart mr-2"></i>
                <span>${message}</span>
            </div>
        `;

        document.body.appendChild(notification);

        // Animate in
        setTimeout(() => {
            notification.style.transform = 'translateX(0)';
        }, 100);

        // Animate out and remove
        setTimeout(() => {
            notification.style.transform = 'translateX(full)';
            setTimeout(() => {
                if (notification.parentNode) {
                    notification.parentNode.removeChild(notification);
                }
            }, 300);
        }, 3000);
    }

    updateFavoriteCount() {
        const countElement = document.querySelector('.favorite-count');
        if (countElement) {
            countElement.textContent = this.favorites.size;
        }
    }

    saveFavorites() {
        localStorage.setItem('stadium-favorites', JSON.stringify([...this.favorites]));
    }

    isFavorited(stadiumId) {
        return this.favorites.has(stadiumId);
    }

    getFavorites() {
        return [...this.favorites];
    }

    // Method để re-initialize sau khi load dữ liệu mới
    reinitialize() {
        this.initializeExistingButtons();
    }
}

// Initialize when DOM is loaded
document.addEventListener('DOMContentLoaded', () => {
    window.stadiumFavoriteManager = new StadiumFavoriteManager();
});

// Nếu bạn load dữ liệu stadium dynamically, gọi method này:
// window.stadiumFavoriteManager.reinitialize();
window.onload = function () {
    // Your code here
    displayListFavorite('', 9, 0);
};

function displayListFavorite(searchTerm, top, skip) {
    var searchUrl = searchTerm + `&$top=${top}&$skip=${skip}`;
    console.log(searchUrl);

    $.ajax({
        url: '/Home/Stadiums', // Endpoint for POST request
        type: 'POST',
        data: { searchTerm: searchUrl },
        success: function (data) {
            let count = data["@@odata.count"];
        
            console.log(skip);
            if (skip + 9 >= count) {
                $('#loadMoreBtn').hide();
            } else {
                $('#loadMoreBtn').show();
            }
            let html = '';
            if (data.value && data.value.length > 0) {
                data.value.forEach(function (item) {
                    let imageUrl = item.StadiumImages.length > 0 ? item.StadiumImages[0].ImageUrl : 'default.jpg';
                    let price = item.Courts.length > 0 ? item.Courts[0].PricePerHour : 0;
                    // Removed console.log(item.val) as 'val' is not defined in the data structure
                    console.log(item);

                    // Format tiền Việt Nam
                    let formattedPrice = new Intl.NumberFormat('vi-VN', {
                        style: 'currency',
                        currency: 'VND'
                    }).format(price);
                    let address = item.Address ?? '';

                    // Thay thế đoạn code HTML của bạn bằng đoạn này:
                    html += `<div class="card-content bg-white rounded-2xl shadow-sm overflow-hidden hover:shadow-lg transition-shadow duration-300">
                            <div class="relative h-48">
                                <img src="https://localhost:7280/${imageUrl}" alt="Stadium" class="w-full h-full object-cover">

                                <!-- Hot badge - Fixed positioning -->
                                <div class="absolute top-3 right-3 bg-gradient-to-r from-red-500 to-red-600 text-white px-2 py-1 rounded-full text-xs font-bold z-10 pulse-animation shadow-lg">
                                    🔥 Hot
                                </div>

                                <!-- Favorite Button - Positioned correctly -->
                                <div class="absolute top-3 left-3 z-20">
                                    <button class="favorite-btn bg-white/90 backdrop-blur-sm hover:bg-white border border-white/20 text-gray-600 hover:text-red-500 p-2.5 circle transition-all duration-300 shadow-lg hover:shadow-xl transform hover:scale-110"
                                            data-stadium-id="${item.Id}"
                                            data-stadium-name="${item.Name}">
                                        <i class="heart-icon far fa-heart text-lg"></i>
                                    </button>
                                </div>

                                <!-- Sport type badge -->
                                <div class="absolute bottom-3 left-3 bg-white/90 backdrop-blur-sm px-3 py-1.5 rounded-full text-sm font-medium text-gray-800">
                                    ${item.Courts[0].SportType}
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

                                <!-- Available time slots -->
                                <div class="mb-4">
                                    <div class="flex items-center text-sm text-gray-600 mb-2">
                                        <i class="ri-time-line mr-1"></i>
                                        <span>Khung giờ trống hôm nay:</span>
                                    </div>
                                    <div class="grid grid-cols-4 gap-1">
                                         <span class="px-3 py-1 bg-green-100 text-green-700 text-xs rounded-md font-medium time">${formatTimeForDisplay(item.OpenTime)}</span>
                                        <span class="px-3 py-1 bg-green-100 text-green-700 text-xs rounded-md font-medium time"><i class="ri-arrow-right-line" style="transform: scaleX(1.3);"></i></span>
                                        <span class="px-3 py-1 bg-green-100 text-green-700 text-xs rounded-md font-medium time">${formatTimeForDisplay(item.CloseTime)}</span>
                                        
                                    </div>
                                </div>

                                <div class="items-center justify-end">
                                    <div class="text-2xl font-bold text-blue-600">
                                        ${formattedPrice}<span class="text-sm font-normal text-gray-500">₫/giờ</span>
                                    </div>
                                    <button class="w-full mt-2 bg-blue-600 text-white px-6 py-2 rounded-lg text-sm font-semibold hover:bg-blue-700 transition-colors"
                                            onclick="redirectToBooking('${item.Id}')">
                                        Đặt ngay
                                    </button>
                                </div>
                            </div>
                        </div>`;
                });
                if (skip === 0) {
                    $('#favorite-list').html(html).show();
                } else {
                    $('#favorite-list').append(html);
                }
            } else {
                $('#favorite-list').empty().hide();
            }
        },
        error: function () {
            $('#favorite-list').empty().hide();
            console.log('Error fetching suggestions');
        }
    });
}