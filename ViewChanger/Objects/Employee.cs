using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewChanger.Objects
{
    [Serializable]
    public class Employee
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
        public int Speciality { get; set; } // Специальность
        public int EmployeeRank { get; set; } // Разряд
        public int WorkExperience { get; set; } // Стаж работы
        public string ImagePath { get; set; } // путь к изображению
        public void CalculateEmployeeAge()
        {
            Age = DateTime.Now.Year - DateOfBirth.Year;
            YearOfBirth = DateOfBirth.Year;
        }
    }
}
