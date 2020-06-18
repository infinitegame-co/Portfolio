//######Functions#####
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

function ChangeWindow(From, To) {
    var CurrentWindow = document.getElementById(From);
    var SwapWindow = document.getElementById(To);
    CurrentWindow.setAttribute('style', "display: none;");
    SwapWindow.setAttribute('style', "display: inline-block");
}

function QuickSwap(From, To) {
    var CurrentWindow = document.getElementById(From);
    var SwapWindow = document.getElementById(To);
    CurrentWindow.setAttribute('style', "display: none;")
    SwapWindow.setAttribute('style', "display: inherit");
}

function OpenAndChangeWindow(WindowID, From, To, x, y) {
    OpenWindowCoord(WindowID, x, y);
    ChangeWindow(From, To);
}



//######JqueryUI#####
$('.Draggable-Container .Draggable').draggable({
    containment: "#containment-wrapper",
    multiple: false,
    scroll: false,
    selected: '.selected',
    beforeStart: function () {
        var $this = $(this);
        if (!$this.hasClass('selected')) {
            $this.siblings('.selected')
                .removeClass('selected');
            $this.addClass('selected');
        }
    }
});

JQuery(function () {
    JQuery("#resizable").resizable({
        helper: "ui-resizable-helper"
    });
});