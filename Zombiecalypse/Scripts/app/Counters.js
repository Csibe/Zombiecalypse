var UserName = UserName;
var PageUrl = PageUrl;
var isYourTurn = IsYourTurn;
var isOnAdventure = IsOnAdventure;
var untilAdventure = AdventureFinishDate;
var untilEnergy = EnergyPlusDate;
var lastZombieStartAttack = LastZombieStartAttack;
var isWaitingOnAdventure = IsWaitingOnAdventure
var dailyMissionDate = DailyMissionDate;
var untilTolerance = ToleranceFinishDate;


var fieldFinishDate = FieldFinishDate;
var fieldID = FieldID;
var attackingZombieFinishDate = AttackingZombieFinishDate
var zombieAttackBaseID = ZombieAttackBaseID


var x = setInterval(function () {
    var now = new Date();
    var distanceAdventure = untilAdventure - now;
    var distanceEnergy = untilEnergy - now;
    var distanceLastZombieStartAttack = now - lastZombieStartAttack;
    var distanceTolerance = untilTolerance - now;


    var today = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 0, 0, 0, 0);
    var tomorrow = new Date(now.getFullYear(), now.getMonth(), now.getDate() + 1, 0, 0, 0, 0);

    var distanceDailyMission = tomorrow - now;

    var Missionhours = Math.floor((distanceDailyMission % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var Missionminutes = Math.floor((distanceDailyMission % (1000 * 60 * 60)) / (1000 * 60));
    var Missionseconds = Math.floor((distanceDailyMission % (1000 * 60)) / 1000);


    if (document.getElementById("missionCounter")) {
        document.getElementById("missionCounter").innerHTML = Missionhours + "h " + Missionminutes + "m " + Missionseconds + "s ";;
    }

    if (isWaitingOnAdventure == 'False' && PageUrl == '/Adventures/AdventureCounter') {
        window.location.href = '/Adventures/OnAdventure/' + UserName;
    }

    if (isWaitingOnAdventure == 'True') {
        var days = Math.floor(distanceAdventure / (1000 * 60 * 60 * 24));
        var hours = Math.floor((distanceAdventure % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        var minutes = Math.floor((distanceAdventure % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((distanceAdventure % (1000 * 60)) / 1000);

    }

    if (isYourTurn == 'False' && isOnAdventure == 'True' && isWaitingOnAdventure == 'False') {
        clearInterval(x);

        var result = '/api/Default/ManageTurns/' + UserName

        $.get(result, function (data) {
            toastr.success(data, { timeOut: 10000 })
            location.reload();
        });

    }

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
        document.getElementById("counter").innerHTML = days + " day(s) " + hours + " hour(s) " + minutes + " minute(s) " + seconds + " second(s) ";
    }


    for (var count = 0; count < FieldFinishDate.length; count++) {

        var untilField = fieldFinishDate[count];
        var fieldID = FieldID[count];

        var distanceField = untilField - now;

        var fieldName = "field" + fieldID;


        if (document.getElementById(fieldName)) {

            var fielddays = Math.floor(distanceField / (1000 * 60 * 60 * 24));
            var fieldhours = Math.floor((distanceField % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
            var fieldminutes = Math.floor((distanceField % (1000 * 60 * 60)) / (1000 * 60));
            var fieldseconds = Math.floor((distanceField % (1000 * 60)) / 1000);


            document.getElementById(fieldName).innerHTML = fieldhours + " h " + fieldminutes + " m " + fieldseconds + " s ";
        }


        if (distanceField < 0) {

            clearInterval(x);

            var result = '/api/Default/GrowUpPlant/';

            $.get(result, function (data) {
                toastr.success(data, { timeOut: 10000 })
            });

        }
    }



    for (var count = 0; count < attackingZombieFinishDate.length; count++) {

        var untilZombie = attackingZombieFinishDate[count];
        var zabID = zombieAttackBaseID[count];

        var distanceZombie = now - untilZombie;

        if (distanceZombie > -500000) {
            clearInterval(x);

            var result = '/api/Default/ZombieDamageBase/';


            $.get(result, function (data) {
                toastr.error(data, { timeOut: 10000 })
            });
        }
    }

    if (distanceAdventure < 0) {
        clearInterval(x);

        var result = '/api/Default/CheckAdventure'


        $.get(result, function (data) {
            toastr.success(data, { timeOut: 10000 })
            location.reload();
        });
    }

    if (distanceEnergy < 0) {
        clearInterval(x);

        var result = '/api/Default/ManageEnergy/' + UserName

        $.get(result, function (data) {
            toastr.success(data, { timeOut: 10000 })
        });
    }

    if (distanceTolerance < 0 && isOnAdventure == "False") {
        clearInterval(x);

        var result = '/api/Default/ManageTolerance/' + UserName

        $.get(result, function (data) {
            toastr.success(data, { timeOut: 10000 })
        });
    }

    if (distanceLastZombieStartAttack > 10000000) {
        clearInterval(x);

        var result = '/api/Default/ZombieStartAttackBase/' + UserName

        $.get(result, function () {
            location.reload();
        });
    }



}, 1000);