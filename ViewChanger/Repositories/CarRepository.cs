using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using ViewChanger.Objects;

namespace ViewChanger.Repositories
{
    public class CarRepository
    {
        protected static ObservableCollection<Car> _parts;
        protected string _projectPath = new DirectoryInfo(".").Parent.Parent.FullName;
        private static CarRepository _instance;
        private CarRepository()
        {
            _parts = new ObservableCollection<Car>
        {
            new Car { Id = 0, Manufacturer = "Mercedes-Benz", Model = "CLA-Класс AMG", OwnerId=0, Year=2011,ImagePath = $"{_projectPath}/Images/Car1.jpeg", ArrivalDate = new DateTime(2020,05,30,09,30,00), DepartureDate = new DateTime(2020,04,30,09,30,00), Fault="Неисправность двигателя", ServiceID=0, ServiceTitle="Диагностика двигателя", EmployeeID=0},
            new Car { Id = 1, Manufacturer = "Mercedes-Benz", Model = "E-Класс", OwnerId=1, Year=2015,ImagePath = $"{_projectPath}/Images/Car2.jpeg", ArrivalDate = new DateTime(1998,04,30,09,30,00), DepartureDate = new DateTime(2018,04,30,09,30,00), Fault="Неисправность ходовой", ServiceID=5, ServiceTitle="Диагностика двигателя", EmployeeID=1},
            new Car { Id = 2, Manufacturer = "Lexus", Model = "LX", OwnerId=2, Year=2016,ImagePath = $"{_projectPath}/Images/Car3.jpeg", ArrivalDate = new DateTime(1998,04,30,09,30,00), DepartureDate = new DateTime(2018,04,30,09,30,00), Fault="Не работает топливный насос", ServiceID=2, ServiceTitle="Диагностика двигателя", EmployeeID=2},
            new Car { Id = 3, Manufacturer = "Lexus", Model = "RX", OwnerId=3, Year=2012,ImagePath = $"{_projectPath}/Images/Car4.jpeg", ArrivalDate = new DateTime(1998,04,30,09,30,00), DepartureDate = new DateTime(2018,04,30,09,30,00), Fault="Неисправность коробки передач", ServiceID=3, ServiceTitle="Диагностика двигателя", EmployeeID=3},

        };
        }

        public static void CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new CarRepository();
                //Deserialize();
            }
        }
        public static ObservableCollection<Car> GetRepository()
        {
            return _parts;
        }

        public static Car GetElementByIndex(int index)
        {
            foreach (var item in _parts)
            {
                if (item.Id == index) return item;
            }
            return null;
        }

        public static void DeleteElementByIndex(int index)
        {
            int toDel = 10000;
            foreach (var item in _parts)
            {
                if (item.Id == index) toDel = _parts.IndexOf(item);
            }
            _parts.RemoveAt(toDel);
        }

        public static void ChangeElement(int index, Car changed)
        {
            // можно было использоваеть changed.Id вместо index но мне уже лень переписывать
            _parts[index] = changed;
        }

        public static void AddElement(Car newPart)
        {
            int maxId = 0;
            foreach (var item in _parts)
            {
                if (item.Id > maxId) maxId = item.Id;
            }
            newPart.Id = maxId + 1;
            _parts.Add(newPart);
        }

        public static void Serialize()
        {
            //File.WriteAllText("AutoPartsXMLStorage.xml", "");
            //XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<Car>));
            //using (FileStream fs = new FileStream("AutoPartsXMLStorage.xml", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, _parts);
            //}
        }

        private static void Deserialize()
        {
            //XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<Car>));
            //using (FileStream fs = new FileStream("AutoPartsXMLStorage.xml", FileMode.OpenOrCreate))
            //{
            //    _parts = (ObservableCollection<Car>)formatter.Deserialize(fs);
            //}
        }
    }
}
