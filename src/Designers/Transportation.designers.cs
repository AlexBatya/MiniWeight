using System;
using System.Windows.Forms;
using System.Text.Json;
using MyApp.Models;

namespace MyApp.Views {
  partial class Transportation {
    
    private void InitializeTitle(){
      string jsonText = File.ReadAllText("C:/Users/user/Desktop/work/programs/desktop/MiniWeight/src/settings.json"); // Читаем файл
      var data = JsonSerializer.Deserialize<SrcSettings>(jsonText); // Десериализация

      this.Text = "Терминал - Колебровка"; // Заголовок окна
      this.Size = new Size(600, 400); // Размер окна
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

    private void InitializePosition(){
    // Настройка таблицы с пропорциями для строк и столбцов
      TableLayoutPanel tableLayoutPanel = new TableLayoutPanel {
        RowCount = 1,
        ColumnCount = 2,
        Dock = DockStyle.Top,
        AutoSize = true, // Автоматический размер по содержимому
        AutoSizeMode = AutoSizeMode.GrowAndShrink,
      };

      // Настройка столбцов
      tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F)); // Используем 50% для каждой колонки
      tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F)); // Используем 50% для каждой колонки

      // Настройка строк
      tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F)); // Размер первой строки 100px
      tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F)); // Основная строка будет занимать весь оставшийся экран
      tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F)); // Еще одна строка снизу
      tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F)); // Еще одна строка снизу
      tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F)); // Еще одна строка снизу

      // Добавление элементов в ячейки
      tableLayoutPanel.Controls.Add(_inputAll, 0, 1); // Кнопка на основной ячейке
      tableLayoutPanel.Controls.Add(_inputZiro, 1, 1); // Кнопка на основной ячейке
      tableLayoutPanel.Controls.Add(_transpAll, 0, 2); // Кнопка на основной ячейке
      tableLayoutPanel.Controls.Add(_transpZiro, 1, 2); // Кнопка на основной ячейке

      tableLayoutPanel.Controls.Add(_customLabel, 0, 3); // Кнопка на основной ячейке
      tableLayoutPanel.SetColumnSpan(_customLabel, 2);

      tableLayoutPanel.Controls.Add(_inputWeight, 0, 4); // Кнопка на основной ячейке

      tableLayoutPanel.Controls.Add(_transpSend, 0, 5); // Кнопка на основной ячейке
      tableLayoutPanel.Controls.Add(_transpClose, 1, 5); // Кнопка на основной ячейке

      this.Controls.Add(tableLayoutPanel);
    }

  }
}
