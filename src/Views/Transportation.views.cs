using System;
using System.Windows.Forms;
using MyApp.Controllers;

namespace MyApp.Views {
  public partial class Transportation: Form {
    private readonly KeyController _keyController;
    private readonly MainButton _transpZiro;
    private readonly MainButton _transpAll;
    private readonly Input _inputZiro;
    private readonly Input _inputAll;
    private readonly Input _inputWeight;

    public Transportation(){
      _keyController = new KeyController(this);
      _transpZiro = new MainButton("Колебровка нуля"); 
      _transpAll= new MainButton("Колебровка шкалы"); 
      _inputAll = new Input("0"); 
      _inputZiro = new Input("0"); 
      _inputWeight = new Input("0");

      InitializeTitle();
      InitializePosition();
    }

  }
}
