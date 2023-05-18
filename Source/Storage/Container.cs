using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Source.Shapes;
using Project.Source.Utils;
using Project.Source.Utils.AbstractFactory;

namespace Project.Source
{
    class Container
    {
        // Список фигур
        MyArray<BaseShape> shapes = new MyArray<BaseShape>();
        //private List<BaseShape> shapes = new List<BaseShape>();

        // Нажата ли клавиша ctrl для выделения нескольких фигур последовательно
        private bool isCtrl = false;
        // Флаг для выбора нескольких элементов при одном нажатии
        private bool isMultiSelection = false;
        private Color shapesColor = Color.Black;

        //private void Change(Shape item1, Shape item2)
        //{
        //    int index = shapes.IndexOf(item1);
        //    shapes.RemoveAt(index);
        //    shapes.Insert(index, item2);
        //}

        // Снимает все выделения фигур
        public void resetAllSelections()
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i] is CDecorator decorator)
                {
                    shapes[i] = decorator.getShape();
                }
            }
        }
        // Обходит контейнер фигур и проверяет, попал ли курсор в одну из фигур
        // Если попал, возвращает true, а также отмечает подходящие фигуры как выбранные
        // Учитывает возможность одинарного и множественного выделения через ctrl
        public bool inShapeContainer(int x, int y)
        {
            bool flagInCont = false;
            if (!isCtrl)
                resetAllSelections();
            for (int i = 0; i < shapes.Count; ++i)
            {
                if (shapes[i].inShape(x, y) && !(shapes[i] is CDecorator))
                {
                    shapes[i] = new CDecorator(shapes[i]);
                    flagInCont = true;
                    if (!isCtrl || !isMultiSelection)
                        break;
                }
            }
            return flagInCont;
        }
        // Добавляет фигуру в контейнер
        public void add(Shape shape)
        {
            shapes.Add(shape);
        }
        // Возвращает последнюю фигуру из списка
        //public Shape last()
        //{
        //    return shapes.Last();
        //}
        // Настройка флага Ctrl
        // Изменяет также chekbox, связанный с этим флагом
        public void setCtrl(bool ctrl, object sender = null)
        {
            isCtrl = ctrl;
            if(sender != null)
                (sender as CheckBox).Checked = ctrl;
        }
        // Возвращает флаг ctrl
        public bool getCtrl()
        {
            return isCtrl;
        }
        // Удаляет выбранные фигуры
        public void removeSelctions()
        {
            for (int i = 0; i < shapes.Count; ++i)
                if (shapes[i] is CDecorator)
                    shapes.RemoveAt(i--);
        }
        public void drawShapes(Graphics gr)
        {
            for (int i = 0; i < shapes.Count; ++i)
            {
                if (shapes[i] is CDecorator decorator)
                    decorator.setColor(shapesColor);
                shapes[i].draw(gr);
            }
        }
        public void setMultiSelection()
        {
            isMultiSelection = !isMultiSelection;
        }
        public void addNewShape(Shape shape, int x, int y)
        {
            if (shape != null)
            {
                resetAllSelections();
                Shape newShape = shape.clone();
                newShape.setX(x);
                newShape.setY(y);
                CDecorator decorator = new CDecorator(newShape);
                shapes.Add(decorator);
            }
        }
        public void moveX(int num, int start, int end)
        {
            foreach (BaseShape shape in shapes)
            {
                if (shape is CDecorator decorator)
                    decorator.moveX(num, start, end);
            }
        }
        public void moveY(int num, int start, int end)
        {
            foreach(BaseShape shape in shapes)
                if(shape is CDecorator decorator)
                    decorator.moveY(num, start, end);
        }
        public void changeSizeShapes(int num)
        {
            foreach(BaseShape shape in shapes)
                if(shape is CDecorator decorator)
                    decorator.changeSize(num);
        }
        public void setShapesColor(Color color) { shapesColor = color; }
        public void groupShapes()
        {
            int countDecorator = 0;
            for(int i = 0; i < shapes.Count; ++i)
            {
                if (shapes[i] is CDecorator)
                    if (++countDecorator > 1)
                        break;
            }
            if(countDecorator > 0)
            {
                BaseShape group = new CComposite();
                for(int i = 0; i < shapes.Count; ++i)
                    if (shapes[i] is CDecorator)
                    {
                        (group as CComposite).addShape(shapes[i]);
                        shapes.RemoveAt(i--);
                    }
                group = new CDecorator(group);
                shapes.Add(group);
            }
        }
        public void ungroupShapes()
        {
            for (int i = 0; i < shapes.Count; ++i)
            {
                if (shapes[i] is CDecorator decorator)
                {
                    if (decorator.getShape() is CComposite group)
                    {
                        while (group.Count > 1)
                        {
                            shapes.Add(group.getShape());
                            group.Remove();
                        }
                        shapes.Add(group.getShape());
                        shapes.Remove(shapes[i]);
                    }
                }
            }
        }
        public void loadShapes(string filename, IAbstractFactory abstractFactory)
        {
            if (!File.Exists(filename))
                return;
            using(StreamReader stream = File.OpenText(filename))
            {
                BaseShape shape;
                string[] line = stream.ReadLine().Split(' ');
                int amount = int.Parse(line.Last());
                for(int i = 0; i < amount; ++i)
                {
                    shape = abstractFactory.createShape(stream.ReadLine());
                    if(shape is CComposite group)
                    {
                        BaseShape shapeGroup;
                        string[] lineGroup = stream.ReadLine().Split(' ');
                        int amountGroup = int.Parse(lineGroup.Last());
                        for(int j = 0; j < amountGroup; ++j)
                        {
                            shapeGroup = abstractFactory.createShape(stream.ReadLine());
                            if(shapeGroup != null)
                            {
                                (shapeGroup as Shape).load(stream);
                                shapeGroup = new CDecorator(shapeGroup);
                                group.addShape(shapeGroup);
                            }
                        }
                        shapes.Add(shape);
                    }
                    else
                    {
                        if(shape != null)
                        {
                            (shape as Shape).load(stream);
                            shapes.Add(shape);
                        }
                    }
                }
            }
        }
        public void saveShapes(string filename)
        {
            using (StreamWriter stream = new StreamWriter(filename, false))
            {
                stream.WriteLine("Components' amount = " + shapes.Count);
                foreach (BaseShape baseShape in shapes)
                    baseShape.save(stream);
            }
        }
    }
}
