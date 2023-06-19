using System;
using System.Linq;
using System.Net.Http.Headers;
using System.IO;
using System.Linq.Expressions;

namespace Lab_03
{
	internal class Program
	{
		static void Main(string[] args)
		{
			UserInterface();
		}

		private static void UserInterface()
		{

			string Process = "";
			while (Process != "10")
			{

				Console.WriteLine("Please Enter the number of the Process\r\n1.Product\r\n" +
				"2.Averge\r\n3.Print stars\r\n4.Max value in a given Array\r\n5.Max value in the arry\r\n" +
				"6.add word to text file\r\n7.Read file content\r\n8.Delete a word from afile and rewrite it in the end\r\n9.Enter a sentence to show each word count");
				Process = Console.ReadLine();
				/////////
				if (Process == "1")
				{
					Console.WriteLine("Please Enter 3 Numbers to find the Product");
					string values = Console.ReadLine();
					int ProductValue = Product(values);
					if (ProductValue != 0)
					{

						Console.WriteLine($"The Product answer is {ProductValue}");
					}
					else { Console.WriteLine($"you did'nt Enter a three correct number"); }
				}
				////////////
				///Average 
				if (Process == "2")
				{
					Console.WriteLine("Please Enter Number between 2 and 10");
					string number = Console.ReadLine();

					int ParseNumber = 0;
					bool IntTest = Int32.TryParse(number, out ParseNumber);
					if (IntTest && ParseNumber > 2 && ParseNumber < 10)
					{
						int[] ValuesArray = new int[ParseNumber];
						for (int i = 1; i <= ParseNumber; i++)
						{
							Console.Write($"Please Enter Number {i}:");
							string value = Console.ReadLine();
							int ParseValue = 0;
							if (Int32.TryParse(value, out ParseValue))
							{
								ValuesArray[i - 1] = ParseValue;
							}
							else { Console.WriteLine($"{value} is Not a number, so it will Not be added to the Averge"); }
						}

						decimal answer = Averge(ValuesArray);
						Console.WriteLine($"the Averge of {ValuesArray.Length} numbers is: {answer}");
					}
					else { Console.WriteLine("Sorry, You did'nt Enter a correct number between 2 and 10"); }

				}

				if (Process == "3")
				{
					PrintStars(5);
				}

				if (Process == "4")
				{
					int[] array = new int[] { 2, 2, 2, 3, 1, 1, 5, 100, 0, 0, 2, 5, 2, 2, 2, 0, 0, 0, 0, 0, 0 };

					int answer = Duplicate(array);
					if (answer == -1)
					{
						Console.WriteLine("The array is empty.");
					}
					else
					{
						Console.WriteLine($"the most reurn number is {answer}");
					}

				}
				if (Process == "5")
				{
					try
					{
						Console.WriteLine($"Please Enter Array of Numbers to find the Max number");
						string number = Console.ReadLine();
						string[] arrayString = number.Split(" ");
						List<int> arrayInt = new List<int>();
						for (int i = 0; i < arrayString.Length; i++)
						{
							int ParseValue = 0;
							if (Int32.TryParse(arrayString[i], out ParseValue))
							{
								arrayInt.Add(ParseValue);
							}
						}
						int answer = MaxInArray(arrayInt);
						if (answer == -1)
						{
							Console.WriteLine($"You did'nt Enter any number to the list");
						}
						else { Console.WriteLine($"the max value in the array is: {answer}"); }
					}
					catch (NullReferenceException ex)
					{
						Console.WriteLine($"the Array is empty: {ex}");
					}
				}
				if (Process == "6")
				{
					
						Console.WriteLine("Please Enter the word:");
						string word = Console.ReadLine();
						if (word == "")
						{

							Console.WriteLine($"Sorry,you didn't Enter any word to be added.");
						}
						else
						{
							string path = "../../../words.txt";
							int answer = AddtoTextFile(word, path);
							if (answer == -1) { Console.WriteLine($"The File Not Exist"); }
							else { Console.WriteLine($"The data has been added"); }


						}
					}

				if (Process == "7")
				{
					string path = "../../../words.txt";
					string answer = ReadTextFile(path);
					if (answer == "")
					{
						Console.WriteLine("The File Not Exist");
					}
					else
					{
						Console.WriteLine($"File data is =>>> {answer}");
					}
				}
				if (Process == "8")
				{
					string path = "../../../words.txt";
					string answer = DeletOneWordAndReaddIt(path);
					if (answer == "")
					{
						Console.WriteLine("The File Is Not Exist Or The file is empty");
					}
					else if(answer == "1") {
						Console.WriteLine($"the file just contain one word so we cant delet the first word");
					}

					else{
						Console.WriteLine($"File data is =>>> {answer}");
					}
				}

				if (Process == "9")
				{
					Console.WriteLine("Please Enter the word:");
					string word = Console.ReadLine();
					if (word == "")
					{

						Console.WriteLine($"Sorry,you didn't Enter any word to be added.");
					}
					else
					{
						 string answer = NumOdcharsInEachWord(word);
						 Console.WriteLine(answer); 


					}
				}
				//DeletOneWordAndReaddIt
				///////////////////////////
				else
				{
					Console.WriteLine("Sorry, You did'nt Enter a number from the list");

				}
			}
		}



