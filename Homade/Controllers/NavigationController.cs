using System.Windows.Controls;
using Homade.Views.Home;
using Homade.Views.Note;

namespace Homade.Controllers;

public class NavigationController(Frame frame)
{
    public void GoHome()
    {
        frame.Navigate(new HomePage());
    }

    public void GoNotes()
    {
        frame.Navigate(new AddNotePage());
    }
}