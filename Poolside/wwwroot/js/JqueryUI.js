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

$(function () {
    $("#resizable").resizable({
        helper: "resizable-helper"
    });
});