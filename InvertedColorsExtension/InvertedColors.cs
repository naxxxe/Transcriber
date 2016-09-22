using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextPoint;

namespace InvertedColorsExtension
{
    public class InvertedColorsExtension : IExtension
    {
        ITextPoint hostApp;

        public void Initialize(ITextPoint hostApplication)
        {
            hostApp = hostApplication;
        }

        public string GetTitle()
        {
            return "Inverted colors";
        }

        public void Execute()
        {
            hostApp.SetBackgroundColor(Color.Black);
            hostApp.SetForegroundColor(Color.LimeGreen);
        }
    }
}
