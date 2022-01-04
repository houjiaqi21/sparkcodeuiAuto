using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P0TestCase
{
    class CustomFun
    {
        public static string LogFolderpath = ConfigurationSettings.AppSettings["LogFinalPath"];
        public static string FinalPath = ConfigurationSettings.AppSettings["LogFinalPath"];
        public static string FileName = "ScopeReport";

        static string imagePath = ConfigurationSettings.AppSettings["ImagePath"];

        public static string MyDateTime = DateTime.Now.ToString("_yyyyMMdd_HHmmss");
        public static string LogTextFile(string WritingText)
        {
            
            FinalPath = LogFolderpath + "\\" + FileName + MyDateTime + ".txt";

            if(!File.Exists(FinalPath))
            {
                using (StreamWriter sw = File.CreateText(FinalPath))
                {

                }
            }

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(FinalPath, true))
            {
                file.WriteLine(WritingText);
            }
            return FinalPath;
        }


        public static void CaptureImage(UITestControl MyWindow, string name)
        {
            Image shot = MyWindow.CaptureImage();
            shot.Save(imagePath + name + MyDateTime + ".png");
        }

        public static string randomstring(int rEPEATcHAR)
        {
            var chars = "ABC--DEFGHIJ+_k LMNOPQRSTUVWXYZ0__12345--6789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, rEPEATcHAR).Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }
        

    }
}
