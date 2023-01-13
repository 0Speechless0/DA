Vue.directive('autocomplete', {
    bind: function (el, binding, vnode) {
        $(el).autocomplete({
            source: function (request, response) {
                $.get(binding.value + "/" + request.term + "/5", function (data) {
                    response($.map(data, function (value, key) {
                        return {
                            label: value.Name,
                            id: value.Id,
                            value: (!value.Value || value.Value === "") ?  " " :  value.Value
                        };
                    }));
                });
            },
            select: function (event, ui) {
                $(this).val(ui.item.label);
                $(this).attr("data-seq", ui.item.id);
                $(this).attr("data-selectedvalue", ui.item.value);
                trigger(el, 'input');

                setTimeout(function () { $(el).autocomplete("close"); }, 100);
                
                return false;
            },
            minLength: 1,
            delay: 100
        });
    }
})