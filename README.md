# How to bind the SQLite Database to the .NET MAUI Chart (SfCartesianChart)

This example demonstrates how to show the SQLite database data to Chart. Please refer KB link for more details,

KB article - [How to bind the SQLite Database to the .NET MAUI Chart (SfCartesianChart)]()

Let us start learning how to work with the .NET MAUI Chart using the SQLite database with the following steps:

**Step 1:** Add the  SQLite reference in your project. 

**Step 2:** Create the database access class as follows,

 ```

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

```

```

public partial class App : Application
{
    static ChartDatabase database;
    …

    public static ChartDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new ChartDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ChartDataBase.db3"));
            }
            return database;
        }
    }
}

```

**Step 3:** Now, create the following Model for the Chart data.

```

public class ChartDataModel
{
        [PrimaryKey]
        public string XValue { get; set; }
        public double YValue { get; set; }
}

```

**Step 4:** Bind the retrieved data from Database to SfChart.

```

<ContentPage.BindingContext>
    <model:ViewModel/>
</ContentPage.BindingContext>

<chart:SfCartesianChart>
    <chart:SfCartesianChart.XAxes>
        <chart:CategoryAxis/>
    </chart:SfCartesianChart.XAxes>
    <chart:SfCartesianChart.YAxes>
        <chart:NumericalAxis/>
    </chart:SfCartesianChart.YAxes>
    <chart:ColumnSeries ItemsSource="{Binding Data}" XBindingPath="XValue" YBindingPath="YValue"/>
</chart:SfCartesianChart>

```

Retrieving the database data of Chart as follows.

```

public partial class ChartSample : ContentPage
{
      public ChartSample ()
      {
             InitializeComponent ();
             (BindingContext as ViewModel).Data = App.Database.GetChartDataModel();
      }
}

```

Also, refer our [feature tour](https://www.syncfusion.com/maui-controls/maui-charts) page to know more features available in our charts.
