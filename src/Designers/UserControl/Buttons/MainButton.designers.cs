using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using System.Text.Json;
using MyApp.Models;

namespace MyApp.Views {
  partial class MainButton {
    private PrivateFontCollection fonts = new PrivateFontCollection();
    
    private void InitializeTitle(){
      string jsonText = File.ReadAllText("C:/Users/user/Desktop/work/programs/desktop/MiniWeight/src/settings.json"); // Читаем файл
      var data = JsonSerializer.Deserialize<SrcSettings>(jsonText); // Десериализация

      this.Dock = DockStyle.Top;
      this.Size = new System.Drawing.Size(150, 50);

      string fontPath = data.FontText; // Укажите путь к файлу шрифта в проекте
      fonts.AddFontFile(fontPath);
      Font digitalFont = new Font(fonts.Families[0], 12, FontStyle.Regular);

      this.Font = digitalFont;
    }
  }
}
