# Basic Input

When a form is submitted to a PHP script, the information from that form is automatically made available to the script. There are few ways to access this information, for example:

- Example #1 A simple HTML form:
```php
<form action="foo.php" method="post">
    Name:  <input type="text" name="username" /><br />
    Email: <input type="text" name="email" /><br />
    <input type="submit" name="submit" value="Submit me!" />
</form>
```

- foo.php:
```php
<?php
echo $_POST['username'];
echo $_REQUEST['username'];
?>
```

Using a GET form is similar except you'll use the appropriate GET predefined variable instead. GET also applies to the QUERY_STRING (the information after the '?' in a URL). So, for example, http://www.example.com/test.php?id=3 contains GET data which is accessible with $_GET['id'].
