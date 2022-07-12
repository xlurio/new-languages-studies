# Namespaces

## Introduction

This is where are the namespaces studies.


## Using Directive

The <strong>using directive</strong> allows you to use types from a different namespace without specifying the fully namespace of that type. In it's basic form, the <strong>using directive</strong> imports all the types from a single namespace as shown above:

´´´
using System;
´´´


## Using Directive Modifiers

You can apply two modifiers to the <strong>using directive</strong>, the <strong>global modifier</strong> and the <strong>static modifier</strong>.

The <strong>global modifier</strong> apply the modified <strong>using directive</strong> to every source file in the project.

The <strong>static modifier</strong> imports only the static members from the namespace.


## Using Directive Alias

You can create an <strong>using alias</strong> to make easier to qualify an identifier to a namespace or type:

´´´
using s = System.Text;
´´´


## Declaring A Namespace

To declare a namespace you can simply use the <strong>namespace</strong> keyword before the namespace name as the follow:

´´´
namespace NamespaceName {
    class ClassName {
        static method_type MethodName() {
            // Code
        }
    }
}
´´´

Or:

´´´
namespace NamespaceName;

class ClassName {
    static method_type MethodName() {
        // Code
    }
}
´´´