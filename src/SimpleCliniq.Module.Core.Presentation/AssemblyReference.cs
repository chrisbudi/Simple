using System.Reflection;

namespace SimpleCliniq.Module.Core.Presentation;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}