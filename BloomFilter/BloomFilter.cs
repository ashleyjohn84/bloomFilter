using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

[assembly :InternalsVisibleTo("BloomFilterTest")]

namespace Ashley.BloomFilter
{
	public class BloomFilter : BloomFilterBase
	{
		internal readonly BitArray bloomArray;
		private readonly IBloomHash IbloomHash;

		public int Count { get; private set; }
		public BloomFilter(int maxElements, double falsePositiveProbability) : base(maxElements, falsePositiveProbability)
		{
			bloomArray = new BitArray(BloomArraySize, false);
			IbloomHash = new BloomHash(BloomArraySize, CountOfhashFunctions);
		}

		public BloomFilter(int maxElements, double falsePositiveProbability,IBloomHash bloomHash) : base(maxElements, falsePositiveProbability)
		{
			bloomArray = new BitArray(BloomArraySize, false);
			this.IbloomHash = bloomHash;
		}


		public override bool Contains(string item)
		{
			if (String.IsNullOrWhiteSpace(item) || String.IsNullOrEmpty(item))
			{
				throw new ArgumentNullException("item", "Item to be checked cannot be empty or null or whitespace");
			}
			foreach (int index in IbloomHash.GetIndices(item))
			{
				if (!bloomArray[index])
					return false;
			}
			return true;
		}

		public override void Insert(string item)
		{
			if(String.IsNullOrWhiteSpace(item) || String.IsNullOrEmpty(item))
			{
				throw new ArgumentNullException("item", "Item to be inserted cannot be empty or null or whitespace");
			}

			foreach(int index in IbloomHash.GetIndices(item))
			{
				bloomArray[index] = true;
			}
			Count++;
		}

		public decimal GetUtilizationratio()
		{
			decimal result = 0;
			int setBits = bloomArray.Cast<bool>().Count(item => item);
			result = setBits * 100 / BloomArraySize;
			return result;
		}
		
	}
}
