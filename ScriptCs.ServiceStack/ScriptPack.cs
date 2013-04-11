using System.Collections.Generic;

using ScriptCs.Contracts;

namespace ScriptCs.ServiceStack
{
    public class ScriptPack : IScriptPack
    {
        public void Initialize(IScriptPackSession session)
        {
            var namespaces = new List<string>
            {
                "ServiceStack.ServiceHost", 
                "ServiceStack.ServiceInterface"
            };

            namespaces.ForEach(session.ImportNamespace);
        }

        public IScriptPackContext GetContext()
        {
            return new ServiceStackPack();
        }

        public void Terminate() { }
    }
}