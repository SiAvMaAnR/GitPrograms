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
	public class AnketsManager
	{

	}

	public class Anketa
	{
		private string Name;//Имя
		public string name
		{
			get
			{
				return Name;
			}
			private set
			{
				try
				{
					if (value == null)
						throw new ArgumentNullException();
				}
				catch (ArgumentNullException)
				{
					Console.WriteLine("Исключение: Не корректное имя!");
				}
				Name = value;
			}
		}


		private string Surname;//Фамилия
		public string surname
		{
			get 
			{
				return Surname;
			}
			private set 
			{
				try
				{
					if (value == null)
						throw new ArgumentNullException();
				}
				catch (ArgumentNullException)
				{
					Console.WriteLine("Исключение: Не корректная фамилия!");
				}
				Surname = value;
			}
		}


		private uint Age;//Возраст
		public uint age
		{
			get
			{
				return Age;
			}
			private set
			{
				try
				{
					if (value < 0 || value > 200)
					{
						throw new ArgumentOutOfRangeException();
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Исключение: Не корректный возраст!");
				}
				Age = value;
			}
		}


		private string Gender;//Пол
		public string gender
		{
			get
			{
				return Gender;
			}
			private set
			{
				try
				{
					if (value == null)
					{
						throw new ArgumentNullException();
					}
				}
				catch (ArgumentNullException)
				{
					Console.WriteLine("Исключение: Не корректный пол!");
				}
				Gender = value;
			}
		}


		public DateTime DateTime { get; private set; }//Дата

		Dictionary<string, object> _Anketa = new Dictionary<string, object>();//Словарь данных анкеты

		//Передача аргументов в поля класса
		public void DataTransfer(in string Name, in string Surname, in uint Age, in string Gender)
		{
			//Передача аргементов в поля класса, при значении null вывод "none"
			name = Name??"none";
			surname = Surname ?? "none";
			age = Age;
			gender = Gender ?? "none";
			DateTime = DateTime.Now;
		}


		//Вывод полей класса
		public void PrintInfo()
		{
			Console.WriteLine($"{Name} {Surname} {Age} {Gender} {DateTime}\n");
		}


		//Конструктор класса, с обработкой исключений и передачей аргументов в словарь
		public Anketa(in string Name, in string Surname, in uint Age, in string Gender)
		{
			//Метод передачи аргументов в поля класса
			DataTransfer(Name, Surname, Age, Gender);

			//Передача в словарь полей класса
			_Anketa.Add("Name", this.Name);
			_Anketa.Add("Surname", this.Surname);
			_Anketa.Add("Age", this.Age);
			_Anketa.Add("Gender", this.Gender);
			_Anketa.Add("Data&Time", this.DateTime);
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
		public void PrintDictionary()
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
			string Name= "Иван";
			string Surname = "Самаркин";
			uint Age = 40;
			string Gender = "Оптимус Прайм";

			Anketa anketa = new Anketa(Name, Surname, Age, Gender);
			anketa.Save();
			anketa.PrintDictionary();
		}
	}
}
