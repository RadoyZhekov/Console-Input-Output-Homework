using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;


/*
Implement the "Falling Rocks" game in the text console.
A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys).
A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. The dwarf is (O).
Ensure a constant game speed by Thread.Sleep(150).
Implement collision detection and scoring system.
 */

namespace _12.FallingRocks
{
    struct Object
    {
        public int positionX;
        public int positionY;
        public char sign;
        public char dwarfSign;
        public ConsoleColor signColor;
    }

    class FallingRocks
    {
        static void PrintObjectOnPosition (int x, int y, char sign, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(sign);
        }
        static void PrintDwarfOnPosition (int x, int y, char dwarfSign, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(dwarfSign);
        }
        static void PrintStringOnPosition(int x, int y, string message, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(message);
        }
        static void Main(string[] args)
        {
            Console.Title = "Falling Rocks ver.1.02";
            int livesCount = 3;
            int livesMaxCount = 10;
            int traveled = 0;
            int highestTraveled = 0;
            int playFieldWidth = 30;
            char[] signList = new char[] {'@', '#', '$', '%', '&', '*', '~', 'v' };
            Console.BufferHeight = Console.WindowHeight = 15;
            Console.BufferWidth = Console.WindowWidth = 60;

            Object dwarf = new Object();
            dwarf.positionX = 2;
            dwarf.positionY = Console.WindowHeight - 1;
            dwarf.dwarfSign = '0';
            dwarf.signColor = ConsoleColor.Green;

            Random randomGenerator = new Random();
            List<Object> objects = new List<Object>();

            while (true)
            {
                traveled++;
                bool collision = false;
                {
                    // Generate objects
                    int chance = randomGenerator.Next(0, 100);
                    if (chance < 20)
                    {
                        // Don't spawn anything
                    }
                    else if (chance < 99)
                    {
                        // Generate obstacles(rocks)
                        Object newObstacle = new Object();
                        newObstacle.signColor = (ConsoleColor)randomGenerator.Next((int)ConsoleColor.Cyan, (int)ConsoleColor.Yellow);
                        newObstacle.sign = signList[randomGenerator.Next(0, 7)];
                        newObstacle.positionX = randomGenerator.Next(0, playFieldWidth);
                        newObstacle.positionY = 0;
                        objects.Add(newObstacle);
                    }
                    else
                    {
                        // Generate power-up(more lives)
                        Object newObstacle = new Object();
                        newObstacle.signColor = ConsoleColor.Green;
                        newObstacle.sign = '+';
                        newObstacle.positionX = randomGenerator.Next(0, playFieldWidth);
                        newObstacle.positionY = 0;
                        objects.Add(newObstacle);
                    }
                }

                // Move dwarf
                // Checks if anything is pressed so the game doesn't wait on us pressing anything
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                    // 'Til theres keypressed stored in the buffer, it will read it(FIX for continious pressing an arrow key)
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (dwarf.positionX - 1 >= 0)
                        {
                            dwarf.positionX = dwarf.positionX - 1;
                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (dwarf.positionX + 1 < playFieldWidth)
                        {
                            dwarf.positionX = dwarf.positionX + 1;
                        }
                    }
                }
                // Move objects(rocks)
                List<Object> newList = new List<Object>();
                for (int i = 0; i < objects.Count; i++)
                {
                    Object oldRock = objects[i];
                    Object newRock = new Object();
                    newRock.positionX = oldRock.positionX;
                    newRock.positionY = oldRock.positionY + 1;
                    newRock.sign = oldRock.sign;
                    newRock.signColor = oldRock.signColor;

                    // Check if object is new life
                    if (newRock.sign == '+' && newRock.positionY == dwarf.positionY && newRock.positionX == dwarf.positionX)
                    {
                        livesCount += 1;
                        if (livesCount > livesMaxCount)
                        {
                            livesCount = livesMaxCount;
                        }
                    }
                    // Check for collision happens
                    if (newRock.sign != '+' && newRock.positionY == dwarf.positionY && newRock.positionX == dwarf.positionX)
                    {
                        livesCount--;
                        collision = true;
                        if (traveled >= highestTraveled)
                        {
                            highestTraveled = traveled;
                        }
                        if (livesCount <= 0)
                        {
                            Console.Clear();
                            PrintStringOnPosition(4, 7, "GAME OVER!", ConsoleColor.Red);
                            PrintStringOnPosition(4, 8, "HIGSCORE: " + highestTraveled, ConsoleColor.White);
                            Console.WriteLine("\n");

                            // Saving HIGHSCORE to a text file textfile procedure below: (may need to create it if it doesn't exist and type in a single zero(0))
                            List<string> highscoreList = new List<string>();
                            string score = highestTraveled.ToString();
                            highscoreList.Add(score);
                            highscoreList.Sort();
                            string[] scoreString = highscoreList.ToArray();

                            // Gets the directory dynamicaly...or atleast I hope it does
                            string path = Directory.GetCurrentDirectory();
                            // Uncomment below to find out the directory and hardcode it if needed
                            //Console.WriteLine("The current directory is {0}", path);
                            string text = System.IO.File.ReadAllText(path + @"\Highscores.txt");
                            if (int.Parse(text) < highestTraveled)
                            {
                                TextWriter tw = new StreamWriter("Highscores.txt");
                                foreach (String str in scoreString)
                                {
                                    tw.WriteLine(str);
                                }
                                tw.Close();
                            }
                            text = System.IO.File.ReadAllText(path + @"\Highscores.txt");
                            System.Console.WriteLine("Highest score of them all = {0}", text);

                            Console.WriteLine("\n");


                            Environment.Exit(0);
                        }
                    }
                    if (newRock.positionY < Console.WindowHeight)
                    {
                        newList.Add(newRock);
                    }
                }
                objects = newList;
                // Clear the console after each itteration in the while cycle
                Console.Clear();
                // Redraw playfield after the console clear with new poisitons, etc...
                PrintDwarfOnPosition(dwarf.positionX, dwarf.positionY, dwarf.dwarfSign, dwarf.signColor);
                foreach (Object rock in objects)
                {
                    PrintObjectOnPosition(rock.positionX, rock.positionY, rock.sign, rock.signColor);
                }
                if (collision)
                {
                    Console.Beep();
                    traveled = 0;
                    objects.Clear();
                    PrintDwarfOnPosition(dwarf.positionX, dwarf.positionY, 'X', ConsoleColor.Red);
                }
                else
                {
                    PrintDwarfOnPosition(dwarf.positionX, dwarf.positionY, dwarf.dwarfSign, dwarf.signColor);
                }
                // Draw info panel
                PrintStringOnPosition(32, 1, "Help Gimli dodge", ConsoleColor.DarkYellow);
                PrintStringOnPosition(32, 2, "the nasty orc stones!", ConsoleColor.DarkYellow);
                PrintStringOnPosition(32, 3, "There's a princess", ConsoleColor.DarkYellow);
                PrintStringOnPosition(32, 4, "in the end...", ConsoleColor.DarkYellow);
                PrintStringOnPosition(32, 5, "             ...I swear.", ConsoleColor.DarkYellow);
                PrintStringOnPosition(32, 7, "Lives: " + livesCount + " /(" + livesMaxCount + ")", ConsoleColor.White);
                PrintStringOnPosition(32, 10, "Traveled: " + traveled + "/(" + highestTraveled + ")", ConsoleColor.White);
                // Slow down program
                Thread.Sleep(150);
            }
        }
    }
}
