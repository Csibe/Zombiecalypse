﻿

var until = FinishDate;
var CharID = ChId;
var ZombieID = ZombId;
var ZabID = zabID;

var x = setInterval(function () {

    var now = new Date();
    var distance = until - now;

    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);


    document.getElementById("demo2").innerHTML = now;
    document.getElementById("demo3").innerHTML = until;
    document.getElementById("demo").innerHTML = days + " nap " + hours + " óra " + minutes + " perc " + seconds + " másodperc ";

    if (distance < 0) {
        clearInterval(x);
        document.getElementById("demo").innerHTML = "EXPIRED";

        window.location.href = '/Zombies/ZombieAttackBase/' + '?ZabID=' + ZabID;
        // window.location = "/Adventures/Index";
    }
}, 1000);