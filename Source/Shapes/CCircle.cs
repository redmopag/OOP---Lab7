using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public override void save(StreamWriter stream)
        {
            string writeString = "Circle\nX = " + _x.ToString()
                + "\nY = " + _y.ToString() + "\nRadius = " + (_width / 2).ToString();
            stream.WriteLine(writeString);
            string color = _color.ToString().Split(' ').Last();
            color = color.Trim('[', ']');
            stream.WriteLine("Color = " + color);
        }
        public override void load(StreamReader stream)
        {
            string[] values = new string[4];
            for (int i = 0; i < 4; ++i)
            {
                string[] line = stream.ReadLine().Split(' ');
                values[i] = line.Last();
            }
            _x = int.Parse(values[0]);
            _y = int.Parse(values[1]);
            _width = _height = int.Parse(values[2]) * 2;
            values[3] = values[3].Trim('[', ']');
            _color = Color.FromName(values[3]);
        }
    }
}
