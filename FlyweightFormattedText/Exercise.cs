using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Coding.Exercise
{
    public class Sentence
    {
        private readonly string[]  _words;
        private readonly Dictionary<int, WordToken> _tokens = new Dictionary<int, WordToken>();
        public Sentence(string plainText)
        {
            this._words = plainText.Split(' ');
        }

        public WordToken this[int index]
        {
            get
            {
                if (_tokens.ContainsKey(index)) return _tokens[index];
                
                _tokens.Add(index, new WordToken());
                return _tokens[index];
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var index = 0; index < _words.Length; index++)
            {
                var c = _words[index];
                if (_tokens.ContainsKey(index))
                {
                    var token = _tokens[index];
                    if (token.Capitalize) c = c.ToUpperInvariant();
                }
                sb.Append(c);
                if (index != _words.Length -1) sb.Append(" ");
            }
            return sb.ToString();
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }
    namespace Coding.Exercise.Tests
    {
        [TestFixture]
        public class TestSuite
        {
            [Test]
            public void Test()
            {
                var s = new Sentence("alpha beta gamma");
                s[1].Capitalize = true;
                Assert.That(s.ToString(),
                    Is.EqualTo("alpha BETA gamma"));
            }
        }
    }
}
