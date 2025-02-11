using System;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyApp.Controllers {
  public class WeightController {
    private SerialPort serialPort;
    public event Action<bool> PortStateChanged; // Событие для уведомления об изменении состояния порта

    public WeightController(string portName, int baudRate) {
      serialPort = new SerialPort(portName, baudRate) {
        DataBits = 8,
        Parity = Parity.None,
        StopBits = StopBits.One,
        Encoding = Encoding.ASCII,
        ReadTimeout = 1000,
        WriteTimeout = 1000
      };
    }

    public void Open() {
      if (serialPort == null)
        return;

      if (!serialPort.IsOpen) {
        try {
          serialPort.Open();
          Console.WriteLine("COM-порт открыт.");
          PortStateChanged?.Invoke(true); // Уведомляем об открытии порта
        } 
        catch (Exception ex) {
          Console.WriteLine($"Ошибка открытия порта: {ex.Message}");
        }
      } 
      else {
        Console.WriteLine("COM-порт уже открыт.");
      }
    }

    public void Close() {
      if (serialPort == null)
        return;

      if (serialPort.IsOpen) {
        try {
          serialPort.Close();
          Console.WriteLine("COM-порт закрыт.");
          PortStateChanged?.Invoke(false); // Уведомляем о закрытии порта
        } catch (Exception ex) {
          Console.WriteLine($"Ошибка закрытия порта: {ex.Message}");
        }
      } 
      else {
        Console.WriteLine("COM-порт уже закрыт.");
      }
    }

    public bool IsPortOpen() {
      return serialPort != null && serialPort.IsOpen;
    }

    // Метод, который отправляет запрос и возвращает ответ
    public int? RequestWeight() {
      if (serialPort.IsOpen) {
        try {
          serialPort.WriteLine("GET"); // Отправляем команду запроса веса

          // Чтение данных с порта (сразу после отправки запроса)
          string data = serialPort.ReadLine().Trim();
          if (int.TryParse(data, out int weight)) {
            return weight; // Возвращаем полученные данные
          } 
          else {
            Console.WriteLine($"Некорректные данные: {data}");
            return null;
          }
        }
        catch (Exception ex) {
          Console.WriteLine($"Ошибка отправки запроса: {ex.Message}");
          return null;
        }
      }
      return null;
    }

    // Асинхронный метод для постоянного опроса и обновления данных
    public async Task StartPollingAsync(Action<int?> updateMethod, CancellationToken token) {
      try {
        while (!token.IsCancellationRequested) {
          if (serialPort.IsOpen) {  // Проверяем, открыт ли порт
            int? weight = RequestWeight();
            updateMethod(weight);
          }

          await Task.Delay(50, token); // Задержка с обработкой отмены
        }
      } catch (OperationCanceledException) {
        Console.WriteLine("Опрос остановлен.");
      } catch (Exception ex) {
        Console.WriteLine($"Ошибка в StartPollingAsync: {ex.Message}");
      }
    }

    public void Tare() {
      if (serialPort.IsOpen) {
          try {
              serialPort.WriteLine("TARE"); // Отправляем команду обнуления
              Console.WriteLine("Команда TARE отправлена.");
          } catch (Exception ex) {
              Console.WriteLine($"Ошибка отправки команды TARE: {ex.Message}");
          }
      } else {
          Console.WriteLine("Ошибка: COM-порт не открыт.");
      }
    }


    public void Calibrate(float calibrationFactor) {
      if (serialPort == null || !serialPort.IsOpen) {
        Console.WriteLine("Ошибка: COM-порт не открыт.");
        return;
      }

      string command = $"CAL {calibrationFactor.ToString("F10")}\r\n"; // Отправляем команду с двумя знаками после запятой
      try {
        serialPort.WriteLine(command);
        Console.WriteLine($"Отправлена команда калибровки: {command}");
      }
      catch (Exception ex) {
        Console.WriteLine($"Ошибка при отправке команды: {ex.Message}");
      }
    }
  }
}
