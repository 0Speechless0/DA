'use strict';

var signaturemixin = {
    methods: {
        updateSignature: function (url, id, callback) {
            this.updateSignature(url, { Id: id }, callback);
        },
        updateSignature2: function (url, data, callback) {
            $.post({
                url: url,
                data: data
            }, function (data) {
                if (data != null && typeof callback !== "undefined") {
                    callback(data.result);
                }
            });
        },
        getSignature: function (url, callback) {
            $.get({
                url: url
            }, function (data) {
                if (data != null && typeof callback !== "undefined") {
                    callback(data.result);
                }
            });
        },
        createSignature: function () {
            return { CreateUser: '', CreateTime: '', ModifyUser: '', ModifyTime: '' };
        }
    }
}