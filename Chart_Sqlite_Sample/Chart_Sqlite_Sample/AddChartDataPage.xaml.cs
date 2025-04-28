namespace Chart_Sqlite_Sample;

public partial class AddChartDataPage : ContentPage
{
	public AddChartDataPage()
	{
		InitializeComponent();
	}

    private void Insert_Clicked(object sender, EventArgs e)
    {
        // Insert items into table
        var todoItem = (ChartDataModel)BindingContext;
        App.Database.SaveChartDataModelAsync(todoItem);
        Navigation.PopAsync();
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        // Delete items into table
        var todoItem = (ChartDataModel)BindingContext;
        App.Database.DeleteChartDataModelAsync(todoItem);
        Navigation.PopAsync();
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}