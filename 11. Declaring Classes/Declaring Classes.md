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
}
´´´


### Auto Implemented Properties

https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties


## Methods

https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods


## Interfaces

https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces


## Abstract and Sealed Classes and Class Members

https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members