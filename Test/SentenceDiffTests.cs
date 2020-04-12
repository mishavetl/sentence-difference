using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Practice8.SentenceDiff;

namespace Practice8.Test
{
    class SentenceDiffTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestEmptyDiff()
        {
            Diff diff = new Text("This is a sentence.")
                .DifferenceComparedTo(new Text("This is a sentence."));
            Assert.AreEqual(
                new Diff(),
                diff
            );
        }

        [Test]
        public void TestEmptyDiffMultiSentence()
        {
            Diff diff = new Text("This is a sentence. This is a sentence1.\nThis is a sentence2. This is a sentence3.")
                .DifferenceComparedTo(new Text("This is a sentence. This is a sentence1.\nThis is a sentence2. This is a sentence3."));
            Assert.AreEqual(
                new Diff(),
                diff
            );
        }

        [Test]
        public void TestRemovedSentenceDiff()
        {
            Diff diff = new Text("This is the second sentence.")
                .DifferenceComparedTo(new Text("This is the first sentence. This is the second sentence."));
            Assert.AreEqual(
                new Diff
                {
                    GuideLines =
                    {
                        new RemoveGuideLine { Line = 1, Column = 1, Source = "This is the first sentence" }
                    }
                },
                diff
            );
        }

        [Test]
        public void TestRemovedSentenceFromEndDiff()
        {
            Diff diff = new Text("This is the first sentence.")
                .DifferenceComparedTo(new Text("This is the first sentence. This is the second sentence."));
            Assert.AreEqual(
                new Diff
                {
                    GuideLines =
                    {
                        new RemoveGuideLine { Line = 1, Column = 28, Source = " This is the second sentence" }
                    }
                },
                diff
            );
        }

        [Test]
        public void TestAddedSentenceToEndDiff()
        {
            Diff diff = new Text("This is the first sentence. This is the second sentence.")
                .DifferenceComparedTo(new Text("This is the first sentence."));
            Assert.AreEqual(
                new Diff
                {
                    GuideLines =
                    {
                        new AddGuideLine { Line = 1, Column = 28, Source = " This is the second sentence" }
                    }
                },
                diff
            );
        }

        [Test]
        public void TestAddedSentenceToBeginningDiff()
        {
            Diff diff = new Text("This is the first sentence. This is the second sentence.")
                .DifferenceComparedTo(new Text("This is the second sentence. This is the first sentence."));
            Assert.AreEqual(
                new Diff
                {
                    GuideLines =
                    {
                        new AddGuideLine { Line = 1, Column = 1, Source = "This is the first sentence" },
                        new RemoveGuideLine { Line = 1, Column = 57, Source = " This is the first sentence" }
                    }
                },
                diff
            );
        }
    }
}
