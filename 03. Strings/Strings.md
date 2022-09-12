# Strings

## Introduction

This is where are the strings studies. The string in C is a sequence of char objects terminated with a null character `\0`.


## Declaration

To declare a string object in C you can use:

```
char c[];

char c[50];

char c[] = "abcd";

char c[50] = "abcd";

char c[] = {'a', 'b', 'c', 'd', '\0'};

char c[5] = {'a', 'b', 'c', 'd', '\0'};
```


## Assigning value

To assign a value to a string variable you can use the `strcpy()` function:

```
strcpy("C programming", str1);
```


## Concatenation

To concatenate two strings, you can use the `strcat()` functions:

```
char str1[100] = "This is ", str2[] = "programiz.com";

// concatenates str1 and str2
// the resultant string is stored in str1.
strcat(str1, str2);
```


## Indexing

To access a specific character in a string you can pass the index of the character after the a string object between brackets:

´´´
char hello[] = "Hello"

puts(hello[0])
// Output: H
´´´