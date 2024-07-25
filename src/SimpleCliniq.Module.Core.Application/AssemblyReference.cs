using System.Reflection;

namespace SimpleCliniq.Module.Core.Application
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
