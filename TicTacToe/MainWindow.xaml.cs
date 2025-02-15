using System.Windows;
using System.Windows.Controls;
using System.Reflection;

namespace TicTacToe;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    int move = 0;
    public MainWindow()
    {
        InitializeComponent();
    }

    private const string X_CHAR = "\u2716";
    private const string O_CHAR = "\u25cb";
    private const string DRAFT_CHAR = "|";
    private void OnButtonCLick(object sender, RoutedEventArgs e)
    {
        Button btn = (sender as Button);
        if (btn.Content != "")
        {
            return;
        }
        if (move == 0)
        {
            btn.Content = X_CHAR;
            move = 1;
        }
        else if (move == 1)
        {
            btn.Content = O_CHAR;
            move = 0; 
        }

        var winner = LineCheck();
        if (winner != DRAFT_CHAR)
        {
            MessageBox.Show("Победили " + winner);
            ResetField();
            move = 0;
        };
    }
    private string LineCheck()
    {
        string winnerChar = DRAFT_CHAR;
        Type myType = typeof(MainWindow);
        for (int i = 1; i < 4; i++)
        {
            bool isLine = true;
            string oldValue = DRAFT_CHAR;
            for (int j = 1; j < 4; j++)
            {
                var btn = myType.GetField($"Button{i}_{j}", BindingFlags.Instance | BindingFlags.NonPublic);
                var value = (btn.GetValue(this) as Button).Content.ToString();
                if ((oldValue != value && oldValue != DRAFT_CHAR) || value == "")
                {
                    isLine = false;
                    break;
                }
                oldValue = value;
                winnerChar = value;
            }

            if (isLine)
            {
                MessageBox.Show("Найдена полная линия");
                return winnerChar;
            }
            else
            {
                winnerChar = DRAFT_CHAR;
            }
        }
        for (int j = 1; j < 4; j++)
        {
            bool isColumn = true;
            string oldValue = DRAFT_CHAR;
            for (int i = 1; i < 4; i++)
            {
                var btn = myType.GetField($"Button{i}_{j}", BindingFlags.Instance | BindingFlags.NonPublic);
                var value = (btn.GetValue(this) as Button).Content.ToString();
                if ((oldValue != value && oldValue != DRAFT_CHAR) || value == "")
                {
                    isColumn = false;
                    break;
                }
                oldValue = value;
                winnerChar = value;
            }
            if (isColumn)
            {
                MessageBox.Show("Найдена полная колонна");
                return winnerChar;
            }
            else
            {
                winnerChar = DRAFT_CHAR;
            }
        }

        var isDiag = false;
        if (Button1_1.Content == Button2_2.Content && Button1_1.Content == Button3_3.Content && Button2_2.Content.ToString() != "")
        {
            isDiag = true;
            MessageBox.Show("Найдена диагональ");
        }
        if (Button1_3.Content == Button2_2.Content && Button2_2.Content == Button3_1.Content && Button2_2.Content.ToString() != "")
        {
            isDiag = true;
            MessageBox.Show("Найдена диагональ");
        }
        if (isDiag)
        {
            return Button2_2.Content.ToString();
        }
        return winnerChar;
    }

    private void ResetField()
    {
        Button1_1.Content = "";
        Button1_2.Content = "";
        Button1_3.Content = "";
        Button2_1.Content = "";
        Button2_2.Content = "";
        Button2_3.Content = "";
        Button3_1.Content = "";
        Button3_2.Content = "";
        Button3_3.Content = "";
    }
}