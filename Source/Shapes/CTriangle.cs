using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public override void save(StreamWriter stream)
        {
            string write = "Triangle\nX = " + _x.ToString()
                + "\nY = " + _y.ToString() + "\nHeight = " + _height.ToString()
                + "\nWidth = " + _width.ToString();
            stream.WriteLine(write);
            string color = _color.ToString().Split(' ').Last();
            color = color.Trim('[', ']');
            stream.WriteLine("Color = " + color);
        }
        public override void load(StreamReader stream)
        {
            string[] values = new string[5];
            for (int i = 0; i < 5; ++i)
            {
                string[] line = stream.ReadLine().Split(' ');
                values[i] = line.Last();
            }
            _x = int.Parse(values[0]);
            _y = int.Parse(values[1]);
            _height = int.Parse(values[2]);
            _width = int.Parse(values[3]);
            values[4] = values[4].Trim('[', ']');
            _color = Color.FromName(values[4]);
        }
    }
}
