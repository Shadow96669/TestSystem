using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystem.Models
{
    public class Question
    {
        public string Content { get; set; }                 // Текст вопроса
        public List<string> Options { get; set; }           // Варианты ответов (для выбора)
        public int CorrectOptionIndex { get; set; }         // Индекс правильного варианта
        public bool IsResolved { get; set; }                // Отвечен ли вопрос пользователем
        public int Points { get; set; }                      // Стоимость вопроса

        public int CountPoints()
        {
            return IsResolved ? Points : 0;
        }

        public void Edit() { /* редактирование полей */ }
    }
}
