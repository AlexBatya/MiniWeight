using System;
using System.Windows.Forms;

namespace MyApp.Views {
  partial class Tablo {

    private void InitializeComponent() {
      this.weightLabel = new Label();
      this.SuspendLayout();

      // Настройки отображения веса
      this.weightLabel.Dock = DockStyle.Fill;
      this.weightLabel.TextAlign = ContentAlignment.MiddleCenter;
      this.weightLabel.Font = new Font("Digital-7", 48, FontStyle.Bold);
      this.weightLabel.ForeColor = Color.Lime;
      this.weightLabel.BackColor = Color.Black;
      this.weightLabel.Text = "0000.00 кг";

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
