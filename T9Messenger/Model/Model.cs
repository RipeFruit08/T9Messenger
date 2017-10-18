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
            predictive = false;
            var p = Directory.GetCurrentDirectory();
            //var fr = new StreamReader("C:\english-words.txt");

            Task.Run(() => populate_dict());
        }
    }
}
