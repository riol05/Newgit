using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._PathFinding
{
    internal class Tilemap
    {
        /******************************************************
		 * 타일맵 (Tilemap)
		 * 
		 * 2차원 평면의 그래프를 정점이 아닌 위치를 통해 표현하는 그래프
		 * 위치의 이동가능 유무만을 가지는 타일맵과,
		 * 타일의 종류를 표현한 이차원 타일맵이 있음
		 * 인접한 이동가능한 위치간 간선이 있으며 가중치는 동일함
		 ******************************************************/

        // <타일맵 그래프>
        // 예시 - 위치의 이동가능 표현한 이차원 타일맵
        // 인접 행렬 그래프 -> [출발정점, 도착정점]
        // 타일맵 그래프 -> [Y위치, X위치]
        bool[,] tileMap1 = new bool[7, 7]
        {
            { false, false, false, false, false, false, false }, //2차원 평면에서 타일맵을 만드는 방법
            { false,  true, false,  true, false, false, false },//[1,0] 갈수 없는 벽이다. [1,1]은 갈수 있는 길이다. 로 표현
            { false,  true, false,  true, false,  true, false },
            { false,  true, false,  true,  true,  true, false },
            { false,  true, false,  true, false, false, false },
            { false,  true,  true,  true,  true,  true, false },
            { false, false, false, false, false, false, false },
        };
        /*
		 * ■ ■ ■ ■ ■ ■ ■ // 네모는 벽이다. // 빈곳은 갈수있는 평지다.
		 * ■    ■    ■ ■ ■    // 갈수있는 지형은 true // 갈수 없는곳은 False로 타일맵으로 배분
		 * ■    ■    ■    ■
		 * ■    ■          ■
		 * ■    ■    ■ ■ ■
		 * ■                ■
		 * ■ ■ ■ ■ ■ ■ ■
		 */

        // 예시 - 타일의 종류를 표현한 이차원 타일맵
        enum TileType
        {
            None = ' ',
            Wall = '■',
            Path = '*',
            Start = 'S',
            Goal = 'E',
        }

        char[,] tileMap2 = new char[9, 9]
        {
            { '■', '■', '■', '■', '■', '■', '■', '■', '■' },
            { '■', 'S' , '■', '■', ' ' , ' ' , '■', '■', '■' },
            { '■', '*' , '■', '■', ' ' , '■', '■', ' ' , '■' },
            { '■', '*' , '■', '■', ' ' , '■', '■', ' ' , '■' },
            { '■', '*' , '■', '*' , '*' , '*' , '*' , '*' , '■' },
            { '■', '*' , '■', '*' , '■', '■', '■', '*' , '■' },
            { '■', '*' , '■', '*' , '■', '■', '■', '*' , '■' },
            { '■', '*' , '*' , '*' , '■', '■', '■', 'E' , '■' },
            { '■', '■', '■', '■', '■', '■', '■', '■', '■' },
        };
        /*
		 * ■ ■ ■ ■ ■ ■ ■ ■ ■
		 * ■ S  ■ ■       ■ ■ ■
		 * ■ *  ■ ■    ■ ■    ■
		 * ■ *  ■ ■    ■ ■    ■
		 * ■ *  ■ *  *  *  *  *  ■
		 * ■ *  ■ *  ■ ■ ■ *  ■
		 * ■ *  ■ *  ■ ■ ■ *  ■
		 * ■ *  *  *  ■ ■ ■ E  ■
		 * ■ ■ ■ ■ ■ ■ ■ ■ ■
		 */
    }
}