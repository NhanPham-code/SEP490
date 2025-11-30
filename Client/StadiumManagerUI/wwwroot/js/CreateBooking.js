// --- KHỞI TẠO BIẾN TOÀN CỤC ---
let stadiumId = null;
let selectedUserId = null;
let openTime;
let closeTime;
let date = null;
let bookings = [];
let stadiumData;
let isProcessingClick = false;
let searchTimeout;
const courtRelations = new Map();
const selectedCourts = new Map();

// --- ĐIỂM KHỞI ĐẦU LOGIC CỦA TRANG (DOCUMENT READY) ---
$(document).ready(function () {

    // 1. SETUP BAN ĐẦU
    $('#stadium-select').on('change', function () {
        stadiumId = $(this).val();
        if (stadiumId) {
            $('#booking-visual-section').show();
            clearAllData();
            forceResetToToday();
            firstLoadUI();
        } else {
            $('#booking-visual-section').hide();
        }
    });

    // 2. LOGIC CHUYỂN ĐỔI CHẾ ĐỘ KHÁCH HÀNG
    $('input[name="customerType"]').on('change', function () {
        const mode = $(this).val();

        if (mode === 'system') {
            $('#system-customer-section').show();
            $('#walkin-customer-section').hide();

            // Reset data khách vãng lai
            $('#walkin-note').val('');

            // Khôi phục ID nếu đã chọn trước đó
            if (selectedUserId) {
                $('#form-user-id').val(selectedUserId);
            } else {
                $('#form-user-id').val('');
            }
        } else {
            $('#system-customer-section').hide();
            $('#walkin-customer-section').show();

            // Reset search box
            $('#customer-search').val('');
            $('#user-search-results').hide();

            // Set ID về 0 cho khách vãng lai
            selectedUserId = null;
            $('#customer-name-display').val('');
            $('#form-user-id').val('0');
        }
    });

    // 3. LOGIC TÌM KIẾM KHÁCH HÀNG (HỆ THỐNG)
    $('#customer-search').on('keyup', function () {
        const query = $(this).val();
        clearTimeout(searchTimeout);

        if (query.length < 3) {
            $('#user-search-results').hide().empty();
            if (query.length === 0) {
                selectedUserId = null;
                $('#customer-name-display').val('Chưa chọn khách hàng');
                $('#form-user-id').val('');
            }
            return;
        }

        searchTimeout = setTimeout(() => {
            $.ajax({
                url: '/Booking/SearchUsers',
                type: 'GET',
                data: { query: query },
                success: function (users) {
                    const resultsContainer = $('#user-search-results');
                    resultsContainer.empty().show();
                    if (users && users.length > 0) {
                        users.forEach(user => {
                            const userInfo = user.email ? user.email : (user.phoneNumber || 'Không có thông tin');
                            resultsContainer.append(`<div class="user-search-item" data-user-id="${user.userId}" data-full-name="${user.fullName}"><strong>${user.fullName}</strong><span class="user-info-text">${userInfo}</span></div>`);
                        });
                    } else {
                        resultsContainer.append('<div class="p-3 text-gray-500">Không tìm thấy người dùng.</div>');
                    }
                },
                error: function () {
                    $('#user-search-results').empty().append('<div class="p-3 text-red-500">Lỗi khi tìm kiếm.</div>').show();
                }
            });
        }, 500);
    });

    $(document).on('click', '.user-search-item', function () {
        selectedUserId = $(this).data('user-id');
        $('#customer-search').val('');
        $('#customer-name-display').val($(this).data('full-name'));
        $('#form-user-id').val(selectedUserId);
        $('#user-search-results').hide().empty();
    });

    // Ẩn kết quả tìm kiếm khi click ra ngoài
    $(document).on('click', function (e) {
        if (!$(e.target).closest('.customer-info-group').length) {
            $('#user-search-results').hide();
        }
    });

    // 4. LOGIC CHO LỊCH ĐẶT TRỰC QUAN
    $(document).on("change", "#date-picker", function () {
        date = $(this).val();
        selectedCourts.clear();
        updateStats();
        updateUI();
    });

    $(document).on('click', '.grid-cell', function () {
        if (isProcessingClick) return;
        isProcessingClick = true;

        try {
            const $this = $(this);
            if ($this.hasClass('unselectable') && !$this.hasClass('selected')) return;

            $this.toggleClass('selected');
            const timeId = $this.data('time');
            const courtId = $this.data('court');
            const isSelected = $this.hasClass('selected');

            if (isSelected) {
                if (!selectedCourts.has(timeId)) selectedCourts.set(timeId, []);
                selectedCourts.get(timeId).push(courtId);
            } else {
                const courtIdsInTime = selectedCourts.get(timeId);
                if (courtIdsInTime) {
                    const index = courtIdsInTime.indexOf(courtId);
                    if (index > -1) courtIdsInTime.splice(index, 1);
                    if (courtIdsInTime.length === 0) selectedCourts.delete(timeId);
                }
            }

            const relatedCourtIds = courtRelations.get(courtId) || [];
            relatedCourtIds.forEach(relatedId => {
                const $relatedCell = $(`.grid-cell[data-court="${relatedId}"][data-time="${timeId}"]`);
                if (!$relatedCell.length || $relatedCell.hasClass('selected')) return;

                const siblingsOfRelated = courtRelations.get(relatedId) || [];
                const isAnySiblingSelected = siblingsOfRelated.some(siblingId => selectedCourts.get(timeId)?.includes(siblingId));

                if (isAnySiblingSelected) {
                    $relatedCell.addClass('unselectable booking-related-overlay');
                } else if (!$relatedCell.hasClass('cdm-pivot')) {
                    $relatedCell.removeClass('unselectable booking-related-overlay');
                }
            });

            updateBordersForCell($this);
            updateStats();
        } finally {
            isProcessingClick = false;
        }
    });

    // 5. MODAL VÀ SUBMIT
    $('#continue-button').on('click', function (e) {
        e.preventDefault();

        // Validate
        const mode = $('input[name="customerType"]:checked').val();
        if (mode === 'walkin') {
            const wNote = $('#walkin-note').val().trim();
            if (!wNote) {
                alert("Vui lòng nhập thông tin khách hàng (Tên, SĐT...) vào ô ghi chú.");
                return;
            }
        } else {
            if (!selectedUserId) {
                alert("Vui lòng chọn một khách hàng thành viên từ hệ thống.");
                return;
            }
        }

        populateAndShowConfirmationModal();
    });

    $('#confirm-booking-btn').on('click', function () {
        submitOwnerBookingForm();
    });

    $('.modal-close-btn, .modal-cancel-btn').on('click', function () {
        $('#confirmation-modal').removeClass('open');
    });

    $('#confirmation-modal').on('click', function (e) {
        if ($(e.target).is('.modal-overlay')) {
            $(this).removeClass('open');
        }
    });

    forceResetToToday();
});

