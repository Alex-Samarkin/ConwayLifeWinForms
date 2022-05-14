using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayLibrary
{
    public class TPainter
    {
        public Control? Control { get; set; } = null;
        public int Width => Control.ClientSize.Width;
        public int Height => Control.ClientSize.Height;
        private Graphics? _graphics = null;
        public Graphics? Graphics => (_graphics = Control.CreateGraphics());
        public TField? Field { get; set; } = null;

        public bool Check()
        {
            if ((Control == null) || (Field == null))
            {
                return false;
            }

            var g = Graphics;
            return true;
        }

        public Color BackColor { get; set; } = Color.Azure;
        public Color PenColor { get; set; } = Color.MediumAquamarine;
        public Color BrushColor { get; set; } = Color.DarkBlue;
        public Color Brush2Color { get; set; } = Color.Gray;

        public void Clear()
        {
            if (Check()) _graphics.Clear(BackColor);
        }

        public void DrawXY(int x, int y)
        {
            if (Check())
            {
                Pen p = new Pen(PenColor, 0.5f);
                Brush b = new SolidBrush(BrushColor);
                var dx = (float)Width / Field.Size;
                var dy = (float)Height / Field.Size;

                if (Field[x, y].State == TCell.KindOfState.Live)
                {
                    _graphics.FillRectangle(b, dx * x, dy * y, dx, dy);
                }

                _graphics.DrawRectangle(p, dx * x, dy * y, dx, dy);

                p.Dispose();
                b.Dispose();
            }
        }

        public void Draw()
        {
            if (Check())
            {
                Pen p = new Pen(PenColor, 0.5f);
                Brush b = new SolidBrush(BrushColor);
                var dx = (float)Width / Field.Size;
                var dy = (float)Height / Field.Size;

                for (int x = 0; x < Field.Size; x++)
                {
                    for (int y = 0; y < Field.Size; y++)
                    {
                        if (Field[x, y].State == TCell.KindOfState.Live)
                        {
                            _graphics.FillRectangle(b, dx * x, dy * y, dx, dy);
                        }

                        _graphics.DrawRectangle(p, dx * x, dy * y, dx, dy);
                    }
                }

                p.Dispose();
                b.Dispose();
            }
        }

        public void QDraw(bool drawRect = false)
        {
            if (Check())
            {
                Pen p = new Pen(PenColor, 0.5f);
                Brush b = new SolidBrush(BrushColor);
                Brush b2 = new SolidBrush(Brush2Color);

                var dx = (float)Width / Field.Size;
                var dy = (float)Height / Field.Size;
                List<RectangleF> rect1 = new List<RectangleF>();
                List<RectangleF> rect2 = new List<RectangleF>();

                for (int x = 0; x < Field.Size; x++)
                {
                    for (int y = 0; y < Field.Size; y++)
                    {
                        if (Field[x, y].State == TCell.KindOfState.Live)
                        {
                           var delta = 1.1f;
                           rect2.Add(new RectangleF( dx * x+delta, dy * y + delta, dx, dy));
                           rect1.Add(new RectangleF( dx * x, dy * y, dx, dy));
                        }
                    }
                }
                _graphics.FillRectangles(b2,rect2.ToArray());
                _graphics.FillRectangles(b, rect1.ToArray());
                if (drawRect) _graphics.DrawRectangles(p,rect1.ToArray());

                p.Dispose();
                b.Dispose();
                b2.Dispose();
            }
        }
    }
}
