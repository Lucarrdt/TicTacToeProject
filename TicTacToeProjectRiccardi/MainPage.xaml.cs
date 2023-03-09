namespace TicTacToeProjectRiccardi;

public partial class MainPage : ContentPage
{
    private readonly Game _game = new Game();
    public MainPage()
    {
        InitializeComponent();
        
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}