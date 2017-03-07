using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.Model
{
    public class WordApplication
    {
        private Microsoft.Office.Interop.Word.Application wordApp;

        public Microsoft.Office.Interop.Word.Application WordApp
        {
            get { return wordApp; }
            set { wordApp = value; }
        }
        private static WordApplication instance;
        private WordApplication() { }
        public static WordApplication GetInstance()
        {
            if (instance == null)
            {
                instance = new WordApplication();
            }
            return instance;
        }
    }
}
