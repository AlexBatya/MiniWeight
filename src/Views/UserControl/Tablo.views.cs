using System;
using System.Threading;
using System.Windows.Forms;

namespace MyApp.Views {
  public partial class Tablo : UserControl {
    private Label weightLabel;
    private string _weight = "0"; // Поле для хранения текущего веса
    private Thread tabloThread;
    private volatile bool _running = true; // Флаг для остановки потока

    public Tablo() {
      InitializeComponent();
      InitializeTitle();
      StartTabloThread(); // Запускаем отдельный поток
    }

    private void StartTabloThread() {
      tabloThread = new Thread(UpdateTabloLoop) {
        IsBackground = true // Фоновый поток, чтобы не мешать приложению
      };
      tabloThread.Start();
    }

    private void UpdateTabloLoop() {
      while (_running) {
        Thread.Sleep(20); // Обновляем табло каждые 100 мс
        if (InvokeRequired) {
          Invoke((MethodInvoker)(() => weightLabel.Text = _weight));
        } else {
          weightLabel.Text = _weight;
        }
      }
    }

    public void UpdateWeight(int newWeight) {
      _weight = newWeight.ToString();
    }

    public void UpdateWeight(string newWeight) {
      _weight = newWeight;
    }

    public string GetWeight() {
      return _weight;
    }

    protected override void Dispose(bool disposing) {
      _running = false; // Останавливаем поток при закрытии
      base.Dispose(disposing);
    }
  }
}

