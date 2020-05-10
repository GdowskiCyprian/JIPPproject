using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity.Core.Objects;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace JIPPproject
{
    /// <summary>
    /// Interaction logic for HighScoresWindow.xaml
    /// </summary>
    public partial class HighScoresWindow : Window
    {
        
        public HighScoresWindow()
        {
            InitializeComponent();
            Thread.Sleep(200);
            this.scoreColumn.SortDirection = System.ComponentModel.ListSortDirection.Descending;
            
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            JIPPproject.D4042020DataSet d4042020DataSet = ((JIPPproject.D4042020DataSet)(this.FindResource("d4042020DataSet")));
            // Load data into the table Score. You can modify this code as needed.
            JIPPproject.D4042020DataSetTableAdapters.ScoreTableAdapter d4042020DataSetScoreTableAdapter = new JIPPproject.D4042020DataSetTableAdapters.ScoreTableAdapter();
            d4042020DataSetScoreTableAdapter.Fill(d4042020DataSet.Score);
            System.Windows.Data.CollectionViewSource scoreViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("scoreViewSource")));
            scoreViewSource.View.MoveCurrentToFirst();
            
            
            



        }

        
    }
}
