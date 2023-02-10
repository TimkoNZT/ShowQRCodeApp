using Binateq.CommandLine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShowQRcodeApp
{
    public class WinformExtension
    {
        public static Form SetPosition(Form frm, int monitorIndex, bool Maximize, IEnumerable<int> Position)
        {
            if (monitorIndex < Screen.AllScreens.Count())
            {
                Point ScreenOffset = new Point();
                Screen screen = Screen.AllScreens[monitorIndex];
                if (screen != null) ScreenOffset = screen.Bounds.Location;

                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = ScreenOffset;

                if (Maximize)
                {
                    frm.WindowState = FormWindowState.Maximized;
                }
                else if (Position == null || !Position.Any())
                {
                    Point CenterFormLocation = new Point(
                        (screen.WorkingArea.Width - frm.Width) / 2,
                        (screen.WorkingArea.Height - frm.Height) / 2
                        );
                    frm.Location = Point.Add(ScreenOffset, (Size)CenterFormLocation);
                }
                else if (Position.Count() >= 2)
                {
                    if (Position.ElementAt(0) > 0 & Position.ElementAt(1) > 0)
                    {
                        frm.Location = Point.Add(ScreenOffset, new Size(Position.ElementAt(1), Position.ElementAt(0)));

                        if (Position.Count() == 4)
                        {
                            if (Position.ElementAt(2) > 0 & Position.ElementAt(3) > 0)
                            {
                                frm.Size = new Size(Position.ElementAt(3), Position.ElementAt(2));
                            }
                        }
                    }
                }
            }
            else
            {
                throw new Exception($"Monitor with index <{monitorIndex}> does not exists.");
            }

            return frm;
        }

        public static Form SetTopmost(Form frm, bool Topmost)
        {
            frm.TopMost = Topmost;
            return frm;
        }

    }
}
