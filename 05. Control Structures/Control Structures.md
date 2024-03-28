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
