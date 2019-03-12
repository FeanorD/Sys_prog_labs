using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Net;

namespace manual_light
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                string text_file = "";
                string write_path1 = @"C:\textDirectory\ManualLight.txt";
                string write_path2 = @"C:\textDirectory\test.txt";

                using (WebClient W = new WebClient())
                {
                    text_file = W.DownloadString("http://mail.univ.net.ua/manual.txt");

                }


                using (StreamWriter sw = new StreamWriter(write_path2, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text_file);
                }

                string[] NewFile = File.ReadAllLines(write_path2);

                using (StreamWriter sw = new StreamWriter(write_path1, false, System.Text.Encoding.Default))
                {
                    for (int i = 0; i < NewFile.Length; i++)
                    {
                        if (NewFile[i].Contains(args[0]) || NewFile[i].IndexOf("if") == 0 || NewFile[i].IndexOf("If") == 0)
                        {
                            NewFile[i] = "";
                            sw.WriteLine(NewFile[i]);
                        }

                        else if (NewFile[i].Contains(" chip ") || NewFile[i].Contains(" chip.") || NewFile[i].Contains(" chip,"))
                        {
                            NewFile[i] = args[1];
                            sw.WriteLine(NewFile[i]);
                        }
                        else
                        {
                            sw.WriteLine(NewFile[i]);
                        }
                       

                        
                    }
                }
            
            


            }
        }
    }
}
