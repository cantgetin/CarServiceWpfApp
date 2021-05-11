using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewChanger.Objects
{
    [Serializable]
    public class Client
    {
        public int Id { get; set; } // Идентификатор
        public string Name { get; set; } // Имя 
        public string Surname { get; set; } // Фамилия
        public string Middlename { get; set; } // Отчество
        public string PhoneNumber { get; set; } // Номер телефона
        public DateTime DateOfBirth { get; set; } // Дата рождения
        public int YearOfBirth { get; set; } // Год рождения
        public int Age { get; set; } // Возраст
        public string Address { get; set; } // Прописка
        public Dictionary<DateTime, Car> Appeals { get; set; } // Обращения на станцию
        public string ImagePath { get; set; } // путь к изображению
        public void CalculateClientAge()
        {
            Age = DateTime.Now.Year - DateOfBirth.Year;
            YearOfBirth = DateOfBirth.Year;
        }

    }
}
