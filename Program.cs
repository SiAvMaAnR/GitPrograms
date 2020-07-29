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
		public string Name { get; private set; }
		public string Surname { get; private set; }
		public uint Age { get; private set; }
		public string Gender { get; private set; }

		public DateTime dateTime;

		Dictionary<string, object> _Anketa = new Dictionary<string, object>();


		//Функция обработки исключений
		public void ProcessString(string name,string surname,uint age, string gender)
		{
			try
			{
				if (name == null||surname==null|| gender == null)
				{
					throw new ArgumentNullException();
				}
				if(age<0||age>200)
				{
					throw new ArgumentOutOfRangeException();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Исключение: {0}", ex);
				Environment.Exit(0);
			}
		}


		//Передача аргументов в поля класса
		public void Data_transfer(in string Name, in string Surname, in uint Age, in string Gender)
		{
			this.Name = Name;
			this.Surname = Surname;
			this.Age = Age;
			this.Gender = Gender;
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
			ProcessString(Name, Surname, Age, Gender);
			Data_transfer(Name, Surname, Age, Gender);
			Print_info();

			_Anketa.Add("Name", Name);
			_Anketa.Add("Surname", Surname);
			_Anketa.Add("Age", Age);
			_Anketa.Add("Gender", Gender);
			_Anketa.Add("Data&Time", dateTime);
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
			Dictionary<string, object> _Anketa_ = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText( "anketa.json"));
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
			string Surname = "Самаркин";
			uint Age = 80;
			string Gender = "Оптимус Прайм";

			Anketa anketa = new Anketa(Name, Surname, Age, Gender);
			anketa.Save();
			anketa.Print_Person();
		}
	}
}
