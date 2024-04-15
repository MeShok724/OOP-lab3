using System;
using System.Drawing;
using WindowsFormsApp1.Classes;
using Rectangle = WindowsFormsApp1.Classes.Rectangle;

namespace WindowsFormsApp1.Menu
{
    public class MenuItem : DisplayObject
    {
        public string _text;
        public int _fontSize;
        public string _textStyle;
        public int _tR, _tG, _tB;

        public int _x, _y;
        public DisplayObject _frameObj;

        public int _index; 
        public int _parentIndex;
        public int _submenuCount;

        public int  _curShiftX, _curShiftY;

        public MenuItem[] subMenuItems = new MenuItem[0];
            
        public bool _isVisible = true;
        public bool _isParent = true;
        public bool _isAbsolute = false;

        private GameField _gameField;
        private Random R;

        public MenuItem(int x, int y, int fontSize, string text, string textStyle, int tR, int tG, int tB, DisplayObject frameObj, int index, GameField gameField)
        {
            _frameObj = frameObj;
            R = new Random();
            _x = x;
            _y = y;

            _text = text;
            _tR = tR;
            _tG = tG;
            _tB = tB;

            _index = index;

            _fontSize = fontSize;

            _gameField = gameField;

            _submenuCount = 0;
            _parentIndex = 0;
            _textStyle = textStyle;
        }

        public override void Draw(Graphics g)
        {
            _frameObj.Draw(g);
        }

        public override void DrawText(Graphics graphics)
        {
            using (Font myFont = new Font(_textStyle, _fontSize))
            {
                Brush brush = new SolidBrush(Color.FromArgb(_tR, _tG, _tB));
                graphics.DrawString(_text, myFont, brush, new PointF(centerTextX(), centerTextY()));
            }
        }

        private int centerTextX()
        {
            if (_frameObj is Triangle || _frameObj is Circle || _frameObj is Square)
            {
                return (_frameObj._clientX1 + (_frameObj._clientX2 - _frameObj._clientX1) / 2 - _text.Length * _fontSize / 2);
            }

            return (_frameObj._clientX1 + (_frameObj._clientX2 - _frameObj._clientX1) / 2 - _text.Length * _fontSize / 3);
        }

        private int centerTextY()
        {
            return (_frameObj._clientY1 + (_frameObj._clientY2- _frameObj._clientY1) / 2 - _fontSize);
        }

        public void changeCoords(int x, int y, int dx, int dy)
        {
            _frameObj._clientX1 = x; 
            _frameObj._clientY1 = y;
            _frameObj._clientX2 = x + (_frameObj._clientX2 - _frameObj._clientX1);
            _frameObj._clientY2 = y + (_frameObj._clientY2 - _frameObj._clientY1);

            _frameObj._clientX1 += dx;
            _frameObj._clientY1 += dy;

            _frameObj._clientX2 += dx;
            _frameObj._clientY2 += dy;

            _curShiftX = _frameObj._clientX2;
            _curShiftY = _frameObj._clientY2;
        }

        public void changeText(string text, string textType, int fontWidth)
        {
            _textStyle = textType;
            _fontSize = fontWidth;
            _text = text;
            int frWidth = _frameObj._clientX2 - _frameObj._clientX1;
            int frHeight = _frameObj._clientY2 - _frameObj._clientY1;

            var (width, height) = CalculateTextSize();
            width += width / 3;
            height += height / 3;

            if (frWidth < width)
            {
                resize(width, frHeight);
                frWidth = width;
            }

            if (frHeight < height) 
                resize(frWidth, height);
        }

        public void resize(int width, int height)
        {
            _frameObj._clientX2 = _frameObj._clientX1 + width;
            _frameObj._clientY2 = _frameObj._clientY1 + height;
        }

