using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;

namespace Homade.Views.Converters;

public class XamlToFlowDocumentConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var xaml = value as string;
        var doc = new FlowDocument();

        if (string.IsNullOrWhiteSpace(xaml))
        {
            return doc;
        }

        try
        {
            using var ms = new MemoryStream(Encoding.UTF8.GetBytes(xaml));
            var range = new TextRange(doc.ContentStart, doc.ContentEnd);
            range.Load(ms, DataFormats.Xaml);
        }
        catch
        {
            // Fallback: load as plain text
            doc.Blocks.Clear();
            doc.Blocks.Add(new Paragraph(new Run(xaml)));
        }

        return doc;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
