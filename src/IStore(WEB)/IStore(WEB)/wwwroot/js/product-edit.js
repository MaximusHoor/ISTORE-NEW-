(function () {
    'use strict'

    feather.replace()

    // Graphs
    var ctx = document.getElementById('myChart')
    // eslint-disable-next-line no-unused-vars
    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: [
                'Sunday',
                'Monday',
                'Tuesday',
                'Wednesday',
                'Thursday',
                'Friday',
                'Saturday'
            ],
            datasets: [{
                data: [
                    15339,
                    21345,
                    18483,
                    24003,
                    23489,
                    24092,
                    12034
                ],
                lineTension: 0,
                backgroundColor: 'transparent',
                borderColor: '#007bff',
                borderWidth: 4,
                pointBackgroundColor: '#007bff'
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: false
                    }
                }]
            },
            legend: {
                display: false
            }
        }
    })
}())


$(document).ready(function ($) {
    $(".table-row").click(function () {
        var cells = $(this).children();

        $("#title").val(cells[1].innerHTML);
        $("#type").val(cells[2].innerHTML);
        $("#vendorCode").val(cells[3].innerHTML);
        $("#brandId").val(cells[5].innerHTML);
        $("#retailPrice").val(cells[6].innerHTML);
        $("#categoryId").val(cells[7].innerHTML);
        $("#packageId").val(cells[8].innerHTML);
        $("#countInStorage").val(cells[9].innerHTML);
        $("#warrantyMonth").val(cells[10].innerHTML);
        $("#series").val(cells[11].innerHTML);
        $("#model").val(cells[12].innerHTML);
        $("#descriptionTextarea").val(cells[4].innerHTML);
    });
});

//$(function () {
//    $.ajax({
//        url: "GetCharacteristic",
//        type: "Get",
//        success: function (response) {
//            $("#charcteristicContainer").html(response);
//        }
//    });
//});



