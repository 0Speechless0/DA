Vue.directive('datepicker', {
    bind: function (el, binding, vnode) {

        $(el).datepicker({
            dateFormat: 'yy/mm/dd',
            onClose: function (date) {
                trigger(el, 'input');
            },
            beforeShow: function () {
                setTimeout(function () {
                    $('.ui-datepicker').css('z-index', 99999999999999);
                }, 0);
            }
        });
    },
    update: function (val) {
        $(this.el).datepicker('setDate', val);
    }
})