using System.Threading.Tasks;

namespace BlogAspNet.Models
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
