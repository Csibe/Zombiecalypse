
var UserName = UserName;
var PageUrl = PageUrl;

var untilAdventure = AdventureFinishDate;
var untilEnergy = EnergyPlusDate;
var lastZombieStartAttack = LastZombieStartAttack;
var endOfExplore = EndOfExplore;


var fieldFinishDate = FieldFinishDate;
var fieldID = FieldID;
var attackingZombieFinishDate = AttackingZombieFinishDate
var zombieAttackBaseID = ZombieAttackBaseID


var x = setInterval(function () {
    var now = new Date();
    var distanceAdventure = untilAdventure - now;
    var distanceEnergy = untilEnergy - now;
    var distanceLastZombieStartAttack = now - lastZombieStartAttack;
    var distanceEndOfExplore = endOfExplore - now;


    var days = Math.floor(distanceAdventure / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distanceAdventure % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distanceAdventure % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distanceAdventure % (1000 * 60)) / 1000);

    if (document.getElementsByClassName("image")) {
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

    console.log(distanceAdventure);
    console.log("distanceLastZombieAttack: " + distanceLastZombieStartAttack);
    if (document.getElementById("counter")) {
        document.getElementById("counter").innerHTML = days + " nap " + hours + " óra " + minutes + " perc " + seconds + " másodperc ";
    }

    for (var count = 0; count < FieldFinishDate.length; count++) {

        var untilField = fieldFinishDate[count];
        var fieldID = FieldID[count];

        var distanceField = untilField - now;
        console.log(fieldFinishDate[count]);

        if (distanceField < 0) {

            clearInterval(x);
            // window.location.href = '/Gathering/GrowUpPlant/' + '?fieldID=' + fieldID;
            var url = '/Gathering/GrowUpPlant/' + '?fieldID=' + fieldID;
            $.get(url, function (data) {
                alert("Load was performed.");
            });

        }
    }



    for (var count = 0; count < attackingZombieFinishDate.length; count++) {

        var untilZombie = attackingZombieFinishDate[count];
        var zabID = zombieAttackBaseID[count];

        var distanceZombie = now - untilZombie;

      //  console.log(distanceZombie);

        if (distanceZombie > 1000000) {
            clearInterval(x);
            window.location.href = '/Zombies/ZombieAttackBase/' + '?ZabID=' + zabID;
            
        }
    }

        if (distanceAdventure < 0) {
            clearInterval(x);
            window.location.href = '/Adventures/CheckAdventure/';
        }

        if (distanceEnergy < 0) {
            clearInterval(x);
            window.location.href = "/Characters/ManageEnergy/" + UserName +"?energyCost=0&returnUrl=" +PageUrl;
        }

       // console.log(distanceLastZombieStartAttack);

        if (distanceLastZombieStartAttack > 11760000) {
            clearInterval(x);
            window.location.href = "/Zombies/ZombieStartAttackBase/" + UserName + "?returnUrl=" + PageUrl;
        }

        if (distanceEndOfExplore < 0) {
            clearInterval(x);
            window.location.href = "/Dogs/StopDogToExplore/";
        }

    }, 1000);