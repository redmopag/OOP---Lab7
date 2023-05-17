using Project.Source.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source.Utils.AbstractFactory
{
    internal class CAbstractFactory : IAbstractFactory
    {
        public BaseShape createShape(string code)
        {
            switch(code)
            {
                case "Circle":
                    return new CCircle();
                case "Square":
                    return new CSquare();
                case "Triangle":
                    return new CTriangle();
                case "Group":
                    return new CComposite();
            }
            return null;
        }
    }
}
