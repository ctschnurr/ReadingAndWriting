using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingAndWriting
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] map = {"^^^''''''''",
                            "^^''''**'''",
                            "^^'''**''''",
                            "^''''''''''",
                            "''''~~~''''",
                            "''''~~~''''",
                            "'''~~~~''''",
                            "'''''~~~'''",
                            "'''''~~~~''",
                            "'''''''~'''",
                            "'''''''''''"};

            // System.IO.File.WriteAllLines(@"map.txt", map);

            // System.IO.File.WriteAllText(@".WriteLines2.txt", lines);

            string[] readMap = System.IO.File.ReadAllLines(@"readMap.txt");
            int mapwidth = readMap[0].Length;
            int mapheight = readMap.Count();
            char[,] Map = new char[mapheight,mapwidth];

            for (int x = 0; x < readMap.Length; x++)
            {
                char[] eatmap = readMap[x].ToCharArray();
                Array.Copy(eatmap, 0, Map, x, eatmap.Length);
            }

            

            Console.ReadKey(true);


        }

        static void DisplayMap()
        {

            for (int mapX = 0; mapX < mapHeight; mapX++)
            {
                Console.SetCursorPosition(0, mapX);
                for (int mapY = 0; mapY < mapWidth; mapY++)
                {
                    Console.Write(map[mapX, mapY]);
                }
                Console.WriteLine();
                Console.WriteLine("Raw Map Data");
            }

        }
    }
}
