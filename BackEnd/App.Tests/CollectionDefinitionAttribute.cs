using System;

namespace App.Tests
{
    internal class CollectionDefinitionAttribute : Attribute
    {
        private string v;
        private bool disableParallelization;

        public CollectionDefinitionAttribute(string v, bool DisableParallelization)
        {
            this.v = v;
            disableParallelization = DisableParallelization;
        }
    }
}
