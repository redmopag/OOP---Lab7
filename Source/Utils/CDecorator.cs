using Project.Source.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source.Utils
{
    class CDecorator : BaseShape
    {
        private BaseShape _shape;
        private int _distForSel = 6;
        private Pen _shapePen = new Pen(Color.Black, 1.0f);

        public CDecorator(BaseShape baseShape)
        {
            _shape = baseShape;
            _shapePen.DashStyle = DashStyle.Dash;
        }

        public bool inShape(int x, int y) { return _shape.inShape(x, y); }
        public void draw(Graphics gr)
        {
            if (_shape is CComposite group)
            {
                group.setSelectionColor(Color.Red);
                group.draw(gr);
                group.setSelectionColor(Color.Black);
            }
            else
            {
                _shape.draw(gr);
                int x = (_shape as Shape).getX();
                int y = (_shape as Shape).getY();
                int width = (_shape as Shape).getWidth() + _distForSel;
                int height = (_shape as Shape).getHeight() + _distForSel;
                gr.DrawRectangle(_shapePen, x - width / 2, y - height / 2, width, height);
            }
        }
        public void setSelectionColor(Color color)
        {
            _shapePen.Color = color;
        }
        public void moveX(int num, int start, int end) { _shape.moveX(num, start, end); }
        public void moveY(int num, int start, int end) { _shape.moveY(num, start, end); }
        public void changeSize(int num) { _shape.changeSize(num);}
        public void setColor(Color color) { _shape.setColor(color); }
        public BaseShape getShape() { return _shape; }
        public bool canMoveX(int num, int start, int end)
        {
            return _shape.canMoveX(num, start, end);
        }
        public bool canMoveY(int num, int start, int end)
        {
            return _shape.canMoveY(num, start, end);
        }
        public void save(StreamWriter stream) { _shape.save(stream); }
    }
}
