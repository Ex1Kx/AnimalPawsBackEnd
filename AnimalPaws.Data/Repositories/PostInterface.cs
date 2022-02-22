using AnimalPaws.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPaws.Data.Repositories
{
    public interface PostInterface
    {
        Task<IEnumerable<Posts>> GetPosts();
        Task<bool> uploadPost(Posts posts);
        Task<bool> updatePost(Posts posts);
        Task<bool> deletePost(Posts posts);
    }
}
