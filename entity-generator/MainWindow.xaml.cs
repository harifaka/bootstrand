using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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
            
        }

        // Event triggered when a template is selected
        private void TemplateSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        // Reset Button Click Event - Reset the token values
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            // Reload the tokens 
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
        }


            // Method to load templates (or perform other actions) based on the selected folder
            private void LoadTemplates()
        {
            // This is where you would load templates based on the selected folder.
            // You can use the `selectedProjectPath` to find template files inside the selected folder.
            // For now, we can show a message to indicate that templates would be loaded here.

            MessageBox.Show($"Loading templates for project at: {selectedProjectPath}");

            // Example logic to load files (you can modify this to match your template loading logic)
            try
            {
                // List all files in the selected folder (e.g., template files)
                string[] files = Directory.GetFiles(selectedProjectPath);

                // Do something with the files (e.g., display them in a DataGrid or other UI elements)
                // This is just an example of showing a list of file names
                foreach (var file in files)
                {
                    Console.WriteLine(Path.GetFileName(file)); // Just an example
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading files in the selected folder: {ex.Message}");
            }
        }

        // You can add additional event handlers for other buttons or functionality here, if needed.

        // Example Button Click Event (resetting templates or handling other actions)
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Reset Button Clicked!");
        }

        // Another Button Click Event (e.g., to generate or process templates)
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Generate Button Clicked!");
        }
    }
}
