dragElement(document.getElementById("Draggable"));

function dragElement(elmnt) {
    var PosX = 0, PosY = 0, OriginalPosX = 0, OriginalPosY = 0;

    if (document.getElementById(elmnt.id + "Header")) {
        document.getElementById(elmnt.id + "Header").onmousedown = dragMouseDown;
    }
    else {
        elmnt.onmousedown = dragMouseDown;
    }

    function dragMouseDown(e) {
        e = e || window.event;
        e.preventDefault();

        OriginalPosX = e.clientX;
        OriginalPosY = e.clientY;
        document.onmouseup = closeDragElement;

        document.onmousemove = elementDrag;
    }

    function elementDrag(e) {
        e = e || window.event;
        e.preventDefault();

        PosX = OriginalPosX - e.clientX;
        PosY = OriginalPosY - e.clientY;
        OriginalPosX = e.clientX;
        OriginalPosY = e.clientY;

        elmnt.style.top = (elmnt.offsetTop - PosY) + "px";
        elmnt.style.left = (elmnt.offsetLeft - PosX) + "px";
    }

    function closeDragElement() {

        document.onmouseup = null;
        document.onmousemove = null;
    }
}