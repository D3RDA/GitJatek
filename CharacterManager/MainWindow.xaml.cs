using System.Collections.ObjectModel;
using System.Windows;

namespace CharacterManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CharacterService _service;
        public ObservableCollection<Character> Characters { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            _service = new CharacterService();
            Characters = new ObservableCollection<Character>();
            CharactersDataGrid.ItemsSource = Characters;
            LoadCharacters();
        }

        private async void LoadCharacters()
        {
            var characters = await _service.GetCharactersAsync();
            Characters.Clear();
            foreach (var character in characters)
            {
                Characters.Add(character);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadCharacters();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new CharacterEditWindow(new Character());
            editWindow.Owner = this;

            if (editWindow.ShowDialog() == true)
            {
                LoadCharacters();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedCharacter = CharactersDataGrid.SelectedItem as Character;
            if (selectedCharacter == null)
            {
                MessageBox.Show("Kérem válasszon egy Charactert a módosításhoz.", "Figyelmezetés", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var editWindow = new CharacterEditWindow(selectedCharacter);
            editWindow.Owner = this;

            if (editWindow.ShowDialog() == true)
            {
                LoadCharacters();
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectCharacter = CharactersDataGrid.SelectedItem as Character;
            
            if (selectCharacter == null)
            {
                MessageBox.Show("Kérem válasszon egy Charactert a törléshez.", "Figyelmezetés", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show($"Bíztos törölni akarod a következő Charactert: {selectCharacter.Name} ?",
                "Törlés megerősítése",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                bool deleteSuccess = await _service.DeleteCharacterAsync(selectCharacter.Id);
                if (deleteSuccess)
                {
                    LoadCharacters();
                }
                else
                {
                    MessageBox.Show("Sikeretelen Character törlés!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}