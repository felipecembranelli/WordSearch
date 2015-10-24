using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordSearch
{
    public interface IDictionary
    {
        string GetWordFromDictionary(long index);
    }
}
