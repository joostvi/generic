namespace GenericNSubstituteTestHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NSubstitute;
    using Xunit;

    public static class NSubstituteExtensions
    {
        /// <summary>
        /// Simple verification no calls are done to the NSubstitute test object then the expected
        /// </summary>
        /// <typeparam name="T">Object type. Must be of type off class.</typeparam>
        /// <param name="mock">The mocked object</param>
        /// <param name="expected">The list names of expected method calls</param>
        /// <exception cref="XUnit.Sdk.EqualException">Thrown when the objects are not equal</exception>
        public static void VerifyNoOtherCalls<T>(this T mock, HashSet<string> expected) where T : class
        {
            var receivedCalls = mock.ReceivedCalls();
            var methods = receivedCalls.Select(a => a.GetMethodInfo().Name).ToHashSet();
            Assert.Equal(expected, methods);

        }

        /// <summary>
        /// Simple verification no calls are done to the NSubstitute test object
        /// </summary>
        /// <typeparam name="T">Object type. Must be of type off class.</typeparam>
        /// <param name="mock">The mocked object</param>
        /// <exception cref="XUnit.Sdk.EmptyException">Thrown when there are calls done</exception>
        public static void VerifyNoCalls<T>(this T mock) where T : class
        {
            var receivedCalls = mock.ReceivedCalls();
            Assert.Empty(receivedCalls);
        }
    }
}
