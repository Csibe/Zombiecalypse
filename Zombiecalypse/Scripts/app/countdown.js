


function startCountDown() {
// Update the count down every 1 second
var until = new Date().getTime() + countDownDate;

//var until = FinishDate*1000;
var ChId = ChId;
var AdId = AdId;
var x = setInterval(function () {


    // Find the distance between now an the count down date

    var now = new Date().getTime();
    var distance = until - now;

    // Output the result in an element with id="demo"
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);
    document.getElementById("demo").innerHTML = hours +" óra " + minutes + " perc " + seconds + " másodperc ";

    // If the count down is over, write some text 
    if (distance < 0) {
        clearInterval(x);
        document.getElementById("demo").innerHTML = "EXPIRED";

      //  window.location.href = '/Adventures/StopAdventure/' + '?AdId=' + AdId + '&ChId=' + ChId;
       // window.location = "/Adventures/Index";
    }
}, 1000);

}


    //// Update the count down every 1 second
    //var x = setInterval(function () {

    //    // Find the distance between now an the count down date
    //    countDownDate = countDownDate - 1;


    //    // Output the result in an element with id="demo"
    //    document.getElementById("demo").innerHTML = countDownDate + "s ";

    //    // If the count down is over, write some text 
    //    if (countDownDate < 0) {
    //        clearInterval(x);
    //        document.getElementById("demo").innerHTML = "EXPIRED";
    //        window.location = "/";
    //    }
    //}, 1000);



//function startCountDown() {
//    // Update the count down every 1 second
//    var x = setInterval(function () {

//        // Find the distance between now an the count down date
//        countDownDate = countDownDate - 1;


//        // Output the result in an element with id="demo"
//        document.getElementById("demo").innerHTML = countDownDate + "s ";

//        // If the count down is over, write some text 
//        if (countDownDate < 0) {
//            clearInterval(x);
//            document.getElementById("demo").innerHTML = "EXPIRED";
//            window.location = "/";
//        }
//    }, 1000);

////}