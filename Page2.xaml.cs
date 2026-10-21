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

namespace prakt5
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 :Page
    {
        private ObservableCollection<Recipe> _reciplist;
        private Recipe _recipe;
        private Recipe? _originalr;
        private Ingredient? _selecteingredient;

        public Ingredient? SelecteIngredient
        {
            get => _selecteingredient;
            set => _selecteingredient = value;
        }
        public Page2(ObservableCollection<Recipe> recipeList, Recipe? recipe = null)
        {
            _originalr = recipe;
            _reciplist = recipeList;
            _recipe = recipe == null ? new Recipe() : new Recipe
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Category = recipe.Category,
                Portions = recipe.Portions
            };
            if (recipe != null)
            {
                foreach (var ins in recipe.Ingredients)
                {
                    _recipe.Ingredients.Add(new Ingredient
                    {
                        Name = ins.Name,
                        WeightGrams = ins.WeightGrams,
                        CaloriesPer100g = ins.CaloriesPer100g,
                    });
                }
            }
            InitializeComponent();
            DataContext = _recipe;
        }

        private void Addingridient_Click(object sender, RoutedEventArgs e)
        {
            var newin = new Ingredient();
            _recipe.Ingredients.Add(newin);
        }

        private void Deleteingridient_Click(object sender, RoutedEventArgs e)
        {
            if(_selecteingredient == null)
            { MessageBox.Show("ингридиент не выбран"); return; }
            bool confirm = MessageBox.Show("вы действительно хотите удалить запись?", "подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
            if (confirm)
            {
                _recipe.Ingredients.Remove(_selecteingredient);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(_originalr == null)
            {
                _reciplist.Add(_recipe);
                BackButton_Click(sender, e);
                return;
            }
            _originalr.Id = _recipe.Id;
            _originalr.Name = _recipe.Name;
            _originalr.Category = _recipe.Category;
            _originalr.Portions = _recipe.Portions;
            _originalr.Ingredients.Clear();
            foreach (var ins in _recipe.Ingredients)
                _originalr.Ingredients.Add(ins);
            BackButton_Click(sender, e);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
