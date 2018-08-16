
var until = AdventureFinishDate;
var ChId = 1;

var x = setInterval(function () {

    var now = new Date();
    console.log("now: " + now);
    console.log("until: " + until);
    console.log("ChId: " + ChId);
    var distance = until - now;

    // Output the result in an element with id="demo"
    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);



    if ($(document.getElementsByClassName("image")) != null) {
        list = document.getElementsByClassName("image");

        for (i = 0; i < list.length; ++i) {
            if (seconds % 2 == 0) {
                list[i].setAttribute("src", "/Content/Pictures/walk1.PNG");
            }
            else {
                list[i].setAttribute("src", "/Content/Pictures/walk2.PNG");
            }
        }
    }

    document.getElementById("demo2").innerHTML = now;
    document.getElementById("demo3").innerHTML = until;
    document.getElementById("adventurecounter").innerHTML = days + " nap " + hours + " óra " + minutes + " perc " + seconds + " másodperc ";

    // If the count down is over, write some text 
    if (distance < 0) {
        clearInterval(x);
        document.getElementById("demo").innerHTML = "EXPIRED";

        window.location.href = '/Adventures/AdventureZombieAttack/' + '?ChId=' + ChId;
        // window.location = "/Adventures/Index";
    }
}, 1000);