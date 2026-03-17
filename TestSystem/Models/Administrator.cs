using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace TestSystem.Models
{
    public class Administrator
    {
        public string Name { get; set; }
        private List<Category> categories;   // ссылка на общий список категорий из MainMenu

        public Administrator(string name, List<Category> categories)
        {
            Name = name;
            this.categories = categories;
        }

        public bool AddCategory(string categoryName)
        {
            if (categories.Any(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase)))
            return false; // категория уже существует
            categories.Add(new Category { Name = categoryName, IsActive = false });
            return true;
        }

        public bool RemoveCategory(string categoryName)
        {
            var cat = categories.FirstOrDefault(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase));
            if (cat == null) return false;


            categories.Remove(cat);
            return true;
        }

        public bool EditCategory(string oldName, string newName)
        {
            var cat = categories.FirstOrDefault(c => c.Name.Equals(oldName, StringComparison.OrdinalIgnoreCase));
            if (cat == null) return false;
            cat.Name = newName;
            return true;
        }



        // Дополнительно: методы для управления вопросами внутри категории
    }
}