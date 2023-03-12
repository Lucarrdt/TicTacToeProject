namespace TicTacToeProjectRiccardi;

public partial class MainPage : ContentPage
{
    private Game _game;

    public MainPage()
    {
        _game = new Game();
        InitializeComponent();
    }
    

    private Game GameInstance
    {
        get => _game;
        set => _game = value;
    }

    private void Button_Clicked(object sender, EventArgs e) // This is the event handler for the 9 buttons that make up the game board and have the same name as the button in the XAML file (Button_Clicked)
    {
        Button clickedButton = sender as Button;
        int row = Grid.GetRow(clickedButton);
        int col = Grid.GetColumn(clickedButton);
        GameInstance.MakeMove(row, col);
    }

    private void OnNewGameButtonClicked(object sender, EventArgs e) // This is the event handler for the New Game button
    {
        GameInstance.GameReset();
    }
}