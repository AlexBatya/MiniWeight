using System;
using System.Windows.Forms;
using MyApp.Controllers;

namespace MyApp.Views {
  public partial class Sensors: Form {
    private readonly KeyController _keyController;
    
    public Sensors(){
      _keyController = new KeyController(this);
      
      InitializeTitle();
    }

  }
}
