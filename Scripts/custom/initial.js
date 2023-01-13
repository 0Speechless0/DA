$(function () {
    hookupdatepicker();
});

function hookupdatepicker() {
    $("[data-type=date]").datepicker({ dateFormat: 'yy/mm/dd' });
}

function normolizestr(input) {
    return (input.trim() === "" || input.trim()  === "-1") ? "null" : input;
}

Date.prototype.yyyymmdd = function () {
    var mm = this.getMonth() + 1; // getMonth() is zero-based
    var dd = this.getDate();

    return [this.getFullYear(), '-', mm, '-', dd].join(''); // padding
};

Date.prototype.yyyymmdd2 = function (depart) {
    var mm = this.getMonth() + 1; // getMonth() is zero-based
    var dd = this.getDate();

    return [this.getFullYear(), depart, mm, depart, dd].join(''); // padding
};