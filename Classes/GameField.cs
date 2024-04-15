using System;

namespace WindowsFormsApp1.Classes
{
    public class GameField : Rectangle
    {
        public DisplayObject[] _figures = new DisplayObject[60];
        public int _p = 0;

        internal int _windowWidth;
        internal int _windowHeight;
        Random R;   

        public GameField(int baseX, int baseY, int x1, int y1, int x2, int y2, int fR, int fG, int fB, int cR, int cG, int cB, int borderWidth, int width, int height)
            : base(baseX, baseY, x1, y1, x2, y2, fR, fG, fB, cR, cG, cB, borderWidth)
        {
            R = new Random();
            _windowHeight = height;
            _windowWidth = width;
        }

        public void Add(DisplayObject o)
        {
            _figures[_p++] = o;
        }

        public void Delete(DisplayObject o)
        {
            int indexToRemove = Array.IndexOf(_figures, o);
            if (indexToRemove < 0)
                return;

            Array.Copy(_figures, indexToRemove + 1, _figures,
                indexToRemove, _figures.Length - indexToRemove - 1);
            _figures[_figures.Length - 1] = null;
            _p--;
        }


        public Rectangle generateRandomRectangle()
        {
               

            // Rectangle rectangle = new Rectangle(0, 0, 100, 100, 200, 200, R.Next(255), R.Next(255), R.Next(255), R.Next(255), R.Next(255), R.Next(255), R.Next(3, 10));
            Rectangle rectangle = new Rectangle(0, 0, 100, 100, 200, 200, 100, 200, 200, 200, 255, 0, 5);

            return rectangle;
        }


    }
}
