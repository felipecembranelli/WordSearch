using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordSearch
{
    public class DictionaryRepositoryFake : IDictionary
    {
        public string[] dictionary = new string[492];

        public DictionaryRepositoryFake()
        {
            this.LoadDictionary();
        }

        public void LoadDictionary()
        {
            try
            {
                dictionary = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"\FakeRepository\dictSample.txt");
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public string GetWordFromDictionary(long index)
        {
            try
            {
                return dictionary[index];

            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

    }
}
