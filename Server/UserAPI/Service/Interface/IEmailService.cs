namespace UserAPI.Service.Interface
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string recipientEmail, string subject, string messageBody, string actionButtonUrl = null, string actionButtonText = null);
    }
}
