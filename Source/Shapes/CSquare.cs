using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source.Shapes
{
    class CSquare : Shape
    {
        public CSquare()
        {
            _x = 0; _y = 0;
        }
        public CSquare(int x, int y) { _x= x; _y = y; }
        public override Shape clone() { return new CSquare(); }
        public override bool inShape(int x, int y)
        {
            bool isIn = false;
            if ((x > _x - _width / 2) && (x < _x + _width / 2) && (y > _y - _height / 2) && (y < _y + _height / 2))
                isIn = true;
            return isIn;
        }
        public override void draw(Graphics gr)
        {
            int centerX = _x - _width / 2;
            int centerY = _y - _height / 2;
            _shapePen.Color = _color;
            gr.DrawRectangle(_shapePen, centerX, centerY, _width, _height);
            _shapePen.Color = Color.Black;
        }
    }
}
