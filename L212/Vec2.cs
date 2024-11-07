using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L212
{
    public class Vec2
    {
        public double x;
        public double y;

        public Vec2(double x, double y) 
        {
            this.x = x;
            this.y = y;
        }

        public void Draw()
        {
            VecGraph graph = new VecGraph();
            Vec2[] This = { this };
            graph.Draw(This);
            graph.Show();
        }

        public static Vec2 operator +(Vec2 a, Vec2 b) => new Vec2(a.x + b.x, a.y + b.y);
        public static Vec2 operator *(Vec2 a, Vec2 b) => new Vec2(a.x * b.x, a.y * b.y);
        public double DotProd(Vec2 b) => this.x * this.y + b.y * b.x;
        //public double Abs(Vec2 )
    }
}
