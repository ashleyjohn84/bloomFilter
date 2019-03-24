using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ashley.BloomFilter
{
	public abstract class BloomFilterBase : IBloomFilter
	{
		public BloomFilterBase(int maxElements,double falsePositiveProbability)
		{
			if(maxElements <= 0)
			{
				throw new ArgumentOutOfRangeException("maxElements", "Max Elements should be greater than zero");
			}
			if(falsePositiveProbability < 0 || falsePositiveProbability > 1)
			{
				throw new ArgumentOutOfRangeException("falsePositiveProbability", "False positive probability should be between 1 and 0");
			}
			BloomArraySize = CalculateArraySize(maxElements, falsePositiveProbability);
			CountOfhashFunctions = GetCountofHashFunctions(BloomArraySize, maxElements);
		}

		private int CalculateArraySize(int maxElements, double falsePositiveProbability)
		{
			double arraySize = maxElements * Math.Log(falsePositiveProbability) / Math.Pow(Math.Log(2), 2);
			arraySize = Math.Round(Math.Abs(arraySize));
			return (int)arraySize;
		}

		private int GetCountofHashFunctions(int arraySize,int maxElements)
		{
			int hashFunctionsCount = (int)Math.Round(Math.Abs((arraySize / maxElements) * Math.Log(2)));
			return hashFunctionsCount;
		}

		public int CountOfhashFunctions { get; }

		public int BloomArraySize { get; }

		public abstract bool Contains(string item);

		public abstract void Insert(string item);
		
	}
}
