using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    public class Rectangle:DisplayObject
    {
        public Rectangle(int baseX, int baseY, int x1, int y1, int x2, int y2, int fR, int fG, int fB, int cR, int cG, int cB, int borderWidth) 
            :base(baseX, baseY, x1, y1, x2, y2, fR,fG,fB, cR,cG,cB, borderWidth / 2)
        { 
            
        }

        public override void Draw(Graphics graphics)
        {
            using (var brush = new SolidBrush(Color.FromArgb(_cR, _cG, _cB)))
            using (var pen = new Pen(Color.FromArgb(_bR, _bG, _bB), _borderWidth * 2))
            {
                int x = _clientX1;
                int y = _clientY1;

                float sizeX = _clientX2 - x;
                float sizeY = _clientY2 - y;

                graphics.FillRectangle(brush, x, y, sizeX, sizeY);
                graphics.DrawRectangle(pen, x, y, sizeX, sizeY);
            }
        }

        public override void DrawText(Graphics graphics)
        {

        }
    }
}
