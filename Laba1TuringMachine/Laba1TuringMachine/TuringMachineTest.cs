using System;
using System.Collections.Generic;
using System.Text;

namespace Laba1TuringMachine
{
    class TuringMachineTest
    {
        public static char[,,] statusTable = {
            { { '_','>','2' },{ 'a','>','2' },{ 'a','>','3' } },
            { { '_','>','3' },{ 'b','>','2' },{ 'b','>','3' } },
            { { 'n','n','n' } ,{ 'a','.','0' },{ 'b','.','0' } }

        };//первое измерение - реакции на алфавит согласно его порядку, второе - состояния, третье - набор действий(напр. _>2-заменить символ на _,сдвинуть вправо,перейти во второе состояние)
        public static string lenta = "____aaab____";
        public static char[] alphabet = { 'a', 'b', '_' };

        
    }
}
