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

using TodoApp.Shared.Models;
using TodoApp.Shared.Services.CategoryService;

namespace TodoApp.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICategoryService _categoryService;
        public MainWindow()
        {
            InitializeComponent();
            _categoryService = new CategoryService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var categories = _categoryService.GetCategories();
            gridCtaegories.ItemsSource = categories;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var all = gridCtaegories.ItemsSource.Cast<CategoryReadModel>().ToList();

            var newCate = _categoryService.Add(new CategoryDto(all.Max(e=>e.Id)+1, txtCategory.Text, false));

            

            all.Add(newCate);
            gridCtaegories.ItemsSource = all;
        }
    }
}