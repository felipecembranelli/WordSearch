using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordSearch
{
    public class WordFullScanSearchService
    {
        DictionaryRepositoryFake dictRepository;

        public WordFullScanSearchService(DictionaryRepositoryFake repository)
        {
            dictRepository = repository;
        }

        /// <summary>
        /// Método criado somente para comparar a eficiência dos algoritmos. Ele realiza um full-scan no dicionário.
        /// Neste caso, estamos considerando que o tamanho do dicionário é conhecido.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public ProcessResult FullScan(string word)
        {
            int catKillerCounter = 0;

            for (int i = 0; i < dictRepository.dictionary.Length; i++)
            {
                string returnedWord = dictRepository.GetWordFromDictionary(i);

                catKillerCounter++;

                int compare = String.Compare(returnedWord, word, true);

                if (compare == 0)
                {
                    return new ProcessResult { deadCats = catKillerCounter, index = i };
                }
            }

            return new ProcessResult { deadCats = catKillerCounter, index = -1 };
        }
    }
}
