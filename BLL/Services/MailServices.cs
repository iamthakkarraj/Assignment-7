using System.Net;
using System.Net.Mail;
using System.Text;

namespace BLL.Services {

    public class MailServices {

        public static int PORT = 587;
        public static string HOST = "YOUR_HOST";        
        public static string SENDER_EMAIL = "YOUR_EMAIL";
        public static string DISPLAY_NAME = "NAME";
        public static string PASSWORD = "YOUR_PASSWORD";

        public static bool SendMail(string receiverEmailId
                                    , string name
                                    , StringBuilder body
                                    , string subject) {
            try {
                MailAddress senderEmail = new MailAddress(SENDER_EMAIL, DISPLAY_NAME);
                MailAddress receiverEmail = new MailAddress(receiverEmailId, name);                
                var smtp = new SmtpClient {
                    Host = HOST,
                    Port = PORT,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, PASSWORD)
                };
                using (MailMessage mailMessage = new MailMessage(senderEmail, receiverEmail) {
                        Subject = subject,
                        Body = body.ToString()}) {
                    mailMessage.IsBodyHtml = true;
                    smtp.Send(mailMessage);
                }
                return true;
            } catch {
                return false;
            }
        }

    }

}