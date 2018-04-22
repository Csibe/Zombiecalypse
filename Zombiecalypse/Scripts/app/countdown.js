

var until = FinishDate;
var ChId = ChId;
var AdId = AdId;

var x = setInterval(function () {

    var now = new Date();
    var distance = until - now;

    // Output the result in an element with id="demo"
    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);


    document.getElementById("demo2").innerHTML = now;
    document.getElementById("demo3").innerHTML = until;
    document.getElementById("demo").innerHTML = days +" nap "  +hours +" óra " + minutes + " perc " + seconds + " másodperc ";

    // If the count down is over, write some text 
    if (distance < 0) {
        clearInterval(x);
        document.getElementById("demo").innerHTML = "EXPIRED";

        window.location.href = '/Adventures/AdventureZombieAttack/' + '?AdId=' + AdId + '&ChId=' + ChId;
       // window.location = "/Adventures/Index";
    }
}, 1000);
