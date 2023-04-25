using VG_TransportAPI.Models;

namespace VG_TransportAPI.Interfaces
{
    public interface IEMailServices
    {

        Task SendEmailAsync(Mailrequest mailRequest);
    }
}
