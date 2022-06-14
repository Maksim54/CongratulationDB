using SQLite;

namespace CongratulationDB.Table
{
    public class CongratulationsTable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string CongratulationText { get; set; }
    }
}
