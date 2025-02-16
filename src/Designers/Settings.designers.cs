using System;
using System.Windows.Forms;
using System.Text.Json;
using MyApp.Models;

namespace MyApp.Views {
  partial class Settings {

    private void InitializeTitle(){
      string jsonText = File.ReadAllText("C:/Users/user/Desktop/work/programs/desktop/MiniWeight/src/settings.json"); // Читаем файл
      var data = JsonSerializer.Deserialize<SrcSettings>(jsonText); // Десериализация
      
      this.Text = "Терминал - Настройки"; // Заголовок окна
      this.Size = new Size(400, 250); // Размер окна
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
          RowCount = 5, // 5 строк (4 для Label+Input + 1 для кнопок)
          ColumnCount = 2, // 2 колонки
          Dock = DockStyle.Top,
          AutoSize = true, // Автоматический размер по содержимому
          AutoSizeMode = AutoSizeMode.GrowAndShrink,
      };

      // Настройка столбцов
      tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F)); // 30% для Label
      tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F)); // 70% для Input

      // Настройка строк
      for (int i = 0; i < 5; i++) {
          tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F)); // Фиксированная высота строки 40px
      }

      // Добавление элементов в ячейки
      AddLabelAndInput(tableLayoutPanel, _labelCOM, _inputCOM, 0); // Первая строка
      AddLabelAndInput(tableLayoutPanel, _labelSpeed, _inputSpeed, 1); // Вторая строка
      AddLabelAndInput(tableLayoutPanel, _labelDiscret, _inputDiscret, 2); // Третья строка
      AddLabelAndInput(tableLayoutPanel, _labelPollingTime, _inputPollingTime, 3); // Четвертая строка

      // Кнопки
      tableLayoutPanel.Controls.Add(_buttonSave, 0, 4); // Кнопка Save в пятой строке
      tableLayoutPanel.Controls.Add(_buttonClose, 1, 4); // Кнопка Close в пятой строке

      this.Controls.Add(tableLayoutPanel);
  }

  // Метод для добавления Label и Input в TableLayoutPanel
    private void AddLabelAndInput(TableLayoutPanel tableLayoutPanel, Label label, Control input, int row) {
      // Настройка Label
      label.TextAlign = ContentAlignment.MiddleLeft; // Выравнивание текста по левому краю
      label.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom; // Привязка к левому краю
      label.AutoSize = true; // Автоматический размер по содержимому

      // Настройка Input
      input.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom; // Растягивание по ширине ячейки
      input.Dock = DockStyle.Fill; // Заполнение всей ячейки

      // Добавление элементов в таблицу
      tableLayoutPanel.Controls.Add(label, 0, row); // Label в первой колонке
      tableLayoutPanel.Controls.Add(input, 1, row); // Input во второй колонке
    }

  }
}
