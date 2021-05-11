using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewChanger.Objects
{
    [Serializable]
    public class Service
    {
        public int Id { get; set; } // Идентификатор
        public string Title { get; set; } // Название услуги
        public int Price { get; set; } // Цена услуги
        public double HourDuration { get; set; } // Время необходимое на выполнение услуги
    }
}