        public void changeObject(string objType)
        {
            if (objType == "rectangle")
            {

                Rectangle obj = _gameField.generateRandomRectangle();

                obj._cR = _frameObj._cR;
                obj._cB = _frameObj._cB;
                obj._cG = _frameObj._cG;

                obj._bR = _frameObj._bR;
                obj._bB = _frameObj._bB;
                obj._bG = _frameObj._bG;

                obj._clientX1 = _frameObj._clientX1;
                obj._clientY1 = _frameObj._clientY1;

                obj._clientX2 = _frameObj._clientX2;
                obj._clientY2 = _frameObj._clientY2;

                _frameObj = obj;

            }
            else if (objType == "circle")
            {

                Circle obj = new Circle(0, 0, 100, 100, 200, 200, R.Next(255), R.Next(255), R.Next(255), R.Next(255), R.Next(255), R.Next(255), R.Next(3, 10));

                obj._cR = _frameObj._cR;
                obj._cB = _frameObj._cB;
                obj._cG = _frameObj._cG;

                obj._bR = _frameObj._bR;
                obj._bB = _frameObj._bB;
                obj._bG = _frameObj._bG;

                obj._clientX1 = _frameObj._clientX1;
                obj._clientY1 = _frameObj._clientY1;

                obj._clientX2 = _frameObj._clientX2;
                obj._clientY2 = _frameObj._clientY2;

                _frameObj = obj;
            }
            else if (objType == "triangle")
            {

                Triangle obj = new Triangle(0, 0, 50, 100, 100, 100, R.Next(255), R.Next(255), R.Next(255), R.Next(255), R.Next(255), R.Next(255), R.Next(3, 10));

                obj._cR = _frameObj._cR;
                obj._cB = _frameObj._cB;
                obj._cG = _frameObj._cG;

                obj._bR = _frameObj._bR;
                obj._bB = _frameObj._bB;
                obj._bG = _frameObj._bG;

                obj._clientX1 = _frameObj._clientX1;
                obj._clientY1 = _frameObj._clientY1;

                obj._clientX2 = _frameObj._clientX2;
                obj._clientY2 = _frameObj._clientY2;

                _frameObj = obj;

            }
            else if (objType == "square")
            {

                Square obj = new Square(0, 0, 100, 100, 200, 200, R.Next(255), R.Next(255), R.Next(255), R.Next(255), R.Next(255), R.Next(255), R.Next(3, 10));

                obj._cR = _frameObj._cR;
                obj._cB = _frameObj._cB;
                obj._cG = _frameObj._cG;

                obj._bR = _frameObj._bR;
                obj._bB = _frameObj._bB;
                obj._bG = _frameObj._bG;

                obj._clientX1 = _frameObj._clientX1;
                obj._clientY1 = _frameObj._clientY1;

                obj._clientX2 = _frameObj._clientX2;
                obj._clientY2 = _frameObj._clientY2;

                _frameObj = obj;

            }
            else if (objType == "ellipse")
            {

                Ellipse obj = new Ellipse(0, 0, 100, 100, 200, 200, R.Next(255), R.Next(255), R.Next(255), R.Next(255), R.Next(255), R.Next(255), R.Next(3, 10));

                obj._cR = _frameObj._cR;
                obj._cB = _frameObj._cB;
                obj._cG = _frameObj._cG;

                obj._bR = _frameObj._bR;
                obj._bB = _frameObj._bB;
                obj._bG = _frameObj._bG;

                obj._clientX1 = _frameObj._clientX1;
                obj._clientY1 = _frameObj._clientY1;

                obj._clientX2 = _frameObj._clientX2;
                obj._clientY2 = _frameObj._clientY2;

                _frameObj = obj;

            }

        }

        public void changeBorderSize(int size)
        {
            _frameObj._borderWidth = size;
        }

        public void changeFillColor(int fR, int fG, int fB)
        {
            _frameObj._cR = fR;
            _frameObj._cG = fG;
            _frameObj._cB = fB;
        }

        public void changeBorderColor(int bR, int bG, int bB)
        {
            _frameObj._bR = bR;
            _frameObj._bG = bG;
            _frameObj._bB = bB;
        }

        public void changeTextColor(int tR, int tG, int tB)
        {
            _tR = tR;
            _tG = tG;
            _tB = tB;
        }
        
        
        public (int Width, int Height) CalculateTextSize()
        {
            using (var bitmap = new Bitmap(1, 1))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    var font = new Font(_textStyle, _fontSize);
                    var size = graphics.MeasureString(_text, font);
                    return ((int)size.Width, (int)size.Height);
                }
            }
        }

    }
}
