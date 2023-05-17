using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source.Shapes
{
    interface BaseShape
    {
        void moveX(int num, int start, int end);
        void moveY(int num, int start, int end);
        void changeSize(int num);
        void setColor(Color color);
        bool canMoveX(int num, int start, int end);
        bool canMoveY(int num, int start, int end);
        void draw(Graphics gr); // Рисование фигуры
        bool inShape(int x, int y);
        void save(StreamWriter stream);
    }
}
