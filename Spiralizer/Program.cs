using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiralizer
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var spiralizer = new Spiralizer(4, 4);
			Console.WriteLine(spiralizer.ToString());
			Console.WriteLine(spiralizer.Spiralize());
		}
	}
}
