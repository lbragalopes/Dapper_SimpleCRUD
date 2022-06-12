using Dapper;
using Dapper.Contrib.Extensions;
using Dapper_SimpleCRUD.Models;
using Dapper_SimpleCRUD.Repository.Interface;
using System.Data;
using System.Data.SqlClient;

namespace Dapper_SimpleCRUD.Repository
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly IDbConnection dbConnection;

        public CustomerRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        //utilizando a biblioteca Dapper.Contrib.Extensions;

        public async Task<Customer> GetByIdAsync (int id)
        {
            //var sql = "SELECT * FROM Customers WHERE CustomerId = @Id";
           //var result = await dbConnection.QuerySingleOrDefaultAsync<Customer>(sql, new {Id = id});

            var result = await dbConnection.GetAsync<Customer>(id);
            return result;
        }

        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            //var sql = "SELECT * FROM Customers";
           //var result = await dbConnection.QueryAsync<Customer>(sql);

            var result = await dbConnection.GetAllAsync<Customer>();
            return result.ToList();
        }

        public async Task<Customer> AddAsync(Customer entity)
        {
            entity.CreationDate = DateTime.Now;

            // var sql = "INSERT INTO Customers (Name, Phone, CreationDate) VALUES (@name, @phone, @creationDate);" +
            // "SELECT CAST(SCOPE_IDENTITY() as int)"; // retorna o id que add. 

            // entity.CostumerId = await dbConnection.QuerySingleAsync<int>(sql, entity);

            entity.CostumerId = await dbConnection.InsertAsync(entity);
            return entity;

        }

        public async Task AddListAsync(List<Customer> entity)
        {
            //forEach para atualizar data de criação
            var data = DateTime.Now;
            entity.ForEach(x => x.CreationDate = data);
           
            await dbConnection.InsertAsync(entity);
           
        }


        public async Task<bool> DeleteAsync(int id)
        //public async Task<int> DeleteAsync(int id)
        {
           // var sql = "DELETE FROM Customes WHERE CustomerId = @id";
           //var result = await dbConnection.ExecuteAsync(sql, new {id = id});

            var result = await dbConnection.DeleteAsync(new Customer { CostumerId = id });
            return result;

        }

        public async Task<bool> UpdateAsync(Customer entity)
        //public async Task<int> UpdateAsync(Customer entity)
        {
            //var sql = "UPDATE Customers SET Name = @name, Phone = @phone WHERE CustomerId = @CustomerId";
            // var result = await dbConnection.ExecuteAsync(sql, entity);

            var result = await dbConnection.UpdateAsync(entity);
            return result;
        }

       
    }
}
