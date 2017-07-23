﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Aliq
{
    public sealed class Product<T, A, B> : Bag<T>
    {
        public Bag<A> InputA { get; }

        public Bag<B> InputB { get; }

        public Expression<Func<A, B, IEnumerable<T>>> Func { get; }

        public Product(
            Bag<A> inputA,
            Bag<B> inputB,
            Expression<Func<A, B, IEnumerable<T>>> func)
        {
            InputA = inputA;
            InputB = inputB;
            Func = func;
        }

        public override R Accept<R>(IVisitor<R> visitor)
            => visitor.Visit(this);
    }
}
