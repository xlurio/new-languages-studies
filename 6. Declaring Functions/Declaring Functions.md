# Declaring Functions

## Introduction

This is where are the function declaring studies. C# does not have "real" functions, since it is a exclusively object oriented programming language. You can declare static methods, which works like functions.


## Static Method Declaration

A static method can be declared as the follow:

´´´
class Program {
    static output_type MethodName () {
        // Code executed when the method is called
    }
}
´´´


Example:

´´´
class Program {
    static void Main(string[] args) {
        PrintHelloWorld();
        // Output: Hello World!
    }

    static void PrintHelloWorld () {
        Console.WriteLine("Hello World!");
    }
}
´´´


## Method Parameters

A method can receive parameters to be used inside it. The parameters are specified between the parenthesis after the method name:

´´´
class Program {
    static output_type MethodName (parameter_type parameter_name) {
        // Code executed when the method is called
    }
}
´´´

Example:

´´´
class Program {
    static void Main(string[] args) {
        PrintGreetings("John");
        // Output: Hello John!
    }

    static void PrintGreetings (string name) {
        Console.WriteLine($"Hello {name}!");
    }
}
´´´


### Default Parameter Value

You can set default values to the parameters to make them optional:

´´´
class Program {
    static output_type MethodName (parameter_type parameter_name = default_value) {
        // Code executed when the method is called
    }
}
´´´

Example:

´´´
class Program {
    static void Main(string[] args) {
        PrintGreetings();
        // Output: Hello Foo!
        PrintGreetings("John");
        // Output: Hello John!
    }

    static void PrintGreetings (string name = "Foo") {
        Console.WriteLine($"Hello {name}!");
    }
}
´´´


### Variable Number of Arguments

By using the keywork <strong>params</strong> you can specify a parameter that takes a variable number of arguments:

´´´
class Program {
    static output_type MethodName (params parameter_type[] parameter_name = default_value) {
        // Code executed when the method is called
    }
}
´´´


Example:

´´´
class Program {
    static void Main(string[] args) {
        PrintGreetings("Foo", "Boo", "John");
        # Output: Hello Foo!
        # Output: Hello Boo!
        # Output: Hello John!
    }

    static void PrintGreetings (params string[] names) {
        for(int i = 0; i < names.length; i++) {
            Console.WriteLine($"Hello {names[i]}!");
        }
    }
}
´´´


## Method Overloading

Method overload allows you to describe different implementations for the same method. This way, the same method can return different data types and perform different algorithms depending on it's parameters:

´´´
class Program {
    static output_type1 MethodName(parameter_type1 parameter1) {
        // Method code 1
    }

    static output_type2 MethodName(parameter_type2 parameter1) {
        // Method code 2
    }

    static output_type2 MethodName(parameter_type1 parameter1, parameter_type2 parameter2) {
        // Method code 3
    }
}
´´´


Example:

´´´
class Program {
    static int SumIntegers(int first_number, int second_number) {
        return first_number + second_number;
    }

    static int SumIntegers(string first_number, int second_number) {
        int parsed_first_number = System.Int32.Parse(first_number);
        int parsed_second_number = System.Int32.Parse(second_number);

        return parsed_first_number + parsed_second_number;
    }
}
´´´