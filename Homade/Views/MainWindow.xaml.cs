using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Homade.Controllers;
using Homade.Controllers.Navigation;

namespace Homade.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly NavigationController _nav;
    
    public MainWindow()
    {
        InitializeComponent();
        
        // Load HomePage at startup
        _nav = new NavigationController(MainFrame);
        _nav.GoNotes();
        SetSelectedMenuItem(NotesMenu);
    }

    private void HomeMenu_Click(object sender, RoutedEventArgs e)
    {
        _nav.GoHome();
        SetSelectedMenuItem(HomeMenu);
    }

    private void NotesMenu_Click(object sender, RoutedEventArgs e)
    {
        _nav.GoNotes();
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