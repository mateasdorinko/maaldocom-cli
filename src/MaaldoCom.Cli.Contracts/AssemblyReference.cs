using System.Reflection;

namespace MaaldoCom.Cli.Contracts;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
