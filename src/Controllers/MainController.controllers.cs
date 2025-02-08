using System;
using System.Windows.Forms;
using MyApp.Views;

namespace MyApp.Controllers {

  public class MainController  {
    private readonly Control? _view;

    public MainController(Control view){
      _view = view;
    }
    
    public void AppExit(object sender, EventArgs e){
      Application.Exit();
    }

    public void OpenSettings(object sender, EventArgs e){
      var settings = new Settings(); 
      settings.Show();
    }

    public void OpenTransportation(object sender, EventArgs e){
      var transportation = new Transportation(); 
      transportation.Show();
    }

    public void OpenAbout(object sender, EventArgs e){
      var about = new About(); 
      about.Show();
    }

    public void OpenSensors(object sender, EventArgs e){
      var sensors = new Sensors(); 
      sensors.Show();
    }

  }
}
