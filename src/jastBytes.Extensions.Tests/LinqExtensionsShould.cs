﻿// MIT License
// 
// Copyright (c) 2018 Jan Steffen
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace jastBytes.Extensions.Tests
{
    public class LinqExtensionsShould
    {
        [Fact]
        public void ForEach()
        {
            var listOfExecuted = new List<int>();
            var enumerable = Enumerable.Range(0, 1000);

            var enumerated = enumerable
                .Skip(1)
                .Take(2)
                .ForEach(i => listOfExecuted.Add(i))
                .ToList();

            Assert.True(listOfExecuted.Count == 2);
            Assert.Equal(enumerated, listOfExecuted);
        }

        [Fact]
        public void Shuffle()
        {
            var enumerable = Enumerable.Range(0, 1000);

            var enumerated = enumerable
                .Shuffle();

            var ordered = true;
            for (var i = 0; i < enumerated.Count; i++)
            {
                ordered = enumerated[i] == i;
                if (!ordered) break;
            }
            Assert.True(!ordered);
        }
    }
}
