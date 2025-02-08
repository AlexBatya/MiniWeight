using System;
using System.Windows.Forms;
using System.Text.Json;
using MyApp.Models;

namespace MyApp.Views {
  partial class MainForm {

    private void InitializeTitle() {
      string jsonText = File.ReadAllText("E:/work/desktop/tablo/src/settings.json"); // Читаем файл
      var data = JsonSerializer.Deserialize<SrcSettings>(jsonText); // Десериализация

      this.Text = "Терминал - Главное окно"; // Заголовок окна
      this.Size = new Size(800, 400); // Размер окна
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

    private void InitializePosition() {
      // Настройка таблицы с пропорциями для строк и столбцов
      TableLayoutPanel tableLayoutPanel = new TableLayoutPanel {
        RowCount = 1,
        ColumnCount = 2,
        Dock = DockStyle.Top,
        AutoSize = true, // Автоматический размер по содержимому
        AutoSizeMode = AutoSizeMode.GrowAndShrink,
      };

      // Настройка столбцов
      tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F)); // Используем 50% для каждой колонки
      tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F)); // Используем 50% для каждой колонки
      tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F)); // Используем 50% для каждой колонки

      // Настройка строк
      tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F)); // Размер первой строки 100px
      tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F)); // Основная строка будет занимать весь оставшийся экран
      tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F)); // Еще одна строка снизу
      tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F)); // Еще одна строка снизу
      tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F)); // Еще одна строка снизу

      // Добавление элементов в ячейки
      _menuBar.Dock = DockStyle.Top;
      tableLayoutPanel.Controls.Add(_menuBar, 0, 0);  // Меню сверху
      tableLayoutPanel.Controls.Add(_tablo, 0, 1); // Кнопка на основной ячейке
      tableLayoutPanel.SetColumnSpan(_tablo, 2);

      tableLayoutPanel.Controls.Add(_openButton, 0, 2); // Кнопка на основной ячейке
      tableLayoutPanel.Controls.Add(_closeButton, 1, 2); // Кнопка на основной ячейке
      tableLayoutPanel.Controls.Add(_mainButton, 0, 3); // Кнопка на основной ячейке
      tableLayoutPanel.SetColumnSpan(_mainButton, 2);

      this.Controls.Add(tableLayoutPanel);
    }
  }
}

