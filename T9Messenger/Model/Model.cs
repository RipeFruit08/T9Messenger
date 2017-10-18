using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace T9Messenger.Model
{
    public class Model
    {
        public HashSet<string> words;
        public bool predictive { get; set; }
        public string text { get; set; }
        public List<List<int>> keyCombs { get; set; }
        public List<string> possible_words { get; set; }
        public int word_cycle { get; set; }
        public bool sug_chosen { get; set; }
        public string suggestion
        {
            get
            {
                if (possible_words.Count == 0)
                {
                    return ""; // no suggestion
                }
                if (word_cycle == possible_words.Count - 1)
                {
                    var res = possible_words[word_cycle];
                    word_cycle = 0;
                    return res;
                }
                else
                {
                    return possible_words[word_cycle++];
                }
            }
        }
        // paired with keyCode, used to determine when and what
        // the last key that was pressed
        public DateTime lastPress { get; set; }
        public int keyCode { get; set; }


        private void populate_dict()
        {
            // having troubles with FileIO, had to put this file
            // waaaay down in like bin /86/Debug/AppX
            var lines = File.ReadAllLines("english-words.txt");
            words = new HashSet<string>();
            foreach (var s in lines)
            {
                words.Add(s);
            }
        }

        public Model(string fn)
        {
            var p = Directory.GetCurrentDirectory();
            Task.Run(() => populate_dict());
            predictive = false;
            text = "";
            lastPress = DateTime.Now;
            keyCode = -1;
            keyCombs = new List<List<int>>();
            possible_words = new List<string>();
            //possible_words.Add("hi");
            //possible_words.Add("hello");
            word_cycle = 0;
            sug_chosen = false;
        }
    }
}
