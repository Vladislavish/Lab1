using System;
using System.Globalization;
using System.IO;

namespace TimeTrees
{
	struct Person
    {
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime BirthDate { get; set; }

		public DateTime? DeathDate { get; set; }
    }

	struct TimelineEvent
	{
		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public string EventDescription { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			string timelineFile = Path.Combine(Environment.CurrentDirectory, "timeline.csv");
			string peopleFile = Path.Combine(Environment.CurrentDirectory, "people.csv");

			if (!File.Exists(timelineFile)
				|| !File.Exists(peopleFile))
			{
				WriteTestFiles(peopleFile, timelineFile);
			}

			object[][] peopleData = ReadDataToObject(peopleFile);
			object[][] timelineData = ReadDataToObject(timelineFile);

			(int years, int months, int days) = DeltaMinAndMaxDate(timelineData);
			// void GetMinAndMaxDate(out DateTime min, out DateTime max);
			// Tuple<DateTime, DateTime> GetMinAndMaxDate(); new Tuple<DateTime, DateTime>>(dt1, dt2); var dates = GetMinAndMaxDate(); dates.Item1; dates.Item2;

			Console.WriteLine($"Между макс и мин датами прошло: {years} лет, {months} месяцев и {days} дней");

			static object[][] ReadDataToObject(string path)
			{
				string[] data = File.ReadAllLines(path);
				object[][] splitedData = new string[data.Length][];
				for (var i = 0; i < data.Length; i++)
				{
					string[] parts = data[i].Split(';');
					splitedData[i] = parts;
				}
				return splitedData;
			}

			static string[] GenerateTimeLineData()
			{
				return new[]
				{
					"1950; событие 1 бла - бла - бла",
					"1991 - 06 - 01; какое - то событие 2",
					"2000 - 01 - 01; наступил миллениум, ура-ура - ура"
				};
			}

			static string[] GeneratePeopleData()
			{
				return new[]
				{
					"1;Имя 1;2000-06-05",
					"2;Имя 2;1950-01-10;2010-01-01"
				};
			}


		}
	}
}
