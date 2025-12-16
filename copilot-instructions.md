# RG.SecurityPrincipal - Copilot Maintenance Instructions

## Repository Overview

This repository provides a source-only NuGet package that implements compile-time authorization primitives for .NET applications. The key types are `ISecurityPrincipal`, `Anyone`, and `Either<T1, T2, ...>` (with overloads up to 10 type parameters).

## Package Type: Source-Only Package

**Important:** This is a **source-only NuGet package**, not a binary package. The source files are embedded directly into consuming projects rather than being distributed as a compiled DLL.

### Why Source-Only?

The `Either<T1, T2>` types are generic types that need to be instantiated with consumer-specific types. If multiple projects in a solution reference this package and also reference each other, having these types as `public` in a binary package would cause **CS0436 compiler warnings** about conflicting types.

By making this a source-only package with `internal` types, each consuming assembly gets its own copy of the types, eliminating any conflicts.

## Critical Design Decisions

### 1. All Types Must Be `internal`

**All types in this library MUST be marked as `internal`**, including:
- `ISecurityPrincipal`
- `Anyone`
- `SecurityPrincipal` (static class)
- All `Either<...>` overloads

**Rationale:** This prevents CS0436 warnings when multiple projects reference each other and both use this package.

**⚠️ DO NOT change these to `public`** - doing so will reintroduce the conflicting type warnings.

### 2. InternalsVisibleTo for Tests

The test project `RG.SecurityPrincipal.Tests` needs access to internal types. This is configured in `AssemblyInfo.cs`:

```csharp
[assembly: InternalsVisibleTo("RG.SecurityPrincipal.Tests")]
```

### 3. Project Configuration

The `.csproj` file has specific settings for source-only packaging:

```xml
<!-- Source-only package configuration -->
<IncludeBuildOutput>false</IncludeBuildOutput>
<DevelopmentDependency>true</DevelopmentDependency>
<ContentTargetFolders>contentFiles</ContentTargetFolders>
<NoWarn>$(NoWarn);NU5128</NoWarn>
```

**Do not remove these settings** or the package will revert to being a binary package.

## Build and Test

### Building the Solution

```bash
dotnet build
```

This will:
1. Compile the library (for local testing)
2. Compile the test project
3. Create the NuGet package with source files

### Running Tests

```bash
dotnet test
```

All 7 tests should pass. These tests verify:
- Implicit conversions work correctly for all `Either` overloads
- Type assignments work as expected
- `Anyone` singleton works correctly

### Creating the NuGet Package

The package is created automatically during build due to `<GeneratePackageOnBuild>True</GeneratePackageOnBuild>`.

To manually pack:

```bash
dotnet pack -c Release -o ./nupkg
```

### Verifying Package Contents

After packing, verify the package contains source files (not a DLL):

```bash
unzip -l ./nupkg/RG.SecurityPrincipal.*.nupkg | grep -E "\.(cs|dll)$"
```

You should see `.cs` files in `contentFiles/cs/any/` and `content/cs/any/`, but **no `.dll` files**.

## Adding New Either Overloads

If you need to add support for more type parameters (e.g., `Either<T1, ..., T11>`):

1. Add the new class to `Either.cs` following the existing pattern
2. **IMPORTANT:** Mark it as `internal sealed class`
3. Implement the implicit conversion operators for each type parameter
4. Add corresponding tests in `EitherTests.cs`

Example template:

```csharp
internal sealed class Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : ISecurityPrincipal
    where T1 : ISecurityPrincipal
    where T2 : ISecurityPrincipal
    // ... add constraints for all type parameters
{
    public ISecurityPrincipal Value { get; }

    private Either(ISecurityPrincipal value) {
        Value = value;
    }

    public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 value) => new(value);
    public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T2 value) => new(value);
    // ... add operators for all type parameters
}
```

## Common Mistakes to Avoid

### ❌ DO NOT: Make Types Public

```csharp
// WRONG - This will cause CS0436 warnings
public sealed class Either<T1, T2> : ISecurityPrincipal
```

### ✅ DO: Keep Types Internal

```csharp
// CORRECT
internal sealed class Either<T1, T2> : ISecurityPrincipal
```

### ❌ DO NOT: Remove IncludeBuildOutput=false

Removing `<IncludeBuildOutput>false</IncludeBuildOutput>` will make this a binary package again, which defeats the purpose of the fix.

### ❌ DO NOT: Remove Content Include

The `<Content Include="*.cs" ...>` section is critical for including source files in the package.

## Preventing Warning Resurgence

To prevent CS0436 warnings from coming back:

1. **Always use `internal` for all types in this library**
2. **Keep the source-only package configuration in the `.csproj`**
3. **Test with multi-project scenarios** where Project A and Project B both reference this package and reference each other
4. **Verify package contents** after any changes to ensure it still contains `.cs` files and not `.dll` files

## Testing for Regressions

To test that the fix is still working:

```bash
# Create two test projects that both embed the source
mkdir -p /tmp/test-conflict/{ProjectA,ProjectB}

# ProjectA references RG.SecurityPrincipal
# ProjectB references both RG.SecurityPrincipal and ProjectA

# Both projects use Either<T1, T2>
# Build should complete with 0 warnings
```

If you see CS0436 warnings, the fix has been broken and types need to be made `internal` again.

## Version Updates

When updating the package version:

1. Update `<Version>` in `RG.SecurityPrincipal.csproj`
2. Build and test
3. Verify package contents (should still be source files)
4. Tag the release in git

## Questions or Issues?

If you encounter issues or have questions about this design:

1. Review this document first
2. Check the git history for the "Fix conflicting Either types" commit
3. Review the issue discussion about conflicting Either types

## Summary

This repository implements a **source-only NuGet package** pattern to avoid type conflicts. The key is keeping all types `internal` and distributing source files instead of compiled assemblies. Never change types to `public` or remove the source-only packaging configuration.
