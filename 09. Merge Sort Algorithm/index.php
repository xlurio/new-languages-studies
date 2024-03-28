<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Sort Numbers</title>
</head>
<body>
    <h1>Sort Numbers</h1>
    <form id="numberForm">
        <label for="numberInput">Enter a Number:</label>
        <input type="number" id="numberInput" required>
        <button type="submit">Submit</button>
    </form>
    <ul id="numberList"></ul>
    <button id="sendButton">Sort</button>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function() {
            var numbers = []; // Array to store numbers

            $('#numberForm').submit(function(event) {
                event.preventDefault();
                var number = $('#numberInput').val();
                if (number.trim() !== '') {
                    numbers.push(number); // Add number to array
                    $('#numberList').append('<li>' + number + '</li>');
                    $('#numberInput').val(''); // Clear input after submission
                }
            });

            function sendNumbers(numbers) {
                $.ajax({
                    url: 'sorted.php',
                    method: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify({ numbers: numbers }),
                    success: function(response) {
                        $("#numberList").html(response);
                    },
                    error: function(xhr, status, error) {
                        console.error('Error sending numbers:', error);
                    }
                });
            }

            $('#sendButton').click(function() {
                sendNumbers(numbers);
            });
        });
    </script>
</body>
</html>
