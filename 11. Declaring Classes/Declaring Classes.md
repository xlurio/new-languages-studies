# Declaring Classes

## Introduction

This is where are the class declaration studies. Classes represents the implementation of a object, containing fields, properties and methods to store, manipulate and retrieve the data owned by it.


## Declaring Classes

To declare a class you can you use the following structure:

´´´
access_modifier class ClassName {
    // Fields, properties and methods
}
´´´

Example:

´´´
public class SampleClass {
    public void SayHello() {
        Console.WriteLine("Hello!");
    }
}
´´´


## Creating Objects

To create an instance of class you can use the following structure:

´´´
TypeName objectName = new ClassName();
´´´


Example:

´´´
SampleClass sampleObject = new SampleClass();
´´´


## Class Inheritance

To inherit a class from another you can you the colon after the class name on the implementation:

´´´
class ClassName : ClassFather
{
    // Fields, properties and methods
}
´´´


## Class Conctructor

The class constructor is a method called every time a object is create, being its parameters passed during the object creation:

´´´
class ClassName {
    public ClassName (ParameterType constructorParameter) {
        // Code to execute on object creation
    }
}
´´´

´´´
ClassName objectName = new ClassName(constructorParameterValue);
´´´


### Static Constructor

You can also declare a static constructor. The static constructor takes no parameters and can be used to initialize static fields:

´´´
class ClassName {
    private static FieldType fieldName;

    static ClassName {
        fieldName = fieldValue;
    }
}
´´´


The static constructor can also be defined with a expression body:

´´´
class ClassName {
    private static FieldType fieldName;

    static ClassName() => fieldName = fieldValue;
}
´´´


## Fields

A field is a variable that can accept member modifiers.


## Properties

A property is a member that provides a flexible mechanism to read, write or compute the value of a private field. This enables data to easily accessed and promote the safety and flexibility of methods.

The get property accessor is used to return the property value, and the set property accessor is used to assign a new value. In C# 9 and later, init property accessor is used to assign a new value only during object construction.

The value keyword is used to define the value being assign by the set or init accessor.

Properties can be read-write (they have both get and a set accessor), read-only (they have a get accessor but no set accessor) or write-only (they have a set accessor but no get accessor).


### Properties With Backing Fields

One basic patter for implementing properties is to use a backing field to retrieve and set the property values:

´´´
using System;

class TimePeriod
{
    private double _seconds;

    public double Hours
    {
        get { return _seconds / 3600 }
        set {
                if (value < 0 || value > 24) {
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} must be between 0 and 24"
                    );
                
                _seconds = value * 3600;
            }
        }
    }
}
´´´


### Expression Body Definitions

Property accessors often consist of single-line expressions:

´´´
using System;

public class Person
{
    private string _firstName;
    private string _lastName;

    public Person (string firstName, string lastName) {
        _firstName = firstName;
        _lastName = lastName;
    }

    public string Name => $"";
}
´´´


### Auto Implemented Properties

For properties that only assign and retrieve values from a backing field, without including any additional logic, you can simply do a auto implemented property:

´´´
using System;

public class SaleItem
{
    public string Name { get; set; }
    public float Price { get; set; }
}
´´´


## Methods

Methods are declared in a class, struct or interface by specifying a access level such as public or private, optional modifiers as abstract or sealed, the return value, the name of the method and any parameters. 

The method parameters are enclosed by parenthesis and separated by commas. Empty parenthesis indicate that the method requires no parameters. This class contains four methods:

´´´
abstract class Motorcycle
{
    // Anyone can call
    public void StartEngine() {
        // Code 
    }

    // Only derived classes can call
    protected void AddGas(int gallons) {
        // Code
    }

    // Derived classes can override
    public virtual int Drive(int miles, int int speed) {
        // Code
    }

    // Derived classes must implement
    public abstract double GetTopSpeed();
}
´´´


## Method access

Method are like fields. To access them, you can write its name after the object's name, separated by a dot. To actually call the method, you need to add parethesis after its name and write the parameters between it:

´´´
using System;

public class TestMotorcycle : Motorcycle
{
    public override double GetTopSpeed() {
        return 108.4;
    }
}

public class Program
{
    public static void Main(string[] args) {
        TestMotorcycle moto = new TestMotorcycle();
        moto.AddGas(15);
        moto.Drive(5, 10);
        double speed = moto.GetTopSpeed();
        Console.WriteLine("My top speed is {0}", speed);

        // Output: My top speed is 108.4
    }
}
´´´

### Return Values

When the return type of the method is not void, it can return values using the return statement:

´´´
public static int SumIntegers(int firstNumber, int secondNumber) {
    return firstNumber + secondNumber;
}
´´´


You can also return a value by reference, that is, instead of returning the value of an object, you can return a reference to its location in memory:

´´´
public ref double GetEstimatedDistance() {
    return ref estDistance;
}
´´´


