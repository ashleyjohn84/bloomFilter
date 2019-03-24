using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ashley.BloomFilter;

namespace BloomFilterTest
{
	[TestClass]
	public class BloomFilterFunctionalityTest
	{
		[TestMethod]
		public void AddAnItemandCheck()
		{
			BloomFilter bloomFilter = new BloomFilter(100, 0.1d);
			bloomFilter.Insert("Ashley");
			Assert.AreEqual(bloomFilter.Contains("Ashley"), true);
		}
	}
}
