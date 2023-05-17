using Project.Source.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Project.Source;
using System.Runtime.InteropServices;
using Project.Source.Utils.AbstractFactory;

namespace Project
{
    public partial class FormMain : Form
    {
        // Списко фигур-прототипов
        private readonly List<Shape> prototypes = new List<Shape>() { new CCircle(), new CSquare(), new CTriangle() };
        Shape shape;
        // Контейнер, хранящий фигуры и мтоды работы с ними
        private Project.Source.Container shapes = new Project.Source.Container();

        private const int step = 10;
        private const int size = 10;

        public FormMain()
        {
            InitializeComponent();
            pictureBoxColor.BackColor = colorDialogShapes.Color;
        }

        private void pictureBoxDrawFigure_MouseDown(object sender, MouseEventArgs e)
        {
            // Проверяем, если не попали ни в одну фигуру, то создаём новую
            // Пока что используя (или патаясь использовать) паттерн прототип :)
            if (!shapes.inShapeContainer(e.X, e.Y))
            {
                shapes.addNewShape(shape, e.X, e.Y);
            }
            pictureBoxDrawFigure.Refresh();
        }

        // Если нажата клавиша delete - удаляет фигуру, ctrl - устанавливает флаг ctrl
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Delete:
                    shapes.removeSelctions();
                    pictureBoxDrawFigure.Refresh();
                    break;
                case Keys.ControlKey:
                    shapes.setCtrl(true, checkBoxCtrl);
                    break;
                case Keys.A:
                    shapes.moveX(-step, pictureBoxDrawFigure.Location.X, pictureBoxDrawFigure.Width);
                    pictureBoxDrawFigure.Refresh();
                    break;
                case Keys.D:
                    shapes.moveX(step, pictureBoxDrawFigure.Location.X, pictureBoxDrawFigure.Width);
                    pictureBoxDrawFigure.Refresh();
                    break;
                case Keys.S:
                    shapes.moveY(step, pictureBoxDrawFigure.Location.Y, pictureBoxDrawFigure.Height);
                    pictureBoxDrawFigure.Refresh();
                    break;
                case Keys.W:
                    shapes.moveY(-step, pictureBoxDrawFigure.Location.Y, pictureBoxDrawFigure.Height);
                    pictureBoxDrawFigure.Refresh();
                    break;
                case Keys.E:
                    shapes.changeSizeShapes(size);
                    pictureBoxDrawFigure.Refresh();
                    break;
                case Keys.Q:
                    shapes.changeSizeShapes(-size);
                    pictureBoxDrawFigure.Refresh();
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }
        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            // Если отпущена кнопка ctrl, флаг "выключается" = false
            if (e.KeyCode == Keys.ControlKey)
                shapes.setCtrl(false, checkBoxCtrl);
        }

        private void pictureBoxDrawFigure_Paint(object sender, PaintEventArgs e)
        {
            shapes.drawShapes(e.Graphics);
        }

        private void checkBoxCtrl_Click(object sender, EventArgs e)
        {
            // Если галочка поставлена - ctrl включен
            shapes.setCtrl(((sender as CheckBox).Checked));
        }

        private void checkBoxMultiSelection_Click(object sender, EventArgs e)
        {
            shapes.setMultiSelection();
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            shape = prototypes[0];
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            shape = prototypes[1];
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            shape = prototypes[2];
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if(colorDialogShapes.ShowDialog() != DialogResult.Cancel)
            {
                pictureBoxColor.BackColor = colorDialogShapes.Color;
                shapes.setShapesColor(colorDialogShapes.Color);
                pictureBoxDrawFigure.Refresh();
            }
        }

        private void buttonGroup_Click(object sender, EventArgs e)
        {
            shapes.groupShapes();
            pictureBoxDrawFigure.Refresh();
        }

        private void buttonUngroup_Click(object sender, EventArgs e)
        {
            shapes.ungroupShapes();
            pictureBoxDrawFigure.Refresh();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            string filepath = "saves.txt";
            shapes.saveShapes(filepath);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            string filepath = "saves.txt";
            IAbstractFactory factory = new CAbstractFactory();
            shapes.loadShapes(filepath, factory);
        }
    }
}
