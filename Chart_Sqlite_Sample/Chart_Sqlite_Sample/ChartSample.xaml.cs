namespace Chart_Sqlite_Sample;

public partial class ChartSample : ContentPage
{
	public ChartSample()
	{
		InitializeComponent();
        (BindingContext as ViewModel).Data = App.Database.GetChartDataModel();
    }
}