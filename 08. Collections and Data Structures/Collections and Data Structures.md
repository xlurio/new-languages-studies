# Arrays

```php
<?php
$array = array(
    "foo" => "bar",
    "bar" => "foo",
);

// Using the short array syntax
$array = [
    "foo" => "bar",
    "bar" => "foo",
];
?>
```

The key can either be an int or a string. The value can be of any type. 

Additionally the following key casts will occur:

- Strings containing valid decimal ints, unless the number is preceded by a + sign, will be cast to the int type. E.g. the key "8" will actually be stored under 8. On the other hand "08" will not be cast, as it isn't a valid decimal integer.
- Floats are also cast to ints, which means that the fractional part will be truncated. E.g. the key 8.7 will actually be stored under 8.
- Bools are cast to ints, too, i.e. the key true will actually be stored under 1 and the key false under 0.
- Null will be cast to the empty string, i.e. the key null will actually be stored under "".
- Arrays and objects can not be used as keys. Doing so will result in a warning: Illegal offset type.

## Indexed arrays

### Without key

```php
<?php
$array = array("foo", "bar", "hello", "world");
var_dump($array);
?>
```

The above example will output:

```console
array(4) {
  [0]=>
  string(3) "foo"
  [1]=>
  string(3) "bar"
  [2]=>
  string(5) "hello"
  [3]=>
  string(5) "world"
}
```

### Keys not on all elements

```php

<?php
$array = array(
         "a",
         "b",
    6 => "c",
         "d",
);
var_dump($array);
?>

```

The above example will output:

```console
array(4) {
  [0]=>
  string(1) "a"
  [1]=>
  string(1) "b"
  [6]=>
  string(1) "c"
  [7]=>
  string(1) "d"
}
```

## Accessing elements

```php
<?php
$array = array(
    "foo" => "bar",
    42    => 24,
    "multi" => array(
         "dimensional" => array(
             "array" => "foo"
         )
    )
);

var_dump($array["foo"]);
var_dump($array[42]);
var_dump($array["multi"]["dimensional"]["array"]);
?>
```

The above example will output:

```console
string(3) "bar"
int(24)
string(3) "foo"
```

## Modifying arrays

An existing array can be modified by explicitly setting values in it.

This is done by assigning values to the array, specifying the key in brackets. The key can also be omitted, resulting in an empty pair of brackets ([]).

```php
$arr[key] = value;
$arr[] = value;
// key may be an int or string
// value may be any value of any type
```

To change a certain value, assign a new value to that element using its key. To remove a key/value pair, call the unset() function on it.

```php
<?php
$arr = array(5 => 1, 12 => 2);

$arr[] = 56;    // This is the same as $arr[13] = 56;
                // at this point of the script

$arr["x"] = 42; // This adds a new element to
                // the array with key "x"
                
unset($arr[5]); // This removes the element from the array

unset($arr);    // This deletes the whole array
?>
```

## Array discontruction

Arrays can be destructured using the [] (as of PHP 7.1.0) or list() language constructs. These constructs can be used to destructure an array into distinct variables.

```php
<?php
$source_array = ['foo', 'bar', 'baz'];

[$foo, $bar, $baz] = $source_array;

echo $foo;    // prints "foo"
echo $bar;    // prints "bar"
echo $baz;    // prints "baz"
?>
```

Array destructuring can be used in foreach to destructure a multi-dimensional array while iterating over it.

```php
<?php
$source_array = [
    [1, 'John'],
    [2, 'Jane'],
];

foreach ($source_array as [$id, $name]) {
    // logic here with $id and $name
}
?>
```

Array elements will be ignored if the variable is not provided. Array destructuring always starts at index 0.

```php
<?php
$source_array = ['foo', 'bar', 'baz'];

// Assign the element at index 2 to the variable $baz
[, , $baz] = $source_array;

echo $baz;    // prints "baz"
?>
```
