using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
        }

        private void SetUpGame()
        {
            List<string> animaLEmoji = new List<string>()
            {
                "🐵","🐵",
                "🦍","🦍",
                "🐪","🐪",
                "🐘","🐘",
                "🦘","🦘",
                "🐓","🐓",
                "🐦","🐦",
                "🐊","🐊",
            };
            //Create a list of eight pairs of emoji
            Random random = new Random();
            //Find every TextBlock in the main grid and
            //repeat the following statements for each of them
        foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                //Pick a random number between 0 and the
                //number of emoji left in the list and call it “index”
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animaLEmoji.Count);
                    string nextEmoji = animaLEmoji[index];
                    textBlock.Text = nextEmoji;
                    animaLEmoji.RemoveAt(index);

                }
               

            }
            timer.Start();
            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;

        }
        TextBlock lastTextBlockClocked;
        bool findingMatch = false;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClocked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClocked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClocked.Visibility = Visibility.Visible;
            }
        }

        private void timeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }

    }
}
