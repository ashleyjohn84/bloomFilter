using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ashley.BloomFilter
{
	public interface IBloomHash
	{
		IEnumerable<int> GetIndices(string input);
	}
}
