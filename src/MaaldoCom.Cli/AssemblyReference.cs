using System.Reflection;

namespace MaaldoCom.Cli;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
