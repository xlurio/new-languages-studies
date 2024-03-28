# Unit Test

## PHPUnit

### How to install

#### PHP Archive (PHAR)

We distribute a PHP Archive (PHAR) that contains everything you need in order to use PHPUnit 11. Simply download it from here and make it executable:

```console
$ wget -O phpunit https://phar.phpunit.de/phpunit-11.phar
$ chmod +x phpunit
$ ./phpunit --version
PHPUnit 11.0.0 by Sebastian Bergmann and contributors.
```

#### Composer

You can add PHPUnit as a local, per-project, development-time dependency to your project using Composer:

```console
$ composer require --dev phpunit/phpunit ^11
$ ./vendor/bin/phpunit --version
PHPUnit 11.0.0 by Sebastian Bergmann and contributors.
```

The example shown above assumes that composer is on your `$PATH`.

Your `composer.json` should look similar to this:

```json
{
    "autoload": {
        "classmap": [
            "src/"
        ]
    },
    "require-dev": {
        "phpunit/phpunit": "^11"
    }
}
```

#### Usage

- `src/Email.php`

```php
<?php declare(strict_types=1);
    final class Email
    {
        private string $email;

        private function __construct(string $email)
        {
            $this->ensureIsValidEmail($email);

            $this->email = $email;
        }

        public static function fromString(string $email): self
        {
            return new self($email);
        }

        public function asString(): string
        {
            return $this->email;
        }

        private function ensureIsValidEmail(string $email): void
        {
            if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
                throw new InvalidArgumentException(
                    sprintf(
                        '"%s" is not a valid email address',
                        $email
                    )
                );
            }
        }
    }
?>
```

- `tests/EmailTest.php`

```php
<?php declare(strict_types=1);
use PHPUnit\Framework\TestCase;

final class EmailTest extends TestCase
{
    public function testCanBeCreatedFromValidEmail(): void
    {
        $string = 'user@example.com';

        $email = Email::fromString($string);

        $this->assertSame($string, $email->asString());
    }

    public function testCannotBeCreatedFromInvalidEmail(): void
    {
        $this->expectException(InvalidArgumentException::class);

        Email::fromString('invalid');
    }
}
?>
```

##### Executing tests with PHP Archive (PHAR)

```console
$ ./phpunit --bootstrap src/autoload.php tests
PHPUnit 11.0.0 by Sebastian Bergmann and contributors.

..                                        2 / 2 (100%)

Time: 70 ms, Memory: 10.00MB

OK (2 tests, 2 assertions)
```

##### Executing tests with Composer

```console
$ ./vendor/bin/phpunit tests
PHPUnit 11.0.0 by Sebastian Bergmann and contributors.

..                                        2 / 2 (100%)

Time: 70 ms, Memory: 10.00MB

OK (2 tests, 2 assertions)
```

##### TestDox

Below you see an alternative output which is based on the idea that the name of a test can be used to document the behavior that is verified by the test:

```console
$ ./phpunit --bootstrap src/autoload.php --testdox tests
PHPUnit 11.0.0 by Sebastian Bergmann and contributors.

..                                        2 / 2 (100%)

Time: 70 ms, Memory: 10.00MB

Email
 ✔ Can be created from valid email address
 ✔ Cannot be created from invalid email address

OK (2 tests, 2 assertions)
```

```console
$ ./vendor/bin/phpunit --testdox tests
PHPUnit 11.0.0 by Sebastian Bergmann and contributors.

..                                        2 / 2 (100%)

Time: 70 ms, Memory: 10.00MB

Email
 ✔ Can be created from valid email address
 ✔ Cannot be created from invalid email address

OK (2 tests, 2 assertions)
```
