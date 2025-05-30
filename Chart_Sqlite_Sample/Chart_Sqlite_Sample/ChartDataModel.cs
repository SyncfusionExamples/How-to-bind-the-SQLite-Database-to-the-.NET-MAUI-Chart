using SQLite;

namespace Chart_Sqlite_Sample
{
    public class ChartDataModel
    {
        [PrimaryKey]
        public string XValue { get; set; }
        public double YValue { get; set; }
    }
}
