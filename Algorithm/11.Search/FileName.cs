using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Search
{
    internal class FileName
    {
        // 11 22 실습
        bool[,] matrixGraph1 = new bool[8, 8]
        {
            { false, false,  true, false,  true, false, false, false},
            { false, false,  true, false, false,  true, false, false},
            {  true,  true, false, false, false,  true,  true, false},
            { false, false, false, false, false, false, false,  true},
            {  true, false, false, false, false, false, false,  true},
            { false, true,  true, false, false, false, false , false},
            { false, false,  true, false, false, false, false, false},
            { false, false, false,  true,  true, false, false, false}
        };
        const int INF = int.MaxValue;


        int[,] matrixGraph3 = new int[8, 8]
        {
            {  0, INF,   8, INF,   2, INF, INF, INF },
            {INF,   0, INF, INF, INF, INF,   9, INF },
            {  8, INF,   0, INF, INF, INF,   1, INF },
            {INF, INF, INF,   0, INF,   1, INF,   4 },
            {  2, INF, INF, INF,   0, INF, INF,   1 },
            {INF, INF, INF,   1, INF,   0, INF, INF },
            {INF,   9,   1, INF, INF, INF,   0, INF },
            {INF, INF, INF,   4,   1, INF, INF,   0 },
        };

    }
}
