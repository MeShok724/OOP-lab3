using System;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

using menu = WindowsFormsApp1.Menu.Menu;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        GameField gameField;

        private int windowWidth;
        private int windowHeight;


        menu userMenu;

        bool isChanged = true;

        public Form1()
        {
            InitializeComponent();
            DrawingField.Width = ClientSize.Width;
            DrawingField.Height = ClientSize.Height;
            // DrawingField.BackColor = System.Drawing.Color.White;
            windowWidth = DrawingField.Width;
            windowHeight = DrawingField.Height;
            gameField = new GameField(0,0, 2, 2, windowWidth - 2, windowHeight - 2, 200,200,200,230,230,230, 10, windowWidth, windowHeight);

            userMenu = new menu(gameField);
        }

        private void DrawingField_Click(object sender, EventArgs e)
        {
        }

        private void DrawingField_Paint(object sender, PaintEventArgs e)
        {
            
            var graphics = e.Graphics;

            gameField.Draw(graphics);

            foreach (var obj in userMenu._menuItems)
            {

                if (obj._isVisible)
                {
                    obj.Draw(graphics);
                    obj.DrawText(graphics);
                }

            }

            if (Program._isEditVisible)
            {
                foreach (var obj in userMenu._editItems)
                {
                    obj.Draw(graphics);
                    obj.DrawText(graphics);

                    foreach (var submenuItem in obj.subMenuItems)
                    {
                        if (submenuItem._isVisible)
                        {
                            submenuItem.Draw(graphics);
                            submenuItem.DrawText(graphics);
                        }
                    }

                }
            }
            
            DrawingField.Invalidate();
        }

        private void DrawingField_MouseDown(object sender, MouseEventArgs e)
        {
            userMenu.onClick(e.X, e.Y, userMenu._menuItems);
            userMenu.onEditClick(e.X, e.Y, userMenu._editItems);
        }
    }
}
