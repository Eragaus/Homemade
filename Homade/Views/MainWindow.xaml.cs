using System.Windows;
using System.Windows.Controls;
using Homade.Views.Home;
using Homade.Views.Note;

namespace Homade.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    
    public MainWindow()
    {
        InitializeComponent();
        GoToNotePage();
    }

    private void HomeMenu_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new HomePage());
        SetSelectedMenuItem(HomeMenu);
    }

    private void NotesMenu_Click(object sender, RoutedEventArgs e)
    {
        GoToNotePage();
    }

    private void GoToNotePage()
    {
        MainFrame.Navigate(new NotePage());
        SetSelectedMenuItem(NotesMenu);
    }

    private void SetSelectedMenuItem(MenuItem selected)
    {
        Style defaultStyle = (Style)FindResource("MaterialDesignMenuItem");
        HomeMenu.Style = defaultStyle;
        NotesMenu.Style = defaultStyle; //TODO improve this part to support more menu items
        
        selected.Style = (Style)FindResource("MaterialDesignMenuItemSelected");
    }
}