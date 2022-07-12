# Strings

## Introduction

This is where are the strings studies. The string in C# is the implementation of a collection of System.Char values.


## String objects

To declare a string object in C# you can use:

´´´
string greeting = "Hello";
´´´


## Concatenation

To concatenate two strings in C# you can use the plus sign:

´´´
Console.WriteLine("Hello " + "world!");
// Output: Hello world!
´´´

Or the Concat() method:

´´´
Console.WriteLine(string.Concat("Hello ", "world!"));
// Output: Hello world!
´´´


## Interpolation

To interpolate strings in C# you cas use the dollar sign ($) before the doublequotes:

´´´
string hello = "Hello"
string world = "world"
Console.WriteLine($"{hello} {world}!");
// Output: Hello world!
´´´


## Indexing

To access a specific character in a string you can pass the index of the character after the a string object between brackets:

´´´
string hello = "Hello"
Console.WriteLine(hello[0])
// Output: H
´´´