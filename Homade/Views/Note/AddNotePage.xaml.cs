using System.Windows;
using System.Windows.Controls;

namespace Homade.Views.Note;

public partial class AddNotePage : Page
{
    public AddNotePage()
    {
        InitializeComponent();
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
}