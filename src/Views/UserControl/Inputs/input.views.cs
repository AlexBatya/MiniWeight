using System;
using System.Windows.Forms;

namespace MyApp.Views {
  public partial class Input: TextBox  {
    
    public Input(string text){
      this.Text = text;
      
      InitializeTitle();
    }

    public void UpdateInputText(string newText) {
      if (this.InvokeRequired) {
        this.Invoke(new Action<string>(UpdateInputText), newText);
      } else {
        this.Text = newText;
      }
    }

    public string GetInputText() {
      return this.Text;
    }

  }
}
