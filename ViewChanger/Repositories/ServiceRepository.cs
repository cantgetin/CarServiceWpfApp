using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewChanger.Objects;

namespace ViewChanger.Repositories
{
    public class ServiceRepository
    {
        protected static ObservableCollection<Service> _services;
        protected string _projectPath = new DirectoryInfo(".").Parent.Parent.FullName;
        private static ServiceRepository _instance;
        private ServiceRepository()
        {
            _services = new ObservableCollection<Service>
        {
            new Service { Id = 0, Title="Диагностика двигателя", Price=2900, HourDuration=5},
            new Service { Id = 1, Title="Замена топливной системы", Price=7900, HourDuration=4},
            new Service { Id = 2, Title="Замена топливного насоса", Price=1999, HourDuration=1},
            new Service { Id = 3, Title="Замена коробки передач", Price=5000, HourDuration=2},
            new Service { Id = 4, Title="Замена резины для 1 колеса", Price=500, HourDuration=1},
            new Service { Id = 5, Title="Диагностика подвески", Price=1000, HourDuration=3},
            new Service { Id = 6, Title="Замена ремня генератора", Price=600, HourDuration=0.5},
            new Service { Id = 7, Title="Замена рычагов подвески", Price=700, HourDuration=1},
            new Service { Id = 8, Title="Замена тормозных колодок и дисков", Price=2400, HourDuration=2},
            new Service { Id = 9, Title="Заправка автокондиционера", Price=500, HourDuration=0.5},
            new Service { Id = 10, Title="Замена ручника", Price=1500, HourDuration=2},
            new Service { Id = 11, Title="Замена ручки коробки передач", Price=500, HourDuration=1},
            new Service { Id = 12, Title="Заменя руля", Price=1500, HourDuration=1},
            new Service { Id = 13, Title="Диагностика и замена свеч зажигание", Price=700, HourDuration=1},
            new Service { Id = 14, Title="Ремонт неисправностей приборной панели", Price=1500, HourDuration=2},
            new Service { Id = 15, Title="Заменя одной фары", Price=250, HourDuration=0.5},
            new Service { Id = 16, Title="Подкачка 4 колес", Price=500, HourDuration=0.5}

        };

        }

        public static void CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new ServiceRepository();
                //Deserialize();
            }
        }
        public static ObservableCollection<Service> GetAutoParts()
        {
            return _services;
        }

        public static Service GetAutoPart(int index)
        {
            return _services[index];
        }

        public static Service GetClientById(int id)
        {
            foreach (var item in _services)
            {
                if (item.Id == id) return item;
            }
            return null;
        }

        public static void DeleteElement(int index)
        {
            int toDel = 10000;
            foreach (var item in _services)
            {
                if (item.Id == index) toDel = _services.IndexOf(item);
            }
            _services.RemoveAt(toDel);
        }

        public static void ChangeElement(int index, Service changed)
        {
            // можно было использоваеть changed.Id вместо index но мне уже лень переписывать
            _services[index] = changed;
        }

        public static void AddPart(Service newPart)
        {
            int maxId = 0;
            foreach (var item in _services)
            {
                if (item.Id > maxId) maxId = item.Id;
            }
            newPart.Id = maxId+1;
            _services.Add(newPart);
        }

        public static void Serialize()
        {
            /*File.WriteAllText("AutoPartsXMLStorage.xml", "");
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<Car>));
            using (FileStream fs = new FileStream("AutoPartsXMLStorage.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, _parts);
            }*/
        }

        private static void Deserialize()
        {
            /*XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<Car>));
            using (FileStream fs = new FileStream("AutoPartsXMLStorage.xml", FileMode.OpenOrCreate))
            {
                _parts = (ObservableCollection<Car>)formatter.Deserialize(fs);
            }*/
        }
    }
}
