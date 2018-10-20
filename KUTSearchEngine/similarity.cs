﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Search;
using FieldInvertState = Lucene.Net.Index.FieldInvertState;

namespace KUTSearchEngine
{
    class similarity: DefaultSimilarity
    {
        /// <summary>Implemented as <c>sqrt(freq)</c>. </summary>
        public override float Tf(float freq)
        {
            //return (float)System.Math.Sqrt(freq);
            return 1;
        }
    }
}
