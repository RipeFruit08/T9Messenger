using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        public List<string> suggestions {
            get
            {
                return m.possible_words;
            }
            set
            {
                m.possible_words = value;
                OnPropertyChanged(nameof(suggestions));
            }
        }

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

        public string text
        {
            get
            {
                return m.text;
            }
            set
            {
                m.text = value;
                OnPropertyChanged(nameof(text));
            }
        }

        public void delete()
        {
            if (text != "")
            {
                text = text.Substring(0, text.Length - 1);
            }
            // throw away current set of keyCombs and revert back to set prior
            if (predictive)
            {
                if (m.keyCombs.Count > 0)
                {
                    var last = m.keyCombs.Last();
                    // means we just wanna get rid of last element here
                    if ( last.Count > 0)
                    {
                        last.RemoveAt(last.Count-1);
                        if (last.Count > 0)
                        {
                            var ws = possible_valid_words(last);
                            suggestions = ws;
                            m.word_cycle = 0;
                        }
                        else
                        {
                            m.keyCombs.RemoveAt(m.keyCombs.Count - 1);
                            suggestions = new List<string>();
                        }
                    }
                    else
                    {
                        m.keyCombs.RemoveAt(m.keyCombs.Count - 1);
                        last = m.keyCombs.Last();
                        var ws = possible_valid_words(last);
                        suggestions = ws;
                        m.word_cycle = 0;
                    }
                }
            }
        }

        public void space()
        {
            text += " ";

            // can only assume that if someone pressed space in predicitive mode
            // then they want to proceed onto the next word
            if (predictive)
            {
                m.keyCombs.Add(new List<int>());
                m.sug_chosen = false;
            }
        }

        public void makeChoice()
        {
            // button doesnt have well defined functionality unless in predictive mode
            if (predictive)
            {
                Debug.WriteLine("youve made a choice!");
                var res = m.suggestion;
                text = text.Substring(0, text.Length - res.Length) + res;
                /*
                string res;
                if ((res = m.suggestion) != "")
                {
                    if (!m.sug_chosen)
                    {
                        text += res;
                        m.sug_chosen = true;
                    }
                    else
                    {
                        text = text.Substring(0, text.Length - res.Length) + res;
                    } 
                }
                */
            }
        }

        public void keypress(int keyCode)
        {
            if (!predictive)
            {
                var chars = keyMap[keyCode];
                // was less than a second since last keypress 
                if ((DateTime.Now - m.lastPress).Seconds < 1 && m.keyCode == keyCode)
                {
                    char lastch = text[text.Length - 1];
                    for (int i = 0; i < chars.Length; i++)
                    {
                        if (lastch == chars[i])
                        {
                            int idx = (i < chars.Length - 1) ? i + 1 : 0;
                            text = text.Substring(0, text.Length - 1) + chars[idx];
                            break;
                        }
                    }
                }
                // add new letter to text 
                else
                {
                    text += chars[0];
                }

                m.lastPress = DateTime.Now;
                m.keyCode = keyCode;
            }
            else
            {
                var last = (m.keyCombs.Count != 0) ? m.keyCombs.Last() : new List<int>();
                last.Add(keyCode);
                // new list, add it
                if (last.Count == 1)
                {
                    m.keyCombs.Add(last);
                }
                var ws = possible_valid_words(last);
                if(ws.Count == 0)
                {
                    var hyphens = "";
                    for ( int i = 0; i < last.Count; i++)
                    {
                        hyphens += '-';
                    }
                    ws.Add(hyphens);
                }
                else
                {
                    var tmp = ws[0];
                    text = text.Substring(0, text.Length - (tmp.Length - 1)) + tmp;
                }
                suggestions = ws;
                m.word_cycle = 0;
                foreach (var w in ws)
                {
                    Debug.Write(w + " ");
                }
                Debug.WriteLine("");
            }
        }

        private List<string> possible_words(IEnumerable<int> comb)
        {
            var letters = keyMap[comb.ElementAt(0)];
            List<string> words = new List<string>();
            if (comb.Count() == 1)
            {
                foreach (var c in letters)
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
                    foreach (var w in sub_words)
                    {
                        words.Add(c + w);
                    }

                }
            }
            return words;
        }

        private List<string> possible_valid_words(IEnumerable<int> comb)
        {
            List<string> valid_words = new List<string>();
            var words = possible_words(comb);
            foreach (var w in words)
            {
                if (m.words.Contains(w))
                {
                    valid_words.Add(w);
                }
            }
            return valid_words;
        }


        private ViewModel()
        {
            m = new Model.Model("english-word.txt");
            //text = "Type some stuff";
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
