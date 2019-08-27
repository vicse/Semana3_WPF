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
using System.Data;

namespace Semana3
{
    /// <summary>
    /// Lógica de interacción para Ejemplo3Caso1.xaml
    /// </summary>
    public partial class Ejemplo3Caso1 : Window
    {
        public Ejemplo3Caso1()
        {
            InitializeComponent();
        }

        ClsDatos cn = new ClsDatos();

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Load(cn.ListaClientes());
            dgClientes.ItemsSource = dt.DefaultView;    
        }
    }
}
