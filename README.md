# How to bind the SQLite Database to the .NET MAUI Chart (SfCartesianChart)

This example demonstrates how to show the SQLite database data to Chart. Please refer KB link for more details,

KB article - [How to bind the SQLite Database to the .NET MAUI Chart (SfCartesianChart)](https://www.syncfusion.com/kb/13690/how-to-bind-the-sqlite-database-to-the-maui-chart-sfcartesianchart)

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

![Displaying the database data in a ListView](https://user-images.githubusercontent.com/53489303/197131224-9da3e363-ca14-4cf5-a359-c90ff6dc4f69.png)

_**Initial page to display the SQLite database data**_

![Inserting an data item in the database](https://user-images.githubusercontent.com/53489303/197131461-ebfada13-b9ae-49c6-a32e-3ebcb2c29d7d.png)

_**Inserting an item into the database**_

![Output after inserting a data into the database](https://user-images.githubusercontent.com/53489303/197131501-f2686a7c-a336-4237-a9b3-3253e047d66e.png)

_**After inserting data into the database**_

![Chart output based on the database data](https://user-images.githubusercontent.com/53489303/197131581-06882f9b-8f5c-4e2c-af5b-f88da28e0c2e.png)

_**Display the chart with generated data**_

Also, refer our [feature tour](https://www.syncfusion.com/maui-controls/maui-charts) page to know more features available in our charts.
