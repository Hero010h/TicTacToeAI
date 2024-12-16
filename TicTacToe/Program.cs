using System.Reflection.Metadata;

namespace TicTacToe;

internal class Program
{
    static void Main(string[] args)
    {
        Map map = new Map();
        bool IsAIEneble;
        bool IsPlayerX;
        (int x, int y) gridPos;
        Symbol queue = Symbol.Cross;
        while (true)
        {
            int steps = 0;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            ConFRed();
            Console.Write("Крестики");
            ConFBlue();
            Console.WriteLine(" Нолики");
            ConStnd();
            Console.WriteLine(" -no AI Edition\n\nВыберете количество игроков: ");
       
            IsAIEneble = Equals(PlayersChoice([("1", ConsoleColor.Red, 1), ("2", ConsoleColor.Blue, 2)]), 1);
            if (IsAIEneble)
            {
                Console.Write("\n\nВыберете фигуру игрока: ");
                IsPlayerX = (bool)PlayersChoice([("X", ConsoleColor.Red, true), ("O", ConsoleColor.Blue, false)]);
            }

            Console.WriteLine("\n");
            gridPos = Console.GetCursorPosition();

            //Цикл игры
            while (true)
            {
                // Рисую поле
                ConStnd();
                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.SetCursorPosition(gridPos.x + j * 2, gridPos.y + i);
                        switch (map.Field[i, j])
                        {
                            case Symbol.None:
                                ConStnd();
                                Console.Write('*');
                                break;

                            case Symbol.Cross:
                                ConFRed();
                                Console.Write('X');
                                break;

                            case Symbol.Zero:
                                ConFBlue();
                                Console.Write('O');
                                break;
                        }
                    }
                }
                ConFGray();
                Console.Write("\n\n1 2 3\n4 5 6\n7 8 9");
                if (IsAIEneble)
                {
                    Console.WriteLine("Эта функция в разработке...");
                }
                else
                {
                    char key = Console.ReadKey(true).KeyChar;
                    switch (key)
                    {
                        case '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9':
                            int inp = int.Parse(key.ToString());
                            if (inp > 6)
                            {
                                map.SetSymbol(2, inp - 7, queue);
                            }
                            else if (inp > 3)
                            {
                                map.SetSymbol(1, inp - 4, queue);
                            }
                            else
                            {
                                map.SetSymbol(0, inp - 1, queue);
                            }
                            if (queue == Symbol.Zero)
                            {
                                queue = Symbol.Cross;
                            }
                            else
                            {
                                queue = Symbol.Zero;
                            }
                            steps++;
                            break;
                    }
                }
                if (map.CheckWiners() != Symbol.None)
                {
                    ConStnd();
                    Console.Write("\nПобедил ");
                    switch (queue)
                    {
                        case Symbol.Cross:
                            ConFBlue();
                            Console.Write("Нолик");
                            break;

                        case Symbol.Zero:
                            ConFRed();
                            Console.Write("Крестик");
                            break;
                    }
                    ConStnd();
                    Console.Write('!');
                    Console.ReadKey(true);
                    break;
                }
                else if (steps == 9)
                {
                    ConStnd();
                    Console.Write("Ничья!");
                    Console.ReadKey(true);
                    break;
                }
            }
            map.ResetField();
        }

        //Позволяет делать крутые выборы
        object PlayersChoice((string Name, ConsoleColor Color, object returnObj)[] options)
        {
            ConsoleKeyInfo key;
            int usersChoice = 0;
            (int X, int Y) cursorPos = Console.GetCursorPosition();

            Console.CursorVisible = false;
            while (true)
            {
                /*if (maxLenght != 0)
                {
                    bool[,] matrix = new bool[options.Length / maxLenght + options.Length%maxLenght, maxLenght];

                }*/

                //Делает пользовательский выбор зацикленным
                if (usersChoice >= options.Length)
                {
                    usersChoice = 0;
                }
                else if (usersChoice < 0)
                {
                    usersChoice = options.Length - 1;
                }

                //Отрисовка выбора
                for (int i = 0; i < options.Length; i++)
                {
                    ConStnd();
                    if (i == usersChoice)
                    {
                        Console.BackgroundColor = options[i].Color;
                        Console.Write(options[i].Name);
                    }
                    else
                    {
                        Console.ForegroundColor = options[i].Color;
                        Console.Write(options[i].Name);
                    }
                    ConStnd();
                    Console.Write("  ");
                }
                key = Console.ReadKey(true);

                //Определение ввода
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow or ConsoleKey.A:
                        usersChoice--;
                        break;

                    case ConsoleKey.RightArrow or ConsoleKey.D:
                        usersChoice++;
                        break;

                    case ConsoleKey.DownArrow or ConsoleKey.S:
                        usersChoice = options.Length - 1;
                        break;

                    case ConsoleKey.UpArrow or ConsoleKey.W:
                        usersChoice = 0;
                        break;

                    case ConsoleKey.Spacebar or ConsoleKey.Enter:
                        return options[usersChoice].returnObj;
                }
                Console.SetCursorPosition(cursorPos.X, cursorPos.Y);
            }
        }

        //Простые функции для уменьшения объёма кода
        //Из названия, думаю, всё понятно
        void ConFGray() => Console.ForegroundColor= ConsoleColor.DarkGray;
        void ConFRed() => Console.ForegroundColor = ConsoleColor.Red;
        void ConFBlue() => Console.ForegroundColor = ConsoleColor.Blue;
        void ConStnd() { Console.ForegroundColor = ConsoleColor.White; Console.BackgroundColor = ConsoleColor.Black; }
    }
}