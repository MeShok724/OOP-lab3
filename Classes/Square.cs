using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    public class Square : Rectangle
    {
        public Square(int baseX, int baseY, int x1, int y1, int x2, int y2, int fR, int fG, int fB, int cR, int cG, int cB, int borderWidth)
            : base(baseX, baseY, x1, y1, x2, y2, fR, fG, fB, cR, cG, cB, borderWidth)
        { 
        
        }
    }
}
