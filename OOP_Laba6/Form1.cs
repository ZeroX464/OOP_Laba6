using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
            public Color BorderColor = Color.Brown;
            public Color Fillcolor = Color.Black;
            public Color SelectedColor = Color.SteelBlue;
            public virtual void DrawMe(Graphics g) {}
            public virtual bool SelectionCheck(Point Location) { return false; }
            public int getRLength(Point Location)
            {
                return (int)Math.Sqrt(Math.Pow((Location.X - x), 2) + Math.Pow((Location.Y - y), 2));
            }
            public virtual void MoveMe(int moveX, int moveY) { }
            public virtual void MakeMeLarger() { }
            public virtual void MakeMeSmaller() { }
            public virtual bool CanBePlaced(int PictureBoxHeight, int PictureBoxWidth) { return false; }
            public virtual bool CanBeLarger(int PictureBoxHeight, int PictureBoxWidth) { return false; }
            public virtual bool CanBeMoved(int PictureBoxHeight, int PictureBoxWidth, int moveX, int moveY) { return false; }
        }
        class Square : Figure
        {
            private int side = 80;
            public Square() { x = 0; y = 0; }
            public Square(int x, int y) { this.x = x; this.y = y; }
            public Square(Square square) { x = square.x; y = square.y; }
            ~Square() { }
            public override void DrawMe(Graphics g)
            {
                Pen pen = new Pen(BorderColor, 3);
                if (selected)
                {
                    g.DrawRectangle(pen, x - side / 2, y - side / 2, side, side);
                    g.FillRectangle(new SolidBrush(SelectedColor), x - side / 2, y - side / 2, side, side);
                }
                else
                {
                    g.DrawRectangle(pen, x - side / 2, y - side / 2, side, side);
                    g.FillRectangle(new SolidBrush(Fillcolor), x - side / 2, y - side / 2, side, side);
                }
            }
            public override bool SelectionCheck(Point Location)
            {
                if ((Location.X >= x - side / 2) && (Location.X <= x + side / 2) && (Location.Y >= y - side / 2) && (Location.Y <= y + side / 2)) { return true; }
                else { return false; }
            }
            public override void MakeMeLarger()
            {
                side += 10;
            }
            public override void MakeMeSmaller()
            {
                if (side > 10)
                {
                    side -= 10;
                }
            }
            public override void MoveMe(int moveX, int moveY)
            {
                x += moveX;
                y += moveY;
            }
            public override bool CanBePlaced(int PictureBoxHeight, int PictureBoxWidth)
            {
                if (x - side / 2 > 0 && // Левая граница
                    y + side / 2 < PictureBoxHeight - 5 && // Нижняя граница
                    x + side / 2 < PictureBoxWidth - 5 && // Правая граница
                    y - side / 2 > 0) // Верхняя граница
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public override bool CanBeLarger(int PictureBoxHeight, int PictureBoxWidth)
            {
                if (x - 5 - side / 2 > 0 && // Левая граница
                    y + 5 + side / 2 < PictureBoxHeight - 5 && // Нижняя граница
                    x + 5 + side / 2 < PictureBoxWidth - 5 && // Правая граница
                    y - 5 - side / 2 > 0) // Верхняя граница
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public override bool CanBeMoved(int PictureBoxHeight, int PictureBoxWidth, int moveX, int moveY)
            {
                int newX = x + moveX;
                int newY = y + moveY;
                if (newX - side / 2 > 0 && // Левая граница
                    newY + side / 2 < PictureBoxHeight - 5 && // Нижняя граница
                    newX + side / 2 < PictureBoxWidth - 5 && // Правая граница
                    newY - side / 2 > 0) // Верхняя граница
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class CCircle : Figure
        {
            private int radius = 40;
            public CCircle() { x = 0; y = 0; }
            public CCircle(int x, int y) { this.x = x; this.y = y; }
            public CCircle(CCircle circle) { x = circle.x; y = circle.y; }
            ~CCircle() { }
            public override void DrawMe(Graphics g)
            {
                Pen pen = new Pen(BorderColor, 3);
                if (selected)
                {
                    g.DrawEllipse(pen, x - radius, y - radius, radius * 2, radius * 2);
                    g.FillEllipse(new SolidBrush(SelectedColor), x - radius, y - radius, radius * 2, radius * 2);
                }
                else
                {
                    g.DrawEllipse(pen, x - radius, y - radius, radius * 2, radius * 2);
                    g.FillEllipse(new SolidBrush(Fillcolor), x - radius, y - radius, radius * 2, radius * 2);
                } 
            }
            public override bool SelectionCheck(Point Location)
            {
                if ((Location.X > x - radius && Location.X < x + radius) && (Location.Y > y - radius && Location.Y < y + radius)) { return true; }
                else { return false; }
            }
            public override void MakeMeLarger()
            {
                radius += 5;
            }
            public override void MakeMeSmaller()
            {
                if (radius > 5)
                {
                    radius -= 5;
                }
            }
            public override void MoveMe(int moveX, int moveY)
            {
                x += moveX;
                y += moveY;
            }
            public override bool CanBePlaced(int PictureBoxHeight, int PictureBoxWidth)
            {
                if (x - radius > 0 && // Левая граница
                    y + radius < PictureBoxHeight - 5 && // Нижняя граница
                    x + radius < PictureBoxWidth - 5 && // Правая граница
                    y - radius > 0) // Верхняя граница
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public override bool CanBeLarger(int PictureBoxHeight, int PictureBoxWidth)
            {
                if (x - 5 - radius > 0 && // Левая граница
                    y + 5 + radius < PictureBoxHeight - 5 && // Нижняя граница
                    x + 5 + radius < PictureBoxWidth - 5 && // Правая граница
                    y - 5 - radius > 0) // Верхняя граница
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public override bool CanBeMoved(int PictureBoxHeight, int PictureBoxWidth, int moveX, int moveY)
            {
                int newX = x + moveX;
                int newY = y + moveY;
                if (newX - radius > 0 && // Левая граница
                    newY + radius < PictureBoxHeight - 5 && // Нижняя граница
                    newX + radius < PictureBoxWidth - 5 && // Правая граница
                    newY - radius > 0) // Верхняя граница
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class Triangle : Figure
        {
            private int size = 40;
            private Point[] points;
            public Triangle() { x = 0; y = 0; points = InitPoints(); }
            public Triangle(int x, int y) { this.x = x; this.y = y; points = InitPoints(); }
            public Triangle(Triangle triangle) { x = triangle.x; y = triangle.y; points = InitPoints(); }
            ~Triangle() { }
            private Point[] InitPoints()
            {
                Point[] points =
                {
                    new Point(x + size, y + size),
                    new Point(x - size, y + size),
                    new Point(x, y - size),
                };
                return points;
        }
            public override void DrawMe(Graphics g)
            {
                Pen pen = new Pen(BorderColor, 3);
                if (selected)
                {
                    g.DrawPolygon(pen, points);
                    g.FillPolygon(new SolidBrush(SelectedColor), points);
                }
                else
                {
                    g.DrawPolygon(pen, points);
                    g.FillPolygon(new SolidBrush(Fillcolor), points);
                }
            }
            public override bool SelectionCheck(Point Location)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddPolygon(points);
                return path.IsVisible(Location); // Функция считает кол-во пересечений полигона лучом из заданной точки в случайном направлении
            }
            public override void MakeMeLarger()
            {
                size += 10;
                points = InitPoints();
            }
            public override void MakeMeSmaller()
            {
                if (size > 10)
                {
                    size -= 10;
                }
                points = InitPoints();
            }
            public override void MoveMe(int moveX, int moveY)
            {
                x += moveX;
                y += moveY;
                points = InitPoints();
            }
            public override bool CanBePlaced(int PictureBoxHeight, int PictureBoxWidth)
            {
                if (x - size > 0 && // Левая граница
                    y + size < PictureBoxHeight - 5 && // Нижняя граница
                    x + size < PictureBoxWidth - 5 && // Правая граница
                    y - size > 0) // Верхняя граница
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public override bool CanBeLarger(int PictureBoxHeight, int PictureBoxWidth)
            {
                if (x - 10 - size > 0 && // Левая граница
                    y + 10 + size < PictureBoxHeight - 5 && // Нижняя граница
                    x + 10 + size < PictureBoxWidth - 5 && // Правая граница
                    y - 10 - size > 0) // Верхняя граница
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public override bool CanBeMoved(int PictureBoxHeight, int PictureBoxWidth, int moveX, int moveY)
            {
                int newX = x + moveX;
                int newY = y + moveY;
                if (newX - size > 0 && // Левая граница
                    newY + size < PictureBoxHeight - 5 && // Нижняя граница
                    newX + size < PictureBoxWidth - 5 && // Правая граница
                    newY - size > 0) // Верхняя граница
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class Section : Figure
        {
            private int penWidth = 5;
            private Point end_point;
            public Section() { x = 0; y = 0; end_point = new Point(0, 0); }
            public Section(Point a, Point b) { this.x = a.X; this.y = a.Y; end_point = b; }
            public Section(Section section) { x = section.x; y = section.y; end_point = section.end_point; }
            ~Section() {}
            public override void DrawMe(Graphics g)
            {
                Pen pen = new Pen(Fillcolor, penWidth);
                if (selected)
                {
                    pen.Color = SelectedColor;
                    g.DrawLine(pen, x, y, end_point.X, end_point.Y);
                }
                else
                {
                    g.DrawLine(pen, x, y, end_point.X, end_point.Y);
                }
            }
            public override bool SelectionCheck(Point Location)
            {
                double A = end_point.Y - y;
                double B = x - end_point.X;
                double C = end_point.X * y - x * end_point.Y;
                double distance = Math.Abs(A * Location.X + B * Location.Y + C) / Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2));

                if (distance < penWidth / 2 + 1)
                {
                    
                    if (Math.Abs(end_point.Y - y) < double.Epsilon) // Горизонтальная прямая
                    {
                        return Math.Min(x, end_point.X) <= Location.X && Location.X <= Math.Max(x, end_point.X);
                    }
                    else if (Math.Abs(end_point.X - x) < double.Epsilon) // Вертикальная прямая
                        
                    {
                        return Math.Min(y, end_point.Y) <= Location.Y && Location.Y <= Math.Max(y, end_point.Y);
                    }
                    else
                    {
                        return Math.Min(x, end_point.X) <= Location.X && Location.X <= Math.Max(x, end_point.X) &&
                               Math.Min(y, end_point.Y) <= Location.Y && Location.Y <= Math.Max(y, end_point.Y);
                    }
                }
                else { return false; }
            }
            public override void MakeMeLarger()
            {
                penWidth += 4;
            }
            public override void MakeMeSmaller()
            {
                if (penWidth > 4)
                {
                    penWidth -= 4;
                }
            }
            public override void MoveMe(int moveX, int moveY)
            {
                x += moveX;
                y += moveY;
                end_point.X += moveX;
                end_point.Y += moveY;
            }
            public override bool CanBePlaced(int PictureBoxHeight, int PictureBoxWidth)
            {
                int vector_x = end_point.X - x;
                int vector_y = end_point.Y - y;
                float vector_length = (float)Math.Sqrt(Math.Pow(vector_x, 2) + Math.Pow(vector_y, 2)); // Длина линии
                float ortho_vector_x = - vector_y / vector_length * (penWidth / 2); // Вектор, ортогональный линии
                float ortho_vector_y = vector_x / vector_length * (penWidth / 2);
                PointF p1 = new PointF(x + ortho_vector_x, y + ortho_vector_y);
                PointF p2 = new PointF(x - ortho_vector_x, y - ortho_vector_y);
                PointF p3 = new PointF(end_point.X + ortho_vector_x, end_point.Y + ortho_vector_y);
                PointF p4 = new PointF(end_point.X - ortho_vector_x, end_point.Y - ortho_vector_y);
                float minX = Math.Min(Math.Min(p1.X, p2.X), Math.Min(p3.X, p4.X));
                float minY = Math.Min(Math.Min(p1.Y, p2.Y), Math.Min(p3.Y, p4.Y));
                float maxX = Math.Max(Math.Max(p1.X, p2.X), Math.Max(p3.X, p4.X));
                float maxY = Math.Max(Math.Max(p1.Y, p2.Y), Math.Max(p3.Y, p4.Y));

                if (minX > 0 && // Левая граница
                    maxY < PictureBoxHeight - 5 && // Нижняя граница
                    maxX < PictureBoxWidth - 5 && // Правая граница
                    minY > 0) // Верхняя граница
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public override bool CanBeLarger(int PictureBoxHeight, int PictureBoxWidth)
            {
                int vector_x = end_point.X - x;
                int vector_y = end_point.Y - y;
                float vector_length = (float)Math.Sqrt(Math.Pow(vector_x, 2) + Math.Pow(vector_y, 2)); // Длина линии
                float ortho_vector_x = -vector_y / vector_length * ((penWidth + 4) / 2); // Вектор, ортогональный линии
                float ortho_vector_y = vector_x / vector_length * ((penWidth + 4) / 2);
                PointF p1 = new PointF(x + ortho_vector_x, y + ortho_vector_y);
                PointF p2 = new PointF(x - ortho_vector_x, y - ortho_vector_y);
                PointF p3 = new PointF(end_point.X + ortho_vector_x, end_point.Y + ortho_vector_y);
                PointF p4 = new PointF(end_point.X - ortho_vector_x, end_point.Y - ortho_vector_y);
                float minX = Math.Min(Math.Min(p1.X, p2.X), Math.Min(p3.X, p4.X));
                float minY = Math.Min(Math.Min(p1.Y, p2.Y), Math.Min(p3.Y, p4.Y));
                float maxX = Math.Max(Math.Max(p1.X, p2.X), Math.Max(p3.X, p4.X));
                float maxY = Math.Max(Math.Max(p1.Y, p2.Y), Math.Max(p3.Y, p4.Y));

                if (minX > 0 && // Левая граница
                    maxY < PictureBoxHeight - 5 && // Нижняя граница
                    maxX < PictureBoxWidth - 5 && // Правая граница
                    minY > 0) // Верхняя граница
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public override bool CanBeMoved(int PictureBoxHeight, int PictureBoxWidth, int moveX, int moveY)
            {
                int vector_x = end_point.X - x;
                int vector_y = end_point.Y - y;
                float vector_length = (float)Math.Sqrt(Math.Pow(vector_x, 2) + Math.Pow(vector_y, 2)); // Длина линии
                float ortho_vector_x = -vector_y / vector_length * ((penWidth + 4) / 2); // Вектор, ортогональный линии
                float ortho_vector_y = vector_x / vector_length * ((penWidth + 4) / 2);
                PointF p1 = new PointF(x + ortho_vector_x, y + ortho_vector_y); // Точки прямоугольника
                PointF p2 = new PointF(x - ortho_vector_x, y - ortho_vector_y);
                PointF p3 = new PointF(end_point.X + ortho_vector_x, end_point.Y + ortho_vector_y);
                PointF p4 = new PointF(end_point.X - ortho_vector_x, end_point.Y - ortho_vector_y);
                float minX = Math.Min(Math.Min(p1.X, p2.X), Math.Min(p3.X, p4.X)) + moveX;
                float minY = Math.Min(Math.Min(p1.Y, p2.Y), Math.Min(p3.Y, p4.Y)) + moveY;
                float maxX = Math.Max(Math.Max(p1.X, p2.X), Math.Max(p3.X, p4.X)) + moveX;
                float maxY = Math.Max(Math.Max(p1.Y, p2.Y), Math.Max(p3.Y, p4.Y)) + moveY;

                if (minX > 0 && // Левая граница
                    maxY < PictureBoxHeight - 5 && // Нижняя граница
                    maxX < PictureBoxWidth - 5 && // Правая граница
                    minY > 0) // Верхняя граница
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
            public bool SelectionCheckAll(Point Location, bool CtrlPressed, bool MultiplySelections)
            {
                bool anyIsSelected = false;
                if (MultiplySelections)
                {
                    bool firstDeselection = true;
                    for (int i = 0; i < size; i++)
                    {
                        if (array[i].SelectionCheck(Location)) 
                        {
                            anyIsSelected = true;
                            if (!CtrlPressed && firstDeselection) 
                            {
                                firstDeselection = false;
                                MakeAllObjsUnselected();
                            }
                            array[i].selected = true;
                        }
                    }
                }
                else
                {
                    if (!CtrlPressed) { MakeAllObjsUnselected(); }
                    int minRLength = 10000;
                    Figure nearestObj = null;
                    for (int i = 0; i < size; i++)
                    {
                        if (array[i].SelectionCheck(Location))
                        {
                            anyIsSelected = true;
                            if (array[i].getRLength(Location) < minRLength)
                            {
                                nearestObj = array[i];
                            }

                        }
                    }
                    if (nearestObj != null)
                    {
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
                        if (array[i].selected)
                        {
                            DeleteObjFromContainer(array[i]);
                            i--;
                        }
                    }
                }
                MakeLastObjSelected();
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
            public void ChangeColorOfSelectedObjs(Color color)
            {
                for (int i = 0; i < size; i++)
                {
                    if (array[i].selected)
                    {
                        array[i].Fillcolor = color;
                    }
                }
            }
            public bool MoveSelectedObjs(int PictureBoxHeight, int PictureBoxWidth, int moveX, int moveY)
            {
                bool anyObjectHasBeenMoved = false;
                for (int i = 0; i < size; i++)
                {
                    if ((array[i].selected) && (array[i].CanBeMoved(PictureBoxHeight, PictureBoxWidth, moveX, moveY)))
                    {
                        anyObjectHasBeenMoved = true;
                        array[i].MoveMe(moveX, moveY);
                    }
                }
                return anyObjectHasBeenMoved;
            }
            public void MakeSelectedObjsLarger(int PictureBoxHeight, int PictureBoxWidth)
            {
                for (int i = 0;i < size;i++)
                {
                    if (array[i].selected && array[i].CanBeLarger(PictureBoxHeight, PictureBoxWidth))
                    {
                        array[i].MakeMeLarger();
                    }
                }
            }
            public void MakeSelectedObjsSmaller()
            {
                for (int i = 0; i < size; i++)
                {
                    if (array[i].selected)
                    {
                        array[i].MakeMeSmaller();
                    }
                }
            }
        }

        container c = new container();
        bool CtrlPressed = false;
        bool MultiplySelections = false;
        bool move = false;
        bool anyObjectHasBeenMoved = false;
        string figure = null;
        Point start_point;

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!c.SelectionCheckAll(e.Location, CtrlPressed, MultiplySelections) && (figure != null) && !anyObjectHasBeenMoved)
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
                if (createdFigure != null && createdFigure.CanBePlaced(pictureBox1.Height, pictureBox1.Width))
                {
                    c.Push_back(createdFigure);
                    createdFigure.selected = true;
                }
            }
            this.Refresh();
            anyObjectHasBeenMoved = false;
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
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            start_point = e.Location;
            move = true;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move && figure == null)
            {
                anyObjectHasBeenMoved = c.MoveSelectedObjs(pictureBox1.Height, pictureBox1.Width, e.X - start_point.X, e.Y - start_point.Y);
                this.Refresh();
                start_point = e.Location;
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) { CtrlPressed = true; }
            else if (e.KeyCode == Keys.ShiftKey) { MultiplySelections = true; }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) { CtrlPressed = false; }
            else if (e.KeyCode == Keys.ShiftKey) { MultiplySelections = false; }
            else if (e.KeyCode == Keys.Delete) 
            {
                c.DeleteSelectedFromContainer();
                this.Refresh();
            }
            else if (e.KeyCode == Keys.Oemplus)
            {
                c.MakeSelectedObjsLarger(pictureBox1.Height, pictureBox1.Width);
                this.Refresh();
            }
            else if (e.KeyCode == Keys.OemMinus)
            {
                c.MakeSelectedObjsSmaller();
                this.Refresh();
            }
        }

        private void toolStripMenuItem1_MouseDown(object sender, MouseEventArgs e)
        {
            figure = null;
        }

        private void toolStripMenuBlackColor_MouseDown(object sender, MouseEventArgs e)
        {
            c.ChangeColorOfSelectedObjs(Color.Black);
        }

        private void toolStripMenuRedColor_MouseDown(object sender, MouseEventArgs e)
        {
            c.ChangeColorOfSelectedObjs(Color.Red);
        }

        private void toolStripMenuGreenColor_MouseDown(object sender, MouseEventArgs e)
        {
            c.ChangeColorOfSelectedObjs(Color.Green);
        }

        private void toolStripMenuBlueColor_MouseDown(object sender, MouseEventArgs e)
        {
            c.ChangeColorOfSelectedObjs(Color.Blue);
        }
    }
}
