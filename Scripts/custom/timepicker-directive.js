Vue.directive('timepicker', {
    bind: function (el, binding, vnode) {

        $(el).datetimepicker({
            format:'HH:mm',
            onClose: function (date) {
                trigger(el, 'input');
            }
        });
    },
    update: function (val) {
        $(this.el).datetimepicker('setValue', val);
    }
})