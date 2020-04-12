using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice8.SentenceDiff
{
    public class Text
    {
        public string Source { get; }

        public Text(string source)
        {
            Source = source;
        }

        public Diff DifferenceComparedTo(Text other)
        {
            string[] initial = other.Source.Split(".").ToArray();
            string[] transformed = Source.Split(".").ToArray();
            Diff diff = new Diff();

            int i = 0, j = 0, line = 1, column = 1;
            while (i < initial.Length && j < transformed.Length)
            {
                int newI = i + 1, newJ = j + 1;

                if (!initial[i].Trim().Equals(transformed[j].Trim()))
                {
                    int k = i, l = j;
                    void FindCommon()
                    {
                        for (; k < initial.Length; ++k)
                        {
                            for (l = j; l < transformed.Length; ++l)
                            {
                                if (initial[k].Trim().Equals(transformed[l].Trim()))
                                {
                                    return;
                                }
                            }
                        }
                    }
                    FindCommon();
                    for (int u = i; u < k; ++u)
                    {
                        diff.GuideLines.Add(new RemoveGuideLine
                        {
                            Line = line,
                            Column = column,
                            Source = initial[u]
                        });
                    }
                    for (int u = j; u < l; ++u)
                    {
                        diff.GuideLines.Add(new AddGuideLine
                        {
                            Line = line,
                            Column = column,
                            Source = transformed[u]
                        });
                    }

                    newI = k;
                    newJ = l;
                }

                line += initial[i].Count(c => c == '\n');
                int newLineIndex = initial[i].LastIndexOf('\n');
                if (newLineIndex >= 0)
                {
                    column = initial[i].Length - newLineIndex + 1;
                } else
                {
                    column += initial[i].Length + 1;
                }

                i = newI;
                j = newJ;
            }

            return diff;
        }
    }
}
