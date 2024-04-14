using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace OOP_lab_3
{
    public partial class FormMain : Form
    {
        private Menu _menu;
        private bool _isMenuAvailable;
        private Graphics _g;
        private Graphics _g1;
        private bool isSubscribed = true;
        
        // public int borderSizeWindow = 10;
        private Bitmap backBuffer;
        // static public Pen _pen;
        public FormMain()
        {
            InitializeComponent();
            // _pen = new Pen(Color.White, borderSizeWindow) { Alignment = PenAlignment.Inset };
        }
        

        private void FormMain_Resize(object sender, EventArgs e)
        {
            _g = CreateGraphics();
            Invalidate();
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            // DrawBorder(this, g);
        }

        private void pbDraw_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(backBuffer, 0, 0);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            _g = CreateGraphics();
            backBuffer = new Bitmap(pbDraw.Width, pbDraw.Height);
            _g1 = Graphics.FromImage(backBuffer);
            
            // DrawBorder(this, g);
        }
        public static void DrawBorder(Form form, Graphics graphics)
        {
            // graphics.DrawRectangle(_pen, form.ClientRectangle);
        }

        private void ShowMenu()
        {
            _isMenuAvailable = true;
            pbDraw.Invalidate();
        }
        private void HideMenu()
        {
            _isMenuAvailable = false;
            pbDraw.Invalidate();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
            {
                if (_isMenuAvailable)
                {
                    HideMenu();
                }
                else
                {
                    ShowMenu();
                }

            }
        }
    }
}