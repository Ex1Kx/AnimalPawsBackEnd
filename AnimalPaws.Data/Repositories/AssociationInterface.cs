using AnimalPaws.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalPaws.Data.Repositories
{
    public interface AssociationInterface
    {
        Task<IEnumerable<Associations>> GetAssociations();
        Task<bool> updloadAssociation(Associations associations);
        Task<bool> updateAssociation(Associations associations);
        Task<bool> deleteAssociation(Associations associations);
    }

}
