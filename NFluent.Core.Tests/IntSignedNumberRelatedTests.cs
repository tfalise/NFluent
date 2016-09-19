﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IntSignedNumberRelatedTests.cs" company="">
// //   Copyright 2013 Thomas PIERRAIN
// //   Licensed under the Apache License, Version 2.0 (the "License");
// //   you may not use this file except in compliance with the License.
// //   You may obtain a copy of the License at
// //       http://www.apache.org/licenses/LICENSE-2.0
// //   Unless required by applicable law or agreed to in writing, software
// //   distributed under the License is distributed on an "AS IS" BASIS,
// //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// //   See the License for the specific language governing permissions and
// //   limitations under the License.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------
namespace NFluent.Tests
{
    using System.Globalization;
    using System.Threading;

    using NUnit.Framework;

    [TestFixture]
    [Culture("fr-FR")]
    public class IntSignedNumberRelatedTests
    {
        private const string DoNotChangeOrRemoveThisLine = Constants.AutoGeneratedNumberClassDisclaimerPlaceHolder;

        // Since this class is the model/template for the generation of the tests on all the other numbers types, don't forget to re-generate all the other classes every time you change this one. To do that, just save the .\T4\NumberTestsGenerator.tt file within Visual Studio 2012. This will trigger the T4 code generation process.
        #region IsPositive (obsolete)

        [Test]
        public void IsPositiveWorks()
        {
            const int Two = 2;

            Check.That(Two).IsPositive();
        }

        [Test]
        public void IsPositiveThrowsExceptionWhenEqualToZero()
        {
            const int Zero = 0;

            Check.ThatCode(() =>
            {
                Check.That(Zero).IsPositive();
            })
            .Throws<FluentCheckException>()
            .WithMessage("\nThe checked value is not strictly positive (i.e. greater than zero).\nThe checked value:\n\t[0]");
        }

        [Test]
        public void NotIsPositiveThrowsExceptionWhenFailing()
        {
            const int Two = 2;

            Check.ThatCode(() =>
            {
                Check.That(Two).Not.IsPositive();
            })
            .Throws<FluentCheckException>()
            .WithMessage("\nThe checked value is strictly positive (i.e. greater than zero), whereas it must not.\nThe checked value:\n\t[2]");
        }

        [Test]
        public void IsPositiveThrowsExceptionWhenValueIsNegative()
        {
            const int MinusFifty = -50;

            Check.ThatCode(() =>
            {
                Check.That(MinusFifty).IsPositive();
            })
            .Throws<FluentCheckException>()
            .WithMessage("\nThe checked value is not strictly positive (i.e. greater than zero).\nThe checked value:\n\t[-50]");
        }

        [Test]
        public void NotIsPositiveWorks()
        {
            const int MinusFifty = -50;

            Check.That(MinusFifty).Not.IsPositive();
        }

        #endregion

        #region IsStrictlyPositive

        [Test]
        public void IsStrictlyPositiveWorks()
        {
            const int Two = 2;

            Check.That(Two).IsStrictlyPositive();
        }

        [Test]
        public void IsStrictlyPositiveThrowsExceptionWhenEqualToZero()
        {
            const int Zero = 0;

            Check.ThatCode(() =>
            {
                Check.That(Zero).IsStrictlyPositive();
            })
            .Throws<FluentCheckException>()
            .WithMessage("\nThe checked value is not strictly positive (i.e. greater than zero).\nThe checked value:\n\t[0]");
        }

        [Test]
        public void NotIsStrictlyPositiveThrowsExceptionWhenFailing()
        {
            const int Two = 2;

            Check.ThatCode(() =>
            {
                Check.That(Two).Not.IsStrictlyPositive();
            })
            .Throws<FluentCheckException>()
            .WithMessage("\nThe checked value is strictly positive (i.e. greater than zero), whereas it must not.\nThe checked value:\n\t[2]");
        }

        [Test]
        public void IsStrictlyPositiveThrowsExceptionWhenValueIsNegative()
        {
            const int MinusFifty = -50;

            Check.ThatCode(() =>
            {
                Check.That(MinusFifty).IsStrictlyPositive();
            })
            .Throws<FluentCheckException>()
            .WithMessage("\nThe checked value is not strictly positive (i.e. greater than zero).\nThe checked value:\n\t[-50]");
        }

        [Test]
        public void NotIsStrictlyPositiveWorks()
        {
            const int MinusFifty = -50;

            Check.That(MinusFifty).Not.IsStrictlyPositive();
        }

        #endregion

        #region IsPositiveOrZero

        [Test]
        public void IsPositiveOrZeroWorks()
        {
            const int Zero = 0;
            const int Two = 2;

            Check.That(Zero).IsPositiveOrZero();
            Check.That(Two).IsPositiveOrZero();
        }

        [Test]
        public void NotIsPositiveOrZeroThrowsExceptionWhenFailing()
        {
            const int Zero = 0;

            Check.ThatCode(() =>
            {
                Check.That(Zero).Not.IsPositiveOrZero();
            })
            .Throws<FluentCheckException>()
            .WithMessage("\nThe checked value is positive or equal to zero, whereas it must not.\nThe checked value:\n\t[0]");
        }