To use that reference, you can store it to a ref local variable:

´´´
ref double distance = SampleObject.GetEstimatedDistance();
´´´


### Async Methods

By using the async feature, you invoke asynchronous methods without using explicit callbacks or manually splitting your code across multiple methods or lambda expressions. To implement it, all you need is to add the <strong>async</strong> modifier.

A asynchronous method allows you to use the <strong>await</strong> operator in its body. When the control reaches an await expression, control returns to the caller and progress in the method is suspended until the awaited task completes.

An async method typically has a return type of Task&lt;TResult&gt;, Task, IAsyncEnumerable&lt;T&gt; or void. When the return type is void, the return statement is required and the caller can not catch exceptions that the method throws.

An async method can't declare any ref or out parameters, but it can call methods that have such parameters.

The Main method is an example of asynchronous method that has return type Task. It goes to the DoSomethingAsync method, and because it is written in a single line, it can omit the async and await keywords. Because DoSomethingAsync method is async, its call must be awaited:

´´´
class Program
{
    static Task Main() =>  DoSomethingAsync();
    // Output: Result: 5

    static async Task DoSomethingAsync()
    {
        int result = await DelayAsync();
        Console.WriteLine($"Result: {result}");
    }

    static async Task<int> DelayAsync()
    {
        await Task.Delay(100);
        return 5;
    }
}
´´´


### Expression Body Definitions

For methods that have a single statement only, you can use expression body definitions using "=>":

´´´
public string Name => $"{firstName} {lastName}";
´´´


### Iterators

To indicate that a method, operator, or get accessor is an iterator you can use the yield contextual keyword in a statement (return for example). 

Using yield return the method will return each element one at a time.

The sequence returned from an iterator method can be consument by using a foreach statement or LINQ query.

When the iterator returns an IAsyncEnumerable, that sequence can be consumed asyschronously using an await foreach statement.

You can use yield break statement to end the iteration.

The declaration of an iterator must meet the following requirements:

<ol>
    <li>The return type must be one of the following types:</li>
    <ul>
        <li>IAsyncEnumerable&lt;T&gt;</li>
        <li>IEnumerable&lt;T&gt;</li>
        <li>IEnumerable</li>
        <li>IEnumerator&lt;T&gt;</li>
        <li>IEnumerator</li>
    </ul>
    <li>The declaration can't have any in, ref or out parameters</li>
</ol>

The yield type of an iterator that returns IEnumerable or IEnumerator is <strong>object</strong>. If the iterator returns IEnumerable&lt;T&gt; or IEnumerator&lt;T&gt;, there must be an implicit conversion from the type of the expression in the yield return statement to the generic type parameter.

You can't include yield in lambda expressions, async methods or methods that contain unsafe blocks.

### Static Members

Members with the <strong>static</strong> modifier can be accessed outside the class or struct without the need of an instance of that class.


## Access Modifiers

### Public

Members with the <strong>public</strong> access level can be accessed from anywhere.


### Protected

Members with the <strong>protected</strong> access level can only be accessed inside its class or struct or the classes that derived from that class.


### Private

Members with the <strong>private</strong> access level can only be accessed inside its class or struct.


### Internal

Members with the <strong>internal</strong> access level can only be accessed inside its assembly;


### Protected Internal

Members with the <strong>internal</strong> access level can only be accessed inside its assembly or derived classes from its assembly.


### Private Protected

Members with the <strong>internal</strong> access level can only be accessed inside its assembly or derived classes inside its assembly.


## Members modifiers

### Abstract

INdicates that the thing being modified has missing or incomplete implementation. Use the abstract modifier in a class declaration to indicate that a class is intended only to be a base class of other classes, not instatiated on its own. Members marked as abstract must be implemented by concrete classes that derive from the abstract class.


### Override

Required to extend or modify the abstract or virtual implementation of an inherited method, property, indexer, or event.


### Sealed

When applied to a class, prevents other classes from inheriting from it. When used on a method or property that overrides a virtual or property in a base class allow the classes to derive from your class and prevent them from overriding specific virtual methods or properties.


### Virtual

Used to modify a method, property, indexer, or event declaration and allow for it to be overriden in a derived class.


## Interfaces

Contains definitions for a group of related functionalities that a concrete class or a struct must implement. May define static methods, which must have an implementation. May define a default implementation for members. May not declare instance data such as fields, auto-implemented properties or property-like events.

Important for implementing behavior from multiple sources, since C# does not support multiple inheritance of classes. Also can work as inheritance for structs.

´´´
    interface IEquatable&lt;T&gt;
    {
        bool Equals(T obj);
    }
´´´


## Structure Types

Value type that can encapsulate data and related functionality:

´´´
public struct Coords
{
    public Coords(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; }
    public double Y { get; }

    public override string ToString() => $"({X}, {Y})"
}
´´´

Because structs have value semantics, it's recommended to define immutable structure types.