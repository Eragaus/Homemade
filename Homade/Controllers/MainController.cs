namespace Homade.Controllers;

public class MainController
{
    private MainWindow _view;

    public MainController()
    {
        _view = new MainWindow();
    }
    
    public void ShowView()
    {
        _view.Show();
    }
}