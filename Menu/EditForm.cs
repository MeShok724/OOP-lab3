using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Menu
{
    public partial class EditForm : Form
    {
        private int childFormNumber = 0;

        public int tR, tG, tB;

        public int fR, fG, fB;

        public int bR, bG, bB;

        public string text, textStyle;

        public int textSize;

        public int borderWidth;

        public int X, Y;

        // public int dx, dy;

        public string objType;

        public int width, height;

        private int _xPrev;
        private int diffX;
        private void Edit_Click(object sender, EventArgs e)
        {
            text = inputText.Text;

            if (String.IsNullOrEmpty(text))
            {
                text = "Text";
            }

            textStyle = fontStyle.Text;

            if (String.IsNullOrEmpty(textStyle))
            {
                textStyle = "Arial";
            }

            if (String.IsNullOrEmpty(inputTextSize.Text))
            {
                textSize = 14;
            }
            else
            {
                int.TryParse(inputTextSize.Text, out textSize);

                if (textSize == 0) textSize = 5;
            }

            if (String.IsNullOrEmpty(inputBorderWidth.Text))
            {
                borderWidth = 5;
            }
            else
            {
                int.TryParse(inputBorderWidth.Text, out borderWidth);

                if (borderWidth == 0)
                {
                    bR = fR;
                    bG = fG;
                    bB = fB;
                }

            }

            objType = figureType.Text;

            if (String.IsNullOrEmpty(objType))
            {
                objType = "rectangle";
            }

            if (String.IsNullOrEmpty(inputX.Text))
            {
                X = _menuItem._clientX1 + 20;
            }
            else
            {
                int.TryParse(inputX.Text, out X);

                if (X == 0) 
                    X = _menuItem._clientX1 + 20;
            }

            if (String.IsNullOrEmpty(inputY.Text))
            {
                Y = _menuItem._clientY1 + 20;
            }
            else
            {
                int.TryParse(inputY.Text, out Y);

                if (Y == 0) 
                    Y = _menuItem._clientY1 + 20;
            }

            if (String.IsNullOrEmpty(inputWidth.Text))
            {
                width = (int)(_menuItem._frameObj._clientX2 - _menuItem._frameObj._clientX1);
            }
            else
            {
                int.TryParse(inputWidth.Text, out width);

                if (width == 0) width = (int)(_menuItem._frameObj._clientX2 - _menuItem._frameObj._clientX1);
            }

            if (String.IsNullOrEmpty(inputHeight.Text))
            {
                height = (int)(_menuItem._frameObj._clientY2 - _menuItem._frameObj._clientY1);
            }
            else
            {
                int.TryParse(inputHeight.Text, out height);

                if (height == 0) height = (int)(_menuItem._frameObj._clientY2 - _menuItem._frameObj._clientY1);
            }

            _menuItem.changeBorderColor(bR, bG, bB);

            _menuItem.changeCoords(X, Y,  int.Parse(textBox1.Text) - diffX, 0);
            _menuItem.resize(width, height);
            _menuItem.changeFillColor(fR, fG, fB);
            _menuItem.changeTextColor(tR, tG, tB);
            _menuItem.changeText(text, textStyle, textSize);
            _menuItem.changeObject(objType);
            _menuItem.changeBorderSize(borderWidth);

            _menuItem._curShiftX = (int)_menuItem._frameObj._clientX2;
            _menuItem._curShiftY = (int)_menuItem._frameObj._clientY2;
        }

        private MenuItem _menuItem;

        public EditForm(MenuItem menuItem, int xPrev)
        {
            InitializeComponent();
            _xPrev = xPrev;
            this._menuItem = menuItem;
            diffX = _menuItem._frameObj._clientX1 - _xPrev;
            

            fontColorBox.BackColor = Color.FromArgb(_menuItem._tR, _menuItem._tG, _menuItem._tB);
            fColorBox.BackColor = Color.FromArgb(_menuItem._frameObj._cR, _menuItem._frameObj._cG, _menuItem._frameObj._cB);
            bColorBox.BackColor = Color.FromArgb(_menuItem._frameObj._bR, _menuItem._frameObj._bG, _menuItem._frameObj._bB);;
            bR = bColorBox.BackColor.R;
            bG = bColorBox.BackColor.G;
            bB = bColorBox.BackColor.B;
            fR = fColorBox.BackColor.R;
            fG = fColorBox.BackColor.G;
            fB = fColorBox.BackColor.B;
            tR = fontColorBox.BackColor.R;
            tG = fontColorBox.BackColor.G;
            
            tB = fontColorBox.BackColor.B;
            inputBorderWidth.Text = menuItem._frameObj._borderWidth.ToString();
            inputText.Text = menuItem._text;
            inputTextSize.Text = menuItem._fontSize.ToString();
            inputWidth.Text = (_menuItem._frameObj._clientX2 - _menuItem._frameObj._clientX1).ToString();
            inputX.Text = menuItem._frameObj._clientX1.ToString();
            inputY.Text = menuItem._frameObj._clientY1.ToString();
            fontStyle.Text = menuItem._textStyle;
            inputHeight.Text = (_menuItem._frameObj._clientY2 - _menuItem._frameObj._clientY1).ToString();
            textBox1.Text = diffX.ToString();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void MenuHandler_Load(object sender, EventArgs e)
        {
        }

        private void btnBColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                bColorBox.BackColor = colorDialog1.Color;


                bR = bColorBox.BackColor.R;
                bG = bColorBox.BackColor.G;
                bB = bColorBox.BackColor.B;
            }
        }

        private void btnFillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                fColorBox.BackColor = colorDialog1.Color;
          
                fR = fColorBox.BackColor.R;
                fG = fColorBox.BackColor.G;
                fB = fColorBox.BackColor.B;
            }
        }

        private void btnFontColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                fontColorBox.BackColor = colorDialog1.Color;

                tR = fontColorBox.BackColor.R;
                tG = fontColorBox.BackColor.G;
                tB = fontColorBox.BackColor.B;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
