using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordSearch;

namespace Test
{
    [TestClass]
    public class WordSearchEfficiencyTests
    {


        static IDictionary dictRepository = new DictionaryRepositoryFake();

        [TestMethod()]
        public void SearchLowIndexWordTests()
        {
            // arrange
            string word = "a";
            WordSearchService serviceBin = new WordSearchService(dictRepository);
            WordFullScanSearchService serviceFull = new WordFullScanSearchService(new DictionaryRepositoryFake());

            // act
            ProcessResult resultBinarySearch = serviceBin.SearchWord(word);
            ProcessResult resultFullScan = serviceFull.FullScan(word);

            //assert
            if (resultBinarySearch.deadCats > resultFullScan.deadCats)
                Assert.Fail("Algorítmo de busca binária ineficiente: Gatos mortos (binary):{0} - Gatos mortos (full):{1}", resultBinarySearch.deadCats, resultFullScan.deadCats);
            else
                System.Diagnostics.Trace.WriteLine(string.Format("Algorítmo de busca binária eficiente: Gatos mortos (binary):{0} - Gatos mortos (full):{1}", resultBinarySearch.deadCats, resultFullScan.deadCats));
        }

        [TestMethod()]
        public void SearchUpperIndexWordTests()
        {
            // arrange
            string word = "matter";
            WordSearchService serviceBin = new WordSearchService(dictRepository);
            WordFullScanSearchService serviceFull = new WordFullScanSearchService(new DictionaryRepositoryFake());

            // act
            ProcessResult resultBinarySearch = serviceBin.SearchWord(word);
            ProcessResult resultFullScan = serviceFull.FullScan(word);

            //assert
            if (resultBinarySearch.deadCats > resultFullScan.deadCats)
                Assert.Fail("Algorítmo de busca binária ineficiente: Gatos mortos (binary):{0} - Gatos mortos (full):{1}", resultBinarySearch.deadCats, resultFullScan.deadCats);
            else
                System.Diagnostics.Trace.WriteLine(string.Format("Algorítmo de busca binária eficiente: Gatos mortos (binary):{0} - Gatos mortos (full):{1}", resultBinarySearch.deadCats, resultFullScan.deadCats));
        }

        [TestMethod()]
        public void SearchMiddleIndexWordTests()
        {
            // arrange
            string word = "exercise";
            WordSearchService serviceBin = new WordSearchService(dictRepository);
            WordFullScanSearchService serviceFull = new WordFullScanSearchService(new DictionaryRepositoryFake());

            // act
            ProcessResult resultBinarySearch = serviceBin.SearchWord(word);
            ProcessResult resultFullScan = serviceFull.FullScan(word);

            //assert
            if (resultBinarySearch.deadCats > resultFullScan.deadCats)
                Assert.Fail("Algorítmo de busca binária ineficiente: Gatos mortos (binary):{0} - Gatos mortos (full):{1}", resultBinarySearch.deadCats, resultFullScan.deadCats);
            else
                System.Diagnostics.Trace.WriteLine(string.Format("Algorítmo de busca binária eficiente: Gatos mortos (binary):{0} - Gatos mortos (full):{1}", resultBinarySearch.deadCats, resultFullScan.deadCats));
        }

    }
}
