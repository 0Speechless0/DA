<template>
    <div>
        <div class="card whiteBG mb-4 pattern-F colorset_G">
            <div class="card-header">
                <h3 class="card-title font-weight-bold">{{DATitle}}分析</h3>
            </div>
            <div class="card-body">

                <!-- Tab panes -->
                <div class="tab-content">
                    <!-- 一 -->
                    <div id="menu01" class="tab-pane active">
                        <div class="tup">說明 : 近三年{{DATitle}}分析</div>
                        <div class="tup2">輸入{{DATitle}}名稱關鍵字後，顯示近三年內的{{DATitle}}清單，選擇後分析</div>
                        <form class="form-group insearch mb-3">
                            <div class="form-row">
                                <div class="col-12 col-sm-6 col-md-auto mb-3 mb-sm-0">
                                    <label>關鍵字：</label>
                                </div>
                                <div class="col-12 col-sm-6 col-md-auto mb-3 mb-sm-0">
                                    <input v-model.trim="keyWord" type="text" class="form-control" value="">
                                </div>
                                <div class="col-12 col-sm-6 col-md-auto mb-3 mb-sm-0">
                                    <button @click="searchData" type="button" class="btn btn-outline-secondary btn-sm"><i class="fas fa-search"></i></button>
                                </div>
                                <div class="col-12 col-sm-6 col-md-auto mb-3 mb-sm-0" v-if="hasBigCategorySelect">
                                    <select v-model="word1" class="form-control"> 
                                        <option v-for="(option,index) in word1Categories" :key="index" :value="option">{{option}}</option>
                                    </select>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>

        <div class="concolud">
            <div class="row">
                <div class="col-8">
                    <div class="card whiteBG mb-4 pattern-F colorset_G">
                        <highcharts :options="mainOptions"></highcharts>
                        <div style="text-align:center;">{{DATitle}}名稱</div>
                    </div>
                    <div class="card whiteBG mb-4 pattern-F colorset_G">
                        <highcharts :options="sub1Options"></highcharts>
                        <div style="text-align:center;">時間</div>
                    </div>
                    <div class="card whiteBG mb-4 pattern-F colorset_G">
                        <highcharts :options="sub2Options"></highcharts>
                        <div style="text-align:center;">時間</div>
                    </div>
                    <div class="card whiteBG mb-4 pattern-F colorset_G">
                        <highcharts :options="sub3Options"></highcharts>
                        <div style="text-align:center;">時間</div>
                    </div>
                </div>
                <div class="col-4">
                    <div class="card2 whiteBG mb-4 pattern-F colorset_G">
                        <div class="wcolud">{{DATitle}}資訊關鍵字雲</div>
                        <div class="tup2" style="text-align:center;">依近三年{{DATitle}}加總的{{DAUnit}}顯示文字雲</div>
                        <figure class="highcharts-figure cloudword">
                            <div id="container">
                                <highcharts :options="wordCloudOptions"></highcharts>
                            </div>
                        </figure>
                    </div>
                </div>
            </div>
            <!-- div class="row justify-content-center col-8">
                <div class="col-12 col-sm-4 col-xl-2 my-2">
                    <button role="button" class="btn btn-shadow btn-color3 btn-block"> 列印 </button>
                </div>
            </div -->
        </div>
    </div>
</template>