		private static int Product(string values)
		{
			int result = 1;

			if (values != null)
			{
				string[] ArrayValues = values.Split(" ");
				if (ArrayValues.Length < 3)
				{ return 0; }
				else
				{

					for (int i = 0; i <= 2; i++)
					{
						int number = 0;
						bool IntTest = Int32.TryParse(ArrayValues[i], out number);
						if (IntTest)
						{
							result = number * result;
						}

					}

				}

				return result;
			}

			else { return 0; }
		}
		////////////////////////////////////////////////
		private static int Averge(int[] valuesArray)
		{

			int sum = 0;
			for (int i = 0; i < valuesArray.Length; i++)
			{

				sum = sum + valuesArray[i];
			}
			return (sum / valuesArray.Length);
		}
		//////////////////
		private static void PrintStars(int rows)
		{
			for (int i = 1; i <= rows; i++)
			{
				for (int j = rows; j >= i; j--)
				{
					Console.Write(" ");
				}
				for (int j = 1; j <= i; j++)
				{
					Console.Write("*");
				}

				for (int j = 1; j < i; j++)
				{
					Console.Write("*");
				}
				Console.WriteLine("");
			}

			for (int i = rows - 1; i >= 1; i--)
			{


				for (int j = 1; j <= i; j++)
				{
					Console.Write(" ");
				}
				for (int j = i; j >= 1; j--)
				{
					Console.Write("*");
				}
				for (int j = i - 1; j >= 1; j--)
				{
					Console.Write("*");
				}

				Console.WriteLine("");
			}

		}
		/// <summary>
		/// ////////////
		/// </summary>
		/// <param name=""></param>
		/// <returns></returns>
		public static int Duplicate(int[] array)
		{
			List<int> numbers = new List<int>();
			List<int> duplicats = new List<int>();


			if (array.Length == 0)
			{
				return -1;
			}
			else
			{

				for (int i = 0; i < array.Length; i++)
				{
					if (!numbers.Contains(array[i]))
					{
						int duplicated = 0;
						int num = array[i];
						for (int j = 0; j < array.Length; j++)
						{
							if (num == array[j])
							{
								duplicated++;
							}
						}
						numbers.Add(num);
						duplicats.Add(duplicated);
					}


				}
				int Index = duplicats.IndexOf(duplicats.Max());
				return numbers[Index];
			}
		}

		/////////////////
		public static int MaxInArray(List<int> array)
		{
			if (array.Count == 0) { return -1; }
			int maxValue = array[0];
			foreach (int item in array)
			{
				if (item > maxValue)
				{
					maxValue = item;
				}
			}
			return maxValue;
		}

		public static int AddtoTextFile(string word, string path)
		{
			try { 
			File.WriteAllText(path, word);


			string data = File.ReadAllText(path);
			return 1; }
		catch(FileNotFoundException) {
			return -1;
		}
		}

		public static string ReadTextFile(string path)
		{
			try
			{
				string data = File.ReadAllText(path);
				return data;
			}
			catch (FileNotFoundException)
			{
				return "";
			}
		}

			public static string DeletOneWordAndReaddIt(string path)
			{
			try
			{
				string data = File.ReadAllText(path);
				if (data != "")
				{
					string[] ArrayData = data.Split(" ");
					if (ArrayData.Length == 1)
					{
						return "1";
					}
					else
					{
						data = "";
						for (int i = 1; i < ArrayData.Length; i++)
						{
							data += ArrayData[i] + " ";
						}
						data += ArrayData[0];
						File.WriteAllText(path, data);
						return File.ReadAllText(path);
					}
				}
				else { return ""; }
			}
			catch (FileNotFoundException)
			{
				return "";
			}
			}

		public static string NumOdcharsInEachWord(string words) {

			string[] array= words.Split(" ");
			string answer = "[ ";
			for (int i = 0; i < array.Length; i++)
			{
				int size= array[i].Length;
				answer += $"{array[i]}: {size}  ";
			}
			answer += "]";
			return answer;
			


		}
	}
}