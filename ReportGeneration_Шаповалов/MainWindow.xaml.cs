using System.Windows;
using ReportGeneration_Шаповалов.Pages;

namespace ReportGeneration_Шаповалов;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        frame.Navigate(new Main());
    }
}
