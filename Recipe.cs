using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace prakt5
{
    public class Recipe :INotifyPropertyChanged
    {
        private int id;
        private string name = "";
        private string category = "";
        private int portions;
        public int Id
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    OnProp();
                }
            }
        }
        public int Portions
        {
            get => portions;
            set
            {
                if (portions != value)
                {
                    portions = value;
                    OnProp();
                }
            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnProp();
                }
            }
        }
        public string Category
        {
            get => category;
            set
            {
                if (category != value)
                {
                    category = value;
                    OnProp();
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Ingredient> Ingredients { get; set; } = new ObservableCollection<Ingredient>();
        public double RecipeCalories
        {
            get
            {
                double total = 0;
                foreach (var ing in Ingredients)
                {
                    total += ing.IngredientCalories;
                }
                return total;
            }
        }
        protected void OnProp([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
