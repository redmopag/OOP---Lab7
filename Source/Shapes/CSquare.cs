using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public override void save(StreamWriter stream)
        {
            string write = "Square\nX = " + _x.ToString()
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
