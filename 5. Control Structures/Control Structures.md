# Control Structures

## Introduction

This is where are the control structures studies.


## Decision Structures

C# has two decision structures, the <strong>if statement</strong> and the <strong>switch statement</strong>.


### If Statement

The <strong>if statement</strong> can be implemented as the following:

´´´
if (condition1) {
    // code to execute if the first condition is true
} else if (condition) {
    // code to execute if the first condition is false and the second condition is true
} else {
    // code to execute if none condition is true
}
´´´


### Switch Statement

The <strong>switch statement</strong> can be implemented as the following:

´´´
switch(expression) {
    case x:
        // Code to execute if the expression returns x
        break;
    case y:
        // Code to execute if the expression returns y
        break;
    default:
        // Code to execute if the expression does not return any of the predicted values
        break;
}
´´´


## Iteration Structures

C# has two iteration structures, the <strong>for loop</strong> and the <strong>while loop</strong>.


### For Loop

The <strong>for loop</strong> can be implemented as the following:

```
for (
    expression to execute before the code block; 
    condition to execute each loop;
    expression to execute by the end of each loop
) {
    // Code to execute at each loop
}
```


### While Loop

The <strong>while loop</strong> can be implemented as the following:

```
while (condition to execute each loop) {
    // Code to execute at each loop
}
```