using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace MyApp.Views {
  partial class Tablo {
    private PrivateFontCollection fonts = new PrivateFontCollection();

    private void InitializeComponent() {
      this.weightLabel = new Label();
      this.SuspendLayout();

      string fontPath = "C:/Users/kegla/Desktop/AlexBatya/MiniWeight/src/Assets/Fonts/digital_7.ttf"; // Укажите путь к файлу шрифта в проекте
      fonts.AddFontFile(fontPath);
      Font digitalFont = new Font(fonts.Families[0], 64, FontStyle.Bold);

      // Настройки отображения веса
      this.weightLabel.Dock = DockStyle.Fill;
      this.weightLabel.TextAlign = ContentAlignment.MiddleCenter;
      this.weightLabel.Font = digitalFont;
      this.weightLabel.ForeColor = Color.Lime;
      this.weightLabel.BackColor = Color.Black;
      this.weightLabel.Text = "0000.00 kg";

      // Добавляем label на UserControl
      this.Controls.Add(this.weightLabel);

      // Настройки самого UserControl
      this.Size = new Size(800, 150);
      this.ResumeLayout(false);
    }

    private void InitializeTitle(){
      this.BorderStyle = BorderStyle.FixedSingle; // Рамка вокруг табло
    }

  }
}
