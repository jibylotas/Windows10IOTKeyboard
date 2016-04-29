using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PCIT.Windows10.IOT.Input.KeyboardInput
{
    public sealed partial class Keyboard : UserControl
    {
        public Keyboard()
        {
            this.InitializeComponent();
            this.Loaded += Keyboard_Loaded;
           

        }

        private void Keyboard_Loaded(object sender, RoutedEventArgs e)
        {
            BindToWindow();
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        public void BindToWindow()
        {
            foreach (TextBox tb in FindVisualChildren<TextBox>(Window.Current.Content))
            {
                tb.GotFocus += Tb_GotFocus;
            }
            this.SendKey += Keyboard_SendKey;
        }

        private void Keyboard_SendKey(string letter)
        {
            if (CurrentlySelected != null)
                CurrentlySelected.Text += letter;

        }

        internal TextBox CurrentlySelected { get; set; }

        private void Tb_GotFocus(object sender, RoutedEventArgs e)
        {
            CurrentlySelected = (TextBox)sender;
            ShowDialog();
        }

        List<List<KeyboardKey>> lines = new List<List<KeyboardKey>>();
        public void InitalizeUSKeyboard(Grid keyboardgrd)
        {
            lines.Clear();

            lines.Add(new List<KeyboardKey>());
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "`", ShiftValue = "~", Display = "`" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "1", ShiftValue = "!", Display = "1" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "2", ShiftValue = "@", Display = "2" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "3", ShiftValue = "#", Display = "3" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "4", ShiftValue = "$", Display = "4" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "5", ShiftValue = "%", Display = "5" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "6", ShiftValue = "^", Display = "6" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "7", ShiftValue = "&", Display = "7" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "8", ShiftValue = "*", Display = "8" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "9", ShiftValue = "(", Display = "9" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "0", ShiftValue = ")", Display = "0" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "-", ShiftValue = "_", Display = "-" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "=", ShiftValue = "+", Display = "=" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "", ShiftValue = "", Display = "Back", Width = 100, IsBackspace=true});
            lines.Add(new List<KeyboardKey>());

            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "q", ShiftValue = "Q", Display = "q" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "w", ShiftValue = "W", Display = "w" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "e", ShiftValue = "E", Display = "e" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "r", ShiftValue = "R", Display = "r" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "t", ShiftValue = "T", Display = "t" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "y", ShiftValue = "Y", Display = "y" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "u", ShiftValue = "U", Display = "u" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "i", ShiftValue = "I", Display = "i" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "o", ShiftValue = "O", Display = "o" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "p", ShiftValue = "P", Display = "p" });
            lines.Add(new List<KeyboardKey>());
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "", ShiftValue = "", Display = "CAPS", Width = 100, IsCapsKey=true, IsShiftKey=true });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "a", ShiftValue = "A", Display = "a" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "s", ShiftValue = "S", Display = "s" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "d", ShiftValue = "D", Display = "d" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "f", ShiftValue = "F", Display = "f" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "g", ShiftValue = "G", Display = "g" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "h", ShiftValue = "H", Display = "h" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "j", ShiftValue = "J", Display = "j" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "k", ShiftValue = "K", Display = "k" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "l", ShiftValue = "L", Display = "l" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "\r", ShiftValue = "\r", Display = "enter", Width=100 });

            lines.Add(new List<KeyboardKey>());
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "", ShiftValue = "", Display = "Shift", Width=100, IsShiftKey = true });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "z", ShiftValue = "Z", Display = "z" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "x", ShiftValue = "X", Display = "x" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "c", ShiftValue = "C", Display = "c" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "v", ShiftValue = "V", Display = "v" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "b", ShiftValue = "B", Display = "b" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "n", ShiftValue = "N", Display = "n" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "m", ShiftValue = "M", Display = "m" });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = ",", ShiftValue = "<", Display = "," });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = ".", ShiftValue = ">", Display = "." });
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = "", ShiftValue = "" ,Display = "Shift", Width = 100, IsShiftKey = true });

            lines.Add(new List<KeyboardKey>());
            lines[lines.Count - 1].Add(new KeyboardKey() { DefaultValue = " ", ShiftValue = " ", Display = "space", Width=1080 });

            keyboardgrd.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            keyboardgrd.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            keyboardgrd.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            keyboardgrd.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            keyboardgrd.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

            int lineCounter = 0;
            foreach (List<KeyboardKey> lineLetters in lines)
            {
                Grid gLine = new Grid();
                gLine.HorizontalAlignment = HorizontalAlignment.Center;

                gLine.SetValue(Grid.RowProperty, lineCounter);

                for (int i = 0; i < lineLetters.Count; i++)
                {
                    gLine.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

                    Button b = new Button();
                    b.Margin = new Thickness(7);
                    b.MinWidth = lineLetters[i].Width;
                    b.MinHeight = 75;
                    b.Click += B_Click;
                    b.Content = lineLetters[i].Display;
                    b.SetValue(Grid.ColumnProperty, i);
                    b.SetValue(Grid.RowProperty, lineCounter);
                    gLine.Children.Add(b);
                }
                keyboardgrd.Children.Add(gLine);
                lineCounter++;
            }
        }
        bool shiftKey = false;
        bool capsKey = false;
        
        private void RefreshKeyboard()
        {
            Grid gRoot = (Grid)cd.Content;
            for (int i=0;i<gRoot.Children.Count;i++)
            {
                Grid g = gRoot.Children[i] as Grid;
                if (g != null)
                {
                    foreach (Button b in g.Children)
                    {
                        
                        int colProp = (int)b.GetValue(Grid.ColumnProperty);
                        int rowProp = (int)b.GetValue(Grid.RowProperty);
                        if (lines[rowProp][colProp].IsCapsKey)
                        {
                            if(capsKey)
                                b.Background = new SolidColorBrush(Color.FromArgb(255, 125, 125, 125));
                            else
                                b.ClearValue(UserControl.BackgroundProperty);
                        }
                        else if (lines[rowProp][colProp].IsShiftKey)
                        {
                            if (shiftKey)
                                b.Background = new SolidColorBrush(Color.FromArgb(255, 125, 125, 125));
                            else
                            {
                                b.ClearValue(UserControl.BackgroundProperty);

                            }
                        }

                        if (shiftKey || capsKey)
                            if(lines[rowProp][colProp].ShiftValue.Trim()!="")
                            b.Content = lines[rowProp][colProp].ShiftValue;
                        else
                                b.Content = lines[rowProp][colProp].Display;
                        else
                            b.Content = lines[rowProp][colProp].Display;
                    }
                }
            }
        }
        private void B_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(((Button)sender).Content);
            FrameworkElement letter = (FrameworkElement)((Button)sender);
            KeyboardKey key = lines[(int)letter.GetValue(Grid.RowProperty)][(int)letter.GetValue(Grid.ColumnProperty)];



            if (key.IsCapsKey )
            {
                
                capsKey = !capsKey;
                if (capsKey)
                    shiftKey = true;
                else
                    shiftKey = false;

            }
            else if (key.IsShiftKey)
            {
                shiftKey = !shiftKey;
                capsKey = false;
            }
            else
                OnSendKey(key, key.IsBackspace);
            RefreshKeyboard();


        }
        public event SendKeyHandler SendKey;

        protected void OnSendKey(KeyboardKey letter, bool backspace = false)
        {
            if (SendKey != null)

                if (!backspace)
                {
                    if (!shiftKey)
                        SendKey(letter.DefaultValue);
                    else
                        SendKey(letter.ShiftValue);
                }
                else
                {
                    if (CurrentlySelected != null)
                    {
                        if (CurrentlySelected.Text.Length - 1 >= 0)
                            CurrentlySelected.Text = CurrentlySelected.Text.Remove(CurrentlySelected.Text.Length - 1, 1);
                    }
                }
            if (shiftKey&&!capsKey)
                shiftKey = false;

        }
        Flyout flyout;
        public async Task Start()

        {

            flyout = new Flyout();
            flyout.Content = keyboardGrid;

            flyout.ShowAt((FrameworkElement)Parent);


        }
        Flyout cd = new Flyout();
        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        public async Task ShowDialog()
        {
            Style s = new Windows.UI.Xaml.Style { TargetType = typeof(FlyoutPresenter) };
            s.Setters.Add(new Setter(FlyoutPresenter.MinWidthProperty, 1600));
            cd.FlyoutPresenterStyle = s;
            cd.Placement = FlyoutPlacementMode.Top;

            Grid g = ((Grid)new Grid());

            InitalizeUSKeyboard(g);
            g.HorizontalAlignment = HorizontalAlignment.Stretch;

            cd.Content = g;
            cd.ShowAt((FrameworkElement)this);
            RefreshKeyboard();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowDialog();
            
        }
    }
    public delegate void SendKeyHandler(string letter);
}
