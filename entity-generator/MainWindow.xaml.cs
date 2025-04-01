using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO;

namespace entity_generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // Define a class to represent each row of data in the CSV
    public class CsvRow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadCsvData();
        }

        // Method to load CSV data into the DataGrid
        private void LoadCsvData()
        {
            // Define the path to your CSV file (adjust if necessary)
            string filePath = "data.csv";

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read all lines of the CSV file
                var lines = File.ReadAllLines(filePath).Skip(1);  // Skip the header row
                var csvData = new List<CsvRow>();

                foreach (var line in lines)
                {
                    var columns = line.Split(',');

                    // Create a new CsvRow object and add it to the list
                    csvData.Add(new CsvRow
                    {
                        Id = int.Parse(columns[0]),
                        Name = columns[1],
                        Description = columns[2]
                    });
                }

                // Bind the list to the DataGrid
                dataGrid.ItemsSource = csvData;
            }
            else
            {
                MessageBox.Show("CSV file not found.");
            }
        }

        // Button 1 Click Event
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button 1 clicked!");
        }

        // Button 2 Click Event
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button 2 clicked!");
        }
    }
}
