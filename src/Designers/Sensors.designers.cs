using System;
using System.Windows.Forms;

namespace MyApp.Views {
  partial class Sensors  {
  
    private void InitializeTitle(){
      this.Text = "Терминал - Датчики"; // Заголовок окна
      this.Size = new Size(700, 400); // Размер окна
      this.StartPosition = FormStartPosition.CenterScreen; // Центрируем окно
      this.FormBorderStyle = FormBorderStyle.FixedDialog; // Фиксированное окно
      this.BackColor = Color.White; // Фон окна
      this.MaximizeBox = false; // Запрещает разворачивание окна
      this.MinimizeBox = true;  // Оставляет возможность свернуть окно
      this.FormBorderStyle = FormBorderStyle.FixedSingle; // Запрещает изменение размера

      try {
        this.Icon = new Icon("E:/work/desktop/tablo/src/Assets/Img/icon.ico"); // Устанавливаем иконку
      } catch {
        Console.WriteLine("Иконка не найдена, используется стандартная.");
      }
    }

  }
}
