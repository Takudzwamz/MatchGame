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

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
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
                int index = random.Next(animaLEmoji.Count);

                string nextEmoji = animaLEmoji[index];
                textBlock.Text = nextEmoji;
                animaLEmoji.RemoveAt(index);

            }

        }
    }
}
