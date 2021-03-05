using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba1TuringMachine
{
    class TuringMachine
    {
        public static char[,,] statusTable;//первое измерение - реакции на алфавит согласно его порядку, второе - состояния, третье - набор действий(напр. _>2-заменить символ на _,сдвинуть вправо,перейти во второе состояние)
        public static char[] lenta;
        public static Dictionary<char,int> alphabet;
        public static void TuringMachineAlgorithm(Dictionary<char, int> alphabet, char[] lenta, int lentaIndexNow, char[,,] statusTable)
        {
            int statusNow = 1;
            int alphabetLetterNow = 0;
            
            while (statusNow != 0)
            {
                alphabetLetterNow = alphabet[lenta[lentaIndexNow]];
                lenta[lentaIndexNow] = statusTable[alphabetLetterNow, statusNow - 1, 0];
                if (statusTable[alphabetLetterNow, statusNow - 1, 1].Equals('>'))
                {
                    lentaIndexNow++;
                }
                if (statusTable[alphabetLetterNow, statusNow - 1, 1].Equals('<'))
                {
                    lentaIndexNow--;
                }
                statusNow = (int)Char.GetNumericValue(statusTable[alphabetLetterNow, statusNow - 1, 2]);
            }
        }

        static void Main(string[] args)
        {
            
            Dictionary<char, int> alphabet = new Dictionary<char, int>
            {
                ['a'] = 0,
                ['b'] = 1,
                ['_'] = 2
            };
            char[] lenta = { '_', '_', '_', '_', 'a', 'a', 'a', 'b', '_', '_', '_', '_' };
            int lentaIndexNow = 4; //мы договариваемся, что с самого начала головка стоит на первой позиции нужного нам слова
            char[,,] statusTable = {
                { { '_','>','2' } , { 'a','>','2' } , { 'a','>','3' } },
                { { '_','>','3' } , { 'b','>','2' } , { 'b','>','3' } },
                { { 'n','n','n' } , { 'a','.','0' } , { 'b','.','0' } }
            };
            Console.WriteLine(alphabet['a']);
            TuringMachineAlgorithm(alphabet, lenta, lentaIndexNow, statusTable);
            Console.WriteLine(lenta);

            Dictionary<char, int> alphabet1 = new Dictionary<char, int>
            {
                ['a'] = 0,
                ['b'] = 1,
                ['*'] = 2,
                ['_'] = 3
            };
            char[] lenta1 = { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', 'a', 'b', 'a', 'b', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_' };
            int lentaIndexNow1 = 12;
            char[,,] statusTable1 = {
                { { '*','<','4' } , { 'a','>','2' } , { 'a','.','1' } , { 'a','<','4' } , { 'a','<','5' } , { 'a','.','0' } },
                { { '*','<','5' } , { 'b','>','2' } , { 'b','.','1' } , { 'b','<','4' } , { 'b','<','5' } , { 'b','.','0' } },
                { { '*','.','6' } , { '*','>','3' } , { '*','>','3' } , { '*','<','4' } , { '*','<','5' } , { '_','<','6' } },
                { { '_','<','1' } , { 'n','n','n' } , { '_','.','1' } , { 'a','>','2' } , { 'b','>','2' } , { 'n','n','n' } }
            };
            TuringMachineAlgorithm(alphabet1, lenta1, lentaIndexNow1, statusTable1);
            Console.WriteLine(lenta1);
        }
    }
}
