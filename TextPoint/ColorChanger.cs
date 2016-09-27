using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextPoint
{
    public class ColorChanger
    {
        public List<Color> GetAll(Color backgroundcolor)
        {
            ColorConverter cc = new ColorConverter();
            List<Color> ColorList = new List<Color>();
            foreach (Color c in cc.GetStandardValues())
            {
                double value = backgroundcolor.GetBrightness() - c.GetBrightness();
                if (value >= 0.5)
                    ColorList.Add(c);
            }
            return ColorList;
        }
    }
}
