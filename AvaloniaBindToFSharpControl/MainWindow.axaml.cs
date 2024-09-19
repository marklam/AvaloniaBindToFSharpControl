using Avalonia.Controls;

namespace AvaloniaBindToFSharpControl
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
            var testPropertyAccess = FSharpControl.UserControl1._MessageProperty;
            var testPropertyAccess2 = FSharpControl.UserControl2.MessageProperty;
        }
    }
}