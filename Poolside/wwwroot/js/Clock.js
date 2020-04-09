function startTime() {
    var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
    var days = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'];
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var d = days[(today.getDay() - 1)];//weekday
    var D = today.getDate();//day of the month
    var M = months[(today.getMonth())];//month
    m = checkTime(m);
    document.getElementById('Clock').innerHTML =
        h + ":" + m + " - " + d + " " + D + " " + M + " 1997";
    var t = setTimeout(startTime, 500);
}
function checkTime(i) {
    if (i < 10) { i = "0" + i };
    return i;
}