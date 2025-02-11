using System;
using System.Windows.Forms;
using MyApp.Controllers;
using MyApp.Services;

namespace MyApp.Views {
  public partial class Transportation: Form {
    private readonly MainForm? _mainForm;

    private readonly KeyController _keyController;
    private readonly MainButton _transpZiro;
    private readonly MainButton _transpAll;
    private readonly MainButton _transpSend;
    private readonly MainButton _transpClose;
    private readonly Input _inputZiro;
    private readonly Input _inputAll;
    private readonly Input _inputWeight;
    private readonly CustomLabel _customLabel;
    private readonly WeightController _controller;

    public Transportation(MainForm mainForm){
      var config = ConfigManager.LoadConfig();

      _mainForm = mainForm;
      _keyController = new KeyController(this);
      _inputAll = new Input(config.TransportationAll.ToString()); 
      _inputZiro = new Input("0"); 
      _inputWeight = new Input(config.TransportationWeight.ToString());
      _transpZiro = new MainButton("Колебровка нуля"); 

      _transpAll= new MainButton("Колебровка шкалы", (e, sender) => {
        CulculateAll();
        _mainForm.GetController().Calibrate(float.Parse("1"));
        _mainForm.GetController().Calibrate(float.Parse(_inputAll.Text));
      }); 

      _transpSend = new MainButton("Отправить", (e, sender) => {
        ConfigManager.UpdateConfig(config => {
          config.TransportationAll = float.Parse(_inputAll.Text);  // Пример нового BaudRate
          config.TransportationWeight = float.Parse(_inputWeight.Text);  // Пример нового BaudRate
        });
      }); 

      _transpClose = new MainButton("Закрыть", (e, sender) => {this.Close();});
      _customLabel = new CustomLabel("Колебровочный вес, кг");

      _controller = new WeightController(config.PortName, config.BaudRate);

      InitializeTitle();
      InitializePosition();
    }

    private void CulculateAll(){
      if (float.TryParse(_inputWeight.Text, out float inputWeight)) {
        int? requestedWeight = _mainForm.GetController().RequestWeight();

        if (requestedWeight.HasValue && requestedWeight.Value != 0) {
          float k = inputWeight / requestedWeight.Value;
          _inputAll.UpdateInputText(k.ToString("F10")); // Округление до 2 знаков
        }
        else {
          _inputAll.UpdateInputText("Ошибка: деление на ноль или нет данных");
        }
      }
      else {
        _inputAll.UpdateInputText("Ошибка: некорректный ввод");
      } 
    }

    private void CulculateZiro(){
      
    }

  }
}
