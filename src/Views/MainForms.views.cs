using System;
using System.Windows.Forms;
using MyApp.Controllers;
using MyApp.Services;

namespace MyApp.Views {
  public partial class MainForm : Form {
    private readonly MenuBar _menuBar;
    private readonly KeyController _keyController;
    private readonly MainButton _mainButton;
    private readonly MainButton _openButton;
    private readonly MainButton _closeButton;
    private readonly CustomLabel _statusCOM;
    private readonly Tablo _tablo;

    public readonly MainFormController _mainFormController;

    public MainForm() {
      _mainFormController = new MainFormController(this);

      _keyController = new KeyController(this);
      _mainButton = new MainButton("Обнулить", OnTareClicked);
      _openButton = new MainButton("Включить", OnOpenPortClicked);
      _closeButton = new MainButton("Отключить", OnClosePortClicked);
      _tablo = new Tablo();

      _menuBar = new MenuBar(this);
      _statusCOM = new CustomLabel(_mainFormController.StatusCOM());

      InitializePosition();
      InitializeTitle();
    }

    private void OnTareClicked(object sender, EventArgs e) {
      _mainFormController.Tare();
    }

    public WeightController GetController(){
      return _mainFormController._controller; 
    }

    private void OnOpenPortClicked(object sender, EventArgs e) {
      _mainFormController.OpenCom();
      _mainFormController.StartPolling();
    }

    private void OnClosePortClicked(object sender, EventArgs e) {
      _mainFormController.StopPolling();
      _tablo.UpdateWeight("STOP");
    }

    public void UpdateWeight(int weight) {
      if (this.InvokeRequired) {
        this.Invoke(new Action<int>(UpdateWeight), weight);
      } 
      else {
        _tablo.UpdateWeight(weight.ToString());
      }
    }
  }
}
