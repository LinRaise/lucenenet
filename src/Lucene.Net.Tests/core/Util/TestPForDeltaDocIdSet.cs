using Lucene.Net.Support;
using NUnit.Framework;
using System.Collections;

namespace Lucene.Net.Util
{
    /*
     * Licensed to the Apache Software Foundation (ASF) under one or more
     * contributor license agreements.  See the NOTICE file distributed with
     * this work for additional information regarding copyright ownership.
     * The ASF licenses this file to You under the Apache License, Version 2.0
     * (the "License"); you may not use this file except in compliance with
     * the License.  You may obtain a copy of the License at
     *
     *     http://www.apache.org/licenses/LICENSE-2.0
     *
     * Unless required by applicable law or agreed to in writing, software
     * distributed under the License is distributed on an "AS IS" BASIS,
     * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
     * See the License for the specific language governing permissions and
     * limitations under the License.
     */

    public class TestPForDeltaDocIdSet : BaseDocIdSetTestCase<PForDeltaDocIdSet>
    {
        public override PForDeltaDocIdSet CopyOf(BitArray bs, int length)
        {
            PForDeltaDocIdSet.Builder builder = (new PForDeltaDocIdSet.Builder()).SetIndexInterval(TestUtil.NextInt(Random(), 1, 20));
            for (int doc = bs.NextSetBit(0); doc != -1; doc = bs.NextSetBit(doc + 1))
            {
                builder.Add(doc);
            }
            return builder.Build();
        }

        public override void AssertEquals(int numBits, BitArray ds1, PForDeltaDocIdSet ds2)
        {
            base.AssertEquals(numBits, ds1, ds2);
            Assert.AreEqual(ds1.Cardinality(), ds2.Cardinality());
        }


        #region BaseDocIdSetTestCase<T>
        // LUCENENET NOTE: Tests in an abstract base class are not pulled into the correct
        // context in Visual Studio. This fixes that with the minimum amount of code necessary
        // to run them in the correct context without duplicating all of the tests.

        /// <summary>
        /// Test length=0.
        /// </summary>
        [Test]
        public override void TestNoBit()
        {
            base.TestNoBit();
        }

        /// <summary>
        /// Test length=1.
        /// </summary>
        [Test]
        public override void Test1Bit()
        {
            base.Test1Bit();
        }

        /// <summary>
        /// Test length=2.
        /// </summary>
        [Test]
        public override void Test2Bits()
        {
            base.Test2Bits();
        }

        /// <summary>
        /// Compare the content of the set against a <seealso cref="BitSet"/>.
        /// </summary>
        [Test]
        public override void TestAgainstBitSet()
        {
            base.TestAgainstBitSet();
        }

        #endregion
    }
}