using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
{
	class Program
	{
		static List<int> Entries = new List<int>();
		static readonly string filePath = @"..\..\..\Input.txt";

		static void Main(string[] args)
		{
			PopulateEntries();
			SolveProblemOne();
			SolveProblemTwo();
			Console.ReadKey();
		}

		private static void SolveProblemTwo()
		{
			int entryOne = 0;
			int entryTwo = 0;
			int entryThree = 0;
			bool quit = false;
			for (int i = 0; i < Entries.Count; i++)
			{
				entryOne = Entries[i];
				for (int j = 0; j < Entries.Count; j++)
				{
					if (i == 0)
						continue;

					entryTwo = Entries[j];

					for (int k = 0; k < Entries.Count; k++)
					{
						if (i == k || j == k)
							continue;

						entryThree = Entries[k];
						if (entryOne + entryTwo + entryThree == 2020)
						{
							quit = true;
							break;
						}
					}

					if (quit)
						break;
				}

				if (quit)
					break;
			}

			var answer = entryOne * entryTwo * entryThree;
			Console.WriteLine($"Answer to problem 2: {answer}");
		}

		private static void SolveProblemOne()
		{
			int entryOne = 0;
			int entryTwo = 0;
			bool quit = false;
			for (int i = 0; i < Entries.Count; i++)
			{
				entryOne = Entries[i];
				for (int j = 0; j < Entries.Count; j++)
				{
					if (i == 0)
						continue;

					entryTwo = Entries[j];
					if (entryOne + entryTwo == 2020)
					{
						quit = true;
						break;
					}
				}

				if (quit)
					break;
			}

			var answer = entryOne * entryTwo;
			Console.WriteLine($"Answer to problem 1: {answer}");
		}

		private static void PopulateEntries()
		{
			using (StreamReader file = new StreamReader(filePath))
			{
				string line;
				while ((line = file.ReadLine()) != null)
				{
					Entries.Add(int.Parse(line));
				}
				file.Close();
			}
		}
	}
}
