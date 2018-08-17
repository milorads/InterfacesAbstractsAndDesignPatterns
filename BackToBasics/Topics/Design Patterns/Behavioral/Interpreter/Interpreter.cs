﻿using System;

namespace BackToBasics.Topics.Design_Patterns.Behavioral.Interpreter
{
    #region Sample code
    /// <summary>
    /// The 'Context' class
    /// </summary>
    class InterpreterContext
    {
    }

    /// <summary>
    /// The 'AbstractExpression' abstract class
    /// </summary>
    abstract class AbstractExpression
    {
        public abstract void Interpret(InterpreterContext context);
        public abstract string Interpret(InterpreterContext context, bool test);
    }

    /// <summary>
    /// The 'TerminalExpression' class
    /// </summary>
    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(InterpreterContext context)
        {
            Console.WriteLine("Called Terminal.Interpret()");
        }

        public override string Interpret(InterpreterContext context, bool test)
        {
            return "Called Terminal.Interpret()";
        }
    }

    /// <summary>
    /// The 'NonterminalExpression' class
    /// </summary>
    class NonterminalExpression : AbstractExpression
    {
        public override void Interpret(InterpreterContext context)
        {
            Console.WriteLine("Called Nonterminal.Interpret()");
        }

        public override string Interpret(InterpreterContext context, bool test)
        {
            return "Called Nonterminal.Interpret()";
        }
    }
    #endregion

    #region Implementation code
    /// <summary>
    /// The 'Context' class
    /// </summary>
    class InterpreterApplicationContext
    {
        private string _input;
        private int _output;

        // Constructor
        public InterpreterApplicationContext(string input)
        {
            this._input = input;
        }

        // Gets or sets input
        public string Input
        {
            get { return _input; }
            set { _input = value; }
        }

        // Gets or sets output
        public int Output
        {
            get { return _output; }
            set { _output = value; }
        }
    }

    /// <summary>
    /// The 'AbstractExpression' class
    /// </summary>
    abstract class Expression
    {
        public void Interpret(InterpreterApplicationContext context)
        {
            if (context.Input.Length == 0)
                return;

            if (context.Input.StartsWith(Nine()))
            {
                context.Output += (9 * Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Four()))
            {
                context.Output += (4 * Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Five()))
            {
                context.Output += (5 * Multiplier());
                context.Input = context.Input.Substring(1);
            }

            while (context.Input.StartsWith(One()))
            {
                context.Output += (1 * Multiplier());
                context.Input = context.Input.Substring(1);
            }
        }

        public abstract string One();
        public abstract string Four();
        public abstract string Five();
        public abstract string Nine();
        public abstract int Multiplier();
    }

    /// <summary>
    /// A 'TerminalExpression' class
    /// <remarks>
    /// Thousand checks for the Roman Numeral M
    /// </remarks>
    /// </summary>
    class ThousandExpression : Expression
    {
        public override string One() { return "M"; }
        public override string Four() { return " "; }
        public override string Five() { return " "; }
        public override string Nine() { return " "; }
        public override int Multiplier() { return 1000; }
    }

    /// <summary>
    /// A 'TerminalExpression' class
    /// <remarks>
    /// Hundred checks C, CD, D or CM
    /// </remarks>
    /// </summary>
    class HundredExpression : Expression
    {
        public override string One() { return "C"; }
        public override string Four() { return "CD"; }
        public override string Five() { return "D"; }
        public override string Nine() { return "CM"; }
        public override int Multiplier() { return 100; }
    }

    /// <summary>
    /// A 'TerminalExpression' class
    /// <remarks>
    /// Ten checks for X, XL, L and XC
    /// </remarks>
    /// </summary>
    class TenExpression : Expression
    {
        public override string One() { return "X"; }
        public override string Four() { return "XL"; }
        public override string Five() { return "L"; }
        public override string Nine() { return "XC"; }
        public override int Multiplier() { return 10; }
    }

    /// <summary>
    /// A 'TerminalExpression' class
    /// <remarks>
    /// One checks for I, II, III, IV, V, VI, VI, VII, VIII, IX
    /// </remarks>
    /// </summary>
    class OneExpression : Expression
    {
        public override string One() { return "I"; }
        public override string Four() { return "IV"; }
        public override string Five() { return "V"; }
        public override string Nine() { return "IX"; }
        public override int Multiplier() { return 1; }
    }
    #endregion
}
