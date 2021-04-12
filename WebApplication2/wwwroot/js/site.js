

//$(document).ready(function () {
//    //create variable
//    var sum = 0;
    
//    $(".addtocart").click(function () {
//        //to number and increase to 1 on each click
//        var x = parseInt(document.getElementById("myInput").value);
//        sum += x;
//        $(".badge").animate({
//            //show span with number
//            opacity: 1
//        }, 300, function () {
//                //write number of counts into span
//                $(this).text(sum);
                
//        });
//    });
//});
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", () => {
    const rows = document.querySelectorAll("tr[data-href]");

    rows.forEach(row => {
        row.addEventListener("click", () => {
            window.location.href = row.dataset.href;
        });
    });
});
