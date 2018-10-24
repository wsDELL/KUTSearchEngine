using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Search;
using FieldInvertState = Lucene.Net.Index.FieldInvertState;

namespace KUTSearchEngine
{
    class Newsimilarity: DefaultSimilarity
    {
        public override float ComputeNorm(System.String field, FieldInvertState state)
        {
            int numTerms;
            if (internalDiscountOverlaps)
                numTerms = state.Length - state.NumOverlap;
            else
                numTerms = state.Length;
            return (state.Boost * LengthNorm(field, numTerms));
        }

        /// <summary>Implemented as <c>1/sqrt(numTerms)</c>. </summary>
        public override float LengthNorm(System.String fieldName, int numTerms)
        {
            return (float)(1.0 / System.Math.Sqrt(numTerms));
        }

        /// <summary>Implemented as <c>1/sqrt(sumOfSquaredWeights)</c>. </summary>
        public override float QueryNorm(float sumOfSquaredWeights)
        {
            return (float)(1.0 / System.Math.Sqrt(sumOfSquaredWeights));
        }

        /// <summary>Implemented as <c>sqrt(freq)</c>. </summary>
        public override float Tf(float freq)
        {
            return (float)System.Math.Sqrt(freq);

        }

        /// <summary>Implemented as <c>1 / (distance + 1)</c>. </summary>
        public override float SloppyFreq(int distance)
        {
            return 1.0f / (distance + 1);
        }

        /// <summary>Implemented as <c>log(numDocs/(docFreq+1)) + 1</c>. </summary>
        public override float Idf(int docFreq, int numDocs)
        {
            return (float)(System.Math.Log(numDocs / (double)(docFreq + 1)) + 1.0);
        }

        /// <summary>Implemented as <c>overlap / maxOverlap</c>. </summary>
        public override float Coord(int overlap, int maxOverlap)
        {
            return overlap / (float)maxOverlap;
        }

        /// <seealso cref="DiscountOverlaps">
        /// </seealso>
        // Default false
        protected internal bool internalDiscountOverlaps;

        /// <summary>Determines whether overlap tokens (Tokens with
        /// 0 position increment) are ignored when computing
        /// norm.  By default this is false, meaning overlap
        /// tokens are counted just like non-overlap tokens.
        /// 
        /// <p/><b>WARNING</b>: This API is new and experimental, and may suddenly
        /// change.<p/>
        /// 
        /// </summary>
        /// <seealso cref="ComputeNorm">
        /// </seealso>
        public virtual bool DiscountOverlaps
        {
            get { return internalDiscountOverlaps; }
            set { internalDiscountOverlaps = value; }
        }
    }
}
