using System.Net.Mail;

namespace Northwind.WebMvc.Models
{
    public class EmailHelper
    {
        public bool SendEmail(string email, string mesaj)
        {
            #region MailMessage tanımları
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("m.isakyildirim@gmaik.com");
            mailMessage.To.Add(email);
            mailMessage.Body = mesaj;
            mailMessage.Subject = "Mail Adresinizi Onaylayın";
            mailMessage.IsBodyHtml = true;
            #endregion

            #region Smtp Ayarlari
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential("cinaliveli5@gmail.com", "AliVeli4950");
            smtpClient.Port = 52109;
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            #endregion

            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
