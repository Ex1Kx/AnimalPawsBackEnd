using AnimalPaws.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPaws.Data.Repositories
{
    public class UserRepository: UserInterface
    {
        private MySqlConfiguration _connectionString;
        public AssociationRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection DbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            var db = DbConnection();
            var sql = @"
                        SELECT id, names, last_name, username, description
                        FROM users";
            return await db.QueryAsync<Users>(sql, new { });

        }
        public async Task<bool> createUser(Users users)
        {
            var db = DbConnection();

            var sql = @"
                         INSERT INTO users (names, last_name, username, description)
                         VALUES (@names, @last_name @username, @description)";
            var result = await db.ExecuteAsync(sql, new {users.names, users.last_name, users.username, users.description});

            return result > 0;

        }

        public async Task<bool> updateUser(Users users)
        {
            var db = DbConnection();

            var sql = @"
                        UPDATE users
                        SET names=@names, last_name=@last_name, username=@username,description=@description
                        WHERE  id= @id";
            var result = await db.ExecuteAsync(sql, new {users.names, users.last_name, users.username, users.description});
            return result > 0;
        }

        public async Task<bool> deleteUser(Users users)
        {
            var db = DbConnection();
            var sql = @"
                        DELETE
                        FROM users
                        WHERE id= @id";
            var result = await db.ExecuteAsync(sql, new {id = users.id});
            return result > 0;
        }
    }
}
