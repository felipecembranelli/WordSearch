using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordSearch
{
    /// <summary>
    /// Armazena o resultado do processamento
    /// </summary>
    public struct ProcessResult
    {
        public int deadCats;
        public long index;
        public bool found;
    }
}
