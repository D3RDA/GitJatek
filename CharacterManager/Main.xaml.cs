using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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

namespace CharacterManager
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        private void ViewCharacters_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            
            
        }

        private void NewCharacter_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new CharacterEditWindow(new Character());
            editWindow.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void StartFight_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var characters = await new CharacterService().GetCharactersAsync();

                if (characters.Count < 2)
                {
                    MessageBox.Show("Nincs elég karakter a harchoz.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Véletlenszerűen kiválasztunk 2 karaktert
                var random = new Random();
                var selected = characters.OrderBy(x => random.Next()).Take(2).ToList();

                var fightWindow = new FightWindow(selected[0], selected[1]);
                fightWindow.Owner = Application.Current.MainWindow;
                fightWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a harc indításakor:\n{ex.Message}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