// --- CÁC HÀM HELPER --- (Giữ nguyên các hàm fetch, render, updateStats như cũ)
// ... (Phần này giống hệt phiên bản trước, tôi sẽ không lặp lại để tiết kiệm không gian,
// nhưng bạn hãy đảm bảo giữ lại các hàm fetchStadiumData, fetchBookedCourts, renderSchedule..., updateStats)
async function updateUI() {
    if (!stadiumId) return;
    await fetchBookedCourts(stadiumId, date);
    renderBookings(bookings);
    disablePastTimeSlots(date);
}

async function firstLoadUI() {
    if (!stadiumId) return;
    await fetchStadiumData(stadiumId);
    if (!stadiumData) return;
    await fetchBookedCourts(stadiumId, date);
    const courtIds = stadiumData.Courts.map(court => court.Id);
    for (const courtId of courtIds) {
        await fetchCourtRelationData(courtId);
    }
    renderBookings(bookings);
    disablePastTimeSlots(date);
}

function clearAllData() {
    stadiumData = null;
    selectedCourts.clear();
    bookings = [];
    $('#scheduleGrid, #fixedColumn, #timeHeader, #sportTypeColumn').empty();
    $('.stat-item:contains("Tổng số giờ") p').text('0');
    $('.stat-item:contains("Giá tiền") p').text('0 VNĐ');
    $('#continue-button').prop('disabled', true);
}

