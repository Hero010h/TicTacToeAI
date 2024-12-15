namespace TicTacToe;

internal class Grid
{
    private char[,] grid = new char[11, 20];
    private char[,] cross = new char[6, 3];
    private char[,] zero = new char[6, 3];

    public Grid()
    {
        string[] crossAsLine =
            {
            "         ",
            "  #   #  ",
            "    #    ",
            "  #   #  ",
            "         "
            };
        string[] zeroAsLine =
           {
            "         ",
            "  # # #  ",
            "  #   #  ",
            "  # # #  ",
            "         "
            };
        string[] gridAsLine = 
            {
            "                             ",
            "         #         #         ",
            "         #         #         ",
            "         #         #         ",
            "         #         #         ",
            " # # # # # # # # # # # # # # ",
            "         #         #         ",
            "         #         #         ",
            "         #         #         ",
            "         #         #         ",
            "         #         #         ",
            " # # # # # # # # # # # # # # ",
            "         #         #         ",
            "         #         #         ",
            "         #         #         ",
            "         #         #         ",
            "                             "

            };
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j] = gridAsLine[i][j];
            }
        }
        for (int i = 0; i < zero.GetLength(0); i++)
        {
            for (int j = 0; j < zero.GetLength(1); j++)
            {
                grid[i, j] = zeroAsLine[i][j];
            }
        }
        for (int i = 0; i < cross.GetLength(0); i++)
        {
            for (int j = 0; j < cross.GetLength(1); j++)
            {
                grid[i, j] = crossAsLine[i][j];
            }
        }
    }

    public void SetSymbol(int Y, int X, Symbol sym)
    {
        if (Y >= 3 || Y < 0 || X >= 3 || X < 0)
        { return; }

        
    }
}