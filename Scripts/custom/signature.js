'use strict';

var signature = {
    template: "#signTemplate",
    data: function(){
        return {

        };
    },
    props: {
        value: {
            type: Object,
            default: function () {
                return { CreateUser: '', CreateTime: '', ModifyUser: '', ModifyTime: '' };
            }
        }
    }
}