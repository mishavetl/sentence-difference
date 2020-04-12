using System;
using System.Collections.Generic;
using System.Text;

namespace Practice8.SentenceDiff
{
    class GuideLinePresenter
    {
        private readonly GuideLine _guideLine;

        public GuideLinePresenter(GuideLine guideLine)
        {
            _guideLine = guideLine;
        }

        public override string ToString()
        {
            if (_guideLine is RemoveGuideLine removeGuideLine)
            {
                return $"--- {removeGuideLine.Line}:{removeGuideLine.Column} {removeGuideLine.Source}";
            } else if (_guideLine is AddGuideLine addGuideLine)
            {
                return $"+++ {addGuideLine.Line}:{addGuideLine.Column} {addGuideLine.Source}";
            }
            throw new NotImplementedException();
        }
    }
}
