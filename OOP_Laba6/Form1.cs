using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Laba6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class Figure 
        {
            protected int x, y;
            public bool selected = false;
            public virtual void DrawMe(Graphics g) {}
            public virtual bool SelectionCheck(MouseEventArgs e) { return false; }
            public int getRLength(MouseEventArgs e)
            {
                return (int)Math.Sqrt(Math.Pow((e.X - x), 2) + Math.Pow((e.Y - y), 2));
            }
            public bool IsSelected()
            {
                if (selected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class Square : Figure
        {
            private const int side = 80;
            public Square() { x = 0; y = 0; }
            public Square(int x, int y) { this.x = x; this.y = y; }
            public Square(Square square) { x = square.x; y = square.y; }
            ~Square() { }
            public override void DrawMe(Graphics g)
            {
                Pen pen = new Pen(Color.Brown, 3);
                if (selected)
                {
                    g.DrawRectangle(pen, x - side / 2, y - side / 2, side, side);
                    g.FillRectangle(Brushes.Blue, x - side / 2, y - side / 2, side, side);
                }
                else
                {
                    g.DrawRectangle(pen, x - side / 2, y - side / 2, side, side);
                    g.FillRectangle(Brushes.Black, x - side / 2, y - side / 2, side, side);
                }
            }
            public override bool SelectionCheck(MouseEventArgs e)
            {
                if ((e.X >= x - side / 2) && (e.X <= x + side / 2) && (e.Y >= y - side / 2) && (e.Y <= y + side / 2)) { return true; }
                else { return false; }
            }
        }
        class CCircle : Figure
        {
            private const int radius = 40;
            public CCircle() { x = 0; y = 0; }
            public CCircle(int x, int y) { this.x = x; this.y = y; }
            public CCircle(CCircle circle) { x = circle.x; y = circle.y; }
            ~CCircle() { }
            public override void DrawMe(Graphics g)
            {
                Pen pen = new Pen(Color.Brown, 3);
                if (selected)
                {
                    g.DrawEllipse(pen, x - radius, y - radius, radius * 2, radius * 2);
                    g.FillEllipse(Brushes.Blue, x - radius, y - radius, radius * 2, radius * 2);
                }
                else
                {
                    g.DrawEllipse(pen, x - radius, y - radius, radius * 2, radius * 2);
                    g.FillEllipse(Brushes.Black, x - radius, y - radius, radius * 2, radius * 2);
                } 
            }
            public override bool SelectionCheck(MouseEventArgs e)
            {
                if ((e.X > x - radius && e.X < x + radius) && (e.Y > y - radius && e.Y < y + radius)) { return true; }
                else { return false; }
            }
        }
        class Triangle : Figure
        {
            private Point[] points;
            public Triangle() { x = 0; y = 0; points = InitPoints(); }
            public Triangle(int x, int y) { this.x = x; this.y = y; points = InitPoints(); }
            public Triangle(Triangle triangle) { x = triangle.x; y = triangle.y; points = InitPoints(); }
            ~Triangle() { }
            private Point[] InitPoints()
            {
                Point[] points =
                {
                    new Point(x + 40, y + 40),
                    new Point(x - 40, y + 40),
                    new Point(x, y - 40),
                };
                return points;
        }
            public override void DrawMe(Graphics g)
            {
                Pen pen = new Pen(Color.Brown, 3);
                if (selected)
                {
                    g.DrawPolygon(pen, points);
                    g.FillPolygon(Brushes.Blue, points);
                }
                else
                {
                    g.DrawPolygon(pen, points);
                    g.FillPolygon(Brushes.Black, points);
                }
            }
            public override bool SelectionCheck(MouseEventArgs e)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddPolygon(points);
                return path.IsVisible(e.Location); // Функция считает кол-во пересечений полигона лучом из заданной точки в случайном направлении
            }
        }
        class Section : Figure
        {
            private Point end_point;
            public Section() { x = 0; y = 0; end_point = new Point(0, 0); }
            public Section(Point a, Point b) { this.x = a.X; this.y = a.Y; end_point = b; }
            public Section(Section section) { x = section.x; y = section.y; end_point = section.end_point; }
            ~Section() {}
            public override void DrawMe(Graphics g)
            {
                Pen pen = new Pen(Color.Black, 100);
                if (selected)
                {
                    pen.Color = Color.Blue;
                    g.DrawLine(pen, x, y, end_point.X, end_point.Y);
                }
                else
                {
                    g.DrawLine(pen, x, y, end_point.X, end_point.Y);
                }
            }
            public override bool SelectionCheck(MouseEventArgs e)
            {
                if () { return true; } // Здесь должна быть проверка расстояния от точки до прямой
                else { return false; }
            }
        }
        class container
        {
            Figure[] array;
            private int size, capacity;
            public container() { size = 0; capacity = 1; array = new Figure[capacity]; }
            public container(int capacity) { size = 0; this.capacity = capacity; array = new Figure[capacity]; }
            public container(container c) { size = c.size; capacity = c.capacity; array = new container(c).array; }
            ~container() { }
            public void Push_back(Figure element)
            {
                if (size >= capacity)
                {
                    capacity *= 2;
                    Figure[] newArr = new Figure[capacity];
                    for (int i = 0; i < size; i++)
                    {
                        newArr[i] = array[i];
                    }
                    array = newArr;
                }
                array[size++] = element;
            }
            public void DrawAll(Graphics g)
            {
                for (int i = 0; i < size; i++)
                {
                    array[i].DrawMe(g);
                }
            }
            public bool SelectionCheckAll(MouseEventArgs e, bool CtrlPressed, bool MultiplySelections)
            {
                bool anyIsSelected = false;
                if (MultiplySelections)
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (array[i].SelectionCheck(e) == true) { anyIsSelected = true; }
                    }
                }
                else
                {
                    int minRLength = 10000;
                    Figure nearestObj = null;
                    for (int i = 0; i < size; i++)
                    {
                        if (array[i].SelectionCheck(e) == true)
                        {
                            anyIsSelected = true;
                            if (array[i].getRLength(e) < minRLength)
                            {
                                nearestObj = array[i];
                            }

                        }
                    }
                    if (nearestObj != null)
                    {
                        if (!CtrlPressed) { MakeAllObjsUnselected(); }
                        nearestObj.selected = true;
                    }

                }
                return anyIsSelected;
            }
            public void DeleteSelectedFromContainer()
            {
                int const_size = size;
                for (int i = 0; i < const_size; i++)
                {
                    if (array[i] != null)
                    {
                        if (array[i].IsSelected())
                        {
                            DeleteObjFromContainer(array[i]);
                            i--;
                        }
                    }
                }
            }
            public void DeleteObjFromContainer(Figure FigureToDelete)
            {
                Figure[] newArr = new Figure[capacity];
                bool elemFind = false;
                size--;
                for (int i = 0; i < size; i++)
                {
                    if (array[i] == FigureToDelete)
                    {
                        elemFind = true;
                    }
                    if (elemFind) { newArr[i] = array[i + 1]; }
                    else { newArr[i] = array[i]; }
                }
                if (array[size] == FigureToDelete) { elemFind = true; } //Для последнего элемента
                array = newArr;
                if (!elemFind) { throw new Exception("ObjNotFoundInContainer"); }
            }
            public void MakeLastObjSelected()
            {
                if (size > 0)
                {
                    array[size - 1].selected = true;
                }
            }
            public void MakeAllObjsUnselected()
            {
                for (int i = 0; i < size; i++)
                {
                    array[i].selected = false;
                }
            }
        }

        container c = new container();
        bool CtrlPressed = false;
        bool MultiplySelections = false;
        string figure = null;
        Point start_point;

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!c.SelectionCheckAll(e, CtrlPressed, MultiplySelections) && (figure != null))
            {
                Figure createdFigure = null;
                switch (figure)
                {
                    case "Square":
                        createdFigure = new Square(e.X, e.Y);
                        break;
                    case "Circle":
                        createdFigure = new CCircle(e.X, e.Y);
                        break;
                    case "Triangle":
                        createdFigure = new Triangle(e.X, e.Y);
                        break;
                    case "Section":
                        createdFigure = new Section(start_point, e.Location);
                        break;
                }
                if (createdFigure != null)
                {
                    c.Push_back(createdFigure);
                    createdFigure.selected = true;
                }
            }
            this.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            c.DrawAll(e.Graphics);
        }

        private void squareButton_MouseClick(object sender, MouseEventArgs e)
        {
            figure = "Square";
        }

        private void circleButton_MouseClick(object sender, MouseEventArgs e)
        {
            figure = "Circle";
        }

        private void triangleButton_MouseClick(object sender, MouseEventArgs e)
        {
            figure = "Triangle";
        }

        private void sectionButton_MouseClick(object sender, MouseEventArgs e)
        {
            figure = "Section";
        }

        private void cursorButton_MouseClick(object sender, MouseEventArgs e)
        {
            figure = null;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            start_point = e.Location;
        }
    }
}
