using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    public class Triangle : DisplayObject
    {
        public Triangle(int baseX, int baseY, int x1, int y1, int x2, int y2, int fR, int fG, int fB, int cR, int cG, int cB, int borderWidth)
        : base(baseX, baseY, x1 + borderWidth / 2, y1 + borderWidth / 2, x2, y2, fR, fG, fB, cR, cG, cB, borderWidth / 2)
        {

            int frameSize = Math.Min(_clientY2 - _clientY1, _clientX2 - _clientX1);

            _clientX2 = _clientX1 + frameSize;
            _clientY2 = _clientY1 + frameSize;
               
        }

        public override void Update(int dx, int dy)
        {
            base.Update(dx, dy);
        }

        private Point[] getTrianglePoints()
        {
            int frameSize = Math.Min(_clientY2 - _clientY1, _clientX2 - _clientX1);

            _clientX2 = _clientX1 + frameSize;
            _clientY2 = _clientY1 + frameSize;

            Point firstPoint = new Point(_clientX1, _clientY1 + frameSize);
            Point secondPoint = new Point(_clientX1 + frameSize, _clientY1 + frameSize);
            Point thirdPoint = new Point((_clientX1 + frameSize / 2), _clientY1);

            _baseX = _clientX1 + frameSize / 2;
            _baseY = _clientY1 + frameSize / 2;

            return new Point[] { firstPoint, secondPoint, thirdPoint };
        }

        public override void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(Color.FromArgb(_cR, _cG, _cB)))
            using (var pen = new Pen(Color.FromArgb(_bR, _bG, _bB), _borderWidth * 2))
            {
                Point[] trianglePoints = getTrianglePoints();

                g.FillPolygon(brush, trianglePoints);
                g.DrawPolygon(pen, trianglePoints);
            }
        }

        public override void DrawText(Graphics graphics)
        {

        }
    }
}
