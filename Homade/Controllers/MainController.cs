using Homade.Models;
using Homade.Views;

namespace Homade.Controllers;

public class MainController
{
    private MainWindow _view;

    public MainController()
    {
        _view = new MainWindow();
        _view.DataContext = new Note
        {
            Title="Welcome to Homade",
            Content="This is your first note. Edit or delete it, and start creating more notes"
        };
    }
    
    public void ShowView()
    {
        _view.Show();
    }
}