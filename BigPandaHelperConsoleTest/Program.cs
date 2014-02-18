using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigPandaHelper;

namespace BigPandaHelperConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var bgd = new BigPandaDeployments("PLACE_YOUR_AUTHORIZATION_TOKEN_HERE");
            
            // Call when you start a deployment
            bgd.Start("Component1","1.0.0.2", new String[] {"PandaVM1", "PandaVM2"}, "PandaBoy", "PandaDeployingSystem");

            // Call when you end a deployment successfully
            bgd.End("Component1", "1.0.0.2", new String[] { "PandaVM1", "PandaVM2" }, "PandaBoy", "PandaDeployingSystem", BigPandaDeployments.Status.Success, null);

            // Call when deployment failed
            bgd.End("Component1", "1.0.0.2", new String[] { "PandaVM1", "PandaVM2" }, "PandaBoy", "PandaDeployingSystem", BigPandaDeployments.Status.Failure, "There was an error during the deployment");
        }
    }
}