<script>
console.log("AS");
    export default {
        props : ['DATitle', "DAUnit", "route" , "hasBigCategorySelect", "anonyName"],
        data: function () {
            return {
                word1: null,
                keyWord: null,
                productids: [],
                selProductId: '',
                mainOptions: {

                    chart: { type: 'line', height: 250, },
                    title: { text: "顯示近三年" },
                    xAxis: {
                        categories: [/* "客戶1","客戶2", */] //x 標籤
                    },
                    yAxis: { title: { text: this.DAUnit }, },
                    legend: {
                        align: 'center',
                        verticalAlign: 'top',
                        borderWidth: 0
                    },
                    //一次顯示多serial point 資訊
                    /*tooltip: {
                        shared: true,
                        crosshairs: true
                    },*/
                    plotOptions: {
                        series: {
                            cursor: 'pointer',
                            events: {
                                click: this.onPointClick
                            }
                        },
                        /*
                        // point 顯示 value
                        line: {
                            dataLabels: {
                                enabled: true
                            },
                            enableMouseTracking: false
                        }*/
                    },
                    series: [
                        /*{
                            name: "2019",
                            data: [12, 18, 22, 25, 32, 35, 26, 18]
                        },*/
                    ]
                },
                sub1Options: {
                    chart: { type: 'line', height: 250 },
                    title: { text: "第一年" },
                    xAxis: {
                        categories: ["1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"]
                    },
                    yAxis: { title: {text :"" }, },
                    legend: {
                        align: 'center',
                        verticalAlign: 'top',
                        borderWidth: 0
                    },
                    series: [ /*{ name: "原料A", data: [12, 18] },*/]
                },
                sub2Options: {
                    chart: { type: 'line', height: 250 },
                    title: { text: "第二年" },
                    xAxis: {
                        categories: ["1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"]
                    },
                    yAxis: { title: {text :""}, },
                    legend: {
                        align: 'center',
                        verticalAlign: 'top',
                        borderWidth: 0
                    },
                    series: []
                },
                sub3Options: {
                    chart: { type: 'line', height: 250 },
                    title: { text: "第三年" },
                    xAxis: {
                        categories: ["1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"]
                    },
                    yAxis: { title: { text :"" }, },
                    legend: {
                        align: 'center',
                        verticalAlign: 'top',
                        borderWidth: 0
                    },
                    series: []
                },
                wordCloudOptions: {
                    chart: {
                        type: 'wordcloud'
                    },
                    series: [{
                        name: ""
                        ,
                        data: []
                    }],
                    title: {
                        text: ''
                    }
                },
                routeContent : {
                    DATitle : null,
                    DAUnit : null
                }
            };
        },
        methods: {
            routeSwitch(index) {
            switch(index) {
                case 0 : 
                    return {
                        DATitle : "職能",
                        DAUnit : "開課數"
                    }
                case 1 :
                    return {
                        DATitle : "學員",
                        DAUnit : "上課數"
                    }
            }
        },
            async getBigCategories() {
                let resp = await window.myAjax.post("DA/getBigCategories", {type : this.route});
                console.log(resp.data);
                this.word1Categories = resp.data.options;
                if(this.word1Categories.length > 0) this.word1 = this.word1Categories[0];
            },
            searchData: function () {
                this.mainOptions.title = { text: "顯示近三年" };
                this.mainOptions.xAxis.categories = [];
                this.mainOptions.series = [];
                this.wordCloudOptions.series[0].data = [];

                window.myAjax.post('DA/getMainDiagramData', { type :this.route, bigCategory: this.word1, category: this.keyWord  })
                    .then(resp => {
                        if (resp.data.result == 0) {
                            console.log(resp.data );
                            this.setChart(resp.data);
                        } else {
                            alert(resp.data.msg);
                        }
                    })
                    .catch(err => {
                        console.log(err);
                    });
            },
            //三年加總
            setChart(chart) {
                // this.mainOptions.title = { text: chart.title };

                this.mainOptions.xAxis.categories = chart.xAxisCategories;
                this.mainOptions.series = chart.series;

                this.wordCloudOptions.series[0].data = chart.wordCloud;
            },
            onPointClick(event) {
                this.getChartForYear(event.point.category);
            },
            //單年依月
            getChartForYear(category) {
                this.sub1Options.title = { text: '' };
                this.sub1Options.series = [];
                this.sub2Options.title = { text: '' };
                this.sub2Options.series = [];
                this.sub3Options.title = { text: '' };
                this.sub3Options.series = [];

                window.myAjax.post('DA/getSubDiagramData', { type :this.route , category: category, bigCategory: this.word1  })
                    .then(resp => {
                        if (resp.data.result == 0) {
                            this.setMonthChart(resp.data);
                        } else {
                            alert(resp.data.msg);
                        }
                    })
                    .catch(err => {
                        console.log(err);
                    });
            },
            setMonthChart(chart) {

                console.log(chart);
                this.sub1Options.series = chart.series[0];
                this.sub1Options.xAxis.categories = chart.xAxis[0];

                this.sub2Options.series = chart.series[1];
                this.sub2Options.xAxis.categories = chart.xAxis[1];

                this.sub3Options.series = chart.series[2];
                this.sub3Options.xAxis.categories = chart.xAxis[2];
            },
        },
        watch:{
            hasBigCategorySelect : {
                handler(value) {
                    if(value)  this.getBigCategories();
                    console.log("AS", value);
                }
            },
            DAUnit:{
                handler(value) {
                    this.mainOptions.yAxis.title.text = value;
                    this.sub1Options.yAxis.title.text = value;
                    this.sub2Options.yAxis.title.text = value;
                    this.sub3Options.yAxis.title.text = value;

                }
            }
        },
        mounted() {

        }
    }
</script>
