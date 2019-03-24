using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ashley.BloomFilter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BloomFilterTest
{
	[TestClass]
	public class BloomHashTest
	{
		[TestMethod]
		public void CountOfIndices_Returned_Should_Besame_as_MaxHasFunctions()
		{
			BloomHash hash = new BloomHash(100, 2);
			Assert.AreEqual(2, hash.GetIndices("test").Count());
		}
	}
}
