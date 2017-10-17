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
            if ( vm.text == "" )
            {
                vm.text = "A";
            }
            else
            {
                var lastch = vm.text[vm.text.Length-1];
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
                        vm.text += "A";
                        break;
                }
            }
        }
    }
}
