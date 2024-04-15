using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    public abstract class DisplayObject
    {
        public int _baseX, _baseY; // Базовая точка

        public int _frameX1, _frameY1; // Левая верхняя точка рамки 
        public int _frameX2, _frameY2; // Правая нижняя точка рамки

        public int _clientX1, _clientY1; // Левая верхняя точка клиентской рамки
        public int _clientX2, _clientY2; // Правая нижняя точка клиентской рамки

        public int _bR, _bG, _bB; // Цвет рамки
        public int _cR, _cG, _cB; // Цвет клиентской области

        public int _borderWidth; // Ширина рамки

        protected DisplayObject(int baseX, int baseY, int clientX1, int clientY1, int clientX2, int clientY2, int bR, int bG, int bB, int cR, int cG, int cB, int borderWidth)
        {
            _baseX = baseX;
            _baseY = baseY;

            _clientX1 = clientX1;
            _clientY1 = clientY1;
            _clientX2 = clientX2;
            _clientY2 = clientY2;

            _frameX1 = clientX1 + borderWidth;
            _frameY1 = clientY1 + borderWidth;
            _frameX2 = clientX2 + borderWidth;
            _frameY2 = clientX2 + borderWidth;

            _bR = bR;
            _bG = bG;
            _bB = bB;

            _cR = cR;
            _cG = cG;
            _cB = cB;

            _borderWidth = borderWidth;
        }

        protected DisplayObject() { }

        public virtual void Update(int dx, int dy)
        {
            _baseX += dx;
            _baseY += dy;

            _clientX1 += dx;
            _clientX2 += dx;
            _clientY1 += dy;
            _clientY2 += dy;

            _frameX1 += dx;
            _frameY1 += dy;
            _frameX2 -= dx;
            _frameY2 -= dy;
        }

        public abstract void Draw(Graphics g);

        public abstract void DrawText(Graphics g);
    }
}
