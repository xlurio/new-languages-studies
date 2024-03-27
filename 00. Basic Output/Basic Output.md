Basic output in PHP is by done by the `echo` language construct as following:

```
<!DOCTYPE html>
<!DOCTYPE html>
<html>
    <head>
        <title>PHP Test</title>
    </head>
    <body>
        <?php echo '<p>Hello World</p>'; ?>
    </body>
</html>
```

`echo` also has a shortcut syntax, where you can immediately follow the opening tag with an equals sign. This syntax is available even with the short_open_tag configuration setting disabled. 

```
<!DOCTYPE html>
<!DOCTYPE html>
<html>
    <head>
        <title>PHP Test</title>
    </head>
    <body>
        <?php $foo = '<p>Hello World</p>'; ?>
        <?=$foo?>
    </body>
</html>
```

It is also possible to concatenate strings when outputting like the following:

```
<!DOCTYPE html>
<!DOCTYPE html>
<html>
    <head>
        <title>PHP Test</title>
    </head>
    <body>
        <?php echo '<p>Hello', ' World</p>'; ?>
    </body>
</html>
```
