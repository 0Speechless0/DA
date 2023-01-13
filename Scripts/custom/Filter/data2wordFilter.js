"use strict";

Vue.filter('bool2word', function (value) {
    return value === true ? "是" : "否";
})