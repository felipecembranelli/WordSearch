using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordSearch.Tests
{
    [TestClass()]
    public class WordSearchServiceTests
    {
        static IDictionary dictRepository = new DictionaryRepositoryFake();

        [TestMethod()]
        public void SearchWord_LowerBoundWordTest()
        {
            // arrange
            string word = "a";
            long expectedIndex = 0;
            int expectedDeadCats = 1;
            WordSearchService service = new WordSearchService(dictRepository);

            // act
            ProcessResult result = service.SearchWord(word);

            //assert
            Assert.AreEqual(expectedIndex, result.index,"Falha ao procurar pela primeira palavra do dicionário");
            Assert.AreEqual(expectedDeadCats, result.deadCats, "Número de gatos mortos incorretos");
        }
       
        [TestMethod()]
        public void SearchWord_UpperBoundWordTest()
        {
            // arrange
            string word = "may";
            long expectedIndex = 491;
            long expectedDeadCats = 19;
            WordSearchService service = new WordSearchService(dictRepository);

            // act
            ProcessResult result = service.SearchWord(word);

            //assert
            Assert.AreEqual(expectedIndex, result.index, "Falha ao procurar pela última palavra do dicionário");
            Assert.AreEqual(expectedDeadCats, result.deadCats, "Número de gatos mortos incorretos");
        }

        [TestMethod()]
        public void SearchWord_WordExistTest()
        {
            // arrange
            string word = "and";
            long expectedIndex = 21;
            long expectedDeadCats = 11;
            WordSearchService service = new WordSearchService(dictRepository);

            // act
            ProcessResult result = service.SearchWord(word);

            //assert
            Assert.AreEqual(expectedIndex, result.index, "Falha ao procurar pela palavra no dicionário");
            Assert.AreEqual(expectedDeadCats, result.deadCats, "Número de gatos mortos incorretos");
        }

        [TestMethod()]
        public void SearchWord_WordDoesntExistTest()
        {
            // arrange
            string word = "XXXXXXXXXXXXXXXX";
            long expectedIndex = -1;
            long expectedDeadCats = 19;
            WordSearchService service = new WordSearchService(dictRepository);

            // act
            ProcessResult result = service.SearchWord(word);

            //assert
            Assert.AreEqual(expectedIndex, result.index, "Falha ao procurar pela palavra no dicionário");
            Assert.AreEqual(expectedDeadCats, result.deadCats, "Número de gatos mortos incorretos");
        }

        [TestMethod()]
        public void SearchWord_InvalidWordTest()
        {
            // arrange
            string word = "-1";
            long expectedIndex = -1;
            long expectedDeadCats = 1;
            WordSearchService service = new WordSearchService(dictRepository);

            // act
            ProcessResult result = service.SearchWord(word);

            //assert
            Assert.AreEqual(expectedIndex, result.index, "Falha ao procurar pela palavra no dicionário");
            Assert.AreEqual(expectedDeadCats, result.deadCats, "Número de gatos mortos incorretos");
        }

        [TestMethod()]
        public void SearchWord_InvalidWordUpperBoundTest()
        {
            // arrange
            string word = "Z9999999999999999999999999";
            long expectedIndex = -1;
            long expectedDeadCats = 19;
            WordSearchService service = new WordSearchService(dictRepository);

            // act
            ProcessResult result = service.SearchWord(word);

            //assert
            Assert.AreEqual(expectedIndex, result.index, "Falha ao procurar pela palavra no dicionário");
            Assert.AreEqual(expectedDeadCats, result.deadCats, "Número de gatos mortos incorretos");
        }

        [TestMethod()]
        public void SearchWord_CaseSensitiveWordTest()
        {
            // arrange
            string word = "alwAYs";
            long expectedIndex = 17;
            long expectedDeadCats = 11;
            WordSearchService service = new WordSearchService(dictRepository);

            // act
            ProcessResult result = service.SearchWord(word);

            //assert
            Assert.AreEqual(expectedIndex, result.index, "Falha ao procurar pela palavra case sensitive no dicionário");
            Assert.AreEqual(expectedDeadCats, result.deadCats, "Número de gatos mortos incorretos");
        }

    }
}