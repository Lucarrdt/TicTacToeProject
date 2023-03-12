using TicTacToeProjectRiccardi;

public partial class MainPage : ContentPage
{
    private Game _game;

    public MainPage()
    {
        _game = new Game();
    }

    private Game GameInstance
    {
        get => _game;
        set => _game = value;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        int row = Grid.GetRow(clickedButton);
        int col = Grid.GetColumn(clickedButton);
        GameInstance.MakeMove(row, col);
    }

    private void OnNewGameButtonClicked(object sender, EventArgs e)
    {
        GameInstance.Reset();
    }
}