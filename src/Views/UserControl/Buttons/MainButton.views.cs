using System;
using System.Windows.Forms;

namespace MyApp.Views {
  public partial class MainButton : Button {
    public MainButton(string text, EventHandler? onClick = null) {
      this.Text = text;
      this.Size = new System.Drawing.Size(150, 50);

      if (onClick != null) {
        this.Click += onClick;
      }

      InitializeTitle();
    }
  }
}
