# Declaring Variables

```php
$foo = "bar";
```

## Constants

```php
define('MIN_VALUE', '0.0');   // RIGHT - Works OUTSIDE of a class definition.
define('MAX_VALUE', '1.0');   // RIGHT - Works OUTSIDE of a class definition.

const MIN_VALUE = 0.0;        // RIGHT - Works both INSIDE and OUTSIDE of a class definition.
const MAX_VALUE = 1.0;        // RIGHT - Works both INSIDE and OUTSIDE of a class definition.
```
