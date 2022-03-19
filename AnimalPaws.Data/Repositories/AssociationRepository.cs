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
    public class AssociationRepository: AssociationInterface
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

        public async Task<IEnumerable<Associations>> GetAssociations()
        {
            var db = DbConnection();
            var sql = @"
                        SELECT id_association, name_association, add_association, desc_association, phone_association, sponsor_association, schedule_association
                        FROM associations";
            return await db.QueryAsync<Associations>(sql, new { });

        }
        public async Task<bool> updloadAssociation(Associations associations)
        {
            var db = DbConnection();

            var sql = @"
                         INSERT INTO associations (name_association, add_association, desc_association, phone_association, sponsor_association, schedule_association)
                         VALUES (@name_association, @add_association, @desc_association, @phone_association, @sponsor_association, @schedule_association)";
            var result = await db.ExecuteAsync(sql, new {associations.name_association, associations.add_association, associations.desc_association, associations.phone_association, associations.sponsor_association, associations.schedule_association});

            return result > 0;

        }

        public async Task<bool> updateAssociation(Associations associations)
        {
            var db = DbConnection();

            var sql = @"
                        UPDATE associations
                        SET name_association=@name_association, add_association=@add_association, desc_association=@desc_association,phone_association=@phone_association, sponsor_association=@sponsor_association, schedule_association=@schedule_association
                        WHERE  id_association= @id_association";
            var result = await db.ExecuteAsync(sql, new {associations.name_association, associations.add_association, associations.desc_association, associations.phone_association, associations.sponsor_association, associations.schedule_association});
            return result > 0;
        }

        public async Task<bool> deleteAssociation(Associations associations)
        {
            var db = DbConnection();
            var sql = @"
                        DELETE
                        FROM associations
                        WHERE id_association= @id_association";
            var result = await db.ExecuteAsync(sql, new {id_association = associations.id_association});
            return result > 0;
        }
    }
}
