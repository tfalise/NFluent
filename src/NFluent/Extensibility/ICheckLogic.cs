﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ICheckLogic.cs" company="NFluent">
//   Copyright 2018 Cyrille DUPUYDAUBY
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

namespace NFluent.Extensibility
{
    using System.Collections;
    using System.Collections.Generic;
#if !DOTNET_35 && !DOTNET_20 && !DOTNET_30
    using System;
#endif
    /// <summary>
    /// Options for message generation.
    /// </summary>
    [System.Flags]
    public enum MessageOption
    {
        /// <summary>
        /// No specific option
        /// </summary>
        None = 0,
        /// <summary>
        /// Removes the description block for the checked value or sut
        /// </summary>
        NoCheckedBlock = 1,
        /// <summary>
        /// Removes the description block for the expected value(s)
        /// </summary>
        NoExpectedBlock = 2,
        /// <summary>
        /// Forces the sut type
        /// </summary>
        ForceType = 4,
        /// <summary>
        /// Add type info
        /// </summary>
        WithType = 8,
        /// <summary>
        /// Add hash for values
        /// </summary>
        WithHash = 16
    }

    /// <summary>
    /// Minimal interface
    /// </summary>
    public interface ICheckLogicBase
    {
        /// <summary>
        ///     Ends check.
        /// </summary>
        /// <remarks>At this point, exception is thrown.</remarks>
        /// <returns>true if succesfull</returns>
        void EndCheck();

        /// <summary>
        /// Gets the failed status.
        /// </summary>
        bool Failed { get; }
    }

    /// <summary>
    /// Provides method to ease coding of checks.
    /// </summary>
    public interface ICheckLogic<out T> : ICheckLogicBase
    {
        /// <summary>
        /// true if testing logic must be inverted
        /// </summary>
        bool IsNegated { get; }

        /// <summary>
        /// Generate an error message stating that this check cannot be used with <see cref="INegateableCheck{T}.Not"/>
        /// </summary>
        /// <param name="checkName">name of the source check</param>
        /// <returns>Continuation object.</returns>
        ICheckLogic<T> CantBeNegated(string checkName);

        /// <summary>
        /// Fails the check if the checked value is null,
        /// </summary>
        /// <param name="error">Error message</param>
        /// <returns>Continuation object.</returns>
        ICheckLogic<T> FailIfNull(string error = "The {0} is null.");

        /// <summary>
        /// Explicitly fails
        /// </summary>
        /// <param name="error">error message</param>
        /// <param name="options">options</param>
        /// <returns>Continuation object</returns>
        ICheckLogic<T> Fail(string error, MessageOption options = MessageOption.None);

        /// <summary>
        /// Specify expected value.
        /// </summary>
        /// <param name="other"></param>
        /// <param name="comparison"></param>
        /// <param name="negatedComparison"></param>
        /// <returns>Continuation object.</returns>
        ICheckLogic<T> DefineExpectedValue<TU>(TU other, string comparison = null, string negatedComparison = "different from");

        /// <summary>
        /// Specify the expected results, with full control on error labels.
        /// </summary>
        /// <typeparam name="TU">Expected result type.</typeparam>
        /// <param name="resultValue">Expected result</param>
        /// <param name="labelForExpected">Label for expected result</param>
        /// <param name="negationForExpected">Label for result when check is negated</param>
        /// <returns>Continuation object.</returns>
        ICheckLogic<T> DefineExpectedResult<TU>(TU resultValue, string labelForExpected, string negationForExpected = "different from");

        /// <summary>
        /// Specify that we expect a list of valies
        /// </summary>
        /// <param name="values">enumeration of values</param>
        /// <param name="count">number of items</param>
        /// <param name="comparison"></param>
        /// <param name="negatedComparison"></param>
        /// <returns>Continuation object</returns>
        ICheckLogic<T> DefineExpectedValues(IEnumerable values, long count, string comparison = null, string negatedComparison = "different from");

        /// <summary>
        /// Specify that we expect a list of valies
        /// </summary>
        /// <param name="values">enumeration of values</param>
        /// <param name="comparison"></param>
        /// <param name="negatedComparison"></param>
        /// <typeparam name="U">Type of values in the list.</typeparam>
        /// <returns>Continuation object</returns>
        ICheckLogic<T> DefinePossibleValues<U>(IEnumerable<U> values, string comparison = "one of", string negatedComparison = "none of");

        /// <summary>
        /// Specify that the expectation is an instance of some type
        /// </summary>
        /// <param name="expectedInstanceType">expected type</param>
        /// <returns>Continuation object</returns>
        ICheckLogic<T> DefineExpectedType(System.Type expectedInstanceType);

        /// <summary>
        /// Failing condition on check negation.
        /// </summary>
        /// <param name="predicate">Predicate, returns true if test fails.</param>
        /// <param name="error">Error message on failure</param>
        /// <param name="options">Options to use on parts of the message</param>
        /// <returns>Continuation object.</returns>
        ICheckLogic<T> OnNegateWhen(Func<T, bool> predicate, string error, MessageOption options = MessageOption.None);

        /// <summary>
        /// Executes arbitrary code on the sut.
        /// </summary>
        /// <param name="action">Code to be executed</param>
        /// <returns>Continuation object.</returns>
        ICheckLogic<T> Analyze(Action<T, ICheckLogic<T>> action);

        /// <summary>
        /// Set the name for the observed system.
        /// </summary>
        /// <param name="name">Name to use</param>
        /// <returns>Continuation object</returns>
        ICheckLogic<T> SetSutName(string name);

        /// <summary>
        /// Change the value of the sut.
        /// </summary>
        /// <param name="sutExtractor">new sut  object.</param>
        /// <param name="sutLabel">new label</param>
        /// <returns>Continuation object</returns>
        ICheckLogic<TU> CheckSutAttributes<TU>(Func<T, TU> sutExtractor, string sutLabel);

        /// <summary>
        /// Set index of interest
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Continuation object</returns>
        ICheckLogic<T> SetValuesIndex(long index);

        /// <summary>
        /// Set values to be given.
        /// </summary>
        /// <typeparam name="TU">Type of reference values</typeparam>
        /// <param name="other"></param>
        /// <param name="comparisonInfo"></param>
        /// <param name="negatedComparisonInfo"></param>
        /// <returns></returns>
        ICheckLogic<T> ComparingTo<TU>(TU other, string comparisonInfo, string negatedComparisonInfo);
    }
}