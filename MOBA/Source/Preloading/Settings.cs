using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MOBA
{
    public class Settings
    {
        private static XmlDocument doc;
        private static bool isLoaded;
        private static string _path;

        public static void LoadSettings(string path)
        {
            isLoaded = false;
            doc = new XmlDocument();

            _path = path;
            if (File.Exists(_path))
            {
                doc.Load(_path);
                Console.WriteLine("Settings file has been succesfully loaded!");
                isLoaded = true;
            }
            else
            {
                isLoaded = false;
                Console.WriteLine(path + " not found!");
            }

            ChangeSettings();
        }

        private static void ChangeSettings()
        {
            //  IF settings.xml file is exist then initialize the window based on the xml file
            //  otherwise load the default settings
            if (isLoaded)
            {
                uint w, h;
                bool vsync;
                w = uint.Parse(doc.DocumentElement.SelectSingleNode("/settings/width").InnerText);
                h = uint.Parse(doc.DocumentElement.SelectSingleNode("/settings/height").InnerText);
                vsync = (doc.DocumentElement.SelectSingleNode("/settings/vsync").InnerText == "true") ? true : false;
                Globals.WINDOW_WIDTH  = w;
                Globals.WINDOW_HEIGHT = h;
                Globals.WINDOW_VSYNC  = vsync;
            }
            else
            {
                Globals.WINDOW_WIDTH = 800;
                Globals.WINDOW_HEIGHT = 600;
                Globals.WINDOW_VSYNC = true;
            }
        }

        public static void CloseSettings()
        {
            if (!isLoaded) Console.WriteLine("Settings couldn't be saved because the file is damaged or missing!");
            else
            {
                doc.Save(_path);
            }
            
        }
    }
}
