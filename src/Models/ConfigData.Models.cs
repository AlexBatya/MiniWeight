using System;
using System.Windows.Forms;

namespace MyApp.Models {
  public class ConfigData  {
    public string PortName { get; set; }
    public int BaudRate { get; set; }
    public string SomeSetting { get; set; }

    public ConfigData() {
      PortName = "COM1";
      BaudRate = 9600;
      SomeSetting = "DefaultSetting";
    }
  }

  
}
