using System;
using System.Windows.Forms;
using MyApp.Controllers;
using MyApp.Services;

namespace MyApp.Views {
  public partial class Settings: Form {
    private readonly MainForm? _mainForm;
    private readonly ButtonController? _buttonController;
    private readonly MainController? _mainController;
    private readonly KeyController? _keyController;
    public readonly Input? _inputCOM;
    private readonly CustomLabel? _labelCOM;
    private readonly Input? _inputSpeed;
    private readonly Input? _inputDiscret;
    private readonly Input? _inputDataSpeed;
    private readonly Input? _inputPollingTime;
    private readonly CustomLabel? _labelSpeed;
    private readonly CustomLabel? _labelDiscret;
    private readonly CustomLabel? _labelDataSpeed;
    private readonly CustomLabel? _labelPollingTime;
    private readonly MainButton? _buttonSave;
    private readonly MainButton? _buttonClose;
    
    public Settings(MainForm mainForm){
      _mainForm = mainForm;
      var config = ConfigManager.LoadConfig();

      _keyController = new KeyController(this);
      _mainController = new MainController(this);

      _buttonController = new ButtonController(this); 

      _inputCOM = new Input(config.PortName);
      _labelCOM = new CustomLabel("COM порт");

      _inputSpeed = new Input(config.BaudRate.ToString());
      _labelSpeed= new CustomLabel("Скорость обмена");

      _inputDiscret = new Input(config.Discret.ToString());
      _labelDiscret = new CustomLabel("Дискрет");

      _inputPollingTime = new Input(config.PollingTime.ToString());
      _labelPollingTime = new CustomLabel("Время запроса, мс");

      _buttonSave = new MainButton("Сохранить", (e, sender) => {
        ConfigManager.UpdateConfig(config => {
          config.PortName = _inputCOM.Text;  // Пример нового порта
          config.BaudRate = Convert.ToInt32(_inputSpeed.Text);  // Пример нового BaudRate
          config.Discret = Convert.ToInt32(_inputDiscret.Text);  // Пример нового BaudRate
          config.PollingTime = Convert.ToInt32(_inputPollingTime.Text);  // Пример нового BaudRate

          Application.Restart();
        });
        
      });
      _buttonClose = new MainButton("Закрыть", (e, sender) => {this.Close();}) ;

      InitializeTitle();
      InitializePosition();
    }

  }
}
