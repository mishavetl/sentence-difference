using System;
using System.Collections.Generic;
using System.Text;

namespace Practice8.SentenceDiff
{
    public abstract class GuideLine
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public string Source { get; set; }

        protected abstract string Type { get; }

        public override bool Equals(object obj)
        {
            return obj is GuideLine line &&
                   Type == line.Type &&
                   Line == line.Line &&
                   Column == line.Column &&
                   Source == line.Source;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Line, Column, Source, Type);
        }
    }
}
