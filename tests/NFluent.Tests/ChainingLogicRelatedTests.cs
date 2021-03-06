﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChainingLogicRelatedTests.cs" company="">
//   Copyright 2013 Cyrille DUPUYDAUBY, Thomas PIERRAIN
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//       http://www.apache.org/licenses/LICENSE-2.0
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace NFluent.Tests
{
    using NUnit.Framework;

    public class ChainingLogicRelatedTests
    {
        [Test]
        public void ShouldFailWhenNoAssertGiven()
        {
            Check.That(2).IsStrictlyPositive();
            //Check.ThatCode(() => Check.That(3).IsNotZero()).ThrowsAny();
        }
    }
}
