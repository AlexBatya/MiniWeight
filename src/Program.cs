using MyApp.Views;
using MyApp.Services;

namespace MyApp;

static class Program {
    [STAThread]
    static void Main() {
      ApplicationConfiguration.Initialize();
      Application.Run(new MainForm());
      var config = ConfigManager.LoadConfig();
    }    
}