function forceResetToToday() {
    const today = new Date();
    const yyyy = today.getFullYear();
    const mm = String(today.getMonth() + 1).padStart(2, '0');
    const dd = String(today.getDate()).padStart(2, '0');
    const currentDate = `${yyyy}-${mm}-${dd}`;
    $("#date-picker").attr("min", currentDate).val(currentDate);
    date = currentDate;
}

// --- CÁC HÀM LẤY DỮ LIỆU TỪ SERVER (FETCH/AJAX) ---

async function fetchStadiumData(id) {
    const searchTerm = `&$filter=Id eq ${id}`;
    try {
        const data = await $.ajax({ url: `/Home/Stadiums`, type: 'GET', data: { searchTerm: searchTerm } });
        if (data.value && data.value.length > 0) {
            stadiumData = data.value[0];
            $('#stadiumName').text(stadiumData.Name);
            $('#stadiumAddress').text(stadiumData.Address);
            openTime = parseHour(stadiumData.OpenTime);
            closeTime = parseHour(stadiumData.CloseTime);
            $('#stadiumHours').text(`${openTime}:00 - ${closeTime}:00`);
            $('#stadiumInfo').show();
            createScheduleTable(openTime, closeTime, stadiumData.Courts);
        } else {
            stadiumData = null;
        }
    } catch (error) {
        console.error("Lỗi tải dữ liệu sân vận động:", error);
        stadiumData = null;
    }
}

async function fetchBookedCourts(stadiumId, date) {
    const parsedStadiumId = parseInt(stadiumId, 10);
    if (isNaN(parsedStadiumId)) return;
    try {
        bookings = await $.ajax({
            url: `/Booking/GetBookedCourtsByDay`,
            method: "GET",
            data: { stadiumId: parsedStadiumId, date: date }
        });
    } catch (err) {
        console.error("Lỗi tải lịch đặt:", err);
    }
}

async function fetchCourtRelationData(courtId) {
    if (!courtId) return;
    courtRelations.set(courtId, []);
    try {
        const [parentData, childData] = await Promise.all([
            $.ajax({ url: "/Booking/GetAllCourtRelationByParentId", data: { parentId: courtId } }),
            $.ajax({ url: "/Booking/GetAllCourtRelationBychildId", data: { childId: courtId } })
        ]);
        const currentRelations = courtRelations.get(courtId);
        parentData.map(item => item.childCourtId).forEach(childId => {
            if (!currentRelations.includes(childId)) currentRelations.push(childId);
        });
        childData.map(item => item.parentCourtId).forEach(parentId => {
            if (!currentRelations.includes(parentId)) currentRelations.push(parentId);
        });
    } catch (error) {
        console.error("Lỗi tải dữ liệu quan hệ sân:", error);
    }
}


// --- CÁC HÀM DỰNG BẢNG LỊCH (RENDER) ---

function createScheduleTable(openHour, closeHour, courtsData) {
    if (!courtsData) return;
    const timeSlots = generateTimeSlots(openHour, closeHour);
    const timeLabels = generateTimeLabels(openHour, closeHour);
    const groupedCourts = {};
    courtsData.forEach(court => { (groupedCourts[court.SportType] ||= []).push(court); });

    renderScheduleHead(openHour, closeHour, timeSlots, timeLabels);
    renderScheduleBody(timeSlots, courtsData, groupedCourts);
    syncScroll();
}

function renderScheduleHead(openHour, closeHour, timeSlots, timeLabels) {
    const numSlots = timeSlots.length;
    $('#timeHeader, #scheduleGrid').css({ 'min-width': `${(numSlots + 1) * 85}px` });
    $('#timeHeader').css({ 'grid-template-columns': `repeat(${numSlots}, 80px)` });
    $('#timeHeader, #fixedColumn').empty();
    $('#fixedColumn').append(`<div class="fixed-header"></div>`);
    timeLabels.forEach((label, i) => {
        $('#timeHeader').append(`<div class="header-label-container" style="grid-column: ${i + 1}"><div class="time-label" style="padding: 0 10px;">${label}</div></div>`);
    });
}

