var UserName = UserName;
var PageUrl = PageUrl;

var untilAdventure = AdventureFinishDate;
var untilEnergy = EnergyPlusDate;
var lastZombieStartAttack = LastZombieStartAttack;
var endOfExplore = EndOfExplore;
var dailyMissionDate = DailyMissionDate;

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

    var today = new Date(now.getFullYear(),now.getMonth(),now.getDate(),0,0,0,0);


    var days = Math.floor(distanceAdventure / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distanceAdventure % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distanceAdventure % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distanceAdventure % (1000 * 60)) / 1000);

    if (dailyMissionDate <= today) {
        clearInterval(x);
        var result = '/api/Default/GenerateDailyMissions'

        $.get(result, function () {
        });

    }



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

    if (document.getElementById("counter")) {
        document.getElementById("counter").innerHTML = days + " nap " + hours + " óra " + minutes + " perc " + seconds + " másodperc ";
    }

    for (var count = 0; count < FieldFinishDate.length; count++) {

        var untilField = fieldFinishDate[count];
        var fieldID = FieldID[count];

        var distanceField = untilField - now;

       console.log("field distance: " +fieldFinishDate[count]);

        if (distanceField < 0) {

            clearInterval(x);
            // window.location.href = '/Gathering/GrowUpPlant/' + '?fieldID=' + fieldID;

            var result = '/api/Default/GrowUpPlant/' + fieldID

          //  var url = '/Gathering/GrowUpPlant/' + '?fieldID=' + fieldID

            $.get(result, function (data) {
                toastr.success('Plant grew up!' + data, 'Success Alert', { timeOut: 10000 })
               // alert("Plant grew up!");
            });

        }
    }



    for (var count = 0; count < attackingZombieFinishDate.length; count++) {

        var untilZombie = attackingZombieFinishDate[count];
        var zabID = zombieAttackBaseID[count];

        var distanceZombie = now - untilZombie;

        console.log("distanceZombie: " + distanceZombie);

        if (distanceZombie > 500000) {
            clearInterval(x);

            //window.location.href = '/Zombies/ZombieAttackBase/' + '?ZabID=' + zabID;

            var result = '/api/Default/ZombieDamageBase/' + zabID

            $.get(result, function () {
              //  alert("Zombie attacked!");
            });
        }
    }
    console.log("distanceAdventure: " + distanceAdventure);

        if (distanceAdventure < 0) {
            clearInterval(x);

            if (PageUrl == '/Adventures/Index' || PageUrl == '/Adventures/OnAdventure' || PageUrl == '/Adventures/CheckAdventure') {
                window.location.href = '/Adventures/CheckAdventure/';
            }

            else {
                var result = '/api/Default/CheckAdventure'


                $.get(result, function () {
                    //alert("Adventure finished!");
                });

            }
        }

        console.log("distanceEnergy: " + distanceEnergy);

        if (distanceEnergy < 0) {
            clearInterval(x);

            var result = '/api/Default/ManageEnergy/' + UserName

            $.get(result, function () {
               // alert("Energy added!");
            });

          //  window.location.href = "/Characters/ManageEnergy/" + UserName +"?energyCost=0&returnUrl=" +PageUrl;
        }


        console.log("distanceLastZombieStartAttack: " + distanceLastZombieStartAttack);


        if (distanceLastZombieStartAttack > 1176000) {
            clearInterval(x);

            var result = '/api/Default/ZombieStartAttackBase/' + UserName

            $.get(result, function () {
                // alert("Energy added!");
            });
         //   window.location.href = "/Zombies/ZombieStartAttackBase/" + UserName + "?returnUrl=" + PageUrl;

        }

        console.log("distanceEndOfExplore: " + distanceEndOfExplore);

        //if (distanceEndOfExplore < 0) {
        //    clearInterval(x);



        //    window.location.href = "/Dogs/StopDogToExplore/";
        //}

    }, 1000);