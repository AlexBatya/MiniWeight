using System;
using System.Windows.Forms;
using MyApp.Controllers;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Views {
    public partial class MainForm: Form {
      private CancellationTokenSource _cts;
      private readonly MenuBar _menuBar; 
      private readonly KeyController _keyController;
      private readonly MainButton _mainButton;
      private readonly MainButton _openButton;
      private readonly MainButton _closeButton;
      private readonly CustomLabel _statusCOM;
      private readonly Tablo _tablo;
      private readonly WeightController _controller;

      public MainForm() {
        _controller = new WeightController("COM5", 9600);

        _menuBar = new MenuBar(); 
        _keyController = new KeyController(this);
        _mainButton = new MainButton("Обнулить", Tare); 
        _openButton = new MainButton("Включить", OpenPort); 
        _closeButton = new MainButton("Отключить", ClosePort); 
        _statusCOM = new CustomLabel("Статус COM: OK");
        _tablo = new Tablo();

        _controller.Open();

        InitializePosition();
        InitializeTitle();
      }

      // Обработчик события получения веса
      private void OnWeightReceived(int weight) {
        // Обновляем UI, используем Invoke, чтобы выполнить обновление в главном потоке
        if (this.InvokeRequired) {
          this.Invoke(new Action<int>(OnWeightReceived), weight);
        } else {
          // Преобразуем вес в строку, если метод ожидает строку
          _tablo.UpdateWeight(weight.ToString());
          Console.WriteLine("Вес: " + weight);
        }
      }

      public async void StartPolling() {
        _cts?.Cancel();  // Отменяем предыдущий опрос (если был)
        _cts = new CancellationTokenSource(); 

        await _controller.StartPollingAsync(weight => {
          if (weight.HasValue) {
            _tablo.UpdateWeight(weight.Value);
          }
        }, _cts.Token);
      }

      public async void OpenPort(object sender, EventArgs e) {
        StartPolling(); // Запуск опроса после открытия
      }

      public async void ClosePort(object sender, EventArgs e) {
        _cts?.Cancel();  // Останавливаем опрос
        _tablo.UpdateWeight("STOP");
      }

      public async void Tare(object sender, EventArgs e) {
        _controller.Tare();
      }
    }
}

