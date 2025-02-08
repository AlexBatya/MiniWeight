using System;
using System.Windows.Forms;
using MyApp.Controllers;
using MyApp.Services;

namespace MyApp.Views {
  public partial class Settings: Form {
    private readonly MainController _mainController;
    private readonly KeyController _keyController;
    private readonly Input _inputCOM;
    private readonly CustomLabel _labelCOM;
    private readonly Input _inputSpeed;
    private readonly CustomLabel _labelSpeed;
    private readonly MainButton _buttonSave;
    private readonly MainButton _buttonClose;
    
    public Settings(){
      
      var config = ConfigManager.LoadConfig();

      _keyController = new KeyController(this);
      _mainController = new MainController(this);

      _inputCOM = new Input(config.PortName);
      _labelCOM = new CustomLabel("COM порт");


      _inputSpeed = new Input(config.BaudRate.ToString());
      _labelSpeed= new CustomLabel("Скорость обмена");

      _buttonSave = new MainButton("Сохранить");
      _buttonClose = new MainButton("Закрыть", (e, sender) => {this.Close();}) ;

      InitializeTitle();
      InitializePosition();
    }

  }
}
