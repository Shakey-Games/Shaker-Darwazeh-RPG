using RPG.gameclasses;
using System;

namespace RPG
{
    internal class Program
    {
        private static Actor player; // Declare player at the class level
        private static Room[] map; // Make map static

        static void Main()
        {
            SetColour("normal");
            Console.Clear();
            Console.WriteLine("RPG\n\n1) Play\n2) Tutorial\n3) Quit\n\n");
            Console.Write("> ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Game();
                    break;
                case "2":
                    Tutorial();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Main();
                    break;
            }
        }

        static void Game()
        {
            Initialise();
            Console.Clear();

            string input;
            string output;


            Console.WriteLine($"{player.location.name.ToUpper()}\n==========\n{player.location.description}\n\n");
            do
            {
                Console.Write("> ");
                SetColour("input");
                input = Console.ReadLine();
                output = RunCommand(input);
                Console.WriteLine(output);
                SetColour("normal");

            } while (input != "q");

        }

        public static string RunCommand(string command)
        {
            string output = "";
            string tidyCommand = command.Trim().ToLower();
            if (tidyCommand != "q")
            {
                if (tidyCommand == "") { SetColour("error"); output = "You must enter a command."; }
                else
                {
                    List<string> stringList = new List<string>(tidyCommand.Split(" ", StringSplitOptions.TrimEntries));
                    output = ParseCommand(stringList);
                }
            }
            return output;

        }

        public static string ParseCommand(List<string> wordList)
        {
            SetColour("error");
            string verb, noun, returnString;
            returnString = "";
            List<string> acceptedVerbs = new List<string>() { "go", "take", "drop" };
            List<string> acceptedNouns = new List<string>() { "north", "south", "east", "west", "n", "s", "e", "w",
                "sword", "ring" };

            if (wordList.Count != 2)
            {
                returnString = "Exactly two command words allowed (Verb then Noun).";
            }
            else
            {
                verb = wordList[0]; noun = wordList[1];
                if (!acceptedVerbs.Contains(verb)) 
                { 
                    return $"{verb} is not a known verb!"; 
                }
                else if (!acceptedNouns.Contains(noun)) { return $"{noun} is not a known noun!"; }
                else
                {
                    SetColour("normal");
                    switch (verb)
                    {
                        case "go":
                            switch (noun)
                            {
                                case "north" or "n":
                                    returnString = MovePlayer(player.location.north);
                                    break;
                                case "south" or "s":
                                    returnString = MovePlayer(player.location.south);
                                    break;
                                case "east" or "e":
                                    returnString = MovePlayer(player.location.east);
                                    break;
                                case "west" or "w":
                                    returnString = MovePlayer(player.location.west);
                                    break;
                            }
                            break;
                        default:
                            returnString = "Command valid but not coded in yet.";
                            break;
                    }
                }
            }

            return returnString;
        }

        public static void Initialise()
        {
            map = new Room[2];
            map[0] = new Room("House", "your very own home.", 1, -1, -1, -1);
            map[1] = new Room("Front Garden", "the front garden of your house.", -1, 0, -1, -1);

            player = new Actor("Player", "You.", map[0]); // Initialize player

        }

        static void Tutorial()
        {
            Console.WriteLine("WIP");
            Console.ReadKey();
            Main();
        }

        public static void SetColour(string colour)
        {
            switch (colour)
            {
                case "error":
                    Console.ForegroundColor = ConsoleColor.Red; break;
                case "normal":
                    Console.ResetColor(); break;
                case "input":
                    Console.ForegroundColor = ConsoleColor.Green; break;
            }
        }

        public static string MovePlayer(int newPos)
        {
            string returnString;
            if (newPos == -1)
            {
                SetColour("error");
                returnString = "You can't go that way!";
            }
            else
            {
                player.location = map[newPos]; 
                SetColour("normal");
                returnString = $"\n{player.location.name.ToUpper()}\n==========\n{player.location.description}\n\n";
            }
            return returnString;
        }
    }
}
