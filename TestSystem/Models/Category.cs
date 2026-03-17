using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystem.Models
{
    public class Category
    {
        public string Name { get; set; }
        public int TotalPoints { get; set; }                 // Сумма баллов за все вопросы (можно вычислять)
        public List<Question> Questions { get; set; } = new();
        public bool IsFinished { get; set; }                  // Завершён ли текущий сеанс тестирования
        public bool IsActive { get; set; }                     // Доступна ли категория для тестируемых

        private int currentQuestionIndex = -1;                 // Для навигации во время теста

        public void ShowInfo() { /* вывод информации о категории */ }

        public void Start() { /* начало тестирования: сброс IsFinished, сброс ответов */ }

        public Question? NextQuestion()
        {
            if (currentQuestionIndex < Questions.Count - 1)
                return Questions[++currentQuestionIndex];
            return null;
        }

        public Question? PreviousQuestion()
        {
            if (currentQuestionIndex > 0)
                return Questions[--currentQuestionIndex];
            return null;
        }

        public int End()
        {
            IsFinished = true;
            return Questions.Sum(q => q.CountPoints());
        }

        public void AddQuestion(Question q) => Questions.Add(q);
        public bool RemoveQuestion(int index) { /* проверка границ и удаление */ }

        public void LoadFromFile(string filename) { /* десериализация из JSON */ }
        public void SaveToFile(string filename) { /* сериализация в JSON */ }
    }
}
