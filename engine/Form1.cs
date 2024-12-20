﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace engine
{
    public partial class Form1 : Form
    {
        List<Point> cube;
        float s = 120; //define size of the cube
        float r = 100; //radius for constructing polygons
        (float, float) size;

        float cx, cy, cz;
        float dx, dy, dz;
        float length;
        float m;
        float tempx, tempy = 0;

        List<(int, int)> connections;
        List<(int, int, int)> triangles;
        List<(int, int, int)> sqaures;
        float rad;
        Timer t;
        Stopwatch sw;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            BackColor = Color.White;
            TransparencyKey = Color.White;

            size = (s, s);

            //center of window
            cx = Width / 2;
            cy = Height / 2;
            cz = 0;

            /*cube
            //actuall points
            cube = new List<Point>();
            cube.Add(new Point(cx - size.Item1 / 2, cy + size.Item2 / 2, cz + size.Item1 / 2));
            cube.Add(new Point(cube[0].X + size.Item1, cube[0].Y, cube[0].Z));
            cube.Add(new Point(cube[0].X, cube[0].Y - size.Item2, cube[0].Z));
            cube.Add(new Point(cube[0].X + size.Item1, cube[0].Y - size.Item2, cube[0].Z));
            
            cube.Add(new Point(cube[0].X, cube[0].Y, cube[0].Z - size.Item1));
            cube.Add(new Point(cube[0].X + size.Item1, cube[0].Y, cube[0].Z - size.Item1));
            cube.Add(new Point(cube[0].X, cube[0].Y - size.Item2, cube[0].Z - size.Item1));
            cube.Add(new Point(cube[0].X + size.Item1, cube[0].Y - size.Item2, cube[0].Z - size.Item1));

            //map of connections betweem vertices
            connections = new List<(int, int)> { 
                (0, 1), 
                (0, 2), 
                (0, 4), 
                (1, 3), 
                (1, 5), 
                (2, 3), 
                (2, 6),
                (3, 7),
                (4, 5),
                (4, 6),
                (5, 7),
                (6, 7)
            };
            */

            /*heart 
            cube = new List<Point>();
            float A = cz + 75;
            cube.Add(new Point(cx, cy - 175f, A));
            cube.Add(new Point(cx + 150, cy - 250, A));
            cube.Add(new Point(cx + 300, cy - 250, A));
            cube.Add(new Point(cx + 400, cy - 200, A));
            cube.Add(new Point(cx + 425, cy - 100, A));
            cube.Add(new Point(cx + 425, cy, A));
            cube.Add(new Point(cx + 375, cy + 100, A));
            cube.Add(new Point(cx + 300, cy + 200, A));
            cube.Add(new Point(cx + 200, cy + 275, A));
            cube.Add(new Point(cx + 100, cy + 325, A));
            cube.Add(new Point(cx, cy + 375, A));
            cube.Add(new Point(cx - 100, cy + 325, A));
            cube.Add(new Point(cx - 200, cy + 275, A));
            cube.Add(new Point(cx - 300, cy + 200, A));
            cube.Add(new Point(cx - 375, cy + 100, A));
            cube.Add(new Point(cx - 425, cy, A));
            cube.Add(new Point(cx - 425, cy - 100, A));
            cube.Add(new Point(cx - 400, cy - 200, A));
            cube.Add(new Point(cx - 300, cy - 250, A));
            cube.Add(new Point(cx - 150, cy - 250, A));

            cube.Add(new Point(cx, cy - 175f, -A));
            cube.Add(new Point(cx + 150, cy - 250, -A));
            cube.Add(new Point(cx + 300, cy - 250, -A));
            cube.Add(new Point(cx + 400, cy - 200, -A));
            cube.Add(new Point(cx + 425, cy - 100, -A));
            cube.Add(new Point(cx + 425, cy, -A));  
            cube.Add(new Point(cx + 375, cy + 100, -A));
            cube.Add(new Point(cx + 300, cy + 200, -A));
            cube.Add(new Point(cx + 200, cy + 275, -A));
            cube.Add(new Point(cx + 100, cy + 325, -A));
            cube.Add(new Point(cx, cy + 375, -A));  
            cube.Add(new Point(cx - 100, cy + 325, -A));
            cube.Add(new Point(cx - 200, cy + 275, -A));
            cube.Add(new Point(cx - 300, cy + 200, -A));
            cube.Add(new Point(cx - 375, cy + 100, -A));
            cube.Add(new Point(cx - 425, cy, -A));  
            cube.Add(new Point(cx - 425, cy - 100, -A));
            cube.Add(new Point(cx - 400, cy - 200, -A));
            cube.Add(new Point(cx - 300, cy - 250, -A));
            cube.Add(new Point(cx - 150, cy - 250, -A));

            for (int i = 0; i < cube.Count; i++)
            {
                cube[i].X = (cube[i].X - cx) / 2 + cx;
                cube[i].Y = (cube[i].Y - cy) / 2 + cy;
                cube[i].Z = (cube[i].Z - cz) / 2 + cz;
            }
            

            connections = new List<(int, int)> { 
                (0, 1),
                (1, 2),
                (2, 3),
                (3, 4),
                (4, 5),
                (5, 6),
                (6, 7),
                (7, 8),
                (8, 9),
                (9, 10),
                (10, 11),
                (11, 12),
                (12, 13),
                (13, 14),
                (14, 15),
                (15, 16),
                (16, 17),
                (17, 18),
                (18, 19),
                (19, 0),
                (20, 21),
                (21, 22),
                (22, 23),
                (23, 24),
                (24, 25),
                (25, 26),
                (26, 27),
                (27, 28),
                (28, 29),
                (29, 30),
                (30, 31),
                (31, 32),
                (32, 33),
                (33, 34),
                (34, 35),
                (35, 36),
                (36, 37),
                (37, 38),
                (38, 39),
                (39, 20),
                (0,20),
		        (1, 21),
                (2, 22),
                (3, 23),
                (4, 24),
                (5, 25),
                (6, 26),
                (7, 27),
                (8, 28),
                (9, 29),
                (10, 30),
                (11, 31),
                (12, 32),
                (13, 33),
                (14, 34),
                (15, 35),
                (16, 36),
                (17, 37),
                (18, 38),
                (19, 39)
            };
            */

            /*The Sims' plumbob or hexagonal bipyramid (⌐⊙_⊙)*/
            cube = new List<Point>();
            rad = (float) Math.PI / 3; //internal angle in a hexagon
            cube.Add(new Point(r,0,0));
            cube.Add(new Point((float) (r - r * Math.Cos(rad)), 0, (float) (r * Math.Sin(rad))));
            cube.Add(new Point(-cube[1].X, 0, cube[1].Z));
            cube.Add(new Point(-r, 0, 0));
            cube.Add(new Point(-cube[1].X, 0, -cube[1].Z));
            cube.Add(new Point(cube[1].X, 0, -cube[1].Z));
            cube.Add(new Point(0, r * 2, 0));
            cube.Add(new Point(0, -r * 2, 0));

            foreach (Point p in cube)
            {
                p.X += cx;
                p.Y += cy;
                p.Z += cz;
            }

            connections = new List<(int, int)>
            {
                (0, 1),
                (1, 2),
                (2, 3),
                (3, 4),
                (4, 5),
                (5, 0),
                (6, 0),
                (6, 1),
                (6, 2),
                (6, 3),
                (6, 4),
                (6, 5),
                (7, 0),
                (7, 1),
                (7, 2),
                (7, 3),
                (7, 4),
                (7, 5)
            };

            triangles = new List<(int, int, int)>
            {
                (0, 1, 6),
                (1, 2, 6),
                (2, 3, 6),
                (3, 4, 6),
                (4, 5, 6),
                (5, 0, 6),

                (0, 1, 7),
                (1, 2, 7),
                (2, 3, 7),
                (3, 4, 7),
                (4, 5, 7),
                (5, 0, 7)
            };

            //instead of using delay, timer would make it possible to "rotate a cube throughout the time"
            t = new Timer();
            t.Interval = 100;
            t.Tick += tick;

            sw = new Stopwatch();
            sw.Start();

            Resize += resize;

            t.Start();
        }
        private void tick(object sender, EventArgs e) //what happens after 1ms of timer lasted
        {
            for (int i = 0; i < cube.Count; i++)
            {
                rotate(cube[i], 0, 0.04f, 0);
                cube[i].Y += (float) (5*Math.Sin(sw.ElapsedMilliseconds / 1000));
            }
            Invalidate();
        }
        private void rotate(Point p, float ax, float ay, float az)
        {
            tempy = p.Y;
            rad = ax;
            p.Y = (float)((p.Y - cy) * Math.Cos(rad) - (p.Z - cz) * Math.Sin(rad) + cy);
            p.Z = (float)((tempy - cy) * Math.Sin(rad) + (p.Z - cz) * Math.Cos(rad) + cz);

            tempx = p.X;
            rad = ay;
            p.X = (float)((p.X - cx) * Math.Cos(rad) + (p.Z - cz) * Math.Sin(rad) + cx);
            p.Z = (float)((p.Z - cz) * Math.Cos(rad) - (tempx - cx) * Math.Sin(rad) + cz);

            tempx = p.X;
            rad = az;
            p.X = (float)((p.X - cx) * Math.Cos(rad) - (p.Y - cy) * Math.Sin(rad) + cx);
            p.Y = (float)((tempx - cx) * Math.Sin(rad) + (p.Y - cy) * Math.Cos(rad) + cy);
        }
        protected override void OnPaint(PaintEventArgs e) //draw pixels
        {
            base.OnPaint(e);
            for (int i = 0; i < triangles.Count; i++) e.Graphics.FillPolygon(new SolidBrush(Color.Green), new PointF[] { new PointF(cube[triangles[i].Item1].X, cube[triangles[i].Item1].Y), new PointF(cube[triangles[i].Item2].X, cube[triangles[i].Item2].Y), new PointF(cube[triangles[i].Item3].X, cube[triangles[i].Item3].Y) });
            for (int i = 0; i < connections.Count; i++) draw_line(cube[connections[i].Item1], cube[connections[i].Item2], e);
        }
        private void draw_line(Point p1, Point p2, PaintEventArgs e) //
        {
            dx = p2.X - p1.X;
            dy = p2.Y - p1.Y;
            dz = p2.Z - p1.Z;
            length = (float)Math.Sqrt(dx * dx + dy * dy);
            m = (float)Math.Atan2(dy, dx);
            for (int i = 0; i < length; i++) e.Graphics.FillRectangle(new SolidBrush(Color.Black), p1.X + (float)(Math.Cos(m) * i), p1.Y + (float)(Math.Sin(m) * i), 1, 1);
        }
        private void resize(object sender, EventArgs e)
        {
            cx = Width / 2;
            cy = Height / 2;
            cz = 0;

            /* cube
            cube[0] = (new Point(cx - size.Item1 / 2, cy + size.Item2 / 2, cz + size.Item1 / 2));
            cube[1] = (new Point(cube[0].X + size.Item1, cube[0].Y, cube[0].Z));
            cube[2] = (new Point(cube[0].X, cube[0].Y - size.Item2, cube[0].Z));
            cube[3] = (new Point(cube[0].X + size.Item1, cube[0].Y - size.Item2, cube[0].Z));
                
            cube[4] = (new Point(cube[0].X, cube[0].Y, cube[0].Z - size.Item1));
            cube[5] = (new Point(cube[0].X + size.Item1, cube[0].Y, cube[0].Z - size.Item1));
            cube[6] = (new Point(cube[0].X, cube[0].Y - size.Item2, cube[0].Z - size.Item1));
            cube[7] = (new Point(cube[0].X + size.Item1, cube[0].Y - size.Item2, cube[0].Z - size.Item1));
            */

            /* plumbob */
            rad = (float) Math.PI / 3;
            cube[0] = (new Point(r, 0, 0));
            cube[1] = (new Point((float)(r - r * Math.Cos(rad)), 0, (float)(r * Math.Sin(rad))));
            cube[2] = (new Point(-cube[1].X, 0, cube[1].Z));
            cube[3] = (new Point(-r, 0, 0));
            cube[4] = (new Point(-cube[1].X, 0, -cube[1].Z));
            cube[5] = (new Point(cube[1].X, 0, -cube[1].Z));
            cube[6] = (new Point(0, r * 2, 0));
            cube[7] = (new Point(0, -r * 2, 0));

            foreach (Point p in cube)
            {
                p.X += cx;
                p.Y += cy;
                p.Z += cz;
            }

            /* heart
            float A = cz + 75;
            cube[0] = new Point(cx, cy + 175f, A);
            cube[1] = new Point(cx + 150, cy + 250, A);
            cube[2] = new Point(cx + 300, cy + 250, A);
            cube[3] = new Point(cx + 400, cy + 200, A);
            cube[4] = new Point(cx + 425, cy + 100, A);
            cube[5] = new Point(cx + 425, cy, A);
            cube[6] = new Point(cx + 375, cy - 100, A);
            cube[7] = new Point(cx + 300, cy - 200, A);
            cube[8] = new Point(cx + 200, cy - 275, A);
            cube[9] = new Point(cx + 100, cy - 325, A);
            cube[10] = new Point(cx, cy - 375, A);
            cube[11] = new Point(cx - 100, cy - 325, A);
            cube[12] = new Point(cx - 200, cy - 275, A);
            cube[13] = new Point(cx - 300, cy - 200, A);
            cube[14] = new Point(cx - 375, cy - 100, A);
            cube[15] = new Point(cx - 425, cy, A);
            cube[16] = new Point(cx - 425, cy + 100, A);
            cube[17] = new Point(cx - 400, cy + 200, A);
            cube[18] = new Point(cx - 300, cy + 250, A);
            cube[19] = new Point(cx - 150, cy + 250, A);

            cube[20] = new Point(cx, cy + 175f, -A);
            cube[21] = new Point(cx + 150, cy + 250, -A);
            cube[22] = new Point(cx + 300, cy + 250, -A);
            cube[23] = new Point(cx + 400, cy + 200, -A);
            cube[24] = new Point(cx + 425, cy + 100, -A);
            cube[25] = new Point(cx + 425, cy, -A);
            cube[26] = new Point(cx + 375, cy - 100, -A);
            cube[27] = new Point(cx + 300, cy - 200, -A);
            cube[28] = new Point(cx + 200, cy - 275, -A);
            cube[29] = new Point(cx + 100, cy - 325, -A);
            cube[30] = new Point(cx, cy - 375, -A);
            cube[31] = new Point(cx - 100, cy - 325, -A);
            cube[32] = new Point(cx - 200, cy - 275, -A);
            cube[33] = new Point(cx - 300, cy - 200, -A);
            cube[34] = new Point(cx - 375, cy - 100, -A);
            cube[35] = new Point(cx - 425, cy, -A);
            cube[36] = new Point(cx - 425, cy + 100, -A);
            cube[37] = new Point(cx - 400, cy + 200, -A);
            cube[38] = new Point(cx - 300, cy + 250, -A);
            cube[39] = new Point(cx - 150, cy + 250, -A);

            for (int i = 0; i < cube.Count; i++)
            {
                cube[i].X = (cube[i].X - cx) / 2 + cx;
                cube[i].Y = (cube[i].Y - cy) / 2 + cy;
                cube[i].Z = (cube[i].Z - cz) / 2 + cz;
            }
            */
        }
    }
}
