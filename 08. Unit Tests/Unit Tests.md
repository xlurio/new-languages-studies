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

On NUnit framework, you can create a test suite by importing the NUnit.Framework namespace and declaring a class with the [TestFixture] attribute:

´´´
namespace SampleTests

using NUnit.Framework

[TestFixture]
public class Tests {
    // Test cases
}
´´´


## Test Case

On NUnit framework, you can create a test case by declaring method with the [Test] attribute inside a test suite:

´´´
[Test]
public void TestCase() {
    // Arrange
    // Act
    // Assert
}
´´´

Test cases must be public void methods with no parameters.


## Assertions

The list of possible assertions can be found at: https://docs.nunit.org/articles/nunit/writing-tests/assertions/assertion-models/classic.html.


## SetUp Method

To execute a code block before the all the tests in a test suite, you can implement a method with an [OneTimeSetUp] attribute. If you want to do it for each test, use the [SetUp] attribute.


## TearDown Method

To execute a code block after all the tests in a test suite, you can implement a method with an [OneTimeTearDown] attribute. If you want to do it for each test, use the [TearDown] attribute.


## References

MICROSOFT. <b>Unit testing C# with NUnit and .NET Core</b>. Available at: https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit.

NUNIT. <b>SetUp and TearDown</b>. Available at: https://docs.nunit.org/articles/nunit/writing-tests/setup-teardown/index.html.