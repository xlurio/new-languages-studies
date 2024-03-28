# Strings

## How to create

```php
<!DOCTYPE html>
<html>
    <head></head>
    <body>
        <h1>Strings</h1>
        <ul>
            <li><?="This is a string"?></li>
            <li><?='This is also a string'?></li>
            <li><?='This is also a string'?></li>
            <li>
<?php
echo <<<END
guess what
END;
?>
            </li>
            <li>
<?php
echo <<<EOD
another one
EOD;
?>
            </li>
        </ul>
    </body>
</html>
```

## How to concatenate

```php
<!DOCTYPE html>
<html>
    <head></head>
    <body>
<?php
    $second_word = "World";
?>
        <p><?="Hello ".$second_word?></p>
    </body>
</html>
```

## How to interpolate

```php
<!DOCTYPE html>
<html>
    <head></head>
    <body>
<?php
    $second_word = "World";
?>
        <p><?="Hello $second_word".PHP_EOL?></p>
        <p><?="Hello {$second_word}"?></p>
    </body>
</html>
```
