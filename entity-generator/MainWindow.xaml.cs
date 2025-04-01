using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace entity_generator
{
    public partial class MainWindow : Window
    {
        public string selectedProjectPath;

        public MainWindow()
        {
            InitializeComponent();
            LoadProjectFolders(); // Load folders from the current directory
        }

        // Method to load project folders from the root directory where the application is running
        private void LoadProjectFolders()
        {
            try
            {
                // Get the current working directory where the application is running
                string rootPath = Directory.GetCurrentDirectory();

                // Get all directories (folders) within this root directory
                var directories = Directory.GetDirectories(rootPath);

                // Clear any existing items in the ComboBox before adding new ones
                ProjectSelector.Items.Clear();

                foreach (var directory in directories)
                {
                    // Create a new ComboBoxItem for each directory
                    var comboBoxItem = new ComboBoxItem
                    {
                        Content = Path.GetFileName(directory), // Folder name as content
                        Tag = directory // Full path as Tag
                    };

                    // Add the ComboBoxItem to the ComboBox
                    ProjectSelector.Items.Add(comboBoxItem);
                }

                // Optionally, select the first folder by default
                if (ProjectSelector.Items.Count > 0)
                {
                    ProjectSelector.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                // Handle errors (like missing directories, permissions, etc.)
                MessageBox.Show($"An error occurred while loading project folders: {ex.Message}");
            }
        }

        // Event handler when the selection in ComboBox changes
        private void ProjectSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Ensure a valid item is selected and that Tag is not null
            if (ProjectSelector.SelectedItem is ComboBoxItem selectedItem)
            {
                // Check if the Tag is not null
                if (selectedItem.Tag != null)
                {
                    // Get the selected directory from the Tag property
                    selectedProjectPath = selectedItem.Tag.ToString();

                    // Load templates when a folder is selected
                    if (!string.IsNullOrEmpty(selectedProjectPath))
                    {
                        LoadTemplates();
                    }
                }
                else
                {
                    MessageBox.Show("The selected item does not have a valid directory path.");
                }
            }
            else
            {
                MessageBox.Show("Please select a valid project folder.");
            }
        }

        // Method to load templates (or perform other actions) based on the selected folder
        // Method to load templates (or perform other actions) based on the selected folder
        private void LoadTemplates()
        {
            // Clear any existing tabs
            Tabs.Items.Clear();

            try
            {
                // List all .csv files in the selected folder (e.g., template files)
                string[] files = Directory.GetFiles(selectedProjectPath, "*.csv");

                // Create a Tab for each CSV file
                foreach (var file in files)
                {
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                    var tabItem = new TabItem { Header = fileNameWithoutExtension };

                    // Create a DataGrid for the CSV file
                    var dataGrid = new DataGrid { AutoGenerateColumns = true, CanUserAddRows = false };

                    // Read the CSV file and load the data into the DataGrid
                    var csvData = LoadCsvData(file);

                    // Bind the DataGrid to the csvData
                    dataGrid.ItemsSource = csvData;

                    // Set the DataGrid as the content of the TabItem
                    tabItem.Content = dataGrid;

                    // Add the TabItem to the TabControl
                    Tabs.Items.Add(tabItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading files in the selected folder: {ex.Message}");
            }
        }


        // Method to read CSV data and return a list of CsvRow objects
        private List<CsvRow> LoadCsvData(string filePath)
        {
            var csvData = new List<CsvRow>();

            try
            {
                var lines = File.ReadAllLines(filePath);

                // Ensure there's at least the header row
                if (lines.Length > 1)
                {
                    // Loop through all lines (skip the header row)
                    for (int i = 1; i < lines.Length; i++)
                    {
                        var values = lines[i].Split(',');

                        // Check if there are exactly 3 columns (Token, Description, Default_Value)
                        if (values.Length == 3)
                        {
                            var row = new CsvRow
                            {
                                Token = values[0],
                                Description = values[1],
                                DefaultValue = values[2]
                            };

                            csvData.Add(row);
                        }
                        else
                        {
                            // Optionally log invalid rows if needed
                            // MessageBox.Show($"Skipping row {i + 1} due to invalid column count.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any file read errors
                // MessageBox.Show($"Error reading CSV file: {ex.Message}");
            }

            return csvData;
        }

        // Button Click Events (Reset, Generate) - Implement as needed
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Reset Button Clicked!");
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Generate Button Clicked!");
        }

        private void TemplateSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
