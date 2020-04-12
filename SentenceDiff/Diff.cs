using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice8.SentenceDiff
{
    public class Diff
    {
        public List<GuideLine> GuideLines { get; set; } = new List<GuideLine>();

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is Diff)
            {
                return (obj as Diff).GuideLines.SequenceEqual(GuideLines);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Join("\n", GuideLines.Select(g => new GuideLinePresenter(g)));
        }
    }
}
