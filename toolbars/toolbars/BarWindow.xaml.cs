using System;
using System.Collections.Generic;
using System.Linq;
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

namespace toolbars
{
    /// <summary>
    /// Interaction logic for BarWindow.xaml
    /// </summary>
    public partial class BarWindow : Window
    {
        public static RoutedCommand mijnRoutectrlb = new RoutedCommand();
        public static RoutedCommand mijnRoutectrli = new RoutedCommand();

        public BarWindow()
        {
            InitializeComponent();

            CommandBinding mijnctrlb = new CommandBinding(mijnRoutectrlb, ctrlbExecuted);
            this.CommandBindings.Add(mijnctrlb);

            KeyGesture toetsctrlb = new KeyGesture(Key.B, ModifierKeys.Control);
            KeyBinding mijnKeyCtrlB = new KeyBinding(mijnRoutectrlb, toetsctrlb);
            this.InputBindings.Add(mijnKeyCtrlB);

            CommandBinding mijnctrli = new CommandBinding(mijnRoutectrli, ctrliExecuted);
            this.CommandBindings.Add(mijnctrli);

            KeyGesture toetsctrli = new KeyGesture(Key.I, ModifierKeys.Control);
            KeyBinding mijnKeyCtrlI = new KeyBinding(mijnRoutectrli, toetsctrli);
            this.InputBindings.Add(mijnKeyCtrlI);

        }

        

        private void Vet_Aan_Uit()
        {
            if (voorbeeldtekst.FontWeight == FontWeights.Normal)
            {
                voorbeeldtekst.FontWeight = FontWeights.Bold;
                Vet.IsChecked = true;
            }
            else
            {
                voorbeeldtekst.FontWeight = FontWeights.Normal;
                Vet.IsChecked = false;
            }
        }

        private void Vet_Click(object sender, RoutedEventArgs e)
        {
            Vet_Aan_Uit();
        }

        private void Schuin_Aan_Uit()
        {
            if (voorbeeldtekst.FontStyle == FontStyles.Normal)
            {
                voorbeeldtekst.FontStyle = FontStyles.Italic;
                Schuin.IsChecked = true;
            }
            else
            {
                voorbeeldtekst.FontStyle = FontStyles.Normal;
                Schuin.IsChecked = false;
            }
        }
        private void Schuin_Click(object sender, RoutedEventArgs e)
        {
            Schuin_Aan_Uit();
        }

        private void Lettertype_Click(object sender, RoutedEventArgs e)
        {
            MenuItem hetlettertype = (MenuItem)sender;
            foreach (MenuItem lettertypes in Font.Items )
            {
                lettertypes.IsChecked = false;
            }

            hetlettertype.IsChecked = true;
            voorbeeldtekst.FontFamily = new FontFamily(hetlettertype.Header.ToString());
           
        }

        private void ctrlbExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Vet_Aan_Uit();
        }

        private void ctrliExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Schuin_Aan_Uit();
        }
    }
}
