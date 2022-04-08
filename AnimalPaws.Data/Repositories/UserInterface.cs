using AnimalPaws.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalPaws.Data.Repositories
{
    public interface UserInterface
    {
        Task<IEnumerable<Users>> GetUsers();
        Task<bool> createUser(Users users);
        Task<bool> updateUser(Users users);
        Task<bool> deleteUser(Users users);
    }

}
