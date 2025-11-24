using System.Windows.Controls;
using Homade.ViewModels.Notes;

namespace Homade.Views.Note;

public partial class NotePage : Page
{
    private NotePageViewModel ViewModel { get; }
    
    public NotePage()
    {
        InitializeComponent();
        ViewModel = new NotePageViewModel();
        DataContext = ViewModel;
    }
    
    private void GoToAddNotePage_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        NavigationService?.Navigate(new AddNotePage());
    }
}