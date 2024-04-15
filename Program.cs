using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.AddMessageFilter(new KeyboardEventFilter());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static bool _isEditVisible = false;
            
        public class KeyboardEventFilter : IMessageFilter
        {
            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == 0x0100) // WM_KEYDOWN
                {
                    Keys key = (Keys)m.WParam.ToInt32();

                    if (key == Keys.M)
                    {
                        _isEditVisible = !_isEditVisible;
                    }
                }

                return false;
            }
        }
    }
}
