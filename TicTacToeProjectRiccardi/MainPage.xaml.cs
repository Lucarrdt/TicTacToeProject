using TicTacToeProjectRiccardi;

public partial class MainPage : ContentPage
{
    private Game _game;

    public MainPage()
    {
        InitializeComponent();
        _game = new Game();
    }
}