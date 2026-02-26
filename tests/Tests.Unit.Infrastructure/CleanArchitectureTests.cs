using NetArchTest.Rules;

namespace Tests.Unit.Infrastructure;

public class UnitTest1
{
    [Fact]
    public void DomainLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    {
        var result = Types.InAssembly(MaaldoCom.Cli.Domain.AssemblyReference.Assembly)
            .Should()
            .NotHaveDependencyOn(MaaldoCom.Cli.Infrastructure.AssemblyReference.Assembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.ShouldBeTrue();
    }

    [Fact]
    public void ApplicationLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    {
        var result = Types.InAssembly(MaaldoCom.Cli.Contracts.AssemblyReference.Assembly)
            .Should()
            .NotHaveDependencyOn(MaaldoCom.Cli.Infrastructure.AssemblyReference.Assembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.ShouldBeTrue();
    }
}
