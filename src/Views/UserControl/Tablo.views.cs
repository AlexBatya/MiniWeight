using System;
using System.Windows.Forms;

namespace MyApp.Views {
  public partial class Tablo: UserControl {
    private Label weightLabel;
    public string weight = "test";

    public Tablo(){

      InitializeComponent();
      InitializeTitle();
    }

    public void UpdateWeight(int newWeight) {
      weight = newWeight.ToString();
      weightLabel.Text = newWeight.ToString() + " kg"; // Преобразуем int в string и обновляем
    }

    public void UpdateWeight(string newWeight) {
        weightLabel.Text = newWeight; // Обновляем текст напрямую
    }

    public string GetWeight(){
      return weightLabel.Text;
    }

  }
}
