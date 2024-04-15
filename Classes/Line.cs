using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    public class Line : DisplayObject
    {
        public Line(int baseX, int baseY, int x1, int y1, int x2, int y2, int fR, int fG, int fB, int cR, int cG, int cB, int borderWidth) 
            : base(baseX, baseY, x1, y1, x2, y2, fR,fG,fB, cR,cB,cG, borderWidth / 2)
        {

        }

        public override void Draw(Graphics graphics)
        {
            using (var pen = new Pen(Color.FromArgb(_cR, _cG, _cB), _borderWidth * 2))
                graphics.DrawLine(pen, _clientX1, _clientY1, _clientX2, _clientY2);
        }

        public override void DrawText(Graphics graphics)
        {

        }
    }
}
