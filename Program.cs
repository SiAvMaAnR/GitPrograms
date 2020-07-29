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
		public Anketa(in string Name, in string Surname, in uint Age, in string Gender)
		{
			ProcessString(Name,Surname,Age,Gender);


			_Anketa.Add("Name", Name);
			_Anketa.Add("Surname", Surname);
			_Anketa.Add("Age", Age);
			_Anketa.Add("Gender", Gender);
			_Anketa.Add("Data&Time", DateTime.Now);
		}
		public Anketa(Dictionary<string, object> _Anketa_)
		{

		}
		public void Save()
		{
			File.WriteAllText("anketa.json", JsonConvert.SerializeObject(_Anketa));
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
			string Name="Опа";
			string Surname = "Федоров";
			uint Age = 800;
			string Gender = "муж";

			Anketa anketa = new Anketa(Name, Surname, Age, Gender);
			anketa.Save();
			anketa.Print_Person();
		}
	}
}
