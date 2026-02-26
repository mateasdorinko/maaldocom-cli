using System.Reflection;

namespace MaaldoCom.Cli.Domain;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
