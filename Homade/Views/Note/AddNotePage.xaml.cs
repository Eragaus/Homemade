using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Homade.Views.Note;

public partial class AddNotePage : Page
{
    public AddNotePage()
    {
        InitializeComponent();
        
        TitleBox.TextChanged += InputChanged;
        NoteEditor.Editor.TextChanged += InputChanged;
    }
    
    private void SaveNote_Click(object sender, RoutedEventArgs e)
    {
        string title = TitleBox.Text;
        string content = NoteEditor.GetContent(); // <-- from your component

        // TODO: persist (database, json, file, etc)
        MessageBox.Show("Note saved:\n" +
                        "Title: " + title + "\n" +
                        "Content length: " + content.Length);
    }
    
    private void InputChanged(object sender, TextChangedEventArgs e)
    {
        bool hasTitle = !string.IsNullOrWhiteSpace(TitleBox.Text);
        
        var textRange = new TextRange(NoteEditor.Editor.Document.ContentStart, NoteEditor.Editor.Document.ContentEnd);
        bool hasContent = !string.IsNullOrEmpty(textRange.Text.Trim());

        SaveNoteButton.IsEnabled = hasTitle && hasContent;
    }
}