using System;
using System.Windows.Forms;

namespace MyApp.Controllers {
  public class KeyController {
    private readonly Form _view;

    public KeyController(Form view) {
      _view = view;
      _view.KeyPreview = true; // Позволяет форме обрабатывать нажатия клавиш
      _view.KeyDown += OnKeyDown;
    }

    private void OnKeyDown(object sender, KeyEventArgs e) {
      if (e.Control && e.KeyCode == Keys.Q) {
        Application.Exit(); // Закрывает всё приложение
      }
      else if (e.Control && e.KeyCode == Keys.W) {
        _view.Close(); // Закрывает только текущее окно
      }
    }
  }
}

