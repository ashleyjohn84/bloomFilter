using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ashley.BloomFilter;
using Moq;

namespace BloomFilterTest
{
	[TestClass]
	public class BloomFilterTest
	{
		[TestMethod]
		public void BloomFilter_InsertFunction_ShouldSet_Indices_ReturnedBy_BloomHash()
		{
			Mock<IBloomHash> bloomhashMock = new Mock<IBloomHash>();
			BloomFilter filter = new BloomFilter(100, 0.1d, bloomhashMock.Object);
			bloomhashMock.Setup(mock => mock.GetIndices(It.IsAny<string>())).Returns(() => Enumerable.Range(1, filter.CountOfhashFunctions));
			filter.Insert("Test");
			Assert.IsTrue(filter.bloomArray[1] && filter.bloomArray[2] && filter.bloomArray[3]);
		}

		[TestMethod]
		public void BloomFilter_InsertFunction_Should_Update_Count_By_One()
		{
			Mock<IBloomHash> bloomhashMock = new Mock<IBloomHash>();
			BloomFilter filter = new BloomFilter(100, 0.1d, bloomhashMock.Object);
			bloomhashMock.Setup(mock => mock.GetIndices(It.IsAny<string>())).Returns(() => Enumerable.Range(1, filter.CountOfhashFunctions));
			filter.Insert("Test");
			Assert.AreEqual(1, filter.Count);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ShouldThrow__ArgumentOutOfRangeException_If_MaxElements_EqualToZero()
		{
			BloomFilter filter = new BloomFilter(0, 0.01d);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ShouldThrow__ArgumentOutOfRangeException_If_MaxElements_LessThanToZero()
		{
			BloomFilter filter = new BloomFilter(-1, 0.01d);
		}


		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ShouldThrow__ArgumentOutOfRangeException_If_Probability_LessThanToZero()
		{
			BloomFilter filter = new BloomFilter(100, -1.2d);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ShouldThrow__ArgumentOutOfRangeException_If_Probability_GreaterThanOne()
		{
			BloomFilter filter = new BloomFilter(100, 1.2d);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ShouldThrow__ArgumentNullException_If_Item_Tobe_Inserted_IsNull()
		{
			BloomFilter filter = new BloomFilter(100, 0.1d);
			filter.Insert(null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ShouldThrow__ArgumentNullException_If_Item_Tobe_Checked_IsNull()
		{
			BloomFilter filter = new BloomFilter(100, 0.1d);
			filter.Contains(null);
		}
	}
}
