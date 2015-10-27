using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordSearch
{
    class Program
    {

        static IDictionary dictRepository = new DictionaryRepository();
        
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.Write("Informe uma palavra :");

                var word = Console.ReadLine();

                if (word == string.Empty)
                    continue;

                ProcessWord(word);
            }
        }

        /// <summary>
        /// Processa a busca da palavra
        /// </summary>
        /// <param name="word"></param>
        private static void ProcessWord(string word)
        {
            WordSearchService service = new WordSearchService(dictRepository);

            ProcessResult processResult = service.SearchWord(word);

            FormatOutput(word, processResult);
        }

        /// <summary>
        /// Formata a saída
        /// </summary>
        /// <param name="word"></param>
        /// <param name="pos"></param>
        /// <param name="deadCats"></param>
        private static void FormatOutput(string word, ProcessResult result)
        {
            if (!result.found)
            {
                Console.WriteLine(String.Format("Palavra não encontrada. Gatos mortos = {2}", word, result.index.ToString(), result.deadCats.ToString()));
            }
            else
            {
                Console.WriteLine(String.Format("Palavra '{0}' encontrada na posição {1}. Gatos mortos = {2}", word, result.index.ToString(), result.deadCats.ToString()));
            }
        }
    }
}
