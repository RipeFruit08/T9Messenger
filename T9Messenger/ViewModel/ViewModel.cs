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
        public static Dictionary<int, char[]> keyMap = new Dictionary<int, char[]>()
        {
            {2, new char[]{'a', 'b', 'c' } },
            {3, new char[]{'d', 'e', 'f' } },
            {4, new char[]{'g', 'h', 'i' } },
            {5, new char[]{'j', 'k', 'l' } },
            {6, new char[]{'m', 'n', 'o' } },
            {7, new char[]{'p', 'q', 'r', 's' } },
            {8, new char[]{'t', 'u', 'v' } },
            {9, new char[]{'w', 'x', 'y', 'z' } }
        };
        public Model.Model m { get; set; }
        public DateTime lastPress { get; set; }
        public int keyCode { get; set; }
        public List<List<int>> keyCombs { get; set; }

        public bool predictive
        {
            get
            {
                return m.predictive;
            }
            set
            {
                m.predictive = value;
                OnPropertyChanged(nameof(predictive));
            }
        }
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
            m = new Model.Model("english-word.txt");
            keyCombs = new List<List<int>>();
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
