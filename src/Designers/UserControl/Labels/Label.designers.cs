using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using System.Text.Json;
using MyApp.Models;

namespace MyApp.Views {
  partial class CustomLabel  {
    private PrivateFontCollection fonts = new PrivateFontCollection();

    private void InitializeTitle(){
      string jsonText = File.ReadAllText("C:/Users/kegla/Desktop/AlexBatya/MiniWeight/src/settings.json"); // Читаем файл
      var data = JsonSerializer.Deserialize<SrcSettings>(jsonText); // Десериализация

      string fontPath = data.FontText; // Укажите путь к файлу шрифта в проекте
      fonts.AddFontFile(fontPath);
      Font digitalFont = new Font(fonts.Families[0], 12, FontStyle.Regular);

      this.Font = digitalFont;
      this.ForeColor = System.Drawing.Color.Black;

      this.Dock = DockStyle.Fill;
    }

  }
}
