// define
Vue.component('dropdownlist', {
    template: '#ddltemplate',
    data: function () {
        return {
            datas: [
            ],
            //current selectedvalue
            selectedvalue: '-1',
            isloaded: false
        }
    },
    computed: {
        selectedtext: {
            cache: false,
            get: function () {
                var ddl = this.$el
                if (ddl.selectedIndex !== -1) {
                    return ddl.options[ddl.selectedIndex].text
                }
                return null;
            }
            //get: function () { return $(this.$el).find(":selected").text(); }
        }
    },
    props: {
        url: String,
        classes: { type: String, default: '' },
        //bind model value
        value: { default: '-1' }
    },
    mounted: function () {
        if (typeof this.url !== "undefined")
            this.getData(this.url);
    },
    methods: {
        //get data from server
        getData: function (url) {
            var datas = [];
            var that = this;
            $.get(url, function (data) {
                that.datas = data;

                if (typeof that.value !== "undefined") {
                    //if (typeof that.value !== "undefined" && $(that.$el).find(":selected").val() !== that.selectedvalue) {

                    var el = that.$el;

                    var isdataDiff = el.selectedIndex === -1 || el.selectedIndex === 0 || el.options[el.selectedIndex].value !== that.selectedvalue;

                    if (!isdataDiff) {
                        if (el.options.length !== that.datas.length) {
                            isdataDiff = true;
                        } else {
                            for (var i = 0; i < datas.length; i++) {
                                if (el.options[i].value !== that.datas[i].Id) {
                                    isdataDiff = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (isdataDiff) {
                        that.selectedvalue = "-1";
                        //­«·strigger selection
                        that.$nextTick(function () {

                            if (!that.isloaded) {
                                for (var i = 0; i < that.datas.length; i++) {
                                    if (that.value === that.datas[i].Id) {
                                        that.selectedvalue = that.value.toString();
                                        break;
                                    }
                                }
                            }

                            if (that.selectedvalue !== that.value.toString()) {
                                that.selectedvalue = "-1";
                            }
                            that.isloaded = true;
                        });
                    }
                }
            });
        },
        change: function () {
            this.$emit('change', event.target.value);
            this.$emit('input', event.target.value);
        },
        initialLV: function () {
            this.datas = [];
        }
    },
    watch: {
        "url": function (val, oldVal) {
            if (val === "") {
                this.initialLV();
            } else {
                this.getData(val);
            }
        },
        "value": function (val, oldVal) {
            if (val !== oldVal && val) {
                this.selectedvalue = val.toString();
                this.isloaded = false;
            }
        }
    }
})