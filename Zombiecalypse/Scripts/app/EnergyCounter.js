var until = EnergyPlusDate;
var UserName = UserName;

var x = setInterval(function () {

    var now = new Date();
    var distance = until - now;

    // Output the result in an element with id="demo"
    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);


    document.getElementsByClassName("EnergyCounter").innerHTML = days + " nap " + hours + " óra " + minutes + " perc " + seconds + " másodperc "
    //console.log(document.getElementsByClassName("EnergyCounter").innerHTML);


    // If the count down is over, write some text 
    if (distance < 0) {
        clearInterval(x);
        window.location.href = "/Characters/CheckEnergyFromJavaScript/" + UserName;
    }
}, 1000);
