using System;
using System.Windows.Forms;

namespace MyApp.Views {
  partial class CustomLabel  {
    
    private void InitializeTitle(){
      this.Font = new System.Drawing.Font("Arial", 12);
      this.ForeColor = System.Drawing.Color.Black;

      this.Dock = DockStyle.Fill;
    }

  }
}
