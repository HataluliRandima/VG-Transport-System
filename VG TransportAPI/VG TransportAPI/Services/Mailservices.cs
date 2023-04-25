
 
using MailKit;
//using Emailserious.Models;
//using NETCore.MailKit.Core;


using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Linq;
using VG_TransportAPI.Interfaces;
using VG_TransportAPI.Models;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace VG_TransportAPI.Services
{
    public class Mailservices : IEMailServices
    {
        private readonly MailSettings _mailSetting;
        public Mailservices(IOptions<MailSettings> mailSetting) {

            _mailSetting = mailSetting.Value;
        }
        public async Task SendEmailAsync( Mailrequest Mailreq)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress (_mailSetting.DisplayName, _mailSetting.Mail));
            email.Sender = new  MailboxAddress(_mailSetting.DisplayName,_mailSetting.Mail);
            email.To.Add(MailboxAddress.Parse(Mailreq.ToEmail));
            email.Subject = Mailreq.Subject;

            //email.From.Add(new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Mail));
            //email.Sender = MailboxAddress.Parse(_mailSetting.Mail);
            //email.To.Add(MailboxAddress.Parse(Mailreq.ToEmail));
            //email.Subject = Mailreq.Subject;
            //email.Headers.Append(MailboxAddress.Parse(_mailSetting.Mail));

            var builder = new BodyBuilder();

            
            //if(Mailreq.Attach != null)

            //{

            //    byte[] filebytes;

            //    foreach(var file in Mailreq.Attach)
            //    {
            //        if(file.Length > 0)
            //        {
            //            using(var ms = new MemoryStream()) { 
                        
            //                file.CopyTo(ms);
            //                filebytes = ms.ToArray();
                        
            //            }

            //            builder.Attachments.Add(file.Name, filebytes, ContentType.Parse(file.ContentType));
            //        }
            //    }

            //}

            builder.HtmlBody = Mailreq.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSetting.Host, _mailSetting.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSetting.Mail,_mailSetting.Password);
         
            
            await smtp.SendAsync(email);
            smtp.Disconnect(true);


            //email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            //email.To.Add(MailboxAddress.Parse(Mailreq.To));
            //email.Subject = request.Subject;
            //email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            //using var smtp = new SmtpClient();
            //smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            //smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            //smtp.Send(email);
            //smtp.Disconnect(true);

        }

        //public Task SendEmailAsync(Mailrequest mailRequest)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
