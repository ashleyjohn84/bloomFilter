using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ashley.BloomFilter;

namespace BloomFilterClient
{
	class Program
	{
		static void Main(string[] args)
		{
			int maxCount;
			double probabilityRatio;
			bool done = false;
			try
			{
				while (!done)
				{
					Console.WriteLine("Enter the maximum count of Elements for the BloomFilter ");
					string maxElementInput = Console.ReadLine();
					if (int.TryParse(maxElementInput, out maxCount) && maxCount > 0)
					{
						Console.WriteLine("Enter the false positive probability you are looking for ");
						string probabilityRatioInput = Console.ReadLine();
						if (double.TryParse(probabilityRatioInput, out probabilityRatio) && probabilityRatio > 0.0d && probabilityRatio < 1.00d)
						{
							BloomFilter bloomFilter = new BloomFilter(maxCount, probabilityRatio);
							PrintFilterCreatedMessage(maxCount, bloomFilter.BloomArraySize, probabilityRatio, bloomFilter.CountOfhashFunctions);
							while (!done)
							{
								var input = Console.ReadKey();
								Console.WriteLine();
								switch (input.KeyChar)
								{
									case 'i':
										Console.WriteLine("Add an Item");
										bloomFilter.Insert(Console.ReadLine());
										PrintAddedMessage(bloomFilter.Count, bloomFilter.GetUtilizationratio());
										break;
									case 'c':
										Console.WriteLine("Search for an Item");
										bool isPresent = bloomFilter.Contains(Console.ReadLine());
										PrintSeachResultMessage(isPresent);
										break;
									default:
										done = true;
										break;
								}
							}
						}
						else
						{
							Console.WriteLine("Please provide a valid ratio greater than 0 but less than 1");
						}
					}
					else
					{
						Console.WriteLine("Please provide a valid integer greater than 0 and less than Int.Max ");
					}
				}
			}
			catch(Exception exp)
			{
				Console.WriteLine(exp.Message);
			}
			finally
			{
				Console.ReadKey();
			}
		}

		static void PrintAddedMessage(int count,decimal percentage)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			string percentageFormatted = string.Format("{0:0.00}% ", percentage);
			Console.WriteLine($"Item Added. Item Count = {count} Utilization Percentage : {percentageFormatted} Please enter the next Command eg.. i or c or any other key to quit");
			Console.ResetColor();
		}

		static void PrintSeachResultMessage(bool isPresent)
		{
			if(isPresent)
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
			}
			Console.WriteLine($"Item is {(isPresent ? "" : "not")} present");
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Please enter the next Command eg.. i or c or any other key to quit");
			Console.ResetColor();
		}

		static void PrintFilterCreatedMessage(int maxCount, int arraySize, double probabilityRatio, int hashFunctions)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"BloomFilter Created . " +
				$"MaxElements : {maxCount}  " +
				$"ArraySize: {arraySize} bits " +
				$"FalsePositive probability: {probabilityRatio}  " +
				$"Count of hash functions: {hashFunctions}");
			Console.WriteLine("Enter i to Add Item , c to Search any other key  to quit");
			Console.ResetColor();
		}


	}
}
