using Dnd5e.Entities;
using Dnd5e.Enums;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Dnd5e
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CharacterContext _context =
            new CharacterContext();
        private CollectionViewSource classesViewSource;
        private CollectionViewSource skillsViewSource;
        private ObservableCollection<Skill> skillList;
        
        public MainWindow()
        {
            WindowState = WindowState.Maximized;
            InitializeComponent();
            //classesViewSource = (CollectionViewSource)FindResource(nameof(classesViewSource));
            skillsViewSource = (CollectionViewSource)FindResource(nameof(skillsViewSource));
            skillList = new ObservableCollection<Skill>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
            _context.Classes.Load();
            _context.Skills.Load();
            //classesViewSource.Source = _context.Classes.Local.ToObservableCollection();
            skillsViewSource.Source = _context.Skills.Local.ToObservableCollection();
            //abilitiesComboBox.ItemsSource = Enum.GetValues(typeof(AbilityScores)).Cast<AbilityScores>();
            foreach(var skill in _context.Skills.Local)
            {
                //skillListView.Items.Add(new CheckBox() { Content = skill.Description + " ("+skill.AbilityType+")", IsChecked = false });
            }
            //skillList = _context.Skills.Local.ToObservableCollection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
            //classesDataGrid.Items.Refresh();
            //charactersDataGrid.Items.Refresh();
            //skillsDataGrid.Items.Refresh();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _context.Dispose();
            base.OnClosing(e);
        }

        private void OpenNewCharacterTab(object sender, RoutedEventArgs e)
        {
            Frame tabFrame = new Frame();
            ClosableTab tabItem = new ClosableTab();
            tabItem.Title ="Create Character";
            tabFrame.Content = new CreateCharacter();
            tabItem.Content = tabFrame;
            Tabs1.Items.Add(tabItem);
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
