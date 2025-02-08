using System;
using System.Windows.Forms;

namespace MyApp.Views {
  public partial class Tablo: UserControl {
    private Label weightLabel;
    public Tablo(){

      InitializeComponent();
      InitializeTitle();
    }

    public void UpdateWeight(int newWeight) {
      weightLabel.Text = newWeight.ToString() + " кг"; // Преобразуем int в string и обновляем
    }

    public void UpdateWeight(string newWeight) {
        weightLabel.Text = newWeight; // Обновляем текст напрямую
    }

  }
}
