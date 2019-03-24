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
			Console.WriteLine("Enter the maximum count of Elements for the BloomFilter ");
			string maxElementInput = Console.ReadLine();
			if (int.TryParse(maxElementInput, out maxCount))
			{
				Console.WriteLine("Enter the false positive probability you are looking for ");
				string probabilityRatioInput = Console.ReadLine();
				if (double.TryParse(probabilityRatioInput, out probabilityRatio) && probabilityRatio > 0.0d && probabilityRatio < 1.00d)
				{
					BloomFilter bloomFilter = new BloomFilter(maxCount, probabilityRatio);
					PrintFilterCreatedMessage(maxCount, bloomFilter.BloomArraySize, probabilityRatio, bloomFilter.CountOfhashFunctions);
					while (!done)
					{
						string input = Console.ReadLine();
						switch (input[0])
						{
							case 'i':
								Console.WriteLine("Add an Item");
								bloomFilter.Insert(Console.ReadLine());
								PrintAddedMessage();
								break;
							case 'c':
								Console.WriteLine("Serach for an Item");
								bool isPresent = bloomFilter.Contains(Console.ReadLine());
								Console.WriteLine($"Item is {(isPresent ? "" : "not")} present");
								break;
							case 'q':
								done = true;
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
				Console.WriteLine("Please provide a valid integer greater than 0 ");
			}
		}

		static void PrintAddedMessage()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Item Added. Please enter the next Command eg.. i or c or q");
			Console.ResetColor();
		}

		static void PrintFilterCreatedMessage(int maxCount, int arraySize, double probabilityRatio, int hashFunctions)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"BloomFilter Created . " +
				$"MaxElements : {maxCount}  " +
				$"ArraySize: {arraySize}  " +
				$"FalsePositive probability: {probabilityRatio}  " +
				$"Count of hash functions: {hashFunctions}");
			Console.WriteLine("Enter i to Add Item , c to Search q to quit");
			Console.ResetColor();
		}


	}
}
