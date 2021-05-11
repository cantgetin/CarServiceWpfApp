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
    public class EmployeeRepository
    {
        protected static ObservableCollection<Employee> _employees;
        protected string _projectPath = new DirectoryInfo(".").Parent.Parent.FullName;
        private static EmployeeRepository _instance;
        private EmployeeRepository()
        {
            _employees = new ObservableCollection<Employee>
        {
            new Employee { Id = 0, Name="Георгий",Surname="Вольный",Middlename="Николаевич", DateOfBirth=new DateTime(1973,04,30), PhoneNumber="+79035343576",ImagePath = $"{_projectPath}/Images/Employee1.jpg", Address="Пр.Прбеды 33"},
            new Employee { Id = 1, Name="Ярослав",Surname="Стоков",Middlename="Юрьевич", DateOfBirth=new DateTime(1982,02,20), PhoneNumber="+79033345576",ImagePath = $"{_projectPath}/Images/Employee2.jpg", Address="Ул.Красная 342"},
            new Employee { Id = 2, Name="Владислав",Surname="Хрущев",Middlename="Петрович", DateOfBirth=new DateTime(1979,10,30), PhoneNumber="+79823445576",ImagePath = $"{_projectPath}/Images/Employee3.jpg", Address="Ул.Тверская 14"},
            new Employee { Id = 3, Name="Радиф",Surname="Игнатов",Middlename="Иванович", DateOfBirth=new DateTime(1991,02,10), PhoneNumber="+79829945576",ImagePath = $"{_projectPath}/Images/Employee4.jpg", Address="Ул.Железнодорожная 6"}
        };

            foreach (var employee in _employees)
            {
                employee.CalculateEmployeeAge();
            }
        }

        public static void CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new EmployeeRepository();
                //Deserialize();
            }
        }
        public static ObservableCollection<Employee> GetAutoParts()
        {
            return _employees;
        }

        public static Employee GetAutoPart(int index)
        {
            return _employees[index];
        }

        public static Employee GetClientById(int id)
        {
            foreach (var item in _employees)
            {
                if (item.Id == id) return item;
            }
            return null;
        }

        public static void DeleteElement(int index)
        {
            int toDel = 10000;
            foreach (var item in _employees)
            {
                if (item.Id == index) toDel = _employees.IndexOf(item);
            }
            _employees.RemoveAt(toDel);
        }

        public static void ChangeElement(int index, Employee changed)
        {
            // можно было использоваеть changed.Id вместо index но мне уже лень переписывать
            _employees[index] = changed;
            foreach (var employee in _employees)
            {
                employee.CalculateEmployeeAge();
            }
        }

        public static void AddPart(Employee newPart)
        {
            int maxId = 0;
            foreach (var item in _employees)
            {
                if (item.Id > maxId) maxId = item.Id;
            }
            newPart.Id = maxId + 1;
            _employees.Add(newPart);

            foreach (var employee in _employees)
            {
                employee.CalculateEmployeeAge();
            }
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

