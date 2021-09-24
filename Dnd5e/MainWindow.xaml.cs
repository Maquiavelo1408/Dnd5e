using Dnd5e.Entities;
using Dnd5e.Enums;
using Dnd5e.RepositoryTools;
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
        private CollectionViewSource classesViewSource;
        private CollectionViewSource skillsViewSource;
        private ObservableCollection<Skill> skillList;
        private readonly CreateCharacter _createCharacter;

        public MainWindow(CreateCharacter createCharacter)
        {
            _createCharacter = createCharacter;
            WindowState = WindowState.Maximized;
            InitializeComponent();
            //classesViewSource = (CollectionViewSource)FindResource(nameof(classesViewSource));
            skillsViewSource = (CollectionViewSource)FindResource(nameof(skillsViewSource));
            skillList = new ObservableCollection<Skill>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }



        private void OpenNewCharacterTab(object sender, RoutedEventArgs e)
        {
            Frame tabFrame = new Frame();
            ClosableTab tabItem = new ClosableTab();
            tabItem.Title ="Create Character";
            tabFrame.Content = _createCharacter;
            tabItem.Content = tabFrame;
            Tabs1.Items.Add(tabItem);
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
