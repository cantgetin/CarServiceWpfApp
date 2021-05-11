using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewChanger.Objects
{
    [Serializable]
    public class Car
    {
        public int Id { get; set; } // Идентификатор
        public string Manufacturer { get; set; } // Производитель 
        public string Model { get; set; } // Модель
        public int OwnerId { get; set; } // Владелец
        public string Fault { get; set; } // Неисправность
        public int ServiceID { get; set; } // ID Услуги
        public int EmployeeID { get; set; } // ID Работника
        public string ServiceTitle { get; set; } // Название услуги
        public int Year { get; set; } // Год выпуска
        //public string Title { get; set; } // название
        //public int Price { get; set; } // цена
        public DateTime ArrivalDate { get; set; } // дата прибытия в сервис
        public DateTime DepartureDate { get; set; } // дата до которой надо сделать
        //public string Compatibility { get; set; } // модели к которым подходит
        public string ImagePath { get; set; } // путь к изображению
    }
}
