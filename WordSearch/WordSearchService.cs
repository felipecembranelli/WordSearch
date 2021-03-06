﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordSearch
{
    public class WordSearchService
    {
        IDictionary dictRepository;

        /// <summary>
        /// Espera a injeção do repositório
        /// </summary>
        /// <param name="repository"></param>
        public WordSearchService(IDictionary repository)
        {
            dictRepository = repository;
        }

        /// <summary>
        /// Busca a palavra dentro do dicionário aplicando binarySearch em 2 sentidos: 
        /// 1) Ascendente: até encontrar uma palavra "maior" que a procurada. Se não encontrar, faz a busca descendente.
        /// 2) Descendente: a partir da posição que parou na ascendente, realiza a busca binária.
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Retorna a posição da palavra no dicionário</returns>
        public ProcessResult SearchWord(string word)
        {

            // recupera o ponteiro inicial no helperDict
            long initialPointer = 0;

            // começa a busca ascendente a partir deste ponteiro
            ProcessResult resultForward = SearchForward(word, initialPointer, 0, 0);

            // se não encontrou ainda , faz a busca descendente
            if (!resultForward.found)
            {
                ProcessResult resultBackward = SearchBackward(word, resultForward.index, resultForward.deadCats);

                if (!resultBackward.found)
                    return new ProcessResult { deadCats = resultBackward.deadCats, index = -1, found = false };
                else
                    return resultBackward;
            }
            else
                return resultForward;
        }

        /// 1) Busca Ascendente: até encontrar uma palavra "maior" que a procurada. 
        private ProcessResult SearchForward(string word, long index, int power, int catKillerCounter)
        {
            ///////////////////////////////////////////////
            // Busca ascendente
            ///////////////////////////////////////////////

            while (true)
            {
                // Procura por uma palavra no dicionário
                string returnedWord = dictRepository.GetWordFromDictionary(index);

                catKillerCounter++;

                // Se não encontrou, significa que caiu fora do range do dicionário (out of index)
                if (returnedWord == null)
                    break;

                // Verifica se a palavra procurada está posicionada antes ou depois dentro do dicionário
                int compare = String.Compare(returnedWord, word, true);

                // Se encontrou a palavra
                if (compare == 0)
                    return new ProcessResult { deadCats = catKillerCounter, index = index, found = true };
                else if (compare < 0)       // Se a palavra está depois
                {
                    index = (long)Math.Pow(2, power);
                    power++;
                }
                else
                    break;  // Se a palavra está antes, para a busca ascendente
            }

            return new ProcessResult { deadCats = catKillerCounter, index = index, found = false };
        }

        /// 2) Busca Descendente: até encontrar uma palavra "maior" que a procurada. 
        private ProcessResult SearchBackward(string word, long index, int catKillerCounter)
        {
            ///////////////////////////////////////////////
            // Busca descendente
            ///////////////////////////////////////////////
            long leftPointer = (index / 2) + 1;
            long rightPointer = index - 1;
            long middle = 0;

            while (leftPointer <= rightPointer)
            {
                middle = leftPointer + (rightPointer - leftPointer) / 2;

                string returnedWord = dictRepository.GetWordFromDictionary(middle);

                catKillerCounter++;

                // Procura por uma palavra no dicionário
                int compare = String.Compare(returnedWord, word, true);

                // Se não encontrou, significa que caiu fora do range do dicionário (out of index)
                // reposiciona ponteiro superior
                if (returnedWord == null)
                    rightPointer = middle - 1;
                else
                {
                    // Se encontrou a palavra
                    if (compare == 0)
                        return new ProcessResult { deadCats = catKillerCounter, index = middle, found = true };
                    else if (compare < 0)
                        leftPointer = middle + 1;       // Se a palavra está depois
                    else
                        rightPointer = middle - 1;      // Se a palavra está antes
                }
            }

            return new ProcessResult { deadCats = catKillerCounter, index = index, found = false };
        }

    }
}
