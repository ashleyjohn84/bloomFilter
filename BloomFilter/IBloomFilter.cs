using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ashley.BloomFilter
{
	public interface IBloomFilter
	{
		int CountOfhashFunctions { get; }
		void Insert(string item);
		bool Contains(string item);
	}
}
