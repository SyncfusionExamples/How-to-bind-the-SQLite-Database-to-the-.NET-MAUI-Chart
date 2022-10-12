using System.ComponentModel;

namespace Chart_Sqlite_Sample
{
    public class ViewModel : INotifyPropertyChanged
    {
        public List<string> HeaderData { get; set; } = new List<string>() { "XValue", "YValue" };

        private List<ChartDataModel> data = new List<ChartDataModel>();
        public List<ChartDataModel> Data
        {
            get { return data; }
            set
            {
                if (data != value)
                {
                    data = value;
                    OnPropertyChanged(nameof(Data));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
