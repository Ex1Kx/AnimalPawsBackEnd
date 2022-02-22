using AnimalPaws.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
namespace AnimalPaws.Data.Repositories
{
    public class PostsRepository : PostInterface
    {
        private MySqlConfiguration _connectionString;
        public PostsRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Posts>> GetPosts()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT idpost, post_title, post_description, url_img, post_category
                        FROM posts";
            return await db.QueryAsync<Posts>(sql, new { });
        }
        public async Task<bool> uploadPost(Posts posts)
        {
            var db = dbConnection();

            var sql = @"
                         INSERT INTO posts (post_title, post_description, url_img)
                         VALUES (@post_title, @post_description, @url_img)";
            var result = await db.ExecuteAsync(sql, new { posts.post_title, posts.post_description, posts.url_img });

            return result > 0;
        }

        public async Task<bool> updatePost(Posts posts)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE posts
                        SET post_title=@post_title, post_description=@post_description, url_img=@url_img
                        WHERE idpost = @idpost";
            var result = await db.ExecuteAsync(sql, new { posts.idpost, posts.post_title, posts.post_description, posts.url_img });
            return result > 0;
        }

        public async Task<bool> deletePost(Posts posts)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE
                        FROM posts
                        WHERE idpost = @idpost";
            var result = await db.ExecuteAsync(sql, new { idpost = posts.idpost });
            return result > 0;
        }
    }
}
