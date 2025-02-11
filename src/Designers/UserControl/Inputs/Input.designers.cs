using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using System.Text.Json;
using MyApp.Models;

namespace MyApp.Views {
  partial class Input {
    private PrivateFontCollection fonts = new PrivateFontCollection();

    private void InitializeTitle(){
      string jsonText = File.ReadAllText("C:/Users/user/Desktop/work/programs/desktop/MiniWeight/src/settings.json"); // Читаем файл
      var data = JsonSerializer.Deserialize<SrcSettings>(jsonText); // Десериализация

      this.Width = 900;
      this.Height = 50;

      string fontPath = data.FontText; // Укажите путь к файлу шрифта в проекте
      fonts.AddFontFile(fontPath);
      Font digitalFont = new Font(fonts.Families[0], 12, FontStyle.Regular);

      this.Font = digitalFont;

      this.ForeColor = System.Drawing.Color.Black; // Черный текст
      this.BackColor = System.Drawing.Color.White; // Белый фон
      this.BorderStyle = BorderStyle.FixedSingle; // Добавим границу

      // Увеличим внутренние отступы для текста
      this.Padding = new Padding(10); // Добавим немного пространства вокруг текста

      // Дополнительная стилизация: радиус углов
      this.Region = new System.Drawing.Region(new System.Drawing.Rectangle(0, 0, this.Width, this.Height)); // Радиус углов
      this.TextAlign = HorizontalAlignment.Left; // Выравнивание текста

      // Добавим эффект при фокусе
      this.Enter += (sender, e) => {
          this.BackColor = System.Drawing.Color.LightYellow; // Изменение фона при фокусе
      };

      this.Leave += (sender, e) => {
          this.BackColor = System.Drawing.Color.White; // Возвращаем фон к белому при потере фокуса
      };
    }

  }
}
