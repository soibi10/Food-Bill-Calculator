using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /*public void got_focus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Trim().Equals("$ 00.00"))
            {
                tb.Text = string.Empty;
            }
            tb.GotFocus -= got_focus;
        }*/
        public void lost_focus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Trim().Equals(string.Empty))
            {
                tb.Text = "$ 00.00";
                tb.Foreground = Brushes.LightGray;
                tb.GotFocus += lost_focus;
            }
        }
        public void value_checker()
        {
            double bill_charges, tip;
            bill_charges = double.Parse(tb_foodcharges.Text);
            if(bill_charges <= 0)
            {
                MessageBox.Show("Please enter the value that i greater than 0");     
            }
            else
            {
                bill_charges = double.Parse(tb_foodcharges.Text);
            }
        }
        
        private void calculate_bill(object sender, RoutedEventArgs e)
        {
            double total = 0;
            float sale_tax = 7;
            float tip = 15;
            double tip_calulate, foodcharge, sales_calculate;

            value_checker();

            foodcharge = double.Parse(tb_foodcharges.Text);
            tip_calulate = (tip / 100) * foodcharge;
            sales_calculate = (sale_tax / 100) * foodcharge;
            total = foodcharge + tip_calulate + sales_calculate;

            tb_tip.Text = tip_calulate.ToString("$###,##0.00");
            tb_sales.Text = sales_calculate.ToString("$###,##0.00");
            tb_billtotal.Text = total.ToString("$###,##0.00");
        }
        private void clear_content(object sender, RoutedEventArgs e)
        {
            tb_foodcharges.Clear();
            tb_sales.Clear();
            tb_tip.Clear();
            tb_billtotal.Clear();
             
           
        }
    }
}
