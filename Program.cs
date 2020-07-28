using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GitPrograms
{
	public class Anketa
	{
		Dictionary<string, object> _Anketa = new Dictionary<string, object>();

		public Anketa(in string Name,in string Surname,in int Age,in string Gender)
		{
			_Anketa.Add("Name1", Name);
			_Anketa.Add("Surname", Surname);
			_Anketa.Add("Age", Age);
			_Anketa.Add("Gender", Gender);
			_Anketa.Add("Data&Time", DateTime.Now);
		}
		public void Save()
		{
			File.WriteAllText( "anketa.json", JsonConvert.SerializeObject(_Anketa));
		}
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
		static void Main(string[] args)
		{
			string Name = "Иван";
			string Surname = "Самаркин";
			int Age = 10;
			string Gender = "Оптимус Прайм";

			Anketa anketa = new Anketa(Name,Surname,Age,Gender);
			anketa.Save();
			anketa.Print_Person();
		}
	}
}
