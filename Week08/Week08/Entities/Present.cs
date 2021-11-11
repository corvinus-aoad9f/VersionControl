using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week08.Abstractions;

namespace Week08.Entities
{
    public class Present : Toy
    {
        public SolidBrush RibbonColor { get; private set; }
        public SolidBrush BoxColor { get; private set; }

        public Present(Color color, Color color1)
        {
            RibbonColor = new SolidBrush(color);
            BoxColor = new SolidBrush(color1);  
        }

        protected override void DrawImage(Graphics g)
        {
            g.FillRectangle(BoxColor, 0, 0, Width, Height);
            g.FillRectangle(RibbonColor, Width / 5, Width / 5, Width/5, Height);
            g.FillRectangle(RibbonColor, Width / 5, Width / 5, Width, Height/5);
        }
    }
}
