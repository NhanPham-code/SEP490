public class BookingScheduleViewModel
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string StadiumName { get; set; }
    public List<BookingScheduleDetailViewModel> BookingDetails { get; set; } = new List<BookingScheduleDetailViewModel>();
}
