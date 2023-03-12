namespace TicTacToeProjectRiccardi;
public class Game
{
    private int[,] _board;
    private readonly int _size;
    private readonly int _winningCount;
    private int _currentPlayer = 1;

    public Game(int size = 3, int winningCount = 3)
    {
        if (size < 2 || winningCount < 2 || winningCount > size)
        {
            throw new ArgumentException("Invalid board size or winning count.");
        }

        _size = size;
        _winningCount = winningCount;
        _board = new int[_size, _size];
    }

    public int[,] Board => _board;

    public bool IsGameOver { get; private set; }

    public int Winner { get; private set; }
    
    public int CurrentPlayer => _currentPlayer;

    public void MakeMove(int row, int col)
    {
        if (IsGameOver)
        {
            throw new InvalidOperationException("The game is already over.");
        }

        if (row < 0 || row >= _size || col < 0 || col >= _size)
        {
            throw new ArgumentException("Invalid move: row or column out of bounds.");
        }

        if (_board[row, col] != 0)
        {
            throw new ArgumentException("Invalid move: cell is already occupied.");
        }

        _board[row, col] = _currentPlayer;

        if (CheckForWinner())
        {
            IsGameOver = true;
            Winner = _currentPlayer;
        }
        if (CheckForTie())
        {
            IsGameOver = true;
            Winner = 0;
        }
    }
    private bool CheckForWinner()
    {
        // Check rows
        for (int row = 0; row < _size; row++)
        {
            int count = 0;
            int lastPlayer = 0;
            for (int col = 0; col < _size; col++)
            {
                int player = _board[row, col];
                if (player == 0 || player != lastPlayer)
                {
                    count = 1;
                    lastPlayer = player;
                }
                else
                {
                    count++;
                }

                if (count == _winningCount)
                {
                    return true;
                }
            }
        }

        // Check columns
        for (int col = 0; col < _size; col++)
        {
            int count = 0;
            int lastPlayer = 0;
            for (int row = 0; row < _size; row++)
            {
                int player = _board[row, col];
                if (player == 0 || player != lastPlayer)
                {
                    count = 1;
                    lastPlayer = player;
                }
                else
                {
                    count++;
                }

                if (count == _winningCount)
                {
                    return true;
                }
            }
        }

        // Check diagonals from top-left to bottom-right
        for (int startRow = 0; startRow <= _size - _winningCount; startRow++)
        {
            for (int startCol = 0; startCol <= _size - _winningCount; startCol++)
            {
                int count = 0;
                int lastPlayer = 0;
                for (int i = 0; i < _winningCount; i++)
                {
                    int player = _board[startRow + i, startCol + i];
                    if (player == 0 || player != lastPlayer)
                    {
                        count = 1;
                        lastPlayer = player;
                    }
                    else
                    {
                        count++;
                    }

                    if (count == _winningCount)
                    {
                        return true;
                    }
                }
            }
        }

        // Check diagonals from top-right to bottom-left
        for (int startRow = 0; startRow <= _size - _winningCount; startRow++)
        {
            for (int startCol = _winningCount - 1; startCol < _size; startCol++)
            {
                int count = 0;
                int lastPlayer = 0;
                for (int i = 0; i < _winningCount; i++)
                {
                    int player = _board[startRow + i, startCol - i];
                    if (player == 0 || player != lastPlayer)
                    {
                        count = 1;
                        lastPlayer = player;
                    }
                    else
                    {
                        count++;
                    }

                    if (count == _winningCount)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
    private bool CheckForTie()
    {
        for (int row = 0; row < _size; row++)
        {
            for (int col = 0; col < _size; col++)
            {
                if (_board[row, col] == 0)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void GameReset()
    {
        _board = new int[_size, _size];
        IsGameOver = false;
        Winner = 0;
        _currentPlayer = 1;
    }
}