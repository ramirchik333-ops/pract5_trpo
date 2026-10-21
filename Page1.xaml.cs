using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace prakt5
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 :Page
    {
          
        public ObservableCollection<Recipe> Recipes { get; set; } = new ObservableCollection<Recipe>();
        public Recipe SelectedRecipe { get; set; }
      

        public Page1()
        {
           
            Recipes.Add(new Recipe() { Id =1, Name = "Домашний", Category="Супы", Portions =3 });
            Recipes.Add(new Recipe() { Id = 2, Name = "Цезарь", Category = "Салаты", Portions = 3 });
            Recipes.Add(new Recipe() { Id = 3, Name = "С свининой", Category = "Пельмени", Portions = 3 });
            InitializeComponent();
            DataContext = this;
        }
        

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2(Recipes));
        }

        private void EditRecipe_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedRecipe == null)
            {
                MessageBox.Show("выберите рецепт для редактирования");
                return;
            }
            NavigationService.Navigate(new Page2(Recipes, SelectedRecipe));
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedRecipe == null)
            {
                MessageBox.Show("рецепт не выбран");
                return;
            }
            bool confirm = MessageBox.Show("вы действительно хотите удалить запись?", "подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
            if(confirm)
            {
                Recipes.Remove(SelectedRecipe);
            }
        }
    }
}
