using System.Windows;
using System.Collections.Generic;

namespace CharacterManager
{
    public partial class CharacterEditWindow : Window
    {
        private readonly CharacterService _characterService;
        private readonly Character _character;
        private readonly bool _isNewCharacter;

      
        private readonly List<string> AvailableClasses = new List<string>
        {
            "Warrior",
            "Mage",
            "Archer",
            "Rogue",
            "Paladin",
            "Necromancer",
            "Druid",
            "Bard",
            "Monk",
            "Sorcerer",
            "Ranger",
            "Assassin",
            "Cleric",
            "Barbarian",
            "Warlock",
            "Knight",
            "Alchemist",
            "Shaman",
            "Hunter",
            "Enchanter"
        };

        public CharacterEditWindow(Character character)
        {
            InitializeComponent();
            _characterService = new CharacterService();
            _character = character;
            _isNewCharacter = character.Id == 0;
            InitializeFields();
        }

        private void InitializeFields()
        {
            IdTextBox.Text = _character.Id == 0 ? "Auto" : _character.Id.ToString();
            NameTextBox.Text = _character.Name;

            
            ClassComboBox.ItemsSource = AvailableClasses;
            if (AvailableClasses.Contains(_character.Class))
                ClassComboBox.SelectedItem = _character.Class;
            else
                ClassComboBox.SelectedIndex = 0;

            DmgTextBox.Text = _character.Dmg.ToString();
            HpTextBox.Text = _character.Hp.ToString();
            CreatedAtTextBox.Text = _character.CreatedAt == default ? DateTime.Now.ToString("g") : _character.CreatedAt.ToString("g");
        }


        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Name megadása kötelező.", "Validációs hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!int.TryParse(DmgTextBox.Text, out int dmg) || dmg < 0)
            {
                MessageBox.Show("Nem valid érték vagy nem lehet negatív.", "Validációs hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!int.TryParse(HpTextBox.Text, out int hp) || hp < 0)
            {
                MessageBox.Show("Nem megfelelő érték vagy nem lehet negatív.", "Validációs hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (ClassComboBox.SelectedItem == null)
            {
                MessageBox.Show("Character Class kiválasztása kötelező.", "Validációs hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput())
                return;

            _character.Name = NameTextBox.Text.Trim();
            _character.Class = ClassComboBox.SelectedItem as string;

            if (!int.TryParse(DmgTextBox.Text, out int dmg))
            {
                MessageBox.Show("Nem megfelelő érték a Dmg mezőben.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _character.Dmg = dmg;

            if (!int.TryParse(HpTextBox.Text, out int hp))
            {
                MessageBox.Show("Nem megfelelő érték a Hp mezőben.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _character.Hp = hp;

            try
            {
                if (_isNewCharacter)
                {
                    _character.CreatedAt = DateTime.Now;
                    var addedCharacter = await _characterService.AddCharacterAsync(_character);
                    if (addedCharacter == null)
                        throw new System.Exception("Hiba a Character hozzáadásakor.");
                }
                else
                {
                    bool updateSuccess = await _characterService.UpdateCharacterAsync(_character);
                    if (!updateSuccess)
                        throw new System.Exception("Hiba a Character frissítésekor.");
                }

                DialogResult = true;
                Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Hiba a Character mentésekor! {ex.Message}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
