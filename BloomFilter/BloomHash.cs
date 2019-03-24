using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ashley.BloomFilter
{
	internal class BloomHash : IBloomHash
	{
		private readonly int maxIndex;
		private readonly int hashFunctionCount;
		public BloomHash(int maxIndex, int hashFunctionCount)
		{
			this.maxIndex = maxIndex;
			this.hashFunctionCount = hashFunctionCount;
		}

		private byte[] GetBytes(string input)
		{
			return Encoding.ASCII.GetBytes(input);
		}
		private int GetSecondaryHashCode(string input)
		{
			int hashCode;
			byte[] inputBytes = GetBytes(input);
			using (MemoryStream stream = new MemoryStream(inputBytes))
			{
				hashCode = MurMurHash3.Hash(stream);
			}
			return hashCode;
		}

		// Performs Dillinger and Manolios double hashing. 
		public IEnumerable<int> GetIndices(string input)
		{
			int primaryhashCode = input.GetHashCode();
			int secondaryhashCode = GetSecondaryHashCode(input);
			for (int i = 0; i < hashFunctionCount; i++)
			{
				yield return Math.Abs((primaryhashCode + i * secondaryhashCode) % maxIndex);
			}
		}
	}
}
