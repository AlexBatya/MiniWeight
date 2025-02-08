using System;
using System.Windows.Forms;
using MyApp.Controllers;
using MyApp.Services;

namespace MyApp.Views {
  public partial class Transportation: Form {
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

    public Transportation(){
      _keyController = new KeyController(this);
      _inputAll = new Input("0"); 
      _inputZiro = new Input("0"); 
      _inputWeight = new Input("");
      _transpZiro = new MainButton("Колебровка нуля"); 
      _transpAll= new MainButton("Колебровка шкалы", (e, sender) => {CulculateAll();}); 
      _transpSend = new MainButton("Отправить"); 
      _transpClose = new MainButton("Закрыть", (e, sender) => {this.Close();});
      _customLabel = new CustomLabel("Колебровочный вес, кг");

      var config = ConfigManager.LoadConfig();
      _controller = new WeightController(config.PortName, config.BaudRate);

      InitializeTitle();
      InitializePosition();
    }

    private void CulculateAll(){
      var tablo = new Tablo();
      Console.WriteLine(tablo.GetWeight());
      float? k = float.Parse(_inputWeight.Text) / 20;
      _inputAll.UpdateInputText(k.ToString());; 
    }

    private void CulculateZiro(){

    }

  }
}
