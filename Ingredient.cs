using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace prakt5
{
    public class Ingredient :INotifyPropertyChanged
    {
        private string name = "";
        private double weightGrams;
        private double caloriesPer100g;

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
        public double WeightGrams
        {
            get => weightGrams;
            set
            {
                if (weightGrams != value)
                {
                    weightGrams = value;
                    OnProp();
                }
            }
        }
        public double CaloriesPer100g
        {
            get => caloriesPer100g;
            set
            {
                if (caloriesPer100g != value)
                {
                    caloriesPer100g = value;
                    OnProp();
                }
            }
        }

        public double IngredientCalories
        {
            get
            {
                return (weightGrams / 100.0) * caloriesPer100g;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnProp([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
