'use restrict';

//Author : Epic Chen
//version : 2019.02.22 21:26
(function ($) {
    /*
        get variable by name in host query string
    */
    //name : target query variable name
    $.getUrlParameter = function (name) {
        return $.getUrlQParameter(decodeURIComponent(window.location.search.substring(1)), name);
    };

        /*
        get variable by name in host query string
    */
    //name : target query variable name
    $.getUrlQParameter = function (url, key) {
        var sPageURL = url.indexOf('?') !== -1 ? url.split('?')[1] : url,
            sURLVariables = sPageURL.split('&'),
            sParameterName,
            i;

        for (i = 0; i < sURLVariables.length; i++) {
            sParameterName = sURLVariables[i].split('=');

            if (sParameterName[0] === key) {
                return sParameterName[1] === undefined ? true : sParameterName[1];
            }
        }

        return undefined;
    };

    /*
        set variable by name in query string
    */
    //name : target query variable name
    $.updateUrlQParameter = function (url, key, value) {
        if (typeof url === "undefined") {
            return url;
        }

        // remove the hash part before operating on the uri
        var i = url.indexOf('#');
        var hash = i === -1 ? '' : url.substr(i);
        url = i === -1 ? url : url.substr(0, i);

        var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
        var separator = url.indexOf('?') !== -1 ? "&" : "?";

        if (!value) {
            // remove key-value pair if value is empty
            url = url.replace(new RegExp("([?&]?)" + key + "=[^&]*", "i"), '');
            if (url.slice(-1) === '?') {
                url = url.slice(0, -1);
            }
            // replace first occurrence of & by ? if no ? is present
            if (url.indexOf('?') === -1) url = url.replace(/&/, '?');
        } else if (url.match(re)) {
            url = url.replace(re, '$1' + key + "=" + value + '$2');
        } else {
            url = url + separator + key + "=" + value;
        }
        return url + hash;
    };

    $.norToNull = function (val) {
        if (val && val !== "") {
            return val;
        }

        return "null";
    };

    $.objToQStr = function (obj) {
        var objStr = '';

        $.each(obj, function (key, item) {
            if (typeof item !== "undefined") {
                objStr += '&' + key + '=' + item;
            }
        });

        return objStr.substring(1);
    };

    $.newTab = function (url) {
        var $a = $('<a></a>').attr('href', url).attr('target', '_blank');

        //send request
        $a.appendTo('body').click().remove();
    };

    //refine date format from xxxx/xx/xx to xxxx-xx-xx so that be able to transport
    $.refineDate = function (date) {
        return date.replace(/\//g, '-');
    };

    //append query string parameter to not active tab
    $.appendQeurtyStrToTab = function (filter, name) {

        filter = filter || ".nav-pills > li:not(.active) > a";

        $.each($(filter), function (index, value) {
            var href = $(value).attr("href");

            $(value).attr("href", $.updateUrlQParameter(href, name, $.getUrlParameter(name)));
        });
    };

    $.fixedEncodeURIComponent = function(str) {
        return encodeURIComponent(str).replace(/[!'()*]/g, (c) => {
            return '%' + c.charCodeAt(0).toString(16)
        });
    }
})(jQuery);