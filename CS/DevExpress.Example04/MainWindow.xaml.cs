using DevExpress.Example04.Data;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DevExpress.Example04 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.DataContext = this;
        }

        protected ObservableCollection<Parent> _Parents;

        public ObservableCollection<Parent> Parents {
            get {
                if(this._Parents == null) {
                    this._Parents = new ObservableCollection<Parent>(DataHelper.GetParents(200));
                }
                return this._Parents;
            }
        }

        private void TableView_CellValueChanging(object sender, Xpf.Grid.CellValueChangedEventArgs e) {
            (sender as TableView).PostEditor();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            this.Parents.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            this.Parents.Add(DataHelper.GetParents(1).First());
        }
    }
}
