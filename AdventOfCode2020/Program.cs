using AdventOfCode2020;
using AdventOfCode2020.Models;
using System;

const string COOKIE = "session=53616c7465645f5f7bfb7351527dca968da37e38b356b8c1d666a024b72b5289f32ef7d21b66d2698b8939ffbd1db3bd";

DayOne();
DayTwo();

void DayOne()
{
	Day1 dayOne = new Day1(COOKIE);
	Console.WriteLine(dayOne.Level1());
	Console.WriteLine(dayOne.Level2());
	Console.ReadLine();
}

void DayTwo()
{
	Day2 dayTwo = new Day2(COOKIE);
	//Console.WriteLine(DayOne.Level1());
	//Console.WriteLine(DayOne.Level2());
	Console.ReadLine();
}