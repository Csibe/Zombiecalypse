


function startCountDown() {
    // Update the count down every 1 second
    var x = setInterval(function () {

        // Find the distance between now an the count down date
        countDownDate = countDownDate - 1;


        // Output the result in an element with id="demo"
        document.getElementById("demo").innerHTML = countDownDate + "s ";

        // If the count down is over, write some text 
        if (countDownDate < 0) {
            clearInterval(x);
            document.getElementById("demo").innerHTML = "EXPIRED";
            window.location = "/";
        }
    }, 1000);

}