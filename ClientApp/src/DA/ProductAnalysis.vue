<template>
    <div>
        <div class="card whiteBG mb-4 pattern-F colorset_G">
            <div class="card-header">
                <h3 class="card-title font-weight-bold">產品分析</h3>
            </div>
            <div class="card-body">

                <!-- Tab panes -->
                <div class="tab-content">
                    <!-- 一 -->
                    <div id="menu01" class="tab-pane active">
                        <div class="tup">說明 : 近三年產品訂單分析</div>
                        <div class="tup2">輸入產品名稱關鍵字後，顯示近三年已完成的產品清單，選擇後分析</div>
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
                        <div style="text-align:center;">產品名稱</div>
                    </div>
                    <div class="card whiteBG mb-4 pattern-F colorset_G">
                        <highcharts :options="sub1Options"></highcharts>
                        <div style="text-align:center;">產品名稱</div>
                    </div>
                    <div class="card whiteBG mb-4 pattern-F colorset_G">
                        <highcharts :options="sub2Options"></highcharts>
                        <div style="text-align:center;">產品名稱</div>
                    </div>
                    <div class="card whiteBG mb-4 pattern-F colorset_G">
                        <highcharts :options="sub3Options"></highcharts>
                        <div style="text-align:center;">產品名稱</div>
                    </div>
                </div>
                <div class="col-4">
                    <div class="card2 whiteBG mb-4 pattern-F colorset_G">
                        <div class="wcolud">產品資訊關鍵字雲</div>
                        <div class="tup2" style="text-align:center;">依近三年各產品加總的公斤顯示文字雲</div>
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
    export default {
        data: function () {
            return {
                keyWord: '',
                productids: [],
                selProductId: '',
                mainOptions: {

                    chart: { type: 'line', height: 250, },
                    title: { text: "顯示近三年" },
                    xAxis: {
                        categories: [/* "客戶1","客戶2", */] //x 標籤
                    },
                    yAxis: { title: { text: "公斤(排程管理)" }, },
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
                    yAxis: { title: { text: "公斤(排程管理)" }, },
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
                    yAxis: { title: { text: "公斤(排程管理)" }, },
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
                    yAxis: { title: { text: "公斤(排程管理)" }, },
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
                        name: '公斤',
                        data: []
                    }],
                    title: {
                        text: ''
                    }
                },
            };
        },
        methods: {
            searchData: function () {
                this.mainOptions.title = { text: "顯示近三年" };
                this.mainOptions.xAxis.categories = [];
                this.mainOptions.series = [];
                this.wordCloudOptions.series[0].data = [];

                window.myAjax.post('BIntelligence/GetProduct3y', { keyWord: this.keyWord })
                    .then(resp => {
                        if (resp.data.result == 0) {
                            console.log(resp.data.chart);
                            this.setChart(resp.data.chart);
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
                this.mainOptions.title = { text: chart.title };
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

                window.myAjax.post('BIntelligence/GetProductYM', { mName: category })
                    .then(resp => {
                        if (resp.data.result == 0) {
                            this.setMonthChart(resp.data.chart);
                        } else {
                            alert(resp.data.msg);
                        }
                    })
                    .catch(err => {
                        console.log(err);
                    });
            },
            setMonthChart(chart) {
                this.sub1Options.title = { text: chart.sub1.title };
                this.sub1Options.series = chart.sub1.series;
                this.sub2Options.title = { text: chart.sub2.title };
                this.sub2Options.series = chart.sub2.series;
                this.sub3Options.title = { text: chart.sub3.title };
                this.sub3Options.series = chart.sub3.series;
            },
        },
        mounted() {
            console.log("產品分析");
        }
    }
</script>
