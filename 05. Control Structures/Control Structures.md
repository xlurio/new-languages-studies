# Control Structures

## Conditional Structures

### If Statement

```php
<?php
    $number = 10;

    if ($number > 5) {
        echo "The number is greater than 5";
    }
?>
```

#### if-else

```php
<?php
    $age = 18;

    if ($age >= 18) {
    echo "You are eligible to vote.";
    } else {
    echo "You are not eligible to vote.";
    }
?>
```

#### if-else if-else

```php
<?php
    $score = 75;

    if ($score >= 90) {
        echo "Your grade is A";
    } else if ($score >= 80) {
        echo "Your grade is B";
    } else if ($score >= 70) {
        echo "Your grade is C";
    } else if ($score >= 60) {
        echo "Your grade is D";
    } else {
        echo "Your grade is F";
    }
?>
```

### Switch Statement

```php
$color = "red";

switch ($color) {
    case "red":
        echo "The color is red.";
        break;
    case "green":
        echo "The color is green.";
        break;
    case "blue":
        echo "The color is blue.";
        break;
    default:
        echo "The color is unknown.";
        break;
}
```

### Alternative Syntaxes

PHP offers an alternative syntax for some of its control structures; namely, if, while, for, foreach, and switch. In each case, the basic form of the alternate syntax is to change the opening brace to a colon (:) and the closing brace to endif;, endwhile;, endfor;, endforeach;, or endswitch;, respectively.

```php
<?php if ($a == 5): ?>
A is equal to 5
<?php endif; ?>
```

In the above example, the HTML block "A is equal to 5" is nested within an if statement written in the alternative syntax. The HTML block would be displayed only if $a is equal to 5.

The alternative syntax applies to else and elseif as well. The following is an if structure with elseif and else in the alternative format:

```php
<?php
if ($a == 5):
    echo "a equals 5";
    echo "...";
elseif ($a == 6):
    echo "a equals 6";
    echo "!!!";
else:
    echo "a is neither 5 nor 6";
endif;
?>
```

### Ternary Operator

```php
<?php
$marks=40;
print ($marks>=40) ? "pass" : "Fail";
?>
```

## Repetition Structures

### For Loop

```php
for ($i = 1; $i <= 10; $i++) {
  echo $i . "\n";
}
```

### While Loop

```php
$num = 1;
while ($num <= 5) {
   echo $num . " ";
   $num++;
}
```

### Foreach Loop

```php
$prices = array("Apple" => 0.50, "Banana" => 0.25, "Orange" => 0.75, "Grapes" => 1.00);

foreach ($prices as $fruit => $price) {
    echo $fruit . " costs $" . $price . "<br>";
}
```

### Do-While Loop

```php
$num = 1;

do {
    echo $num;
    $num++;
} while ($num <= 5);
```
