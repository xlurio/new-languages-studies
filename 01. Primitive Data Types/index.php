<!DOCTYPE html>
<html>
    <head></head>
    <body>
        <h1>PHP Data Types</h1>
        <ul>
            <li><?=gettype(null)?></li>
            <li><?=gettype(true)?></li>
            <li><?=gettype(0)?></li>
            <li><?=gettype(0.0)?></li>
            <li><?=gettype("Hello World")?></li>
            <li><?=gettype(array(0 => "first", 1 => "second", 2 => "third"))?></li>
<?php
    class SomeClass
    {
        public static function some_method()
        {
            return new SomeClass;
        }
    }

    $some_object = new SomeClass;
?>
            <li><?=gettype($some_object)?></li>
<?php
    function does_not_end(){
        // This is function returns `never`
        exit();
    }
?>
            <li><?="never"?></li>
<?php
    function does_nothing(){
        // Returns void
        return;
    }
?>
            <li><?="void"?></li>
<?php
    // This is an allocated resource
    $image = @imagecreate(480, 320) or die("Could not initialize image");
?>
            <li><?="resource"?></li>
<?php
    // Deallocating resource
    imagedestroy($image)
?>
            <li><?="Relative class types"?></li>
            <li><?="callable"?></li>
        </ul>
    </body>
</html>
