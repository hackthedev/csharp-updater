using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;

// Just some Using statements I ended up with. You dont have to neccessary copy them


namespace AdminInstall // The Project Name i came up with.
{
    public static  class Updater
    {
        // If you create for example a C# Winform, you will only
        // need the code following from this comment below, as
        // the rest is created automatically (like that namespace stuff)
    
        // just a string to save StreamReader Content because it thowed
        // an error for me saying it cant use it otherwise
        static string content;
        
        // Method to Check if a new updated version does exist.
        public static void check()
        {
            Form1 f = new Form1();                                                          // To get access to Form1 (my main Form)
            WebClient client = new WebClient();                                             // WebClient to get latest version number from Server

            try
            {
                Stream stream = client.OpenRead("http://127.0.0.1/path/to/version.txt");    // Replace URL with your server. End must be version.txt, otherwise
                StreamReader reader = new StreamReader(stream);                             // update the code to your changes
                content = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                Clipboard.SetText(ex.Message);                                              // If any errors happen, it copies the error message to clipboard
                MessageBox.Show("Konnte keinen Versions-Abgleich durchführen", "error");
            }

            if (content == System.Windows.Forms.Application.ProductVersion)
            {
                // Do nothing because you are already on the newest version
            }
            else
            {
                MessageBox.Show("Update gefunden", "info");

                try
                {
                    // This downloads the update.exe and saves it to the applications startup path.
                    // update.exe is a SFX WinRAR Archive using Override Existing files etc...
                    client.DownloadFile("http://127.0.0.1/path/to/update.exe", Application.StartupPath + "\\update.exe");

                    // If downloaded Update file exists, execute update file and close itself
                    // (close itself because of overwriting issues if keeps running)
                    if (File.Exists(Application.StartupPath + "\\update.exe"))
                    {
                        Process.Start(Application.StartupPath + "\\update.exe");
                        Application.Exit();
                    }
                }
                catch (Exception ex1)
                {
                    Clipboard.SetText(ex1.Message);
                    MessageBox.Show("Could not download update", "error");
                }
            }
        }
    }
}
