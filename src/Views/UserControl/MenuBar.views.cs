using System;
using System.Windows.Forms;
using MyApp.Controllers;

namespace MyApp.Views {
  public class MenuBar: UserControl {
    private readonly MainController _mainController;
    private readonly MainForm _mainForm;
    
    public MenuBar(MainForm mainForm){
      _mainForm = mainForm;
      _mainController = new MainController(this);

      var menuStrip = new MenuStrip {
        Dock = DockStyle.Top
      };

      var fileMenu = new ToolStripMenuItem("Файл");
      var exitMenuItem = new ToolStripMenuItem("Выход", null, _mainController.AppExit){
        ShortcutKeys = Keys.Control | Keys.W
      };
      var settingsItem = new ToolStripMenuItem("Настройки", null, (e, sender) => {
        var settings = new Settings(_mainForm); 
        settings.Show();
      }){
        ShortcutKeys = Keys.Control | Keys.S
      };
      var transportation = new ToolStripMenuItem("Колебровка", null, (e, sender) => {
        var transportation = new Transportation(_mainForm); 
        transportation.Show();
      }){
        ShortcutKeys = Keys.Control | Keys.K
      };

      fileMenu.DropDownItems.AddRange(new ToolStripItem[] {
        settingsItem,
        transportation,
        exitMenuItem,
      });

      

      var options = new ToolStripMenuItem("Опции");
      var aboutItem = new ToolStripMenuItem("О программе", null, _mainController.OpenAbout){
        ShortcutKeys = Keys.Control | Keys.O
      };

      var dachick = new ToolStripMenuItem("Датчики", null, _mainController.OpenSensors){
        ShortcutKeys = Keys.Control | Keys.D
      };

      options.DropDownItems.AddRange(new ToolStripItem[] {
        dachick,
        aboutItem,
      });

      menuStrip.Items.AddRange(new ToolStripItem[]{
        fileMenu,
        options
      });

      this.Controls.Add(menuStrip);
    }

  }

}
