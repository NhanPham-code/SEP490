class FindTeamManager {
    constructor() {
        this.baseUrl = '/FindTeam';
        this.currentPage = 1;
        this.pageSize = 12;
        this.totalRecords = 0;
        this.currentFilters = {};
        this.init();
    }

    init() {
        this.bindEvents();
        this.loadTeamPosts();
        this.initDatePicker();
    }

    bindEvents() {
        // Filter events
        document.addEventListener('change', (e) => {
            if (e.target.matches('.custom-checkbox, .date-input, .location-input')) {
                this.applyFilters();
            }
        });

        // Filter toggle for mobile
        document.getElementById('mobile-filter-btn')?.addEventListener('click', () => {
            this.toggleMobileFilters();
        });

        document.getElementById('close-filter')?.addEventListener('click', () => {
            this.closeMobileFilters();
        });

        // Clear filters
        document.querySelector('.clear-filters')?.addEventListener('click', () => {
            this.clearFilters();
        });

        // Load more button
        document.querySelector('.load-more button')?.addEventListener('click', () => {
            this.loadMore();
        });

        // Create post button
        document.getElementById('create-post')?.addEventListener('click', () => {
            this.showCreatePostModal();
        });

        // Time slots
        document.querySelectorAll('.time-slot').forEach(slot => {
            slot.addEventListener('click', (e) => {
                if (!e.target.classList.contains('unavailable')) {
                    document.querySelectorAll('.time-slot').forEach(s => s.classList.remove('selected'));
                    e.target.classList.add('selected');
                    this.applyFilters();
                }
            });
        });

        // Facility tags
        document.querySelectorAll('.facility-tag').forEach(tag => {
            tag.addEventListener('click', (e) => {
                e.target.classList.toggle('active');
                this.applyFilters();
            });
        });
    }

    buildODataUrl() {
        let url = `${this.baseUrl}/GetAllAndSearch?url=$filter=`;
        let filters = [];

        // Sport filter
        const selectedSports = Array.from(document.querySelectorAll('#sport-filter .custom-checkbox:checked'))
            .map(cb => cb.nextElementSibling.nextElementSibling.textContent);
        if (selectedSports.length > 0) {
            const sportFilter = selectedSports.map(sport => `Sport eq '${sport}'`).join(' or ');
            filters.push(`(${sportFilter})`);
        }

        // Date filter
        const selectedDate = document.querySelector('.date-input').value;
        if (selectedDate) {
            filters.push(`PlayDate eq ${selectedDate}`);
        }

        // Time filter
        const selectedTime = document.querySelector('.time-slot.selected')?.textContent;
        if (selectedTime) {
            const timeStr = `${selectedTime}:00`;
            filters.push(`TimePlay eq time'${timeStr}'`);
        }

        // Location filter
        const location = document.querySelector('.location-input').value;
        if (location) {
            filters.push(`contains(Location, '${location}')`);
        }

        // Build final URL
        if (filters.length > 0) {
            url += encodeURIComponent(filters.join(' and '));
        } else {
            url = `${this.baseUrl}/GetAllAndSearch?url=`;
        }

        // Add pagination
        url += `&$skip=${(this.currentPage - 1) * this.pageSize}&$top=${this.pageSize}`;

        // Add ordering
        url += `&$orderby=CreatedAt desc`;

        return url;
    }

    async loadTeamPosts(append = false) {
        try {
            this.showLoading();
            const url = this.buildODataUrl();

            const response = await fetch(url);
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }

            const data = await response.json();

            if (append) {
                this.appendTeamPosts(data.value || data);
            } else {
                this.renderTeamPosts(data.value || data);
            }

            this.totalRecords = data['@odata.count'] || (data.value ? data.value.length : data.length);
            this.updateLoadMoreButton();

        } catch (error) {
            console.error('Error loading team posts:', error);
            this.showError('Không thể tải dữ liệu. Vui lòng thử lại.');
        } finally {
            this.hideLoading();
        }
    }

    renderTeamPosts(posts) {
        const container = document.querySelector('.players-grid');
        if (!container) return;

        if (!posts || posts.length === 0) {
            container.innerHTML = `
                <div class="no-results">
                    <i class="ri-search-line"></i>
                    <h3>Không tìm thấy kết quả</h3>
                    <p>Thử điều chỉnh bộ lọc hoặc tạo bài viết mới</p>
                </div>`;
            return;
        }

        container.innerHTML = posts.map(post => this.createPostCard(post)).join('');
        this.bindCardEvents();
    }

    appendTeamPosts(posts) {
        const container = document.querySelector('.players-grid');
        if (!container || !posts || posts.length === 0) return;

        const newCards = posts.map(post => this.createPostCard(post)).join('');
        container.insertAdjacentHTML('beforeend', newCards);
        this.bindCardEvents();
    }

    createPostCard(post) {
        const playerLevel = this.getPlayerLevel(post.CreatedBy);
        const formattedDate = new Date(post.PlayDate).toLocaleDateString('vi-VN', {
            day: '2-digit',
            month: 'short',
            year: 'numeric'
        });
        const formattedTime = post.TimePlay;

        return `
            <article class="player-card" data-post-id="${post.Id}">
                <div class="player-header">
                    <div class="player-avatar">
                        <img src="https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=60&h=60&fit=crop&crop=face" alt="${post.CreatedByName || 'User'}">
                    </div>
                    <div class="player-info">
                        <h3 class="player-name">${post.CreatedByName || 'Người dùng'}</h3>
                        <div class="player-level ${playerLevel.class}">
                            <i class="ri-star-fill"></i>
                            ${playerLevel.text}
                        </div>
                    </div>
                    <button class="bookmark-btn" onclick="findTeamManager.toggleBookmark(${post.Id})">
                        <i class="ri-bookmark-line"></i>
                    </button>
                </div>

                <div class="game-details">
                    <div class="detail-item">
                        <i class="ri-football-line"></i>
                        <span>${post.Sport}</span>
                    </div>
                    <div class="detail-item">
                        <i class="ri-calendar-line"></i>
                        <span>${formattedDate} - ${formattedTime}</span>
                    </div>
                    <div class="detail-item">
                        <i class="ri-map-pin-line"></i>
                        <span>${post.Location}</span>
                    </div>
                    <div class="detail-item">
                        <i class="ri-group-line"></i>
                        <span>Cần ${post.NeededPlayers} người chơi</span>
                    </div>
                </div>

                <p class="game-description">${post.Description}</p>

                <div class="card-footer">
                    <div class="price-info">
                        <span class="price">${post.Price || '50.000'}đ</span>
                        <span class="price-label">mỗi người</span>
                    </div>
                    <button class="btn btn-primary btn-join" onclick="findTeamManager.joinTeam(${post.Id})">
                        <i class="ri-user-add-line"></i>
                        Tham Gia
                    </button>
                </div>
            </article>`;
    }

    getPlayerLevel(playerId) {
        // Mock function - replace with actual logic
        const levels = [
            { class: 'beginner', text: 'Mới Bắt Đầu' },
            { class: 'intermediate', text: 'Trung Bình' },
            { class: 'advanced', text: 'Nâng Cao' }
        ];
        return levels[Math.floor(Math.random() * levels.length)];
    }

    bindCardEvents() {
        // Bind any additional events for cards here
    }

    applyFilters() {
        this.currentPage = 1;
        this.loadTeamPosts();
    }

    clearFilters() {
        // Clear checkboxes
        document.querySelectorAll('.custom-checkbox').forEach(cb => cb.checked = false);

        // Clear date
        document.querySelector('.date-input').value = '';

        // Clear location
        document.querySelector('.location-input').value = '';

        // Clear time selection
        document.querySelectorAll('.time-slot').forEach(slot => slot.classList.remove('selected'));

        // Clear facility tags
        document.querySelectorAll('.facility-tag').forEach(tag => tag.classList.remove('active'));

        this.applyFilters();
    }

    loadMore() {
        this.currentPage++;
        this.loadTeamPosts(true);
    }

    updateLoadMoreButton() {
        const loadMoreBtn = document.querySelector('.load-more button');
        if (!loadMoreBtn) return;

        const currentlyLoaded = (this.currentPage * this.pageSize);
        if (currentlyLoaded >= this.totalRecords) {
            loadMoreBtn.style.display = 'none';
        } else {
            loadMoreBtn.style.display = 'block';
        }
    }

    showLoading() {
        // Add loading spinner
        const container = document.querySelector('.players-grid');
        if (container && this.currentPage === 1) {
            container.innerHTML = `
                <div class="loading-spinner">
                    <i class="ri-loader-2-line"></i>
                    <p>Đang tải...</p>
                </div>`;
        }
    }

    hideLoading() {
        // Remove loading spinner
    }

    showError(message) {
        const container = document.querySelector('.players-grid');
        if (container) {
            container.innerHTML = `
                <div class="error-message">
                    <i class="ri-error-warning-line"></i>
                    <p>${message}</p>
                    <button class="btn btn-secondary" onclick="findTeamManager.loadTeamPosts()">Thử lại</button>
                </div>`;
        }
    }

    initDatePicker() {
        const dateInput = document.querySelector('.date-input');
        if (dateInput) {
            // Set minimum date to today
            const today = new Date().toISOString().split('T')[0];
            dateInput.min = today;
        }
    }

    toggleMobileFilters() {
        const sidebar = document.getElementById('filter-sidebar');
        const overlay = document.getElementById('filter-overlay');

        sidebar?.classList.add('active');
        overlay?.classList.add('active');
        document.body.style.overflow = 'hidden';
    }

    closeMobileFilters() {
        const sidebar = document.getElementById('filter-sidebar');
        const overlay = document.getElementById('filter-overlay');

        sidebar?.classList.remove('active');
        overlay?.classList.remove('active');
        document.body.style.overflow = '';
    }

    // Create Post Modal Methods
    showCreatePostModal() {
        this.createModalHTML();
        document.getElementById('createPostModal').style.display = 'flex';
        document.body.style.overflow = 'hidden';
    }

    hideCreatePostModal() {
        const modal = document.getElementById('createPostModal');
        if (modal) {
            modal.style.display = 'none';
            document.body.style.overflow = '';
        }
    }

    createModalHTML() {
        // Remove existing modal
        const existingModal = document.getElementById('createPostModal');
        if (existingModal) {
            existingModal.remove();
        }

        const modalHTML = `
            <div class="modal-overlay" id="createPostModal">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2>Tạo Bài Viết Tìm Đồng Đội</h2>
                        <button class="close-modal" onclick="findTeamManager.hideCreatePostModal()">
                            <i class="ri-close-line"></i>
                        </button>
                    </div>
                    
                    <form id="createPostForm" class="modal-form">
                        <div class="form-row">
                            <div class="form-group">
                                <label for="postTitle">Tiêu đề *</label>
                                <input type="text" id="postTitle" name="title" required placeholder="Ví dụ: Tìm đồng đội chơi bóng đá">
                            </div>
                            <div class="form-group">
                                <label for="postSport">Môn thể thao *</label>
                                <select id="postSport" name="sport" required>
                                    <option value="">Chọn môn thể thao</option>
                                    <option value="Bóng Đá">Bóng Đá</option>
                                    <option value="Bóng Rổ">Bóng Rổ</option>
                                    <option value="Tennis">Tennis</option>
                                    <option value="Cầu Lông">Cầu Lông</option>
                                    <option value="Bóng Chuyền">Bóng Chuyền</option>
                                    <option value="Đa Môn">Đa Môn</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group">
                                <label for="postLocation">Địa điểm *</label>
                                <input type="text" id="postLocation" name="location" required placeholder="Ví dụ: Sân Victory Court">
                            </div>
                            <div class="form-group">
                                <label for="postBookingId">Booking ID *</label>
                                <input type="number" id="postBookingId" name="bookingId" required placeholder="ID đặt sân">
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group">
                                <label for="postPlayDate">Ngày chơi *</label>
                                <input type="date" id="postPlayDate" name="playDate" required>
                            </div>
                            <div class="form-group">
                                <label for="postTimePlay">Giờ chơi *</label>
                                <input type="time" id="postTimePlay" name="timePlay" required>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group">
                                <label for="postMaxPlayers">Tổng số người chơi *</label>
                                <input type="number" id="postMaxPlayers" name="maxPlayers" required min="2" placeholder="Ví dụ: 10">
                            </div>
                            <div class="form-group">
                                <label for="postNeededPlayers">Số người cần tìm *</label>
                                <input type="number" id="postNeededPlayers" name="neededPlayers" required min="1" placeholder="Ví dụ: 3">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="postDescription">Mô tả</label>
                            <textarea id="postDescription" name="description" rows="4" placeholder="Mô tả về trận đấu, yêu cầu trình độ, v.v..."></textarea>
                        </div>

                        <div class="form-actions">
                            <button type="button" class="btn btn-secondary" onclick="findTeamManager.hideCreatePostModal()">Hủy</button>
                            <button type="submit" class="btn btn-primary">
                                <i class="ri-add-line"></i>
                                Tạo Bài Viết
                            </button>
                        </div>
                    </form>
                </div>
            </div>`;

        document.body.insertAdjacentHTML('beforeend', modalHTML);
        this.bindCreatePostFormEvents();
    }

    bindCreatePostFormEvents() {
        const form = document.getElementById('createPostForm');
        if (!form) return;

        // Set minimum date to today
        const dateInput = document.getElementById('postPlayDate');
        if (dateInput) {
            const today = new Date().toISOString().split('T')[0];
            dateInput.min = today;
        }

        form.addEventListener('submit', (e) => {
            e.preventDefault();
            this.submitCreatePost();
        });

        // Close modal when clicking overlay
        document.getElementById('createPostModal').addEventListener('click', (e) => {
            if (e.target.classList.contains('modal-overlay')) {
                this.hideCreatePostModal();
            }
        });
    }

    async submitCreatePost() {
        const form = document.getElementById('createPostForm');
        if (!form) return;

        const formData = new FormData(form);

        // Convert to DTO format
        const postData = {
            Title: formData.get('title'),
            Location: formData.get('location'),
            Sport: formData.get('sport'),
            MaxPlayers: parseInt(formData.get('maxPlayers')),
            NeededPlayers: parseInt(formData.get('neededPlayers')),
            Description: formData.get('description'),
            TimePlay: formData.get('timePlay') + ':00', // Convert to TimeSpan format
            PlayDate: formData.get('playDate') + 'T00:00:00Z', // Convert to DateTime format
            CreatedAt: new Date().toISOString(),
            UpdatedAt: new Date().toISOString(),
            CreatedBy: 1, // Replace with actual user ID
            BookingId: parseInt(formData.get('bookingId'))
        };

        try {
            const submitBtn = form.querySelector('button[type="submit"]');
            submitBtn.disabled = true;
            submitBtn.innerHTML = '<i class="ri-loader-2-line"></i> Đang tạo...';

            const response = await fetch('/api/TeamPost/Create', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(postData)
            });

            if (response.ok) {
                this.hideCreatePostModal();
                this.showSuccessMessage('Tạo bài viết thành công!');
                this.loadTeamPosts(); // Reload posts
            } else {
                const error = await response.text();
                this.showErrorMessage('Có lỗi xảy ra: ' + error);
            }
        } catch (error) {
            console.error('Error creating post:', error);
            this.showErrorMessage('Không thể tạo bài viết. Vui lòng thử lại.');
        } finally {
            const submitBtn = form.querySelector('button[type="submit"]');
            submitBtn.disabled = false;
            submitBtn.innerHTML = '<i class="ri-add-line"></i> Tạo Bài Viết';
        }
    }

    showSuccessMessage(message) {
        this.showNotification(message, 'success');
    }

    showErrorMessage(message) {
        this.showNotification(message, 'error');
    }

    showNotification(message, type) {
        // Remove existing notifications
        const existing = document.querySelector('.notification');
        if (existing) existing.remove();

        const notification = document.createElement('div');
        notification.className = `notification ${type}`;
        notification.innerHTML = `
            <i class="ri-${type === 'success' ? 'check' : 'error-warning'}-line"></i>
            <span>${message}</span>
            <button onclick="this.parentElement.remove()">
                <i class="ri-close-line"></i>
            </button>`;

        document.body.appendChild(notification);

        // Auto remove after 5 seconds
        setTimeout(() => {
            if (notification.parentElement) {
                notification.remove();
            }
        }, 5000);
    }

    // Utility methods
    async joinTeam(postId) {
        try {
            const response = await fetch(`/api/TeamPost/Join/${postId}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                }
            });

            if (response.ok) {
                this.showSuccessMessage('Đã tham gia thành công!');
                this.loadTeamPosts(); // Reload to update needed players count
            } else {
                this.showErrorMessage('Không thể tham gia. Vui lòng thử lại.');
            }
        } catch (error) {
            console.error('Error joining team:', error);
            this.showErrorMessage('Có lỗi xảy ra khi tham gia.');
        }
    }

    toggleBookmark(postId) {
        // Implement bookmark functionality
        const bookmarkBtn = document.querySelector(`[data-post-id="${postId}"] .bookmark-btn i`);
        if (bookmarkBtn) {
            if (bookmarkBtn.classList.contains('ri-bookmark-line')) {
                bookmarkBtn.className = 'ri-bookmark-fill';
                this.showSuccessMessage('Đã lưu bài viết');
            } else {
                bookmarkBtn.className = 'ri-bookmark-line';
                this.showSuccessMessage('Đã bỏ lưu bài viết');
            }
        }
    }
}

// Initialize when DOM is loaded
document.addEventListener('DOMContentLoaded', () => {
    window.findTeamManager = new FindTeamManager();
});

// Filter accordion functionality
document.addEventListener('DOMContentLoaded', () => {
    document.querySelectorAll('.filter-header').forEach(header => {
        header.addEventListener('click', () => {
            const target = document.getElementById(header.dataset.target);
            const icon = header.querySelector('.toggle-icon');

            if (target) {
                target.classList.toggle('active');
                icon.style.transform = target.classList.contains('active') ? 'rotate(180deg)' : 'rotate(0deg)';
            }
        });
    });
});