var help = new Vue({
    el: '#help',
    props: {
        showLoading: {
            type: Boolean,
            default: false
        }
    },
    components: {
        'loader': {
            template: '#loader-template',
        }
    }
})

//Vue.http.interceptors.push(function (request, next) {
//    help.show = true
//    next(function (response) {
//        help.show = false
//        return response
//    });
//});

axios.interceptors.request.use(function (config) {
    // Do something before request is sent
    help.showLoading = true;
    return config;
}, function (error) {
    // Do something with request error
    help.showLoading = false;
    return Promise.reject(error);
});

// Add a response interceptor
axios.interceptors.response.use(function (response) {
    // Do something with response data
    help.showLoading = false;
    return response;
}, function (error) {
    // Do something with response error
    help.showLoading = false;
    return Promise.reject(error);
});