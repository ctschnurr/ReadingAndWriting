using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingAndWriting
{
    internal class Program
    {

        static string name;
        static string[] readMap;

        static char[,] map;

        static void Main(string[] args)
        {
            if (System.IO.File.Exists("name.txt"))
            {
                name = System.IO.File.ReadAllText(@"name.txt");

                Console.WriteLine("Welcome back, " + name + "!");
                Console.WriteLine();
                Console.WriteLine("(L)oad Map File");
                Console.WriteLine("(I)'m not " + name + "!");
                
                ConsoleKeyInfo choice = Console.ReadKey(true);

                if (choice.Key == ConsoleKey.I)
                {
                    ChangeName();
                }
            }

            else
            {
                Console.WriteLine("Please enter your name, I'll remember you next time!");
                name = Console.ReadLine();

                System.IO.File.Create(@"name.txt").Close();
                System.IO.File.WriteAllText(@"name.txt", name);

            }

            if (System.IO.File.Exists("map.txt") == true)
            {
                readMap = System.IO.File.ReadAllLines(@"map.txt");

                int mapWidth = readMap[0].Length;
                int mapHeight = readMap.Count();

                map = new char[mapHeight, mapWidth];

                Console.WriteLine();
                Console.WriteLine("Map Load Successful");
                Console.ReadKey(true);

                Console.Clear();

                for (int y = 0; y < readMap.Length; y++)
                {
                    int next = 0;
                    foreach (char letter in readMap[y])
                    {
                        map[y, next] = letter;
                        next++;
                    }
                }

                DisplayMap(mapHeight, mapWidth);
                Console.WriteLine();
                Console.WriteLine("Press any key to close program.");
                Console.WriteLine();
                Console.ReadKey(true);


            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Map file not found.");
                Console.ReadKey(true);
            }

            
        }

        static void DisplayMap(int mapHeight, int mapWidth)
        {

            for (int mapX = 0; mapX < mapHeight; mapX++)
            {
                Console.SetCursorPosition(0, mapX);
                for (int mapY = 0; mapY < mapWidth; mapY++)
                {
                    Console.Write(map[mapX, mapY]);
                }
            }
        }

        static void ChangeName()
        {
            Console.Clear();
            Console.WriteLine("Please enter your name:");
            string nameSave = Console.ReadLine();

            System.IO.File.WriteAllText(@"name.txt", nameSave);

            Console.WriteLine("Thank you, " + nameSave + "! I'll remember you for next time.");
        }
    }
}
