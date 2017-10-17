using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace T9Messenger.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private static ViewModel Instance = new ViewModel();
        public DateTime lastPress { get; set; }
        public int keyCode { get; set; }
        private string _text;
        public string text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(text));
            }
        }

        private ViewModel()
        {
            lastPress = DateTime.Now;
            //text = "Type some stuff";
            text = "";
            keyCode = -1;
        }

        public static ViewModel GetViewModel()
        {
            return Instance;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
