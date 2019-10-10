using System;
using System.Collections.Generic;
using ConsoleUI;
using GameEngine;
using MenuSystem;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Clear();

            Console.WriteLine("Hello Game!");

            var menuLevel2 = new Menu(2)
            {
                Title = "Level2 menu",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "1", new MenuItem()
                        {
                            Title = "Nothing here",
                            CommandToExecute = null
                        }
                    },
                }
            };


            var gameMenu = new Menu(1)
            {
                Title = "Start a new game of connect 4",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "1", new MenuItem()
                        {
                            Title = "Computer starts",
                            CommandToExecute = TestGame
                        }
                    },

                    {
                        "2", new MenuItem()
                        {
                            Title = "One more menu",
                            CommandToExecute = menuLevel2.Run
                        }
                    },
                }
            };



            var menu0 = new Menu(0)
            {
                Title = "Tic Tac Toe Main Menu",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "S", new MenuItem()
                        {
                            Title = "Start game",
                            CommandToExecute = gameMenu.Run
                        }
                    }
                }
            };


            menu0.Run();
        }

        static string TestGame()
        {
            var game = new Game(7, 7);
            var done = false;
            do
            {
                Console.Clear();
                GameUI.PrintBoard(game);

                var userXint = 0;
                var userCanceled = false;

                (userXint, userCanceled) = GetUserIntInput("Enter X coordinate", 1, 7, 0);
                if (userCanceled)
                {
                    done = true;
                }
                else
                {
                    done = game.Move(userXint - 1);
                    GameUI.PrintBoard(game);
                }


            } while (!done);


            return "GAME OVER!!";
        }

        static string Move() {

            return "asd";
        }

        static (int result, bool wasCanceled) GetUserIntInput(string prompt, int min, int max, int? cancelIntValue = null, string cancelStrValue = "")
        {
            do
            {
                Console.WriteLine(prompt);
                if (cancelIntValue.HasValue || !string.IsNullOrWhiteSpace(cancelStrValue))
                {
                    Console.WriteLine($"To cancel input enter: {cancelIntValue}" +
                                      $"{ (cancelIntValue.HasValue && !string.IsNullOrWhiteSpace(cancelStrValue) ? " or " : "") }" +
                                      $"{cancelStrValue}");
                }

                Console.Write(">");
                var consoleLine = Console.ReadLine();

                if (consoleLine == cancelStrValue) return (0, true);

                if (int.TryParse(consoleLine, out var userInt))
                {
                    return userInt == cancelIntValue ? (userInt, true) : (userInt, false);
                }

                Console.WriteLine($"'{consoleLine}' cant be converted to int value!");
            } while (true);

            return (0, true);
        }

    }
}
