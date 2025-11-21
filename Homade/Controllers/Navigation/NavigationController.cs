using System.Windows.Controls;
using Homade.Views.Home;
using Homade.Views.Note;

namespace Homade.Controllers.Navigation;


// TODO make it with singleton pattern
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