

var until = AttackingZombieFinishDate;
var ZabID = ZombieAttackBaseID;

var x = setInterval(function () {

    var now = new Date();
    var distance = until - now;

    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);



    list = document.getElementsByClassName("counterZombieAttack");
    for (i = 0; i < list.length; ++i) {
        list[i].innerHTML = days + " nap " + hours + " óra " + minutes + " perc " + seconds + " másodperc ";
    }

    if (distance < 0) {
        clearInterval(x);
        document.getElementById("counterZombieAttack").innerHTML = "EXPIRED";

        window.location.href = '/Zombies/ZombieAttackBase/' + '?ZabID=' + ZabID;
        // window.location = "/Adventures/Index";
    }
}, 1000);

