<!DOCTYPE html>
<html>
    <head></head>
    <body>
<?php
    $second_word = "World";
?>
        <h1>Strings</h1>
        <h2>How to create</h2>
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
        <h2>How to concatenate</h2>
        <p><?="Hello ".$second_word?></p>
        <h2>How to interpolate</h2>
        <ul>
            <li><?="Hello $second_word".PHP_EOL?></li>
            <li><?="Hello {$second_word}"?></li>
        </ul>
    </body>
</html>