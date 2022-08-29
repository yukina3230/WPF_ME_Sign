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
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace WPF_ME_Sign.Components
{
    /// <summary>
    /// Interaction logic for NumberTextbox.xaml
    /// </summary>
    public partial class NumberTextbox : UserControl
    {
        private bool isTextChanging;
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(NumberTextbox), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, TextboxPropertyChanged, null, false, UpdateSourceTrigger.PropertyChanged));

        private static void TextboxPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NumberTextbox numberTextBox)
            {
                numberTextBox.UpdateText();
            }
        }

        private void UpdateText()
        {
            if (!isTextChanging)
            {
                numberTextbox.Text = Text;
            }
        }

        public NumberTextbox()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void numberTextbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void numberTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isTextChanging = true;
            Text = numberTextbox.Text;
            isTextChanging = false;
        }
    }
}
