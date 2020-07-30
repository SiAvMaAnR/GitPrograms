using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GitPrograms
{
	public class Anketa
	{
		public string Name { get; private set; }//Имя
		public string Surname { get; private set; }//Фамилия
		public uint Age { get; private set; }//Возраст
		public string Gender { get; private set; }//Пол

		public DateTime dateTime;//Дата

		Dictionary<string, object> _Anketa = new Dictionary<string, object>();//Словарь данных анкеты


		//Функция обработки исключений
		public void ProcessString(string name, string surname, uint age, string gender)
		{
			try
			{
				//Проверка строк на null
				if (name == null || surname == null || gender == null)
				{
					throw new ArgumentNullException();
				}
				//Проверка uint возраста на корректность
				if (age < 0 || age > 200)
				{
					throw new ArgumentOutOfRangeException();
				}
			}
			//При наличии null строк вызов исключения
			catch (ArgumentNullException)
			{
				Console.WriteLine("Исключение: Не корректные данные!");
			}
			//При наличии не корректного значения вызов исключения
			catch (ArgumentOutOfRangeException)
			{
				Console.WriteLine("Исключение: Не корректный возраст!");
			}
		}


		//Передача аргументов в поля класса
		public void Data_transfer(in string Name, in string Surname, in uint Age, in string Gender)
		{
			//Передача аргементов в поля класса, при значении null вывод "none"
			this.Name = Name??"none";
			this.Surname = Surname ?? "none";
			this.Age = Age;
			this.Gender = Gender ?? "none";
			dateTime = DateTime.Now;
		}


		//Вывод полей класса
		public void Print_info()
		{
			Console.WriteLine($"{Name} {Surname} {Age} {Gender} {dateTime}\n");
		}


		//Конструктор класса, с обработкой исключений и передачей аргументов в словарь
		public Anketa(in string Name, in string Surname, in uint Age, in string Gender)
		{
			//Метод вызова исключений
			ProcessString(Name, Surname, Age, Gender);
			//Метод передачи аргументов в поля класса
			Data_transfer(Name, Surname, Age, Gender);

			//Передача в словарь полей класса
			_Anketa.Add("Name", this.Name);
			_Anketa.Add("Surname", this.Surname);
			_Anketa.Add("Age", this.Age);
			_Anketa.Add("Gender", this.Gender);
			_Anketa.Add("Data&Time", this.dateTime);
		}


		public Anketa(Dictionary<string, object> _Anketa_)
		{

		}


		//Сохранение сериализированных данных в JSON
		public void Save()
		{
			File.WriteAllText("anketa.json", JsonConvert.SerializeObject(_Anketa));
		}


		//Чтение/Десериализация/Вывод JSON
		public void Print_Person()
		{
			//Чтение, Десериализация и Запись JSON файла в словарь
			Dictionary<string, object> _Anketa_ = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText( "anketa.json"));
			//Вывод Словаря после записи данных из JSON
			foreach (var item in _Anketa_)
			{
				Console.WriteLine(item.Key + " - " + item.Value);
			}
		}
	};
	class Program
	{
		//Имитация фронта
		static void Main(string[] args)
		{
			string Name="Иван";
			string Surname = null;
			uint Age = 40;
			string Gender = "Оптимус Прайм";

			Anketa anketa = new Anketa(Name, Surname, Age, Gender);
			anketa.Save();
			anketa.Print_Person();
		}
	}
}
