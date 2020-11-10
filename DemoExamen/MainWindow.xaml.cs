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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoExamen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using(ModelDB db=new ModelDB())
            {
                StackPanel rootPanel = new StackPanel();
                rootPanel.Orientation = Orientation.Vertical;
                StackPanel st1 = new StackPanel();
                st1.Orientation = Orientation.Horizontal;
                StackPanel st2 = new StackPanel();
                st2.Orientation = Orientation.Horizontal;
                StackPanel st3 = new StackPanel();
                st3.Orientation = Orientation.Horizontal;
                var query = from p in db.Product
                            select p;
                int k = 1;//номер stackpanel
                int n = 1;
                foreach (var i in query)
                {
                    if (n <= 10)
                    {
                        UserControlTovar tovar = new UserControlTovar();
                        Image myImage3 = new Image();
                        BitmapImage bi3 = new BitmapImage();
                        bi3.BeginInit();
                        bi3.UriSource = new Uri(i.MainImagePath, UriKind.Relative);
                        bi3.EndInit();
                        myImage3.Stretch = Stretch.Fill;
                        tovar.Image.Source = bi3;
                        tovar.Name.Content=i.Title;
                        tovar.Cost.Content = i.Cost.ToString()+" рублей";
                        if (i.IsActive == 1)
                        {
                            tovar.Background = Brushes.White;
                        } 
                        else
                        {
                            tovar.Background = Brushes.Gray;
                        }
                        n++;
                        switch(k)
                        {
                            case 1: st1.Children.Add(tovar);break;
                            case 2: st2.Children.Add(tovar); break;
                            case 3: st3.Children.Add(tovar); break;
                        }
                    }
                    else
                    {
                        switch(k)
                        {
                            case 1: rootPanel.Children.Add(st1); break;
                            case 2: rootPanel.Children.Add(st2); break;
                            case 3: rootPanel.Children.Add(st3); break;
                        }
                        n = 1;
                        k++;
                    }
                }
                parent.Children.Add(rootPanel);
            }

        }
    }
}
