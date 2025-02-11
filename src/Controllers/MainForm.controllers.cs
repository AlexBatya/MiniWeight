using System;
using System.Windows.Forms;
using MyApp.Views;

namespace MyApp.Controllers {
  public class MainFormController  {
    private readonly MainForm? _view;
    
    public MainFormController(MainForm view){
      _view = view;
    }

  }
}
