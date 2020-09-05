using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlashCard
{
    public class ScreenInfo
    {
        public Point Location { get; set; }
        
        public int Width { get; set; }

        public int Height { get; set; }

        public ScreenInfo(Control control)
        {
            this.Location = control.Location;
            this.Width = control.Width;
            this.Height = control.Height;
        }

        public void CopyToControl(Control control)
        {
            control.Location = this.Location;
            control.Width = this.Width;
            control.Height = this.Height;
        }
    }
}
