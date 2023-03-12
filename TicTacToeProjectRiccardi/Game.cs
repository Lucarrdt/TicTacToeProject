namespace TicTacToeProjectRiccardi;

public class Game
{
    private readonly int[,] _board = new int[5, 5];

    public int[,] Board => _board;
    
    public bool IsGameOver { get; private set; }
    
    public int Winner { get; private set; }
    
    public void MakeMove (int row, int col, int player)
    {
        if (IsGameOver)
            return;
        
        if (row is < 0 or > 2 || col is < 0 or > 2)
            return;
        
        if (_board[row, col] != 0)
            return;
        
        _board[row, col] = player;
        
        if (CheckForWinner())
        {
            IsGameOver = true;
            Winner = player;
        }
        else if (IsTie())
        {
            IsGameOver = true;
        }
    }
    private bool CheckForWinner()
    {
        // Checking rows
        for (int i = 0; i < 4; i++)
        {
            if (_board[i, 0] == _board[i, 1] && _board[i, 1] == _board[i, 2] && _board[i, 2] == _board[i, 3] && _board[i, 0] != 0)
                return true;
        }

        // Checking columns
        for (int j = 0; j < 3; j++)
        {
            if (_board[0, j] == _board[1, j] && _board[1, j] == _board[2, j] && _board[2, j] == _board[3, j] && _board[0, j] != 0)
                return true;
        }

        // Checking diagonals
        if (_board[0, 0] == _board[1, 1] && _board[1, 1] == _board[2, 2] && _board[2, 2] == _board[3, 3] && _board[0, 0] != 0)
            return true;

        if (_board[0, 3] == _board[1, 2] && _board[1, 2] == _board[2, 1] && _board[2, 1] == _board[3, 0] && _board[0, 3] != 0)
            return true;

        return false;
    }
    private bool IsTie()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_board[i, j] == 0)
                    return false;
            }
        }

        return true;
    }
}