function renderScheduleBody(timeSlots, courts, groupedCourts) {
    $('#scheduleGrid, #fixedColumn, #sportTypeColumn').empty();
    $('#fixedColumn').append(`<div class="court-header">Sân</div>`);
    $('#sportTypeColumn').append(`<div class="fixed-header">Loại</div>`);
    Object.entries(groupedCourts).forEach(([sportType, courtsInGroup]) => {
        const rowSpan = courtsInGroup.length;
        $('#sportTypeColumn').append(`<div class="sport-type" style="grid-row: span ${rowSpan}; height: ${80 * rowSpan}px;">${sportType}</div>`);
        courtsInGroup.forEach(court => {
            $('#fixedColumn').append(`<div class="court-name">${court.Name}</div>`);
            const $row = $(`<div class="court-row" data-court="${court.Id}"></div>`).css({ 'display': 'grid', 'grid-template-columns': `repeat(${timeSlots.length}, 80px)` });
            const isDisabled = !court.IsAvailable;
            timeSlots.forEach(slot => {
                const $cell = $(`<div class="grid-cell" data-time="${slot.display}" data-court="${court.Id}"></div>`);
                if (isDisabled) $cell.addClass('blocked').css({ "pointer-events": "none", "background-color": "#a9a9a9", "cursor": "not-allowed" });
                $row.append($cell);
            });
            $('#scheduleGrid').append($row);
        });
    });
}

function renderBookings(bookingsData) {
    $('.grid-cell.booked').css('background-color', '');
    $('.grid-cell').removeClass('booked booking-related-overlay cdm-pivot unselectable locked-by-booking');
    $('.star-icon').remove();

    if (!bookingsData || bookingsData.length === 0) return;

    bookingsData.forEach(booking => {
        booking.bookingDetails.forEach(detail => {
            addBookingToCell(detail.courtId, detail.startTime, detail.endTime);
            const relatedCourts = courtRelations.get(detail.courtId) || [];
            relatedCourts.forEach(relatedCourtId => {
                if (relatedCourtId !== detail.courtId) {
                    addRelatedBookingToCell(relatedCourtId, detail.startTime, detail.endTime);
                }
            });
        });
    });
}

function addBookingToCell(courtId, startTime, endTime) {
    const startHour = new Date(startTime).getHours();
    const endHour = new Date(endTime).getHours();
    const $courtRow = $(`.court-row[data-court="${courtId}"]`);
    if (!$courtRow.length) return;

    for (let h = startHour; h < endHour; h++) {
        const displayTime = `${String(h).padStart(2, '0')}:00-${String(h + 1).padStart(2, '0')}:00`;
        const $cell = $courtRow.find(`.grid-cell[data-time="${displayTime}"]`);
        if ($cell.length > 0) {
            $cell.addClass('unselectable locked-by-booking booked');
            if (!$cell.hasClass('disabled')) $cell.css('background-color', '#ff0000');
        }
    }
}

function addRelatedBookingToCell(courtId, startTime, endTime) {
    const startHour = new Date(startTime).getHours();
    const endHour = new Date(endTime).getHours();
    for (let h = startHour; h < endHour; h++) {
        const timeSlot = `${String(h).padStart(2, '0')}:00-${String(h + 1).padStart(2, '0')}:00`;
        const cell = document.querySelector(`.grid-cell[data-court="${courtId}"][data-time="${timeSlot}"]`);
        if (cell) cell.classList.add('unselectable', 'cdm-pivot', 'locked-by-booking', 'booking-related-overlay');
    }
}

