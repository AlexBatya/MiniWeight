using System;
using System.Threading;
using System.Threading.Tasks;
using MyApp.Services;
using MyApp.Views;

namespace MyApp.Controllers {
  public class MainFormController {
    private readonly MainForm _view;
    public readonly WeightController _controller;
    private CancellationTokenSource _cts;

    // Добавляем свойство для дискрета
    public int Discret { get; set; } = 1; // По умолчанию дискрет равен 1 г

    public MainFormController(MainForm view) {
      _view = view;

      var config = ConfigManager.LoadConfig();
      _controller = new WeightController(config.PortName, config.BaudRate);
      _controller.Open();
      this.Discret = config.Discret;
    }

    public string StatusCOM() {
      return _controller.IsPortOpen() ? "Статус COM: OK" : "Статус COM: НЕТ СВЯЗИ";
    }

    public async void StartPolling() {
      _cts?.Cancel(); // Отменяем предыдущий опрос (если был)
      _cts = new CancellationTokenSource();

      await _controller.StartPollingAsync(weight => {
        if (weight.HasValue) {
          // Применяем дискрет к значению веса
          int discretizedWeight = ApplyDiscret(weight.Value);
          _view.UpdateWeight(discretizedWeight);
        }
      }, _cts.Token);
    }

    // Метод для применения дискрета
    private int ApplyDiscret(int weight) {
      if (Discret <= 0) {
        return weight; // Если дискрет не задан, возвращаем исходное значение
      }
      return (weight / Discret) * Discret; // Округляем до ближайшего значения, кратного дискрету
    }

    public void CloseCom() {
      _controller.Close();
    }

    public void OpenCom() {
      _controller.Open();
    }

    public void Tare() {
      _controller.Tare();
    }

    public void StopPolling() {
      _cts?.Cancel();
    }
  }
}
