document.addEventListener("DOMContentLoaded", function () {
    var button = document.getElementById('toggleButton');
    var calcButton = document.getElementById('calculateButton');
    var form = document.getElementById('calculationForm');
    var resultDiv = document.getElementById('result');

    button.addEventListener('click', function () {
        var elements = document.querySelectorAll('.main');

        elements.forEach(function (element) {
            if (element.style.display === 'none') {
                element.style.display = 'block';
            } else {
                element.style.display = 'none';
            }
        });
    });

    calcButton.addEventListener('click', function () {
        var input1 = parseInt(document.getElementById('input1').value);
        var input2 = parseInt(document.getElementById('input2').value);
        var sum = input1 + input2;
        resultDiv.innerText = "Sum: " + sum;
    });
});
