document.addEventListener('DOMContentLoaded', function () {
    // Filter toggle functionality
    const filterHeaders = document.querySelectorAll('.filter-header');

    filterHeaders.forEach(header => {
        header.addEventListener('click', function (e) {
            e.stopPropagation(); // Prevent event bubbling
            const targetId = this.getAttribute('data-target');
            const filterContent = document.getElementById(targetId);

            // Toggle active state
            this.classList.toggle('active');
            filterContent.classList.toggle('active');
        });
    });

    // Enhanced mobile filter functionality
    const mobileFilterBtn = document.getElementById('mobile-filter-btn');
    const filterSidebar = document.getElementById('filter-sidebar');
    const filterOverlay = document.getElementById('filter-overlay');
    const closeFilterBtn = document.getElementById('close-filter');
    const body = document.body;

    function openMobileFilter() {
        // Show overlay first
        filterOverlay.classList.add('active');

        // Small delay for better animation
        setTimeout(() => {
            filterSidebar.classList.add('active');
        }, 50);

        // Prevent body scroll
        body.classList.add('filter-open');

        // Store current scroll position
        const scrollY = window.scrollY;
        body.style.top = `-${scrollY}px`;

        // Focus management
        setTimeout(() => {
            const firstFocusable = filterSidebar.querySelector('button, input, [tabindex]:not([tabindex="-1"])');
            if (firstFocusable) {
                firstFocusable.focus();
            }
        }, 350);
    }

    function closeMobileFilter() {
        // Remove classes for animation
        filterSidebar.classList.remove('active');

        setTimeout(() => {
            filterOverlay.classList.remove('active');
        }, 300);

        // Restore body scroll
        body.classList.remove('filter-open');

        // Restore scroll position
        const scrollY = body.style.top;
        body.style.top = '';
        window.scrollTo(0, parseInt(scrollY || '0') * -1);

        // Return focus to filter button
        if (mobileFilterBtn) {
            mobileFilterBtn.focus();
        }
    }

    // Event listeners
    if (mobileFilterBtn) {
        mobileFilterBtn.addEventListener('click', function (e) {
            e.preventDefault();
            e.stopPropagation();
            openMobileFilter();
        });
    }

    if (closeFilterBtn) {
        closeFilterBtn.addEventListener('click', function (e) {
            e.preventDefault();
            e.stopPropagation();
            closeMobileFilter();
        });
    }

    if (filterOverlay) {
        filterOverlay.addEventListener('click', function (e) {
            // Only close if clicking the overlay itself, not its children
            if (e.target === filterOverlay) {
                closeMobileFilter();
            }
        });
    }

    // Prevent sidebar clicks from closing the filter
    if (filterSidebar) {
        filterSidebar.addEventListener('click', function (e) {
            e.stopPropagation();
        });
    }

    // Clear all filters functionality
    const clearFiltersBtn = document.querySelector('.clear-filters');
    if (clearFiltersBtn) {
        clearFiltersBtn.addEventListener('click', function (e) {
            e.stopPropagation();

            // Clear checkboxes
            const checkboxes = document.querySelectorAll('.custom-checkbox');
            checkboxes.forEach(checkbox => {
                checkbox.checked = false;
            });

            // Clear date input
            const dateInput = document.querySelector('.date-input');
            if (dateInput) {
                dateInput.value = '';
            }

            // Clear location input
            const locationInput = document.querySelector('.location-input');
            if (locationInput) {
                locationInput.value = '';
            }

            // Reset price range
            const priceRange = document.querySelector('.range-slider');
            if (priceRange) {
                priceRange.value = priceRange.min;
                updatePriceDisplay(priceRange.value);
            }

            // Clear selected time slots
            const timeSlots = document.querySelectorAll('.time-slot.selected');
            timeSlots.forEach(slot => {
                slot.classList.remove('selected');
            });

            // Clear selected facility tags
            const facilityTags = document.querySelectorAll('.facility-tag.active');
            facilityTags.forEach(tag => {
                tag.classList.remove('active');
            });

            showToast('Đã xóa tất cả bộ lọc');
        });
    }

    // Time slot selection
    const timeSlots = document.querySelectorAll('.time-slot');
    timeSlots.forEach(slot => {
        slot.addEventListener('click', function (e) {
            e.stopPropagation();
            if (!this.classList.contains('unavailable')) {
                this.classList.toggle('selected');
            }
        });
    });

    // Facility tag selection
    const facilityTags = document.querySelectorAll('.facility-tag');
    facilityTags.forEach(tag => {
        tag.addEventListener('click', function (e) {
            e.stopPropagation();
            this.classList.toggle('active');
        });
    });

    // Price range update
    const priceRange = document.querySelector('.range-slider');
    const currentPriceDisplay = document.querySelector('.current-price');

    function updatePriceDisplay(value) {
        if (currentPriceDisplay) {
            const formattedPrice = parseInt(value).toLocaleString('vi-VN');
            currentPriceDisplay.textContent = `${formattedPrice}đ/giờ`;
        }
    }

    if (priceRange) {
        priceRange.addEventListener('input', function () {
            updatePriceDisplay(this.value);
        });
    }

    // Toast notification function
    function showToast(message, duration = 3000) {
        const toast = document.createElement('div');
        toast.className = 'toast';
        toast.textContent = message;
        toast.style.cssText = `
            position: fixed;
            bottom: 20px;
            left: 50%;
            transform: translateX(-50%);
            background: var(--gray-800);
            color: white;
            padding: 12px 24px;
            border-radius: 8px;
            z-index: 10001;
            font-size: 14px;
            opacity: 0;
            transition: opacity 0.3s ease;
        `;

        document.body.appendChild(toast);

        setTimeout(() => {
            toast.style.opacity = '1';
        }, 100);

        setTimeout(() => {
            toast.style.opacity = '0';
            setTimeout(() => {
                if (document.body.contains(toast)) {
                    document.body.removeChild(toast);
                }
            }, 300);
        }, duration);
    }

    // Initialize filter states
    function initializeFilters() {
        const sportFilter = document.getElementById('sport-filter');
        const sportHeader = document.querySelector('[data-target="sport-filter"]');
        if (sportFilter && sportHeader) {
            sportFilter.classList.add('active');
            sportHeader.classList.add('active');
        }
    }

    initializeFilters();

    // Handle window resize
    let resizeTimer;
    window.addEventListener('resize', function () {
        clearTimeout(resizeTimer);
        resizeTimer = setTimeout(function () {
            if (window.innerWidth > 768 && filterSidebar.classList.contains('active')) {
                closeMobileFilter();
            }
        }, 100);
    });

    // Handle escape key
    document.addEventListener('keydown', function (e) {
        if (e.key === 'Escape' && filterSidebar.classList.contains('active')) {
            closeMobileFilter();
        }
    });
});

