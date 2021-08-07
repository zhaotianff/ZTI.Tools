using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZTI.Tools.WPF.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSetCursor_Click(object sender, RoutedEventArgs e)
        {
            ZTI.Tools.WPF.Mouse.SetCursor("pointer.cur");
            Window window = new Window();
            window.Show();
        }

        private void btnSetSystemCursor_Click(object sender, RoutedEventArgs e)
        {
            ZTI.Tools.WPF.Mouse.SetSystemCursor(Definitions.OCR_TYPE.OCR_NORMAL, "pointer.cur");
        }

        private void btnResetSystemCursor_Click(object sender, RoutedEventArgs e)
        {     
            ZTI.Tools.WPF.Mouse.ResetSystemCursor(Definitions.OCR_TYPE.OCR_NORMAL);
        }


        static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void btnMouseHook_Click(object sender, RoutedEventArgs e)
        {
            if(Mouse.HookMouse())
            {
                MessageBox.Show("Set hook success,press [ESC] to unhook");
            }
            else
            {
                MessageBox.Show("Set hook failed");
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                Mouse.UnhookMouse();
            }
        }
    }
}
