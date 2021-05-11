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
    public class ClientRepository
    {
        protected static ObservableCollection<Client> _clients;
        protected string _projectPath = new DirectoryInfo(".").Parent.Parent.FullName;
        private static ClientRepository _instance;
        private ClientRepository()
        {
            _clients = new ObservableCollection<Client>
        {
            new Client { Id = 0, Name="Василий",Surname="Иванов",Middlename="Иванович", DateOfBirth=new DateTime(1967,04,30), PhoneNumber="+79823345576",ImagePath = $"{_projectPath}/Images/DefaultClient.jpg", Address="Пр.Прбеды 33"},
            new Client { Id = 1, Name="Иван",Surname="Смелый",Middlename="Иванович", DateOfBirth=new DateTime(1990,02,20), PhoneNumber="+79823345576",ImagePath = $"{_projectPath}/Images/DefaultClient.jpg", Address="Ул.Красная 342"},
            new Client { Id = 2, Name="Петр",Surname="Яковлев",Middlename="Иванович", DateOfBirth=new DateTime(1988,10,30), PhoneNumber="+79823345576",ImagePath = $"{_projectPath}/Images/Client3.jpg", Address="Ул.Тверская 14"},
            new Client { Id = 3, Name="Николай",Surname="Кличко",Middlename="Иванович", DateOfBirth=new DateTime(1993,02,10), PhoneNumber="+79823345576",ImagePath = $"{_projectPath}/Images/Client4.jpg", Address="Ул.Железнодорожная 6"}
        };

            foreach (var client in _clients)
            {
                client.CalculateClientAge();
            }
        }

        public static void CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new ClientRepository();
                //Deserialize();
            }
        }
        public static ObservableCollection<Client> GetAutoParts()
        {
            return _clients;
        }

        public static Client GetAutoPart(int index)
        {
            return _clients[index];
        }

        public static Client GetClientById(int id)
        {
            foreach (var item in _clients)
            {
                if (item.Id == id) return item;
            }
            return null;
        }

        public static void DeleteElement(int index)
        {
            int toDel = 10000;
            foreach (var item in _clients)
            {
                if (item.Id == index) toDel = _clients.IndexOf(item);
            }
            _clients.RemoveAt(toDel);
        }

        public static void ChangeElement(int index, Client changed)
        {
            // можно было использоваеть changed.Id вместо index но мне уже лень переписывать
            _clients[index] = changed;
            foreach (var client in _clients)
            {
                client.CalculateClientAge();
            }
        }

        public static void AddPart(Client newPart)
        {
            int maxId = 0;
            foreach (var item in _clients)
            {
                if (item.Id > maxId) maxId = item.Id;
            }
            newPart.Id = maxId + 1;
            _clients.Add(newPart);

            foreach (var client in _clients)
            {
                client.CalculateClientAge();
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

