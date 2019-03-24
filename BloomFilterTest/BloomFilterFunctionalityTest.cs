using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ashley.BloomFilter;

namespace BloomFilterTest
{
	[TestClass]
	public class BloomFilterFunctionalityTest
	{
		[TestMethod]
		public void AddedItemShouldReturnTrueWhenChecked()
		{
			BloomFilter bloomFilter = new BloomFilter(100, 0.1d);
			bloomFilter.Insert("Ashley");
			Assert.AreEqual(bloomFilter.Contains("Ashley"), true);
		}

		[TestMethod]
		public void NotAddedItemShouldReturnFalseWhenChecked()
		{
			BloomFilter bloomFilter = new BloomFilter(100, 0.1d);
			bloomFilter.Insert("Ashley");
			Assert.IsFalse(bloomFilter.Contains("Bloom"));
		}
	}
}
