using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace ProductInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public const string path = @"C:\Users\milan\Downloads\Produkte.json";
        
        public List<Category> Categories { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            GetDataFromJson();
            CategoryCB.ItemsSource =Categories?.Select(_=>_.CategoryName);
            CategoryCB.SelectedIndex = 0;
            PriceTxt.IsReadOnly = true;
            ProductTxt.IsReadOnly=true;
            CategoryCB.IsReadOnly=true;
           


        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedProduct= ProductsLB.SelectedItem;
            if (selectedProduct != null)
            {
                
                ProductTxt.Text = selectedProduct.ToString();
                Category? selectedCategory = Categories?.FirstOrDefault(c => c.CategoryName == CategoryCB.SelectedItem);
                PriceTxt.Text = selectedCategory.Products.FirstOrDefault(p => p.Name == selectedProduct)?.Price.ToString("C");
            }
        }

        private void GetDataFromJson() 
        {
            string json = File.ReadAllText(path);
            Categories = JsonSerializer.Deserialize<List<Category>>(json);

            //foreach (var category in Categories)
            //{
            //    Console.WriteLine($"Kategorie: {category.CategoryName}");
            //    foreach (var product in category.Products)
            //    {
            //        Console.WriteLine($"  Produkt: {product.Name}, Preis: {product.Price}");
            //    }
            //}
        }

        private void CatregoryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Category? selectedCategory = Categories?.FirstOrDefault(c => c.CategoryName ==CategoryCB.SelectedItem);
            ProductsLB.ItemsSource = selectedCategory?.Products?.Select(_=>_.Name);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Prog.Close();
        }
    }
}