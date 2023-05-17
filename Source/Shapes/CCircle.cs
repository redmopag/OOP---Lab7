using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source.Shapes
{
    class CCircle : Shape
    {
        public CCircle()
        {
            _x = 0; _y = 0;
        }
        public CCircle(int x, int y) { _x = x; _y = y; }

        // Создаёт круг с серединной в указанной точке
        public override Shape clone() { return new CCircle(); }
        // Находится ли указанные координаты внутри фигуры
        public override bool inShape(int x, int y)
        {
            bool isBigger = Math.Sqrt(Math.Pow(x - _x, 2) +  Math.Pow(y - _y, 2)) > _width / 2;
            return !isBigger;
        }
        // Прорисовка круга: в случае выделения и созодания
        public override void draw(Graphics gr)
        {
            _shapePen.Color = _color;
            gr.DrawEllipse(_shapePen, _x - _width / 2, _y - _height / 2, _width, _height);
            _shapePen.Color = Color.Black;
        }
    }
}
