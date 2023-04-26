using VG_TransportAPI.Models;

namespace VG_TransportAPI.Interfaces
{
    public interface IEMailServices
    {

        Task SendEmailAsync(string ToEmail, string Subject, string Bodyt);


       // Task SendEmailAsync(Mailrequest mailRequest);
    }
}
