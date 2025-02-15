using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe;

public partial class Upgrades : Window
{
    ClickerGame _mainGame;
    TextBox scoreBox = new TextBox();
    public Upgrades(ClickerGame mainGame)
    {
        InitializeComponent();
        _mainGame = mainGame;
    }
    private void Upgrade1(object sender, RoutedEventArgs e)
    {
        if (_mainGame.Score >= 100)
        {
            _mainGame.ValuePerClick++;
            _mainGame.Score -= 100;
        }
    }
    private void Upgrade2(object sender, RoutedEventArgs e)
    {
        if (_mainGame.Score >= 1000)
        {
            _mainGame.ValuePerClick+=10;
            _mainGame.Score -= 1000;
        }
    }
    private void Upgrade3(object sender, RoutedEventArgs e)
    {
        if (_mainGame.Score >= 10000)
        {
            _mainGame.ValuePerClick *= 2;
            _mainGame.Score -= 10000;
        }
    }

    private void what(object sender, RoutedEventArgs e)
    {
        if (_mainGame.Score >= 666666)
        {
            for (int i = 0; i < 15; i++)
            {
                MessageBox.Show("666666");
            }

            string url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
            this.Close();
        }
    }
    private void GoBack(object sender, RoutedEventArgs e)
    {
        _mainGame.Show();
        this.Close();
    }
}