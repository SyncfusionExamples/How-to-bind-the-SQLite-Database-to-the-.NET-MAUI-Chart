using SQLite;

namespace Chart_Sqlite_Sample
{
    public class ChartDatabase
    {
        readonly SQLiteConnection _database;

        public ChartDatabase(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<ChartDataModel>();
        }

        //Get the list of ChartDataModel items from the database
        public List<ChartDataModel> GetChartDataModel()
        {
            return _database.Table<ChartDataModel>().ToList();
        }

        //Insert an item in the database
        public int SaveChartDataModelAsync(ChartDataModel chartDataModel)
        {
            if (chartDataModel == null)
            {
                throw new Exception("Null");
            }

            return _database.Insert(chartDataModel);
        }

        //Delete an item in the database 
        public int DeleteChartDataModelAsync(ChartDataModel chartDataModel)
        {
            return _database.Delete(chartDataModel);
        }
    }
}
