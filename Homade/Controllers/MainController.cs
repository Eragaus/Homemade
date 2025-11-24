using System.Windows;
using Homade.Views;

namespace Homade.Controllers;

public class MainController
{
    private MainWindow _view;

    public MainController()
    {
        _view = new MainWindow();
        _view.WindowState = WindowState.Maximized;
    }
    
    public void ShowView()
    {
        _view.Show();
    }
}