        [Test]
        public void IsPositiveOrZeroThrowsExceptionWhenValueIsNegative()
        {
            const int MinusFifty = -50;

            Check.ThatCode(() =>
            {
                Check.That(MinusFifty).IsPositiveOrZero();
            })
            .Throws<FluentCheckException>()
            .WithMessage("\nThe checked value is not positive or equal to zero.\nThe checked value:\n\t[-50]");
        }

        [Test]
        public void NotIsPositiveOrZeroWorks()
        {
            const int MinusFifty = -50;

            Check.That(MinusFifty).Not.IsPositiveOrZero();
        }

        #endregion

        #region IsNegative (obsolete)

        [Test]
        public void IsNegativeWorks()
        {
            const int MinusFifty = -50;

            Check.That(MinusFifty).IsNegative();
        }

        [Test]
        public void IsNegativeThrowsExceptionWhenEqualToZero()
        {
            const int Zero = 0;

            Check.ThatCode(() =>
            {
                Check.That(Zero).IsNegative();
            })
            .Throws<FluentCheckException>()
            .WithMessage("\nThe checked value is not strictly negative.\nThe checked value:\n\t[0]");
        }

        [Test]
        public void NotIsNegativeThrowsExceptionWhenFailing()
        {
            const int MinusFifty = -50;

            Check.ThatCode(() =>
            {
                Check.That(MinusFifty).Not.IsNegative();
            })
            .Throws<FluentCheckException>()
            .WithMessage("\nThe checked value is strictly negative, whereas it must not.\nThe checked value:\n\t[-50]");
        }

        [Test]
        public void IsNegativeThrowsExceptionWhenValueIsPositive()
        {
            const int Two = 2;

            Check.ThatCode(() =>
            {
                Check.That(Two).IsNegative();
            })
            .Throws<FluentCheckException>()
            .WithMessage("\nThe checked value is not strictly negative.\nThe checked value:\n\t[2]");
        }

        [Test]
        public void NotIsNegativeWorks()
        {
            const int Two = 2;

            Check.That(Two).Not.IsNegative();
        }

        #endregion

        #region IsStrictlyNegative

        [Test]
        public void IsStrictyNegativeWorks()
        {
            const int MinusFifty = -50;

            Check.That(MinusFifty).IsStrictlyNegative();
        }

        [Test]
        public void IsStrictyNegativeThrowsExceptionWhenEqualToZero()
        {
            const int Zero = 0;
            
            Check.ThatCode(() =>
            {
                Check.That(Zero).IsStrictlyNegative();
            })
            .Throws<FluentCheckException>()
            .WithMessage("\nThe checked value is not strictly negative.\nThe checked value:\n\t[0]");
        }

        [Test]
        public void NotIsStrictyNegativeThrowsExceptionWhenFailing()
        {
            const int MinusFifty = -50;

            Check.ThatCode(() =>
            {
                Check.That(MinusFifty).Not.IsStrictlyNegative();
            })
            .Throws<FluentCheckException>()
            .WithMessage("\nThe checked value is strictly negative, whereas it must not.\nThe checked value:\n\t[-50]");
        }

        [Test]
        public void IsStrictyNegativeThrowsExceptionWhenValueIsPositive()
        {
            const int Two = 2;

            Check.ThatCode(() =>
            {
                Check.That(Two).IsStrictlyNegative();
            })
            .Throws<FluentCheckException>()
            .WithMessage("\nThe checked value is not strictly negative.\nThe checked value:\n\t[2]");
        }

        [Test]
        public void NotIsStrictyNegativeWorks()
        {
            const int Two = 2;

            Check.That(Two).Not.IsStrictlyNegative();
        }

        #endregion
        
        #region IsNegativeOrZero

        [Test]
        public void IsNegativeOrZeroWorks()
        {
            const int MinusFifty = -50;
            const int Zero = 0;

            Check.That(Zero).IsNegativeOrZero();
            Check.That(MinusFifty).IsNegativeOrZero();
        }

        [Test]
        public void NotIsNegativeOrZeroThrowsExceptionWhenFailing()
        {
            const int MinusFifty = -50;

            Check.ThatCode(() =>
            {
                Check.That(MinusFifty).Not.IsNegativeOrZero();
            })
            .Throws<FluentCheckException>()
            .WithMessage("\nThe checked value is negative or equal to zero, whereas it must not.\nThe checked value:\n\t[-50]");
        }

        [Test]
        public void IsIsNegativeOrZeroThrowsExceptionWhenValueIsPositive()
        {
            const int Two = 2;

            Check.ThatCode(() =>
            {
                Check.That(Two).IsNegativeOrZero();
            })
            .Throws<FluentCheckException>()
            .WithMessage("\nThe checked value is not negative or equal to zero.\nThe checked value:\n\t[2]");
        }

        [Test]
        public void NotIsNegativeOrZeroWorks()
        {
            const int Two = 2;

            Check.That(Two).Not.IsNegativeOrZero();
        }

        #endregion
    }
}
