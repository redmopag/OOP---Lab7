using Project.Source.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Source.Utils.AbstractFactory
{
    internal interface IAbstractFactory
    {
        BaseShape createShape(string code);
    }
}