function disablePastTimeSlots(selectedDateStr) {
    const selectedDate = new Date(selectedDateStr);
    const today = new Date();
    today.setHours(0, 0, 0, 0);
    selectedDate.setHours(0, 0, 0, 0);

    $(".grid-cell, .time-label").removeClass("disabled").removeAttr("style");
    $('.time-overlay').remove();

    if (selectedDate.getTime() === today.getTime()) {
        const now = new Date();
        $(".grid-cell").each(function () {
            const [startStr] = $(this).data("time").split("-");
            const [hour, minute] = startStr.split(":").map(Number);
            const slotStart = new Date();
            slotStart.setHours(hour, minute, 0, 0);
            if (now >= slotStart) {
                $(this).addClass("disabled").css({ "position": "relative" });
                if (!$(this).find(".time-overlay").length) {
                    $(this).append($("<div>").addClass("time-overlay").css({ position: "absolute", inset: 0, background: "#a9a9a9", opacity: 0.7, zIndex: 100 }));
                }
            }
        });
    }
}

// --- CÁC HÀM TÍNH TOÁN VÀ HELPER ---

function updateStats() {
    const selectedTimeSlots = getSelectedCourtsWithTimes();
    const totalHours = selectedTimeSlots.length;
    const courtsForPriceCalculation = getSelectedCourtsGrouped();
    const totalPrice = calculateTotalPrice(courtsForPriceCalculation);

    $('.stat-item:contains("Tổng số giờ") p').text(totalHours);
    $('.stat-item:contains("Giá tiền") p').text(totalPrice.toLocaleString('vi-VN') + ' VNĐ');

    if (totalHours > 0) {
        $('#continue-button').prop('disabled', false).removeClass('cursor-not-allowed opacity-50');
    } else {
        $('#continue-button').prop('disabled', true).addClass('cursor-not-allowed opacity-50');
    }
}

function calculateTotalPrice(courts) {
    let total = 0;
    if (!courts || !stadiumData) return 0;

    courts.forEach(courtGroup => {
        const pricePerHour = getPriceForCourt(courtGroup.courtId);
        if (courtGroup.times && courtGroup.times.length) {
            total += courtGroup.times.length * pricePerHour;
        }
    });
    return total;
}

function getPriceForCourt(courtId) {
    if (!stadiumData || !stadiumData.Courts) return 0;
    const court = stadiumData.Courts.find(c => c.Id === courtId);
    return court ? court.PricePerHour : 0;
}

function getSelectedCourtsWithTimes() {
    const result = [];
    selectedCourts.forEach((courtIds, timeSlot) => {
        courtIds.forEach(courtId => {
            result.push({ courtId: courtId, time: timeSlot });
        });
    });
    return result;
}

function getSelectedCourtsGrouped() {
    const result = [];
    const courtsWithTimes = new Map();

    selectedCourts.forEach((courtIds, timeSlot) => {
        courtIds.forEach(courtId => {
            if (!courtsWithTimes.has(courtId)) courtsWithTimes.set(courtId, []);
            courtsWithTimes.get(courtId).push(timeSlot);
        });
    });

    courtsWithTimes.forEach((timeSlots, courtId) => {
        timeSlots.sort();
        if (timeSlots.length === 0) return;

        let currentBlock = { courtId: courtId, times: [timeSlots[0]] };
        for (let i = 1; i < timeSlots.length; i++) {
            const prevEndTime = timeSlots[i - 1].split('-')[1];
            const currentStartTime = timeSlots[i].split('-')[0];
            if (prevEndTime === currentStartTime) {
                currentBlock.times.push(timeSlots[i]);
            } else {
                result.push(currentBlock);
                currentBlock = { courtId: courtId, times: [timeSlots[i]] };
            }
        }
        result.push(currentBlock);
    });
    return result;
}

function getCourtNameById(courtId) {
    if (!stadiumData || !stadiumData.Courts) return `Sân #${courtId}`;
    const court = stadiumData.Courts.find(c => c.Id === courtId);
    return court ? court.Name : `Sân #${courtId}`;
}

function generateTimeSlots(openHour, closeHour) {
    const slots = [];
    for (let i = openHour; i < closeHour; i++) {
        const s = formatHour(i);
        const e = formatHour(i + 1);
        slots.push({ start: s, end: e, display: `${s}-${e}` });
    }
    return slots;
}

function generateTimeLabels(openHour, closeHour) {
    const labels = [];
    for (let i = openHour; i <= closeHour; i++) {
        labels.push(formatHour(i));
    }
    return labels;
}

