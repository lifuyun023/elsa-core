using System.Linq;
using System.Threading.Tasks;
using Elsa.Core.IntegrationTests.Workflows;
using Elsa.Testing.Shared.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Elsa.Core.IntegrationTests
{
    public class WhileWorkflowTests : WorkflowsUnitTestBase
    {
        public WhileWorkflowTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }
        
        [Fact(DisplayName = "Runs loop while condition is true.")]
        public async Task Test01()
        {
            const int loopCount = 3;
            var workflow = new WhileWorkflow(loopCount);
            var workflowInstance = await WorkflowRunner.RunWorkflowAsync(workflow);
            var iterationLogs = workflowInstance.ExecutionLog.Where(x => x.ActivityId == "WriteLoopCount").ToList();

            Assert.Equal(loopCount, iterationLogs.Count);
        }
    }
}