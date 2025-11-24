using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Homade.Controllers.Notes;

namespace Homade.Views.Note;

public partial class AddNotePage : Page
{
    private NoteController _controller = NoteController.Instance;
    
    public AddNotePage()
    {
        InitializeComponent();
        
        TitleBox.TextChanged += InputChanged;
        NoteEditor.Editor.TextChanged += InputChanged;
    }
    
    private void SaveNote_Click(object sender, RoutedEventArgs e)
    {
        _controller.Create(new Models.Notes.Note
        {
            Title = TitleBox.Text,
            Content = NoteEditor.GetContent()
        });
        NavigationService?.Navigate(new NotePage());
    }
    
    private void InputChanged(object sender, TextChangedEventArgs e)
    {
        var hasTitle = !string.IsNullOrWhiteSpace(TitleBox.Text);
        
        var textRange = new TextRange(NoteEditor.Editor.Document.ContentStart, NoteEditor.Editor.Document.ContentEnd);
        var hasContent = !string.IsNullOrEmpty(textRange.Text.Trim());

        SaveNoteButton.IsEnabled = hasTitle && hasContent;
    }
}