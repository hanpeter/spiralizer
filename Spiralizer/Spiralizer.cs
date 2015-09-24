using System;
using System.Collections.Generic;
using System.Text;

namespace Spiralizer
{
	public class Spiralizer
	{
		private readonly int x;
		private readonly int y;
		private readonly int[,] matrix;

		private const int MAX_VALUE = 100;

		/// <summary>
		/// Creates a 2D array with a random x and y dimensions. The values are capped at 100.
		/// </summary>
		public Spiralizer()
		{
			var random = new Random();
			this.x = random.Next(1, MAX_VALUE);
			this.y = random.Next(1, MAX_VALUE);
			this.matrix = new int[this.x, this.y];

			this.Init();
		}

		/// <summary>
		/// Creates a 2D array with given x and y dimensions.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public Spiralizer(int x, int y)
		{
			this.x = x;
			this.y = y;
			this.matrix = new int[this.x, this.y];

			this.Init();
		}

		private void Init()
		{
			for (int i = 0; i < (this.x * this.y);)
			{
				int x = i % this.x;
				int y = i / this.x;

				this.matrix[x, y] = ++i;
			}
		}

		/// <summary>
		/// Returns a comma deliminated string with the element of array listed out in spiral manner.
		/// </summary>
		/// <param name="offset">Starting point for the traversing</param>
		/// <returns>A comma deliminated string with the element of array listed out in spiral manner</returns>
		public string Spiralize(int offset = 0)
		{
			if (offset >= Math.Ceiling(this.x / 2.0M) || offset >= Math.Ceiling(this.y / 2.0M))
			{
				return string.Empty;
			}
			else if (offset < (this.x / 2.0M) && (offset + 1) > (this.x / 2.0M)
					&& offset < (this.y / 2.0M) && (offset + 1) > (this.y / 2.0M))
			{
				return this.matrix[(this.x / 2), (this.y / 2)] + ",";
			}

			int x = offset;
			int y = offset;

			var list = new List<int>();

			for (; x < this.x - offset - 1; x++)
			{
				list.Add(this.matrix[x, y]);
			}

			for (; y < this.y - offset - 1; y++)
			{
				list.Add(this.matrix[x, y]);
			}

			for (; x > offset; x--)
			{
				list.Add(this.matrix[x, y]);
			}

			for (; y > offset; y--)
			{
				list.Add(this.matrix[x, y]);
			}

			return string.Join(",", list) + "," + Spiralize(offset + 1);
		}

		/// <summary>
		/// Returns a string representation of 2D array with comma and newline delimiters.
		/// </summary>
		/// <returns>A string representation of 2D array with comma and newline delimiters</returns>
		public override string ToString()
		{
			var builder = new StringBuilder();

			for (int y = 0; y < this.y; y++)
			{
				for (int x = 0; x < this.x; x++)
				{
					builder.Append(this.matrix[x, y]).Append(",");
				}

				builder.AppendLine();
			}

			return builder.ToString();
		}
	}
}
