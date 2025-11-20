using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Homade.Views.Components.Input;

public partial class RichTextEditor : UserControl
{
    public RichTextEditor()
    {
        InitializeComponent();
    }
    
    // Extract XAML-formatted content
    public string GetContent()
    {
        var range = new TextRange(Editor.Document.ContentStart, Editor.Document.ContentEnd);

        using (var ms = new MemoryStream())
        {
            range.Save(ms, DataFormats.Xaml);
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }

    // Load XAML-formatted content
    public void SetContent(string xaml)
    {
        if (string.IsNullOrEmpty(xaml))
        {
            Editor.Document.Blocks.Clear();
            return;
        }

        var range = new TextRange(Editor.Document.ContentStart, Editor.Document.ContentEnd);
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(xaml));
        range.Load(ms, DataFormats.Xaml);
    }
}