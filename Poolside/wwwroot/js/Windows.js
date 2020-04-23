
function CloseWindow(WindowId) {
    var window = document.getElementById(WindowId).childNodes;
    window[1].setAttribute('style', 'display: none;');
}

function OpenWindow(WindowId) {
    var window = document.getElementById(WindowId).childNodes;
        window[1].setAttribute('style', 'position: absolute; border: 1px solid #000; left:0; top:0; ');
}
function OpenWindowCoord(WindowId, x, y) {
    var window = document.getElementById(WindowId).childNodes;
        window[1].setAttribute('style', "position: absolute; border: 1px solid #000; left:" + x + "px;" + " top:" + y + "px;");
}