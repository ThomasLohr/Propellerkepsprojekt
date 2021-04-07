

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