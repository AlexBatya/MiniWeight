using System;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks; // Для async/await

namespace MyApp.Controllers {
  public class WeightController {
    private SerialPort serialPort;

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
      try {
        serialPort.Open();
        Console.WriteLine("COM-порт открыт.");
      } catch (Exception ex) {
        Console.WriteLine($"Ошибка открытия порта: {ex.Message}");
      }
    }

    public void Close() {
      if (serialPort.IsOpen) {
        serialPort.Close();
        Console.WriteLine("COM-порт закрыт.");
      }
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
    public async Task StartPollingAsync(Action<int?> updateMethod) {
      while (true) {
        // Отправляем запрос и получаем ответ
        int? weight = RequestWeight();
        updateMethod(weight);  // Обновляем данные через переданный метод

        // Задержка 50 мс (не блокирует поток)
        await Task.Delay(50);
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
  }
}

