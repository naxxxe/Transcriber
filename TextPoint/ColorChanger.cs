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
        public List<Color> GetAll()
        {
            ColorConverter cc = new ColorConverter();
            List<Color> ColorList = new List<Color>();
            foreach (Color c in cc.GetStandardValues())
            {
                if (c.GetBrightness() <= 0.5)
                    ColorList.Add(c);
            }
            return ColorList;
        }
    }
}
