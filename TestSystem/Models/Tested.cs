using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestSystem.Models
{

    public class Tested
    {
        public string Name { get; set; }
        public List<Category> AvailableCategories { get; set; } // категории, где IsActive == true
        public int TotalPoints
        {
            get; private set
    ;
        }


        private List<Category> completedCategories = new(); // для истории результатов

        public Tested(string name, List<Category> allCategories)
        {
            Name = name;
            AvailableCategories = allCategories.Where(c => c.IsActive).ToList();
        }

        public int StartCategory(string categoryName)
        {
            var category = AvailableCategories.FirstOrDefault(c => c.Name == categoryName);

            if
          (category ==null) throw new Exception("Категория не доступна");
            if (category.Questions.Count == 0) throw new Exception("В категории нет вопросов");

            category.Start();
            // Здесь логика опроса вопросов через консоль (или вызывается внешний метод)
            // После завершения:
            int earned = category.End();
            TotalPoints += earned;
            completedCategories.Add(category);
            return earned;
        }

        public void GetResults()
        {
            if (completedCategories.Count == 0)
            {
                Console.WriteLine("Вы ещё не прошли ни одного теста.");
                return;
            }
            // Вывод результатов по каждой пройденной категории
        }

        public void ExportResultsToFile(string filename)
        {
            /* сериализа
           ц
           ия рез
           ультатов */
        }
    }
}
