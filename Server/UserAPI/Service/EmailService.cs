using MailKit.Net.Smtp;
using MimeKit;
using UserAPI.Service.Interface;

namespace UserAPI.Service
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _emailSender = "cakywordvietnam@gmail.com";
        private readonly string _emailPassword = "eqjm qmnx twbl gqfe";

        public async Task<bool> SendEmailAsync(string recipientEmail, string subject, string messageBody, string actionButtonUrl = null, string actionButtonText = null)
        {
            try
            {
                var htmlBody = BuildModernHtmlEmail(subject, messageBody, actionButtonUrl, actionButtonText);

                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("Sportivey", _emailSender));
                emailMessage.To.Add(new MailboxAddress("", recipientEmail));
                emailMessage.Subject = subject;

                emailMessage.Body = new TextPart("html")
                {
                    Text = htmlBody
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(_emailSender, _emailPassword);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Build a modern HTML email template with optional action button.
        /// </summary>
        private string BuildModernHtmlEmail(string subject, string messageBody, string actionButtonUrl = null, string actionButtonText = null)
        {
            // Có thể thay logo bằng link logo của bạn
            string logoUrl = "https://i.imgur.com/7vM1GcY.png"; // Example logo (replace with your own)
            string buttonSection = string.Empty;

            if (!string.IsNullOrEmpty(actionButtonUrl) && !string.IsNullOrEmpty(actionButtonText))
            {
                buttonSection = $@"
                    <tr>
                        <td align=""center"" style=""padding: 25px 0 0 0;"">
                            <a href=""{actionButtonUrl}"" style=""background:linear-gradient(90deg,#7f9cf5,#a18cd1);color:white;padding:12px 30px;border-radius:7px;text-decoration:none;font-weight:600;font-size:16px;display:inline-block;"">
                                {actionButtonText}
                            </a>
                        </td>
                    </tr>
                ";
            }

            return $@"
                <!DOCTYPE html>
                <html>
                <head>
                  <meta charset=""UTF-8"">
                  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                  <title>{subject}</title>
                </head>
                <body style=""background: #f4f7fa; margin: 0; padding: 0;"">
                  <table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0"">
                    <tr>
                      <td align=""center"" style=""padding: 40px 0;"">
                        <table width=""420"" cellpadding=""0"" cellspacing=""0"" border=""0"" style=""background: #fff; border-radius: 16px; box-shadow: 0 3px 16px #a18cd125; overflow: hidden; font-family: 'Segoe UI', Arial, sans-serif;"">
                          <tr>
                            <td align=""center"" style=""background: linear-gradient(90deg,#7f9cf5,#a18cd1);padding:24px 0 14px 0;"">
                              
                              <h2 style=""color: #fff; font-size: 26px; margin: 18px 0 0 0; font-weight: 800; letter-spacing: 1px;"">Sportivey</h2>
                            </td>
                          </tr>
                          <tr>
                            <td style=""padding: 32px 32px 18px 32px; color: #2a2254;"">
                              <h3 style=""margin-top:0;margin-bottom:12px;font-size:21px;color:#6847a4;"">{subject}</h3>
                              <div style=""font-size:16px;line-height:1.6;color:#41436e;"">{messageBody}</div>
                            </td>
                          </tr>
                          {buttonSection}
                          <tr>
                            <td style=""padding: 30px 32px 20px 32px; color: #a1a1c8; font-size: 13px;"">
                              <hr style=""border: 0; border-top: 1px solid #eee; margin-bottom: 16px;"">
                              Nếu bạn có bất kỳ thắc mắc nào, vui lòng liên hệ với chúng tôi tại <a href=""mailto:sportivey@contact.com"" style=""color:#7f9cf5;text-decoration:none;"">sportivey@contact.com</a>.<br>
                              <span style=""color: #bbb; font-size: 12px;"">&copy; {DateTime.Now.Year} Sportivey. All rights reserved.</span>
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                  </table>
                </body>
                </html>
                ";
        }
    }
}
