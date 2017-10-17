using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace T9Messenger
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public ViewModel.ViewModel vm { get; set; }

        public MainPage()
        {
            vm = ViewModel.ViewModel.GetViewModel();
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button was pressed");
            var b = sender as Button;
            var keyCode = b.CommandParameter ?? "-1";
            switch(keyCode)
            {
                case "1":
                    // nothing
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "7":
                    break;
                case "8":
                    break;
                case "9":
                    break;
                case "*":
                    break;
                case "0":
                    break;
                case "#":
                    break;
                default:
                    break;
            }
            //vm.text = "1";
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            // was less than a second since last keypress 
            if ( (DateTime.Now - vm.lastPress).Seconds < 1 && vm.keyCode == 2 )
            {
                var lastch = vm.text[vm.text.Length - 1];
                switch (lastch)
                {
                    case 'A':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "B";
                        break;
                    case 'B':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "C";
                        break;
                    case 'C':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "A";
                        break;
                    default:
                        break;
                }
            }

            // add new letter 
            else
            {
                vm.text += "A";
            }

            vm.lastPress = DateTime.Now;
            vm.keyCode = 2;
        }
        
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            // was less than a second since last keypress 
            if ( (DateTime.Now - vm.lastPress).Seconds < 1 && vm.keyCode == 3)
            {
                var lastch = vm.text[vm.text.Length - 1];
                switch (lastch)
                {
                    case 'D':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "E";
                        break;
                    case 'E':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "F";
                        break;
                    case 'F':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "D";
                        break;
                    default:
                        break;
                }
            }

            // add new letter 
            else
            {
                vm.text += "D";
            }

            vm.lastPress = DateTime.Now;
            vm.keyCode = 3;
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            // was less than a second since last keypress 
            if ( (DateTime.Now - vm.lastPress).Seconds < 1 && vm.keyCode == 4)
            {
                var lastch = vm.text[vm.text.Length - 1];
                switch (lastch)
                {
                    case 'G':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "H";
                        break;
                    case 'H':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "I";
                        break;
                    case 'I':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "G";
                        break;
                    default:
                        break;
                }
            }

            // add new letter 
            else
            {
                vm.text += "G";
            }

            vm.lastPress = DateTime.Now;
            vm.keyCode = 4;
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            // was less than a second since last keypress 
            if ( (DateTime.Now - vm.lastPress).Seconds < 1 && vm.keyCode == 5)
            {
                var lastch = vm.text[vm.text.Length - 1];
                switch (lastch)
                {
                    case 'J':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "K";
                        break;
                    case 'K':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "L";
                        break;
                    case 'L':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "J";
                        break;
                    default:
                        break;
                }
            }

            // add new letter 
            else
            {
                vm.text += "J";
            }

            vm.lastPress = DateTime.Now;
            vm.keyCode = 5;
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            // was less than a second since last keypress 
            if ( (DateTime.Now - vm.lastPress).Seconds < 1 && vm.keyCode == 6)
            {
                var lastch = vm.text[vm.text.Length - 1];
                switch (lastch)
                {
                    case 'M':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "N";
                        break;
                    case 'N':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "O";
                        break;
                    case 'O':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "M";
                        break;
                    default:
                        break;
                }
            }

            // add new letter 
            else
            {
                vm.text += "M";
            }

            vm.lastPress = DateTime.Now;
            vm.keyCode = 6;
        }

        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            // was less than a second since last keypress 
            if ( (DateTime.Now - vm.lastPress).Seconds < 1 && vm.keyCode == 7)
            {
                var lastch = vm.text[vm.text.Length - 1];
                switch (lastch)
                {
                    case 'P':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "Q";
                        break;
                    case 'Q':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "R";
                        break;
                    case 'R':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "S";
                        break;
                    case 'S':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "P";
                        break;
                    default:
                        break;
                }
            }

            // add new letter 
            else
            {
                vm.text += "P";
            }

            vm.lastPress = DateTime.Now;
            vm.keyCode = 7;
        }

        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            // was less than a second since last keypress 
            if ( (DateTime.Now - vm.lastPress).Seconds < 1 && vm.keyCode == 8)
            {
                var lastch = vm.text[vm.text.Length - 1];
                switch (lastch)
                {
                    case 'T':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "U";
                        break;
                    case 'U':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "V";
                        break;
                    case 'V':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "T";
                        break;
                    default:
                        break;
                }
            }

            // add new letter 
            else
            {
                vm.text += "T";
            }

            vm.lastPress = DateTime.Now;
            vm.keyCode = 8;
        }

        private void Button_Click9(object sender, RoutedEventArgs e)
        {
            // was less than a second since last keypress 
            if ( (DateTime.Now - vm.lastPress).Seconds < 1 && vm.keyCode == 9)
            {
                var lastch = vm.text[vm.text.Length - 1];
                switch (lastch)
                {
                    case 'W':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "X";
                        break;
                    case 'X':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "Y";
                        break;
                    case 'Y':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "Z";
                        break;
                    case 'Z':
                        vm.text = vm.text.Substring(0, vm.text.Length - 1) + "W";
                        break;
                    default:
                        break;
                }
            }

            // add new letter 
            else
            {
                vm.text += "W";
            }

            vm.lastPress = DateTime.Now;
            vm.keyCode = 9;
        }

        private void Button_ClickSpace(object sender, RoutedEventArgs e)
        {
            vm.text += " ";
        }

        private void Button_ClickDel(object sender, RoutedEventArgs e)
        {
            if ( vm.text != "")
            {
                vm.text = vm.text.Substring(0, vm.text.Length - 1);
            }
        }
    }
}
