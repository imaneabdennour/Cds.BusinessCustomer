using Cds.Foundation.Test.Pact.Provider;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Cds.TestFormationDotnetcore.Tests.Pact.Provider
{
    /// <summary>
    /// Defines the TestFormationDotnetcore provider tests
    /// </summary>
    public class TestFormationDotnetcoreProviderTests : BaseProviderTests<TestFormationDotnetcoreProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestFormationDotnetcoreProviderTests"/> class
        /// </summary>
        /// <param name="output">The Xunit output</param>
        /// <param name="provider">The provider</param>
        public TestFormationDotnetcoreProviderTests(ITestOutputHelper output, TestFormationDotnetcoreProvider provider) : base(output, provider)
        {
        }

#pragma warning disable S125
        //[Fact]
        //public Task Provider_TestFormationDotnetcore() => EnsureProviderHonoursPactAsync();
#pragma warning restore S125
    }
}
