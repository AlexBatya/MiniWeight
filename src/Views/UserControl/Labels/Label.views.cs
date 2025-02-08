using System;
using System.Windows.Forms;

namespace MyApp.Views {
  public partial class CustomLabel: Label  {

    public CustomLabel(string text){
      this.Text = text;

      InitializeTitle();
    }

    public void ChangeText(string newText) {
      this.Text = newText;
    }

  }
}
