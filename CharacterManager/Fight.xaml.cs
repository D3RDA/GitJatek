using System;
using System.Threading.Tasks;
using System.Windows;

namespace CharacterManager
{
    public partial class FightWindow : Window
    {
        private readonly Character _char1;
        private readonly Character _char2;
        private int _char1Hp;
        private int _char2Hp;

        public FightWindow(Character char1, Character char2)
        {
            InitializeComponent();
            _char1 = char1;
            _char2 = char2;

            _char1Hp = char1.Hp;
            _char2Hp = char2.Hp;

            InitializeUI();
        }

        private void InitializeUI()
        {
            LeftName.Text = _char1.Name;
            LeftClass.Text = _char1.Class;   
            LeftHpBar.Maximum = _char1.Hp;
            LeftHpBar.Value = _char1Hp;

            RightName.Text = _char2.Name;
            RightClass.Text = _char2.Class;  
            RightHpBar.Maximum = _char2.Hp;
            RightHpBar.Value = _char2Hp;
        }


        private async void FightButton_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            while (_char1Hp > 0 && _char2Hp > 0)
            {
                await Task.Delay(500); 

                // Karakter 1 támad
                int dmg1 = Math.Max(1, _char1.Dmg + rnd.Next(-2, 3));
                _char2Hp -= dmg1;
                if (_char2Hp < 0) _char2Hp = 0;
                RightHpBar.Value = _char2Hp;

                if (_char2Hp == 0) break;

                await Task.Delay(500);

                // Karakter 2 visszatámad
                int dmg2 = Math.Max(1, _char2.Dmg + rnd.Next(-2, 3));
                _char1Hp -= dmg2;
                if (_char1Hp < 0) _char1Hp = 0;
                LeftHpBar.Value = _char1Hp;
            }

            string winner = _char1Hp > 0 ? _char1.Name : _char2.Name;
            MessageBox.Show($"{winner} győzött a harcban!", "Győzelem", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
