using System.Threading.Tasks;

namespace BlogAspNet.Models
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequests();
    }
}
