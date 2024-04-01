<?php
header("Content-Type: application/json");
echo json_encode(new class {
    public string $message = "Hello World!";
});
?>