function formatHour(h) {
    return h.toString().padStart(2, '0') + ":00";
}

function parseHour(timeString) {
    if (!timeString) return 0;
    const match = timeString.match(/PT(\d+)H/);
    return match ? parseInt(match[1]) : 0;
}

function syncScroll() {
    const $h = $('.time-header-wrapper');
    const $b = $('.schedule-body-wrapper');
    $b.off('scroll.sync').on('scroll.sync', () => { $h.scrollLeft($b.scrollLeft()); });
    $h.off('scroll.sync').on('scroll.sync', () => { $b.scrollLeft($h.scrollLeft()); });
}

function updateBordersForCell($cell) {
    // Hiện tại không có logic, để trống
}


// --- MODAL VÀ SUBMIT FORM ---

function populateAndShowConfirmationModal() {
    const courtsForCheckout = getSelectedCourtsGrouped();
    const totalPrice = calculateTotalPrice(courtsForCheckout);
    const totalHours = getSelectedCourtsWithTimes().length;
    const courtNames = [...new Set(courtsForCheckout.map(c => getCourtNameById(c.courtId)))].join(', ');

    const mode = $('input[name="customerType"]:checked').val();
    let customerDisplay = "";
    let noteDisplay = "";

    if (mode === 'walkin') {
        customerDisplay = "Khách vãng lai";
        noteDisplay = $('#walkin-note').val();
        $('#modal-note-row').show();
        $('#modal-note-display').text(noteDisplay);
    } else {
        customerDisplay = $('#customer-name-display').val();
        $('#modal-note-row').hide();
        $('#modal-note-display').text('');
    }

    $('#modal-customer-name').text(customerDisplay);
    $('#modal-stadium-name').text(stadiumData.Name);
    $('#modal-date').text(new Date($('#date-picker').val()).toLocaleDateString('vi-VN'));
    $('#modal-courts').text(courtNames);
    $('#modal-hours').text(totalHours + ' giờ');
    $('#modal-total-price').text(totalPrice.toLocaleString('vi-VN') + ' VNĐ');

    $('#confirmation-modal').addClass('open');
}

function submitOwnerBookingForm() {
    const dateValue = $("#date-picker").val();
    const courtsForCheckout = getSelectedCourtsGrouped();
    const totalPrice = calculateTotalPrice(courtsForCheckout);
    const mode = $('input[name="customerType"]:checked').val();

    $("#form-stadium-id").val(stadiumId);
    $("#form-date").val(dateValue);
    $("#form-total-price").val(totalPrice);
    $("#form-original-price").val(totalPrice);

    // XỬ LÝ NOTE VÀ USER ID
    if (mode === 'walkin') {
        $("#form-user-id").val('0'); // Khách vãng lai
        // Lấy nội dung từ textarea và gán vào input hidden "Note"
        const walkinInfo = $('#walkin-note').val();
        $("#form-note").val("[Vãng Lai] " + walkinInfo);
    } else {
        $("#form-user-id").val(selectedUserId);
        $("#form-note").val("Đặt bởi chủ sân cho thành viên");
    }

    const detailsContainer = $('#booking-details-container');
    detailsContainer.empty();
    let detailIndex = 0;
    courtsForCheckout.forEach(courtGroup => {
        const courtId = courtGroup.courtId;
        if (courtGroup.times.length > 0) {
            const startTimeRaw = courtGroup.times[0].split('-')[0];
            const endTimeRaw = courtGroup.times[courtGroup.times.length - 1].split('-')[1];
            const startTime = `${dateValue}T${startTimeRaw}:00`;
            const endTime = `${dateValue}T${endTimeRaw}:00`;
            detailsContainer.append(`<input type="hidden" name="BookingDetails[${detailIndex}].CourtId" value="${courtId}" />`);
            detailsContainer.append(`<input type="hidden" name="BookingDetails[${detailIndex}].StartTime" value="${startTime}" />`);
            detailsContainer.append(`<input type="hidden" name="BookingDetails[${detailIndex}].EndTime" value="${endTime}" />`);
            detailIndex++;
        }
    });

    $("#ownerBookingForm").submit();
}