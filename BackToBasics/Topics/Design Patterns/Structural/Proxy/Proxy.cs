﻿using System;

namespace BackToBasics.Topics.Design_Patterns.Structural.Proxy
{
    #region Structure code
    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    abstract class Subject
    {
        public abstract void Request();
        public abstract string Request(bool test);
    }

    /// <summary>
    /// The 'RealSubject' class
    /// </summary>
    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Called RealSubject.Request()");
        }

        public override string Request(bool test)
        {
            return "Called RealSubject.Request()";
        }
    }

    /// <summary>
    /// The 'Proxy' class
    /// </summary>
    class Proxy : Subject
    {
        private RealSubject _realSubject;

        public override void Request()
        {
            // Use 'lazy initialization'
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }

            _realSubject.Request();
        }

        public override string Request(bool test)
        {
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }

             return _realSubject.Request(true);
        }
    }
    #endregion

    #region Implementation code
    /// <summary>
    /// The 'Subject interface
    /// </summary>
    public interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Div(double x, double y);
    }

    /// <summary>
    /// The 'RealSubject' class
    /// </summary>
    class Math : IMath
    {
        public double Add(double x, double y) { return x + y; }
        public double Sub(double x, double y) { return x - y; }
        public double Mul(double x, double y) { return x * y; }
        public double Div(double x, double y) { return x / y; }
    }

    /// <summary>
    /// The 'Proxy Object' class
    /// </summary>
    class MathProxy : IMath
    {
        private Math _math = new Math();

        public double Add(double x, double y)
        {
            return _math.Add(x, y);
        }
        public double Sub(double x, double y)
        {
            return _math.Sub(x, y);
        }
        public double Mul(double x, double y)
        {
            return _math.Mul(x, y);
        }
        public double Div(double x, double y)
        {
            return _math.Div(x, y);
        }
    }
    #endregion
}
