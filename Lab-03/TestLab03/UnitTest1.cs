
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Lab_03;
using Newtonsoft.Json.Linq;

namespace TestLab03
	
{
	public class UnitTest1
	{

		[Theory]
		[InlineData(8, "2 2 2")]
		[InlineData(8, "2 2 2 2")]
		[InlineData(0, "2 2")]
		[InlineData(-8, "-2 -2 -2")]
		[InlineData(0, "")]
		public void ReturnValueForProduct(int expectedValue, string values)
		{

			Assert.Equal(expectedValue, Lab_03.Program.Product(values));
		}

		//int [] values= new int[] { 1, 2, 3, 4 }

		[Theory]
		[InlineData(4, new int[] { 5, 3, 4, 4 })]
		[InlineData(2, new int[] { 1, 2, 3, 4 })]
		[InlineData(0, new int[] { 0,0 })]
		public void ReturnValueForAverge(decimal expectedValue, int[] values)
		{

			Assert.Equal(expectedValue, Lab_03.Program.Averge(values));
		}
		[Theory]
		[InlineData(1, new int[] { 14,1,5,5,6,1,6,1 })]
		[InlineData(3, new int[] { 3,3,3,3 })]
		[InlineData(3, new int[] { 3,2,3,5,2 })]
		public void ReturnValueForDuplicate(int expectedValue, int[] values)
		{

			Assert.Equal(expectedValue, Lab_03.Program.Duplicate(values));
		}
		//List<int> test=new List<int>
		[Theory]
		[InlineData(-1, new int[] {})]
		[InlineData(20, new int[] { 16,5,20,3,0})]
		[InlineData(20, new int[] { -16, 5, 20, -3, 0 })]
		public void ReturnValueForMaxInArray(int expectedValue, int[] array)
		{

			Assert.Equal(expectedValue, Lab_03.Program.MaxInArray(array));
		}

		[Theory]
		[InlineData("[ hi: 2 Im: 2 alaa: 4 ]","hi Im alaa")]
		[InlineData("","")]
		//[InlineData()]
		public void ReturnValueForNumOdcharsInEachWord(string expectedValue, string word)
		{

			Assert.Equal(expectedValue, Lab_03.Program.NumOdcharsInEachWord(word));
		}
	}
}