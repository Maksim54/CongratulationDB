using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace CongratulationDB
{
    public class DataBaseFunction
    {
        readonly SQLiteAsyncConnection _database;

        public DataBaseFunction(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Table.ContactTable>().Wait();
            _database.CreateTableAsync<Table.CongratulationsTable>().Wait();
        }

        public Task<List<Table.ContactTable>> GetAsyncContact()
        {
            return _database.Table<Table.ContactTable>().ToListAsync();
        }

        public Task<List<Table.CongratulationsTable>> GetAsyncMessage()
        {
            return _database.Table<Table.CongratulationsTable>().ToListAsync();
        }

        public Task<int> SaveAsyncContact(Table.ContactTable contact)
        {
            return _database.InsertAsync(contact);
        }

        public Task<int> SaveAsyncMessage(Table.CongratulationsTable message)
        {
            return _database.InsertAsync(message);
        }

        public Task<int> DeleteAsyncContact(Table.ContactTable contact)
        {
            return _database.DeleteAsync(contact);
        }

        public Task<int> DeleteAsyncMessage(Table.CongratulationsTable message)
        {
            return _database.DeleteAsync(message);
        }
    }
}
