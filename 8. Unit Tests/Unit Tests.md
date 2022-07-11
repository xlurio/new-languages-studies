# Unit Tests

## Introduction

This is where are the unit tests studies.


## Solutions File

A solution file ornanize different projects into one solution, allowing you to reference namespace from a project to another, as well as sharing states between them.

You can create a solution by running the following command in the solution folder:

´´´
dotnet new sln
´´´

To add link projects to a solution you can run the following:

´´´
dotnet sln add {path to the project file}
´´´


## Adding Other Projects As Dependency

You can also add another project as dependency of the current project with the following command:

´´´
dotnet add reference {path to the project file}
´´´


## Test Suite

On NUnit framework, you can create a test suite by importing the NUnit.Framework namespace and declaring a class with the [TestFixture] decorator:

´´´
namespace SampleTests

using NUnit.Framework

[TestFixture]
public class Tests {
    // Test cases
}
´´´


## Test Case

On NUnit framework, you can create a test case by declaring method with the [Test] decorator inside a test suite:

´´´
[Test]
public void TestCase() {
    // Arrange
    // Act
    // Assert
}
´´´


## Assertions

The list of possible assertions can be found at: https://docs.nunit.org/articles/nunit/writing-tests/assertions/assertion-models/classic.html.


## SetUp Method


## TearDown Method


## References

MICROSOFT. <b>Teste de unidade em C# com NUnit e .NET Core</b>. Available on: https://docs.microsoft.com/pt-br/dotnet/core/testing/unit-testing-with-nunit.