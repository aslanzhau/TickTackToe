using System.Windows;
namespace TicTacToe;
public partial class ClickerGame : Window
{
    public ClickerGame()
    {
        InitializeComponent();
        
    }
    public int Score = 666665;
    public int ValuePerClick = 1;
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Score += ValuePerClick;
        Counter.Text = $"Clicks: {Score}";
    }
    private void ButtonShopClick(object sender, RoutedEventArgs e)
    {
        Upgrades shop = new Upgrades(this);
        shop.Show();
        this.Hide();
    }
    
}