namespace ConsoleHelper
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ChoiceMenu
    {
        public Settings _settings;
        public List<MenuItem> Options { get; }
        public ChoiceMenu(Settings settings = null)
        {
            if (settings == null)
            {
                settings = new Settings
                {
                    IntroText = "Please choice:",
                    Selection = "*",
                    SelectionColor = ConsoleColor.Yellow
                };

            }

            _settings = settings;
            Options = new List<MenuItem>();


        }

        public MenuItem ReadChoice(bool canCancel = false)
        {
            Console.Clear();
            if (Options.Count > 0)
            {
                if (!string.IsNullOrEmpty(_settings.IntroText))
                {
                    Console.WriteLine($"{Environment.NewLine}{_settings.IntroText}");
                }

                int x = 0;
                int y = 15;
                int currentSelection = 0;

                ConsoleKey key;
                Console.CursorVisible = false;
                
                do
                {
                    for (int i = 0; i < Options.Count; i++)
                    {
                        Console.SetCursorPosition(x,y + i);

                        if (i == currentSelection)
                        {
                            Console.ForegroundColor = _settings.SelectionColor;
                            Console.WriteLine($"{_settings.Selection} {Options[i].Title}");
                        }
                        else
                        {
                            Console.WriteLine($"{string.Empty.PadLeft(_settings.Selection.Length + 1)}{Options[i].Title}");
                        }

                        Console.ResetColor();
                    }

                    key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            {
                                if (currentSelection >= 1)
                                    currentSelection -= 1;
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                if (currentSelection < Options.Count - 1)
                                    currentSelection += 1;
                                break;
                            }
                        case ConsoleKey.Escape:
                            {
                                if (canCancel)
                                    return null;
                                break;
                            }
                    }
                } while (key != ConsoleKey.Enter);

                Console.CursorVisible = true;
                Console.SetCursorPosition(0, Console.CursorTop + 2);

                return Options[currentSelection];
            }

            return null;
        }


    }
}
