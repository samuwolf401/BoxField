using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxField
{
    class Box
    {
        public int x, y, size, speed;
        public string colour;

        public Box(int _x, int _y, int _size, int _speed, string _colour)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            colour = _colour;
        }

    }
}
