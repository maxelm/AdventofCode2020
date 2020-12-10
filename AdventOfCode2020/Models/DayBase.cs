using System;
using System.Linq;
using System.Net;
using System.Text;

namespace AdventOfCode2020
{
	public abstract class DayBase
	{
		private readonly string cookie;
		public abstract int Day { get; }
		public string[] Input { get; set; }
		public abstract string Level1();
		public abstract string Level2();
		public abstract void Initialize();

		public DayBase(string cookie)
		{
			this.cookie = cookie;
			this.Initialize();
		}

		internal void GetInput(bool includeNullOrWhiteSpace = false)
		{
			string url = $"https://adventofcode.com/2020/day/{Day}/input";
			using WebClient client = new WebClient();
			client.Headers.Add(HttpRequestHeader.Cookie, cookie);

			var result = client.DownloadData(url);
			var collection = Encoding.UTF8.GetString(result).Split("\n");

			if (!includeNullOrWhiteSpace)
			{
				collection = collection.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
			}

			Input = collection;
		}

		public void Solve()
		{
			Console.WriteLine($"--- AoC2020 Day {Day} ---");
			Console.WriteLine($"Level 1 Answer: {Level1()}");
			Console.WriteLine($"Level 2 Answer: {Level2()}");
			Console.WriteLine($"---------------------\n");
		}
	}
}
