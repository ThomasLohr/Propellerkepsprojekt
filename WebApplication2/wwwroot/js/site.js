

$(document).ready(function () {
    //create variable
    var x = document.getElementById("myInput").value;
    
    
    $(".addtocart").click(function () {
        //to number and increase to 1 on each click
        x = parseInt(document.getElementById("myInput").value);
        $(".badge").animate({
            //show span with number
            opacity: 1
        }, 300, function () {
                //write number of counts into span
                $(this).text(x);
                
        });
    });
});
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
