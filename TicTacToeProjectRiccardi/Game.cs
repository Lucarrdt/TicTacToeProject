namespace TicTacToeProjectRiccardi;

public class Game
{
    private readonly int[,] _board = new int[3, 3]; //This represents the board

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
    }

    private bool CheckForWinner()
    {
        //Checking rows
        for (int i = 0; i < 3; i++)
        {
            if (_board[i, 0] == _board[i, 1] && _board[i, 1] == _board[i, 2] && _board[i, 0] != 0)
                return true;

            if (_board[0, i] == _board[1, i] && _board[1, i] == _board[2, i] && _board[0, i] != 0)
                return true;

            if (_board[0, 0] == _board[1, 1] && _board[1, 1] == _board[2, 2] && _board[0, 0] != 0)
                return true;
            
            if (_board[0, 2] == _board[1, 1] && _board[1, 1] == _board[2, 0] && _board[0, 2] != 0)
                return true;
        }

        return false;
    }
}