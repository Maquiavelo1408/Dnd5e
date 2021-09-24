using Dnd5e.Entities;
using Dnd5e.RepositoryTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dnd5e
{
    /// <summary>
    /// Interaction logic for CreateCharacter.xaml
    /// </summary>
    public partial class CreateCharacter : Page
    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        private readonly DndRepository _repository;
        public CreateCharacter(DndRepository repository)
        {
            _repository = repository;
            InitializeComponent();
            txtBoxCharismaScore.MaxLength = 2;
            txtBoxDexterityScore.MaxLength = 2;
            txtBoxIntelligenceScore.MaxLength = 2;
            txtBoxStregthScore.MaxLength = 2;
            txtBoxWisdomScore.MaxLength = 2;
            txtBoxConstitutionScore.MaxLength = 2;
            FillClassDropDown();
        }
        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }

        private void SaveCharacter(object sender, RoutedEventArgs e)
        {
            var character = new Character();
            character.Name = txtBoxCharacterName.Text;
            character.StrengthScore = Convert.ToInt32(txtBoxStregthScore.Text);
            character.DexterityScore = Convert.ToInt32(txtBoxDexterityScore.Text);
            character.IntelligenceScore = Convert.ToInt32(txtBoxIntelligenceScore.Text);
            character.WisdomScore = Convert.ToInt32(txtBoxWisdomScore.Text);
            character.CharismaScore = Convert.ToInt32(txtBoxCharismaScore.Text);
            character.ConstitutionScore = Convert.ToInt32(txtBoxConstitutionScore.Text);
            character.FlyingSpeed = 0;
            character.WalkingSpeed = 0;
            character.SwimingSpeed = 0;
            character.Level = 1;
            character.HitPoints = 0;
            var t = comboBoxClass.SelectedItem;
            var y = comboBoxClass.SelectedIndex;
            character.Classes = _repository.GetSingle<Classes>(a => a.ClassesId == Convert.ToInt32(((ComboBoxItem)comboBoxClass.SelectedItem).Tag));
            _repository.Add(character);
            _repository.Commit();
        }
        private void FillClassDropDown()
        {
            var classes = _repository.GetAll<Classes>();
            foreach(var classs in classes)
            {
                comboBoxClass.Items.Add(new ComboBoxItem() { Content = classs.Name, Tag = classs.ClassesId });
            }
        }
    }
}
