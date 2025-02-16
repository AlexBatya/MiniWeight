using System;
using System.Windows.Forms;

namespace MyApp.Models {
  public class ConfigData  {
    public string PortName { get; set; }
    public int BaudRate { get; set; }
    public int Discret { get; set; }
    public int PollingTime { get; set; }
    public float TransportationAll{ get; set; }
    public float TransportationWeight{ get; set; }
    public string SomeSetting { get; set; }

    public ConfigData() {
      PortName = "COM5";
      BaudRate = 9600;
      TransportationAll = 1;
      TransportationWeight = 1;
      Discret = 1;
      PollingTime = 20;
      SomeSetting = "DefaultSetting";
    }
  }

  
}
