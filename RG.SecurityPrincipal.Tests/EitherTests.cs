namespace RG.SecurityPrincipal.Tests;

public sealed record Admin : ISecurityPrincipal;
public sealed record User : ISecurityPrincipal;
public sealed record Guest : ISecurityPrincipal;

public class EitherTests {
    [Fact]
    public void Either2_ImplicitConversion_FromT1_SetsValue() {
        Admin admin = new();

        Either<Admin, User> either = admin;

        Assert.Same(admin, either.Value);
    }

    [Fact]
    public void Either2_ImplicitConversion_FromT2_SetsValue() {
        User user = new();

        Either<Admin, User> either = user;

        Assert.Same(user, either.Value);
    }

    [Fact]
    public void Either3_ImplicitConversion_FromT1_SetsValue() {
        Admin admin = new();

        Either<Admin, User, Guest> either = admin;

        Assert.Same(admin, either.Value);
    }

    [Fact]
    public void Either3_ImplicitConversion_FromT2_SetsValue() {
        User user = new();

        Either<Admin, User, Guest> either = user;

        Assert.Same(user, either.Value);
    }

    [Fact]
    public void Either3_ImplicitConversion_FromT3_SetsValue() {
        Guest guest = new();

        Either<Admin, User, Guest> either = guest;

        Assert.Same(guest, either.Value);
    }

    [Fact]
    public void Either_WithAnyone_ImplicitConversion_SetsValue() {
        Anyone anyone = SecurityPrincipal.Anyone;

        Either<Admin, Anyone> either = anyone;

        Assert.Same(anyone, either.Value);
    }

    [Fact]
    public void Either_IsSecurityPrincipal() {
        Admin admin = new();

        Either<Admin, User> either = admin;

        Assert.IsAssignableFrom<ISecurityPrincipal>(either);
    }
}
