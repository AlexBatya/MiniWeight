using System;
using System.Windows.Forms;
using System.Text.Json;
using MyApp.Models;

namespace MyApp.Views {
  partial class About  {
    

    private void InitializeTitle(){
      string jsonText = File.ReadAllText("C:/Users/kegla/Desktop/AlexBatya/MiniWeight/src/settings.json"); // Читаем файл
      var data = JsonSerializer.Deserialize<SrcSettings>(jsonText); // Десериализация

      this.Text = "Терминал - О программе"; // Заголовок окна
      this.Size = new Size(300, 300); // Размер окна
      this.StartPosition = FormStartPosition.CenterScreen; // Центрируем окно
      this.FormBorderStyle = FormBorderStyle.FixedDialog; // Фиксированное окно
      this.BackColor = Color.White; // Фон окна
      this.MaximizeBox = false; // Запрещает разворачивание окна
      this.MinimizeBox = true;  // Оставляет возможность свернуть окно
      this.FormBorderStyle = FormBorderStyle.FixedSingle; // Запрещает изменение размера

      try {
        this.Icon = new Icon(data.Icon); // Устанавливаем иконку
      } catch {
        Console.WriteLine("Иконка не найдена, используется стандартная.");
      }
    }

  }
}
