﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
    {

        public Box(T value)
        {
            this.Value = value;
        }

        public T Value;


        public override string ToString()
        {
            return $"{this.Value.GetType()}: {this.Value}";
        }
    }

}