using System.Windows;
using Homade.Controllers;

namespace Homade;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private Mutex? _mutex;
    private const string AppMutexName = "Homade";
    
    // on Startup with mutex to prevent multiple instances
    protected override void OnStartup(StartupEventArgs e)
    {
        _mutex = new Mutex(false, AppMutexName);
        // TimeSpan.Zero to test the mutex's signal state and
        // return immediately without blocking
        if (!_mutex.WaitOne(System.TimeSpan.Zero))
        {
            // Initializes the variables to pass to the MessageBox.Show method.
            string message = "This application is already started";
            string caption = "Homade";
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBox.Show(message, caption, buttons);
            Shutdown();
            return;
        }
        
        base.OnStartup(e);
        MainController controller = new MainController();
        controller.ShowView();
    }
    
    protected override void OnExit(ExitEventArgs e)
    {
        _mutex?.ReleaseMutex();
        _mutex?.Dispose();
        
        base.OnExit(e);
    }
}