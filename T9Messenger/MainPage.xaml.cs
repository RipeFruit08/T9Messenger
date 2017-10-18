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
                    do_keypress(2, new char[] { 'A', 'B', 'C' });
                    break;
                case "3":
                    do_keypress(3, new char[] { 'D', 'E', 'F' });
                    break;
                case "4":
                    do_keypress(4, new char[] { 'G', 'H', 'I' });
                    break;
                case "5":
                    do_keypress(5, new char[] { 'J', 'K', 'L' });
                    break;
                case "6":
                    do_keypress(6, new char[] { 'M', 'N', 'O' });
                    break;
                case "7":
                    do_keypress(7, new char[] { 'P', 'Q', 'R', 'S' });
                    break;
                case "8":
                    do_keypress(8, new char[] { 'T', 'U', 'V' });
                    break;
                case "9":
                    do_keypress(9, new char[] { 'W', 'X', 'Y', 'Z' });
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

        private void do_keypress(int keyCode, char[] chars)
        {
            if (!vm.predictive)
            {
                // was less than a second since last keypress 
                if ((DateTime.Now - vm.lastPress).Seconds < 1 && vm.keyCode == keyCode)
                {
                    char lastch = vm.text[vm.text.Length - 1];
                    for (int i = 0; i < chars.Length; i++)
                    {
                        if (lastch == chars[i])
                        {
                            int idx = (i < chars.Length - 1) ? i + 1 : 0;
                            vm.text = vm.text.Substring(0, vm.text.Length - 1) + chars[idx];
                            break;
                        }
                    }
                }
                // add new letter to text 
                else
                {
                    vm.text += chars[0];
                }

                vm.lastPress = DateTime.Now;
                vm.keyCode = keyCode;
            }
            else
            {
                var last = (vm.keyCombs.Count != 0) ? vm.keyCombs.Last() : new List<int>();
                last.Add(keyCode);
                // new list, add it
                if(last.Count == 1)
                {
                    vm.keyCombs.Add(last);
                }
                var ws = possible_valid_words(last);
                foreach ( var w in ws)
                {
                    Debug.Write(w + " ");
                }
                Debug.WriteLine("");
            }
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

        private List<string> possible_words(IEnumerable<int> comb)
        {
            var letters = ViewModel.ViewModel.keyMap[comb.ElementAt(0)];
            List<string> words = new List<string>();
            if (comb.Count() == 1)
            {
                foreach(var c in letters)
                {
                    words.Add(c.ToString());
                }
                return words;
            }
            else
            {
                foreach (var c in letters)
                {
                    var tail = comb.Skip(1);
                    var sub_words = possible_words(tail);
                    foreach( var w in sub_words )
                    {
                        words.Add(c + w);   
                    }

                }
            }
            //List<string> words = new List<string>();
            return words;
        }

        private List<string> possible_valid_words(IEnumerable<int> comb)
        {
            List<string> valid_words = new List<string>();
            var words = possible_words(comb);
            foreach ( var w in words)
            {
                if ( vm.m.words.Contains(w))
                {
                    valid_words.Add(w);
                }
            }
            return valid_words;
        }
    }
}
