'use strict';

Vue.directive('multiselect', {
    bind: function (el, binding, vnode) {
    },
    inserted: function (el, binding, vnode) {

        var registerMultiselect = function () {
            $(el).multiselect(
                 {
                     maxHeight: 200,
                     dropUp: true,
                     allSelectedText: "已全選",
                     buttonText: function (options, select) {
                         if (options.length === 0) {
                             return '請選擇';
                         }
                         else if (options.length > 3) {
                             return '已選' + options.length + '項';
                         }
                         else {
                             var labels = [];
                             options.each(function () {
                                 if ($(this).attr('label') !== undefined) {
                                     labels.push($(this).attr('label'));
                                 }
                                 else {
                                     labels.push($(this).html());
                                 }
                             });
                             return labels.join(', ') + '';
                         }
                     },
                     enableFiltering: true,
                     onChange: function (option, checked, select) {
                         trigger(el, 'change');
                     }
                 });
        };

        var $select = $(el);

        var url = $select.attr("data-url");
        if (url !== "undefined" && url !== null) {
            $.get(url, function (data) {

                $select.html("");
                $.each(data, function (index, value) {
                    $select.append("<option value=" + value.Id + ">" + value.Name + "</option>")
                });

                registerMultiselect();
            });
        } else {
            registerMultiselect();
        }
    },
    componentUpdated: function (el, binding, vnode) {

        var selected = binding.value;
        var $select = $(el);

        //在delay下有 bug
        //改用暴力法
        //$select.multiselect('deselectAll', false);
        //$select.multiselect('updateButtonText');

        //移除所有選項勾選
        $select.find("option").each(function () {
            $select.multiselect('deselect', $(this).val())
        });

        if (selected !== null) {
            for (var i = 0; i < selected.length; i++) {
                selected.forEach(function (element, index, array) {
                    $select.multiselect('select', element)
                });
            }
        }
    }
});