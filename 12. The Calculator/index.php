<!DOCTYPE html>
<html>
    <head>
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css">
        <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"></script>
        <script src="https://code.jquery.com/jquery-3.7.1.slim.min.js"></script>
    </head>
    <body>
        <main class="container">
            <h1>Calculator</h1>
            <form method="post">
                <div class="row">
                    <div class="input-field col s12 m10">
                        <input id="account" 
                            name="account" 
                            class="validate"
                            onfocus="$('#account-label').addClass('active')"
                            onblur="$('#account-label').removeClass('active')"
                        >
                        <label id="account-label" for="account">Write an account:</label>
                    </div>
                    <div class="col m2">
                        <button type="submit" class="waves-effect waves-light btn">Calculate</button>
                    </div>
                </div>
            </form>
<?php
if ($_POST) {
    try {
        $calculator = new Calculator($_POST["account"]);
        echo "<p style=\"font-weight: 500;\" class=\"card-panel teal lighten-5 teal-text right-align\">= ".$calculator->calculate()."</p>";
    } catch (Throwable $exc) {
        echo "<p class=\"card-panel red lighten-5 red-text\">".$exc->getMessage()."</p>";
    }
}
?>
        </main>
        <script>
            M.AutoInit();
        </script>
<?php
abstract class Account {
    protected int $number1;
    protected int $number2;

    public function __construct(int $number1, int $number2) {
        $this->number1 = $number1;
        $this->number2 = $number2;
    }

    abstract public function getResult(): int|float;
}

class Calculator {
    private Account $account;

    public function __construct(string $raw_account) {
        $this->account = makeAccount($raw_account);
    }

    public function calculate(): int|float {
        return $this->account->getResult();
    }
}

function makeAccount($raw_account) {
    if (preg_match("/^[\s]*([0-9]+)[\s]*(\+|\-|\*|\/)[\s]*([0-9]+)[\s]*/", $raw_account, $matches) <= 0) {
        throw new ValueError("Account $raw_account is not a valid format".PHP_EOL);
    }
    [$number1, $signal, $number2] = array($matches[1][0], $matches[2][0], $matches[3][0]);

    switch ($signal) {
        case "+":
            return new SumAccount($number1, $number2);
            break;
        case "-":
            return new SubstractionAccount($number1, $number2);
            break;
        case "*":
            return new MultiplicationAccount($number1, $number2);
            break;
        case "/":
            return new DivisionAccount($number1, $number2);
            break;
        default:
            throw new ValueError("'$signal' is not a valid operation".PHP_EOL);
    }
}

class SumAccount extends Account {
    public function getResult(): int|float {
        return $this->number1 + $this->number2;
    }
}

class SubstractionAccount extends Account {
    public function getResult(): int|float {
        return $this->number1 - $this->number2;
    }
}

class MultiplicationAccount extends Account {
    public function getResult(): int|float {
        return $this->number1 * $this->number2;
    }
}

class DivisionAccount extends Account {
    public function getResult(): int|float {
        return $this->number1 / $this->number2;
    }
}
?>
    </body>
</html>
