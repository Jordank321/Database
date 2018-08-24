using System.Threading.Tasks;

namespace Database.Data.Example
{
    public class ExampleContext : ContextBase
    {
        public ExampleContext(string baseDirectory) : base(baseDirectory)
        {
        }

        public override Task Initialise()
        {
            throw new System.NotImplementedException();
        }
    }
}