using NetArchTest.Rules;

namespace Tests.Unit.Cli;

public class CleanArchitectureTests
{
    [Fact]
    public void DomainLayer_ShouldNotHaveDependencyOn_CliLayer()
    {
        var result = Types.InAssembly(MaaldoCom.Cli.Domain.AssemblyReference.Assembly)
            .Should()
            .NotHaveDependencyOn(MaaldoCom.Cli.AssemblyReference.Assembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.ShouldBeTrue();
    }

    [Fact]
    public void ApplicationLayer_ShouldNotHaveDependencyOn_CliLayer()
    {
        var result = Types.InAssembly(MaaldoCom.Cli.Contracts.AssemblyReference.Assembly)
            .Should()
            .NotHaveDependencyOn(MaaldoCom.Cli.AssemblyReference.Assembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.ShouldBeTrue();
    }

    [Fact]
    public void InfrastructureLayer_ShouldNotHaveDependencyOn_CliLayer()
    {
        var result = Types.InAssembly(MaaldoCom.Cli.Infrastructure.AssemblyReference.Assembly)
            .Should()
            .NotHaveDependencyOn(MaaldoCom.Cli.AssemblyReference.Assembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.ShouldBeTrue();
    }
}
