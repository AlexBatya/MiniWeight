using System;
using System.Windows.Forms;

namespace MyApp.Views {
  partial class Input {

    private void InitializeTitle(){
      this.Width = 900;
      this.Height = 50;

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
