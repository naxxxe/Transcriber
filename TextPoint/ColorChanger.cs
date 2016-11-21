using System.Collections.Generic;
using System.Drawing;

namespace TextPoint
{
    public class ColorChanger
    {
        public List<Color> GetAll(Color backgroundcolor)
        {
            ColorConverter cc = new ColorConverter();
            List<Color> colorList = new List<Color>();
            foreach (Color c in cc.GetStandardValues())
            {
                double value = backgroundcolor.GetBrightness() - c.GetBrightness();
                if (value >= 0.5)
                    colorList.Add(c);
            }
            return colorList;
        }
    }
}
