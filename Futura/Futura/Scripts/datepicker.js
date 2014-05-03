

$(function () { // will trigger when the document is ready
    $('.datepicker').datepicker(); //Initialise any date pickers

    jQuery.validator.methods.date = function (value, element) {
        return Globalize.parseDate(value);
    };

    $.validator.methods.number = function (value, element) {
        if (Globalize.parseFloat(value)) {
            return true;
        }
        return false;
    };

    jQuery(document).ready(function () {
        Globalize.culture("de-DE");
    });
});
