<?php
    function mergeSort(&$array) {
        $width = 1;

        while ($width < count($array)) {
            $left = 0;

            while ($left < count($array)) {
                $middle = min($left + $width - 1, count($array) - 1);
                $right = min($left + 2 * $width - 1, count($array) - 1);
                merge($array, $left, $middle, $right);
                $left += $width * 2;
            }

            $width *= 2;
        }
    }

    function merge(&$array, $left, $middle, $right) {
        $leftArraySize = $middle - $left + 1;
        $rightArraySize = $right - $middle;

        $leftTempArray = array();
        $rightTempArray = array();

        for ($leftArrayIndex = 0; $leftArrayIndex < $leftArraySize; $leftArrayIndex++) {
            $leftTempArray[$leftArrayIndex] = $array[$left + $leftArrayIndex];
        }

        for ($rightArrayIndex = 0; $rightArrayIndex < $rightArraySize; $rightArrayIndex++) {
            $rightTempArray[$rightArrayIndex] = $array[$middle + 1 + $rightArrayIndex];
        }

        $leftArrayIndex = 0;
        $rightArrayIndex = 0;
        $originalArrayIndex = $left;

        while ($leftArrayIndex < $leftArraySize and $rightArrayIndex < $rightArraySize) {
            if ($leftTempArray[$leftArrayIndex] <= $rightTempArray[$rightArrayIndex]) {
                $array[$originalArrayIndex] = $leftTempArray[$leftArrayIndex];
                $leftArrayIndex++;
            } else {
                $array[$originalArrayIndex] = $rightTempArray[$rightArrayIndex];
                $rightArrayIndex++;
            }
            $originalArrayIndex++;
        }

        while ($leftArrayIndex < $leftArraySize) {
            $array[$originalArrayIndex] = $leftTempArray[$leftArrayIndex];
            $leftArrayIndex++;
            $originalArrayIndex++;
        }

        while ($rightArrayIndex < $rightArraySize) {
            $array[$originalArrayIndex] = $rightTempArray[$rightArrayIndex];
            $rightArrayIndex++;
            $originalArrayIndex++;
        }
    }

    $_POST = json_decode(file_get_contents('php://input'), true);
    if ($_POST) {        
        $numbers = array();

        foreach ($_POST["numbers"] as $number){
            $numbers[] = intval($number);
        }

        mergeSort($numbers);

        foreach ($numbers as $number){
            echo "<li>".$number."</li>";
        }
    }
?>
