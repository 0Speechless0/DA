<template>
    <div>
        <div class="card whiteBG mb-4 pattern-F colorset_G">
            <div class="card-header">
                <h3 class="card-title font-weight-bold">原物料分析</h3>
            </div>
            <div class="card-body">

                <!-- Tab panes -->
                <div class="tab-content">
                    <!-- 一 -->
                    <div id="menu01" class="tab-pane active">
                        <div class="tup">說明 : 近三年原物料使用分析</div>
                        <div class="tup2">輸入原物料關鍵字後，顯示近三年的入庫產品的原物料清單，選擇後分析該原物料在各產品的使用數量</div>
                        <div class="btn-nup">
                            <template>
                                <button v-for="p in productids" v-bind:key="p" v-bind:class="{'btn btn-nu-sub':(selProductId == p), 'btn btn-nu':(selProductId != p)}" v-on:click="onClickProductId(p)">{{p}}</button>
                            </template>
                            <template>
                                <div>
                                    <button v-for="p in productids2" v-bind:key="p" style="margin-right:12px; margin-bottom:12px; " v-bind:class="{'btn btn-nu-sub':(selProductId2 == p), 'btn btn-success':(selProductId != p)}" v-on:click="searchProductDataByProductId(p)">{{p}}</button>
                                </div>
                            </template>
                        </div>

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
                        <div style="text-align:center;">原物料</div>
                    </div>
                    <div class="card whiteBG mb-4 pattern-F colorset_G">
                        <highcharts :options="sub1Options"></highcharts>
                        <div style="text-align:center;">原物料</div>
                    </div>
                    <div class="card whiteBG mb-4 pattern-F colorset_G">
                        <highcharts :options="sub2Options"></highcharts>
                        <div style="text-align:center;">原物料</div>
                    </div>
                    <div class="card whiteBG mb-4 pattern-F colorset_G">
                        <highcharts :options="sub3Options"></highcharts>
                        <div style="text-align:center;">原物料</div>
                    </div>
                </div>
                <div class="col-4">
                    <div class="card2 whiteBG mb-4 pattern-F colorset_G">
                        <div class="wcolud">原物料國際趨勢</div>
                        <div class="tup2" style="text-align:center;">依近三年各原物料的使用量加總顯示文字雲</div>
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
                keyWord:'',
                productids: [],
                productids2: [],
                selProductId: '',
                selProductId2: '',
                mainOptions: {
                    
                    chart: { type: 'line', height: 250, },
                    title: { text: "顯示近三年" },
                    xAxis: {
                        categories: [/* "客戶1","客戶2", */ ] //x 標籤
                    },
                    yAxis: { title: { text: "使用量(領用)" }, },
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
                    ],
                    /*exporting: {
                        menuItemDefinitions: {
                            // Custom definition
                            label: {
                                onclick: function () {
                                    this.renderer.label(
                                        'You just clicked a custom menu item',
                                        100,
                                        100
                                    )
                                        .attr({
                                            fill: '#a4edba',
                                            r: 5,
                                            padding: 10,
                                            zIndex: 10
                                        })
                                        .css({
                                            fontSize: '1.5em'
                                        })
                                        .add();
                                },
                                text: 'Show label'
                            }
                        },
                        buttons: {
                            contextButton: {
                                menuItems: ['downloadPNG', 'downloadSVG', 'separator', 'label']
                            }
                        }
                    }*/
                },
                sub1Options: {
                    chart: { type: 'line', height: 250 },
                    title: { text: "第一年" },
                    xAxis: {
                        categories: ["1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" ] 
                    },
                    yAxis: { title: { text: "使用量(領用)" }, },
                    legend: {
                        align: 'center',
                        verticalAlign: 'top',
                        borderWidth: 0
                    },
                    series: [ /*{ name: "原料A", data: [12, 18] },*/ ]
                },
                sub2Options: {
                    chart: { type: 'line', height: 250 },
                    title: { text: "第二年" },
                    xAxis: {
                        categories: ["1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"]
                    },
                    yAxis: { title: { text: "使用量(領用)" }, },
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
                    yAxis: { title: { text: "使用量(領用)" }, },
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
                        name:'使用量',
                        data: []
                    }],
                    title: {
                        text: ''
                    }
                },
            };
        },
        methods: {
            //取得分類ID 1
            getproductids: function () {
                var that = this;
                window.myAjax.get('ProductItem/AllProductId').then(function (response) {
                    that.productids = response.data;
                });
            },
            //取得分類ID 2
            getProductidsByStartWith: function () {
                var that = this;
                window.myAjax.get('ProductItem/AllProductIdByStartWith' + '/' + that.selProductId).then(function (response) {
                    that.productids2 = response.data;
                });
                /*that.$http.get('@Url.Action("AllProductIdByStartWith", "ProductItem")' + '/' + that.searchProductid1).then(function (response) {
                    that.productids2 = response.data;
                });*/
            },
            onClickProductId(p) {
                this.selProductId = p;
                this.selProductId2 = '';
                this.getProductidsByStartWith();
            },
            searchProductDataByProductId: function (value) {
                this.selProductId2 = value;
                //this.searchkeyword = this.getCategoryKeyword();
                //this.searchProductData();
            },
            searchData: function () {
                if (this.selProductId == '' || this.selProductId2 == '') {
                    alert('請選取產品分類');
                    return;
                }
                this.mainOptions.title = { text: "顯示近三年"};
                this.mainOptions.xAxis.categories = [];
                this.mainOptions.series = [];
                this.wordCloudOptions.series[0].data = [];

                window.myAjax.post('BIntelligence/GetMat3y', { pId: this.selProductId, keyWord: this.keyWord, pId2: this.selProductId2,  })
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
                if (this.selProductId == '') return;

                this.sub1Options.title = { text: '' };
                this.sub1Options.series = [];
                this.sub2Options.title = { text: '' };
                this.sub2Options.series = [];
                this.sub3Options.title = { text: '' };
                this.sub3Options.series = [];

                window.myAjax.post('BIntelligence/GetMatYM', { pId: this.selProductId, mName: category })
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
            onShowMax() {
                this.mainOptions.chart.height = 800;
            }
        },
        mounted() {
            console.log("原物料分析");
            this.getproductids();
        }
    }
</script>
<style>
    .btn-nu-sub {
        color: #f8f9fa;
        background: #4B5DC0;
        margin: 5px;
        box-shadow: 0 3px 6px rgba(0, 0, 0, 15%);
        transition: .35s;
        width: 4.4rem;
    }
</style>
