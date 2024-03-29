﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        double length;
        double height;
        double width;

        public Box(double length, double width, double height)
        {
            Length = length;
            Height = height;
            Width = width;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.BoxParameterCannotBeZeroOrNegative,nameof(Length)));
                }
                length = value;
            }
        }
        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.BoxParameterCannotBeZeroOrNegative, nameof(Height)));
                }
                height = value;
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.BoxParameterCannotBeZeroOrNegative, nameof(Width)));
                }
                width = value;
            }
        }


        public double SurfaceArea()
        {
            return 2 * (Length * Width + Length * Height + Width * Height);
        }
        public double LateralSurfaceArea()
        {
            return 2 * Height * (Width + Length);
        }
        public double Volume()
        {
            return Length * Width * Height;
        }


    }
}
