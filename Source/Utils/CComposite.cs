using Project.Source.Shapes;
using Project.Source.Utils.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Project.Source.Utils
{
    internal class CComposite : BaseShape
    {
        private List<BaseShape> _compShapes = new List<BaseShape>();
        public int Count { get => _compShapes.Count; }

        // Добавление элемента в группу
        public void addShape(BaseShape baseShape)
        {
            _compShapes.Add(baseShape);
        }
        //--------------------------------------------------------------
        // Бизнес-логика движения группы
        public bool canMoveX(int num, int start, int end)
        {
            foreach (BaseShape baseShape in _compShapes)
                if (!baseShape.canMoveX(num, start, end))
                    return false;
            return true;
        }
        public void moveX(int num, int start, int end)
        {
            if(canMoveX(num, start, end))
                foreach(BaseShape baseShape in _compShapes)
                    baseShape.moveX(num, start, end);
        }
        public bool canMoveY(int num, int start, int end)
        {
            foreach (BaseShape baseShape in _compShapes)
                if (!baseShape.canMoveY(num, start, end))
                    return false;
            return true;
        }
        public void moveY(int num, int start, int end)
        {
            if(canMoveY(num, start, end))
                foreach(BaseShape baseShape in _compShapes)
                    baseShape.moveY(num, start, end);
        }
        //--------------------------------------------------------------

        public void changeSize(int num)
        {
            foreach (BaseShape baseShape in _compShapes)
                baseShape.changeSize(num);
        }
        public void setColor(Color color)
        {
            foreach (BaseShape baseShape in _compShapes)
                baseShape.setColor(color);
        }
        public void draw(Graphics gr)
        {
            foreach (BaseShape baseShape in _compShapes)
                baseShape.draw(gr);
        }
        public void setSelectionColor(Color color)
        {
            foreach (BaseShape baseShape in _compShapes)
                if (baseShape is CDecorator decorator)
                    decorator.setSelectionColor(color);
        }
        public void Remove()
        {
            _compShapes.RemoveAt(0);
        }
        public BaseShape getShape()
        {
            return _compShapes[0];
        }
        public bool inShape(int x, int y)
        {
            foreach (BaseShape baseShape in _compShapes)
                if (baseShape.inShape(x, y))
                    return true;
            return false;
        }
        public void save(StreamWriter stream)
        {
            stream.WriteLine("Group");
            stream.WriteLine("Amount = " + _compShapes.Count);
            foreach (BaseShape baseShape in _compShapes)
                baseShape.save(stream);
        }
    }
}
