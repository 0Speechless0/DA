import Vue from 'vue'
import axios from 'axios';

Vue.config.devtools = true;//瀏覽器外掛 Vue 監視啟用
Vue.config.productionTip = false
window.Vue = Vue;

//import { BootstrapVue } from 'bootstrap-vue';
//import 'bootstrap/dist/css/bootstrap.css'
//import 'bootstrap-vue/dist/bootstrap-vue.css'

//Vue.use(BootstrapVue);

//import vueEsign from 'vue-esign'
//Vue.use(vueEsign)

import Highcharts from "highcharts/highcharts";
import wordcloud from "highcharts/modules/wordcloud";
wordcloud(Highcharts);
import exporting from "highcharts/modules/exporting";
exporting(Highcharts);

import HighchartsVue from 'highcharts-vue'
Vue.use(HighchartsVue)
//
import common from './Common/Common';
window.comm = common;

let baseURL = window.location.origin  ;
//無 loading UI
window.myAjax = axios.create({ baseURL: baseURL});

// axios 自動顯示 loading 圖示
import Loading from 'vue-loading-overlay'
import 'vue-loading-overlay/dist/vue-loading.css'
Vue.use(Loading);
window.myLoader = null;
window.loadingAjax = axios.create({ baseURL: baseURL });
window.loadingAjax.interceptors.request.use(
    (config) => {
        console.log('interceptors.request');
        if (window.myLoader == null) {
            console.log('$loading.show()');
            window.myLoader = Vue.$loading.show();
        }
        return config;
    },
    (error) => {
        hideLoader();
        return Promise.reject(error);
    }
);
function hideLoader() {
    console.log('hideLoader()');
    if (window.myLoader != null) {
        window.myLoader.hide();
        window.myLoader = null;
    }
}
window.loadingAjax.interceptors.response.use(
    (response) => {
        hideLoader();
        return response;
    },
    (error) => {
        hideLoader();
        return Promise.reject(error);
    }
);

import './sub1.js';