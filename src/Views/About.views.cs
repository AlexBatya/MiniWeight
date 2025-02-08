using System;
using System.Windows.Forms;
using MyApp.Controllers;

namespace MyApp.Views{
  public partial class About: Form {
  private readonly KeyController _keyController;

    public About(){
      _keyController = new KeyController(this);

      InitializeTitle();
    }

  }
}
