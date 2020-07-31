using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
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
					if (value < 0)
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



		//Конструктор класса, с обработкой исключений и передачей аргументов в словарь
		public Anketa(in string Name, in string Surname, in uint Age, in string Gender)
		{
			name = Name;
			surname = Surname;
			age = Age;
			gender = Gender;
			DateTime = DateTime.Now;
		}

		//Правописание «год», «года» или «лет»
		private string Year(uint year)
		{
			uint t1 = year % 10;
			uint t2 = year % 100;
			if (t1 == 1 && t2 != 11)
				return "год";
			if (t1 >= 2 && t1 <= 4 && (t2 < 10 || t2 >= 20))
				return "года";
			else
				return "лет";
		}
		//Возврат строки
		public string AnketaToString()
		{
			return $"{Name} {Surname} {Age} {Year(Age)} {Gender}";
		}

	};
	class Program
	{
		//Имитация фронта
		static void Main(string[] args)
		{
			string Name= "Иван";
			string Surname = "Самаркин";
			uint Age = 102;
			string Gender = "Оптимус Прайм";

			Anketa anketa = new Anketa(Name, Surname, Age, Gender);
			Console.WriteLine(anketa.AnketaToString());
		}
	}
}
