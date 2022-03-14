using AnimalPaws.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalPaws.Data.Repositories
{
    public interface FoundationInterface
    {
        Task<IEnumerable<Foundation>> GetFoundation();
        Task<bool> uploadFoundation(Foundation foundation);
        Task<bool> updateFoundation(Foundation foundation);
        Task<bool> deleteFoundation(Foundation foundation);
    }

}
