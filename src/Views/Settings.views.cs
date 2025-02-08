using System;
using System.Windows.Forms;
using MyApp.Controllers;

namespace MyApp.Views {
  public partial class Settings: Form {
    private readonly KeyController _keyController;
    
    public Settings(){
      _keyController = new KeyController(this);

      InitializeTitle();
    }

  }
}
