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
        static IDictionary dictRepository;

        [ClassInitialize]
        public static void Setup(TestContext ctx)
        {
            dictRepository = new DictionaryRepositoryFake();
        }

        /// <summary>
        /// Testa o limit inferior do dicionário, esperando encontrar a primeira
        /// na primeira posição
        /// </summary>
        [TestMethod()]
        public void WordSearchService_SearchLowestWord_RendersLowestPosition()
        {
            // arrange
            string word = "a";
            long expectedIndex = 0;
            WordSearchService service = new WordSearchService(dictRepository);

            // act
            ProcessResult result = service.SearchWord(word);

            //assert
            Assert.AreEqual(expectedIndex, result.index,"Falha ao procurar pela primeira palavra do dicionário");
        }


        /// <summary>
        /// Testa o limit inferior do dicionário, esperando matar somente 1 gato
        /// </summary>
        [TestMethod()]
        public void WordSearchService_SearchLowestWord_RendersOneCatDead()
        {
            // arrange
            string word = "a";
            int expectedDeadCats = 1;
            WordSearchService service = new WordSearchService(dictRepository);

            // act
            ProcessResult result = service.SearchWord(word);

            //assert
            Assert.AreEqual(expectedDeadCats, result.deadCats, "Número de gatos mortos incorretos");
        }

        /// <summary>
        /// Testa o limite superior do dicionário. Espera encontrar a palavra 
        /// no limite superior do dicionário
        /// </summary>
        [TestMethod()]
        public void WordSearchService_SearchHighestWord_RendersHighestPosition()
        {
            // arrange
            string word = "may";
            long expectedIndex = 491;
            WordSearchService service = new WordSearchService(dictRepository);

            // act
            ProcessResult result = service.SearchWord(word);

            //assert
            Assert.AreEqual(expectedIndex, result.index, "Falha ao procurar pela última palavra do dicionário");
        }

        /// <summary>
        /// Testa o limite superior do dicionário. Espera matar um número máximo de gatos.
        /// </summary>
        [TestMethod()]
        public void WordSearchService_SearchHighestWord_RendersMaxNumberOfDeadCats()
        {
            // arrange
            string word = "may";
            long expectedDeadCats = 19;
            WordSearchService service = new WordSearchService(dictRepository);

            // act
            ProcessResult result = service.SearchWord(word);

            //assert
            Assert.AreEqual(expectedDeadCats, result.deadCats, "Número de gatos mortos incorretos");
        }

        /// <summary>
        /// Procura por uma determinada palavra no dicionário.
        /// </summary>
        [TestMethod()]
        public void WordSearchService_SearchWordExists_RendersWordPosition()
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


        /// <summary>
        /// Procura por uma palavra que não existe no dicionário.
        /// </summary>
        [TestMethod()]
        public void WordSearchService_SearchWordDoesntExists_RendersNotFound()
        {
            // arrange
            string word = "XXXXXXXXXXXXXXXX";
            long expectedIndex = -1;
            WordSearchService service = new WordSearchService(dictRepository);

            // act
            ProcessResult result = service.SearchWord(word);

            //assert
            Assert.AreEqual(expectedIndex, result.index, "Falha ao procurar pela palavra no dicionário");
        }

        /// <summary>
        /// Procura por uma palavra com caracteres inválidos.
        /// </summary>
        [TestMethod()]
        public void WordSearchService_SearchInvalidWord_RendersNotFound()
        {
            // arrange
            string word = "x1???zx/";
            long expectedIndex = -1;
            WordSearchService service = new WordSearchService(dictRepository);

            // act
            ProcessResult result = service.SearchWord(word);

            //assert
            Assert.AreEqual(expectedIndex, result.index, "Falha ao procurar pela palavra no dicionário");
        }


        /// <summary>
        /// Procura por uma palavra "Null"
        /// </summary>
        [TestMethod()]
        public void WordSearchService_SearchNullWord_RendersNotFound()
        {
            // arrange
            string word = null;
            long expectedIndex = -1;
            WordSearchService service = new WordSearchService(dictRepository);

            // act
            ProcessResult result = service.SearchWord(word);

            //assert
            Assert.AreEqual(expectedIndex, result.index, "Falha ao procurar pela palavra no dicionário");
        }


        /// <summary>
        /// Procura por uma palavra utilizando caracteres maiúsculos/mínusculos
        /// </summary>
        [TestMethod()]
        public void WordSearchService_SearchWordCaseSensitive_RendersWordPosition()
        {
            // arrange
            string word = "alwAYs";
            long expectedIndex = 17;
            WordSearchService service = new WordSearchService(dictRepository);

            // act
            ProcessResult result = service.SearchWord(word);

            //assert
            Assert.AreEqual(expectedIndex, result.index, "Falha ao procurar pela palavra case sensitive no dicionário");
        }

    }
}