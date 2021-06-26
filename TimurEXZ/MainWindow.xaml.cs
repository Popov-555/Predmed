using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimurEXZ.Model;

namespace TimurEXZ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string SelectedSpec = "";
        private IEnumerable<Abiturent> _AbiturentList = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<AbitSpec> AbitSpecList { get; set; }
        public IEnumerable<Abiturent> AbiturentList
        {
            get
            {
                var res = _AbiturentList;
                   res = res.Where(c =>(SelectedSpec == "Все специальности" || c.Spec == SelectedSpec));
                if (SearchFilter != "")
                    res = res.Where(c => c.Name.IndexOf(SearchFilter, StringComparison.OrdinalIgnoreCase) >= 0);
                return res;
            }
            set
            {
                _AbiturentList = value;
            }
        }
      
       
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Globals.dataProvider = new LocalDataProvider();
            AbiturentList = Globals.dataProvider.GetAbiturents();
            AbitSpecList = Globals.dataProvider.GetAbitSpecs().ToList();
            AbitSpecList.Insert(0, new AbitSpec { Title = "Все специальности" });
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
      
        
        private void Invalidate()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("AbiturentList"));
        }
        private void SpecFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedSpec = (SpecFilterComboBox.SelectedItem as AbitSpec).Title;
            Invalidate();
        }
        private string SearchFilter = "";
        private void SearchFilterTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            SearchFilter = SearchFilterTextBox.Text;
            Invalidate();
        }
    }
}
