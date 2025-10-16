using System;

namespace Shapes
{
    // Base abstract class for all shapes
    public abstract class Shape
    {
        private string _color;

        public Shape(string color)
        {
            _color = color;
        }

        public string GetColor()
        {
            return _color;
        }

        public void SetColor(string color)
        {
            _color = color;
        }

        public abstract double GetArea();
    }
}