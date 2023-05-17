using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source.Shapes
{
    class CTriangle : Shape
    {
        private Point[] _vertices = new Point[3];
        // Вычисление координат вершин треугольника
        // Выисляется от центра треугольника, указанного в _x, _y
        // Значения добавляются в _vertiсes
        private void getVertices()
        {
            // Левый нижний угол треугольника
            Point a = new Point(_x - _width / 2, _y + _height / 2);
            _vertices[0] = a;
            // Верхний угол
            Point b = new Point(_x, _y - _height / 2);
            _vertices[1] = b;
            // Правый нижний угол
            Point c = new Point(_x + _width / 2, _y + _height / 2);
            _vertices[2] = c;
        }

        public CTriangle()
        { 
            _x =  0; _y = 0;
        }
        public CTriangle(int x, int y) { _x = x; _y = y; }

        public override Shape clone() { return new CTriangle(); }
        public override bool inShape(int x, int y)
        {
            bool isIn = false;
            getVertices();
            // Вычисляем векторное и псевдоскалярное произведения
            int a = (_vertices[0].X - x) * (_vertices[1].Y - _vertices[0].Y) - (_vertices[1].X - _vertices[0].X) * (_vertices[0].Y - y);
            int b = (_vertices[1].X - x) * (_vertices[2].Y - _vertices[1].Y) - (_vertices[2].X - _vertices[1].X) * (_vertices[1].Y - y);
            int c = (_vertices[2].X - x) * (_vertices[0].Y - _vertices[2].Y) - (_vertices[0].X - _vertices[2].X) * (_vertices[2].Y - y);
            // Если их знаки равны между собой - точка лежит на или в треугольнике
            if ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0))
                isIn = true;
            return isIn;
        }
        public override void draw(Graphics gr)
        {
            getVertices();
            _shapePen.Color = _color;
            gr.DrawPolygon(_shapePen, _vertices);
            _shapePen.Color = Color.Black;
        }
    }
}
