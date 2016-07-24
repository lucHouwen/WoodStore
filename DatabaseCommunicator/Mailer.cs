using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace DatabaseCommunicator
{
    public static class Mailer
    {
        #region Public Methods

        public static async Task MailAsync(string toAddress, string subject, string content, string attachment, string hotelname)
        {
            await Task.Run((() => Mail(toAddress, subject, content, attachment, hotelname)));
        }
        public static void Mail(string toAddress, string subject, string content, string attachment, string hotelname)
        {
            using (SmtpClient smtp = new SmtpClient("smtp.live.com", 587))
            {
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("syntrasyntra@outlook.com", "syntraHotel2016");
                try
                {
                    using (MailMessage message = new MailMessage(new MailAddress("syntrasyntra@outlook.com"), new MailAddress(toAddress)))
                    {
                        message.IsBodyHtml = true;
                        message.Subject = subject;
                        message.Body = content;
                        if (attachment != string.Empty && attachment != null)
                        {
                            ContentType ct = new ContentType(".pdf");
                            Attachment a = new Attachment(attachment, ct);
                        }
                        smtp.Send(message);
                    }
                }
                catch(Exception e) { int i = 0;  }
            }
        }

        #endregion Public Methods
    }
}