namespace AdventOfCode2020.Models
{
	public class Day3 : DayBase
	{
		public Day3(string cookie) : base(cookie)
		{
		}

		public override int Day => 3;

		public override string Level1()
		{
			return GetTreesHit(3, 1).ToString();
		}

		public override string Level2()
		{
			return (GetTreesHit(1, 1) * GetTreesHit(3, 1) * GetTreesHit(5, 1) * GetTreesHit(7, 1) * GetTreesHit(1, 2)).ToString();
		}

		private long GetTreesHit(int right, int down)
		{
			int treeCounter = 0;
			int columnIndex = 0;
			for (int i = 0; i < Input.Length; i += down)
			{
				if (Input[i][columnIndex] == '#')
					treeCounter++;

				columnIndex = (columnIndex + right) % Input[i].Length;
			}
			return treeCounter;
		}
	}
}
