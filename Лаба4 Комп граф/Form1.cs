using System;
using System.Drawing;
using System.Windows.Forms;

namespace Лаба4_Комп_граф
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }
        private void button1_Click(object sender, EventArgs e)
        {

            int[] t = { -8, -1, 1, 5, -2, -6, -10, 2, 9, 0, 18,
                18, 10, 12, 4, -8, 3, 3, 18, 10, -2, -6, 0, 4, 5,
                4, 12, 16, 8, 5, 7 };
            Graphics g = pictureBox1.CreateGraphics();
            Pen penMore0 = new Pen(Color.DarkGreen);
            Font fn = new Font("Tahoma", 11);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            // Рисуем ось X
            // начальная точка первой линии
            int x1 = 0; int y1 = pictureBox1.Size.Height / 2;
            // конечная точка первой линии
            int x2 = pictureBox1.Size.Width;
            int y2 = pictureBox1.Size.Height / 2;
            g.DrawLine(penMore0, x1, y1, x2, y2);
            // Рисуем ось Y
            // начальная точка первой линии
            x1 = 0; y1 = 0;
            // конечная точка первой линии
            x2 = 0; y2 = pictureBox1.Size.Height;
            g.DrawLine(penMore0, x1, y1, x2, y2);
            // Находим максимум в массиве темепратур
            int max = -1;
            for (int i = 0; i < t.Length; i++) { if (t[i] > max) max = t[i]; }
            // Находим количество экранных точек в единице длины по оси Y
            int dy = pictureBox1.Size.Height / (2 * max);
            // Находим количество экранных точек в единице длины по оси X
            int dx = pictureBox1.Size.Width / 31;
            // ************** Ставим метки по оси Y вверх **************
            int y = pictureBox1.Size.Height / 2;
            for (int i = 0; i <= max; i++)
            {
                g.DrawString(Convert.ToString(i), fn, Brushes.Red, 10, y, sf);
                g.DrawLine(penMore0, 0, y, pictureBox1.Size.Width, y);
                y = y - dy;
            }
            // ************** Ставим метки по оси Y вниз ****************
            y = pictureBox1.Size.Height / 2;
            for (int i = 0; i <= max; i++)
            {
                g.DrawString(Convert.ToString(i), fn, Brushes.Red, 10, y, sf);
                g.DrawLine(penMore0, 0, y, pictureBox1.Size.Width, y);
                y = y + dy;
            }
            // *************** Ставим метки по оси X ********************
            int x = dx;
            for (int i = 1; i <= 31; i++)
            {
                g.DrawString(Convert.ToString(i), fn, Brushes.Red, x,
                pictureBox1.Size.Height / 2 - 22, sf);
                g.DrawLine(penMore0, x, pictureBox1.Size.Height / 2 - 5, x,
                pictureBox1.Size.Height / 2 + 5);
                x = x + dx;
            }
            penMore0.Dispose();
            // *************** Выводим график температур ***************
            // Задаем цвет и толщину пера для вывода графика температур
            penMore0 = new Pen(Color.Blue, 4);
            // Задаем стиль линии "точечная"
            penMore0.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            Pen penLess0 = new Pen(Color.Blue);
            penLess0 = new Pen(Color.Blue, 4);
            penLess0.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            Pen pen15 = new Pen(Color.Red);
            pen15 = new Pen(Color.Red, 4);
            pen15.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;

            Pen pen5 = new Pen(Color.Yellow);
            pen5 = new Pen(Color.Yellow, 4);
            pen5.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;

            // Задаем начальную координату x
            x = dx;
            // Отмечаем кружком значение температуры в первый день
            g.DrawEllipse(Pens.Red, x - 3, pictureBox1.Size.Height / 2 - t[0] * dy - 3, 6, 6);
            // Организуем цикл по элементам массива температур
            for (int i = 1; i <= t.Length - 1; i++)
            {
                // Проводим линию из одного значения температуры в другое
                if (t[i] > 0)
                {
                    if (t[i - 1] < 0)
                    {
                        g.DrawLine(penLess0, x, pictureBox1.Size.Height / 2 - t[i - 1] * dy,
                        x + dx, pictureBox1.Size.Height / 2);

                        g.DrawLine(penMore0, x + dx, pictureBox1.Size.Height / 2,
                        x + dx, pictureBox1.Size.Height / 2 - t[i] * dy);
                    }

                    else if (t[i] >= 15 && t[i - 1] >= 15)
                    {
                        g.DrawLine(pen15, x, pictureBox1.Size.Height / 2 - t[i - 1] * dy,
                      x + dx, pictureBox1.Size.Height / 2 - t[i] * dy);
                     
                    }

                    else if (t[i] >= 15)
                    {
                        g.DrawLine(penMore0, x, pictureBox1.Size.Height / 2 - t[i - 1] * dy,
                        x + dx, pictureBox1.Size.Height / 2 - 15 * dy);

                        g.DrawLine(pen15, x + dx, pictureBox1.Size.Height / 2 - 15 * dy,
                        x + dx, pictureBox1.Size.Height / 2 - t[i] * dy);
                    }

                    else if (t[i - 1] >= 15)
                    {
                        g.DrawLine(pen15, x, pictureBox1.Size.Height / 2 - t[i - 1] * dy,
                        x + dx, pictureBox1.Size.Height / 2 - 15 * dy);

                        g.DrawLine(penMore0, x + dx, pictureBox1.Size.Height / 2 - 15 * dy,
                        x + dx, pictureBox1.Size.Height / 2 - t[i] * dy);
                    }
                  
                    else g.DrawLine(penMore0, x, pictureBox1.Size.Height / 2 - t[i - 1] * dy,
                    x + dx, pictureBox1.Size.Height / 2 - t[i] * dy);
                }

                if (t[i] <= 0)
                {
                    if (t[i - 1] > 0)
                    {
                        g.DrawLine(penMore0, x, pictureBox1.Size.Height / 2 - t[i - 1] * dy,
                        x + dx, pictureBox1.Size.Height / 2);

                        if (t[i] <= -5)
                        {
                            g.DrawLine(penLess0, x + dx, pictureBox1.Size.Height / 2,
                            x + dx, pictureBox1.Size.Height / 2 + 5 * dy);

                            g.DrawLine(pen5, x + dx, pictureBox1.Size.Height / 2 + 5 * dy,
                            x + dx, pictureBox1.Size.Height / 2 - t[i] * dy);
                        }                        

                        else g.DrawLine(penLess0, x + dx, pictureBox1.Size.Height / 2,
                        x + dx, pictureBox1.Size.Height / 2 - t[i] * dy);
                    }





                    else if (t[i] <= -5 && t[i - 1] <= -5)
                    {
                        g.DrawLine(pen5, x, pictureBox1.Size.Height / 2 - t[i - 1] * dy,
                      x + dx, pictureBox1.Size.Height / 2 - t[i] * dy);

                    }

                    else if (t[i] <= -5)
                    {
                        g.DrawLine(penLess0, x, pictureBox1.Size.Height / 2 - t[i - 1] * dy,
                        x + dx, pictureBox1.Size.Height / 2 + 5 * dy);

                        g.DrawLine(pen5, x + dx, pictureBox1.Size.Height / 2 + 5 * dy,
                        x + dx, pictureBox1.Size.Height / 2 - t[i] * dy);
                    }

                    else if (t[i - 1] <= -5)
                    {
                        g.DrawLine(pen5, x, pictureBox1.Size.Height / 2 - t[i - 1] * dy,
                        x + dx, pictureBox1.Size.Height / 2 + 5 * dy);

                        g.DrawLine(penLess0, x + dx, pictureBox1.Size.Height / 2 + 5 * dy,
                        x + dx, pictureBox1.Size.Height / 2 - t[i] * dy);
                    }







                    else g.DrawLine(penLess0, x, pictureBox1.Size.Height / 2 - t[i - 1] * dy,
                    x + dx, pictureBox1.Size.Height / 2 - t[i] * dy);
                }

                // Отмечаем кружком значение температуры
                g.DrawEllipse(Pens.Red, x + dx - 3, pictureBox1.Size.Height / 2 - t[i] * dy - 3, 6, 6);
                // Переходим к следующему дню месяца
                x = x + dx;
            }
            penMore0.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
