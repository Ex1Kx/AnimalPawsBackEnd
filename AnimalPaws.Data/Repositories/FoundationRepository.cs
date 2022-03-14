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
    public class FoundationRepository: FoundationInterface
    {
        private MySqlConfiguration _connectionString;
        public FoundationRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection DbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Foundation>> GetFoundation()
        {
            var db = DbConnection();
            var sql = @"
                        SELECT codigo_foundation, name_fundation, address_foundation, description_foundation, phone_foundation, sponsorship_foundation, schedules_foundation
                        FROM foundation";
            return await db.QueryAsync<Foundation>(sql, new { });

        }
        public async Task<bool> uploadFoundation(Foundation foundation)
        {
            var db = DbConnection();

            var sql = @"
                         INSERT INTO foundation (codigo_foundation, name_fundation, address_foundation, description_foundation, phone_foundation, sponsorship_foundation, schedules_foundation)
                         VALUES (@codigo_foundation, @name_fundation, @address_foundation, @description_foundation, @phone_foundation, @sponsorship_foundation, @schedules_foundation)";
            var result = await db.ExecuteAsync(sql, new { foundation.name_fundation, foundation.address_foundation, foundation.description_foundation, foundation.phone_foundation, foundation.sponsorship_foundation, foundation.schedules_foundation });

            return result > 0;

        }

        public async Task<bool> updateFoundation(Foundation foundation)
        {
            var db = DbConnection();

            var sql = @"
                        UPDATE posts
                        SET name_fundation=@name_fundation, address_foundation=@address_foundation, description_foundation=@description_foundation, 
                        phone_foundation=@phone_foundation, sponsorship_foundation=@sponsorship_foundation, schedules_foundation=@schedules_foundation
                        WHERE  codigo_foundation= @codigo_foundation";
            var result = await db.ExecuteAsync(sql, new { foundation.name_fundation, foundation.address_foundation, foundation.description_foundation, foundation.phone_foundation, foundation.sponsorship_foundation, foundation.schedules_foundation });
            return result > 0;
        }

        public async Task<bool> deleteFoundation(Foundation foundation)
        {
            var db = DbConnection();
            var sql = @"
                        DELETE
                        FROM foundation
                        WHERE codigo_foundation= @codigo_foundation";
            var result = await db.ExecuteAsync(sql, new { codigo_foundation = foundation.codigo_foundation });
            return result > 0;
        }
    }
}
