'use strict';

Vue.filter('tostring', {
    read: function (value) {
        if (value == null) {
            return "-1";
        } else {
            return value.toString();
        }
    },
    write: function (value) {
        return value;
    }
})

//begin HeaderTemplate
var lvHeaderTemplateComponent = Vue.extend({
    props: [
        'columns',
        'showorder',
          'model',
        'templatename'
    ],
    created: function () {
        if (this.templatename != null && this.templatename !== '') {
            this.$options.template = this.templatename;
        }
    }
});
//Vue.component('lvHeaderTemplate', {
//    //template: '#lvHeaderTemplate',
//    props: [
//        'columns',
//        'showorder',
//          'model',
//        'templatename'
//    ],
//    created: function () {
//        if (this.templatename != null && this.templatename !== '') {
//            this.$options.template = this.templatename;
//        }
//    }
//})
//end HeaderTemplate

//begin ItemTemplate
var lvItemTemplateComponent = Vue.extend({
    props: [
        'index',
        'columns',
        'model',
        'showorder',
        'currentpage',
        'pagesize',
        'templatename',
        'editbuttontype'
    ],
    created: function () {
        if (this.templatename != null && this.templatename !== '') {
            this.$options.template = this.templatename;
        }
    },
    methods: {
        notify: function (cmd, param) {
            if (cmd == 'edit') {
                this.$emit('editing', this.index, param);
            } else if (cmd == 'delete') {
                this.$emit('deleting', this.index, param);
            }
            else {
                this.$emit('commanding', this.index, cmd, param);
            }
        }
    }
});
//Vue.component('lvItemTemplate', {
//    // template: '#lvItemTemplate',
//    props: [
//        'index',
//        'columns',
//        'model',
//        'showorder',
//        'templatename',
//        'editbuttontype'
//    ],
//    created: function () {
//        if (this.templatename != null && this.templatename !== '') {
//            this.$options.template = this.templatename;
//        }
//    },
//    methods: {
//        notify: function (cmd) {
//            if (cmd == 'edit') {
//                this.$emit('editing', this.index);
//            } else if (cmd == 'delete') {
//                this.$emit('deleting', this.index);
//            }
//            else {
//                this.$emit('commanding', this.index, cmd);
//            }
//        }
//    }
//})
//end ItemTemplate

var lvEditItemTemplateComponent = Vue.extend({
    props: {
        index: Number,
        model: {
            type: Object,
            default: {}
        },
        templatename: String
    },
    created: function () {
        if (this.templatename != null && this.templatename !== '') {
            this.$options.template = this.templatename;
        }
    },
    methods: {
        notify: function (cmd, param) {
            if (cmd == 'update') {
                this.$emit('updateing', this.index, param);
            } else if (cmd == 'cancel') {
                this.$emit('canceling', this.index, param);
            }
        }
    }
})

//begin EditItemTemplate
//Vue.component('lvEditItemTemplate', {
//    template: '#lvEditItemTemplate',
//    props: {
//        index: Number,
//        model: {
//            type: Object,
//            default: {}
//        },
//        templatename: String
//    },
//    created: function () {
//        if (this.templatename != null && this.templatename !== '') {
//            this.$options.template = this.templatename;
//        }
//    },
//    methods: {
//        notify: function (cmd) {
//            if (cmd == 'update') {
//                this.$emit('updateing', this.index);
//            } else if (cmd = 'cancel') {
//                this.$emit('canceling', this.index);
//            }
//        }
//    }
//})
//end EditItemTemplate

var lvInsertItemTemplateComponent = Vue.extend({
    props: {
        index: Number,
        model: {
            type: Object,
            default: {}
        },
        templatename: String
    },
    created: function () {
        if (this.templatename != null && this.templatename !== '') {
            this.$options.template = this.templatename;
        }
    },
    methods: {
        notify: function (cmd, param) {
            if (cmd == 'insert') {
                this.$emit('inserting', param);
            }
        }
    }
});

//begin InsertItemTemplate
//Vue.component('lvInsertItemTemplate', {
//    template: '#lvInsertItemTemplate',
//    props: {
//        index: Number,
//        model: {
//            type: Object,
//            default: {}
//        },
//        templatename: String
//    },
//    created: function () {
//        if (this.templatename != null && this.templatename !== '') {
//            this.$options.template = this.templatename;
//        }
//    },
//    methods: {
//        notify: function (cmd) {
//            if (cmd == 'insert') {
//                this.$emit('inserting', this.index);
//            }
//        }
//    }
//})
//end lvInsertItemTemplate

// define
Vue.component('listview', Vue.extend({
    template: "#lvTemplate",
    components: {
        'lvHeaderTemplate': lvHeaderTemplateComponent.extend({ template: this.headertemplete }),
        'lvInsertItemTemplate': lvInsertItemTemplateComponent.extend({ template: this.inserttemplete }),
        'lvEditItemTemplate': lvEditItemTemplateComponent.extend({ template: this.edittemplete }),
        'lvItemTemplate': lvItemTemplateComponent.extend({ template: this.itemtemplete }),
    },
    data: function () {
        return {
            //current edit index
            editindex: -1,
            defaultnodatamsg: ""
        }
    },
    props: {
        tag: {},
        templatename: {
            type: String,
            default: ''
        },
        islistresult: {
            type: Boolean,
            default: false
        },
        //data source for list
        datasource: Array,
        //column info for list
        columns: Array,
        //position of insert row(n: no insert row / u:insert row at top / d:insert row at bottom)
        insertposition: {
            type: String,
            default: 'n'
        },
        //itemtemplate button type
        editbuttontype: {
            type: Number,
            default: 0 // 0: edit and delete 1: delete 2:edit
        },
        enablerowedit: {
            type: Boolean,
            default: false
        },
        //model of insert
        insertmodel: {
            type: Object,
            default: null
        },
        defaultvaluemodel: {
            type: Object,
            default: null
        },
        showheader: {
            type: Boolean,
            default: true
        },
        customheader: {
            type: Boolean,
            default: false
        },
        //is show order at first column
        showorder: {
            type: Boolean,
            default: false
        },
        currentpage: {
            type: Number,
            default: 1
        },
        pagesize: {
            type: Number,
            default: 0
        },
        classes: {
            type: String
        },
        headertemplete: {
            type: String,
            default: '#lvHeaderTemplate'
        },
        edittemplete: {
            type: String,
            default: '#lvEditItemTemplate'
        },
        inserttemplete: {
            type: String,
            default: '#lvInsertItemTemplate'
        },
        itemtemplete: {
            type: String,
            default: '#lvItemTemplate'
        }
    },
    created: function () {
        if (this.templatename != null && this.templatename !== '') {
            this.$options.template = this.templatename;
        }
    },
    mounted: function () {
        this.upadeInsertModelByDefault(this.insertmodel);
    },
    computed: {
        //is show header
        header: function () {
            return typeof this.columns !== "undefined" || this.customheader;
        },
        updatemodel: {
            // getter
            get: function () {
                return this.datasource != null && typeof this.datasource != 'undefined' && this.editindex !== -1 && this.datasource.length > this.editindex ? this.cloneObject(this.datasource[this.editindex]) : null;
            }
        },
        nodatamsg: {
            get: function () {
                return this.defaultnodatamsg;
            },
            set: function (value) {
                this.defaultnodatamsg = value;
            }
        },
    },
    methods: {
        //begin of region event
        iteminserting: function (index, param) {
            this.$emit('iteminserting', index, this.insertmodel, param);
        },
        itemediting: function (index, model, param) {
            if (this.enablerowedit) {
                this.setitemindex(index);
            }

            this.$emit('itemediting', index, this.updatemodel, param);
        },
        itemdeleting: function (index, param) {
            this.$emit('itemdeleting', index, this.datasource[index], param);
        },
        itemupdateing: function (index, param) {
            this.$emit('itemupdateing', index, this.updatemodel, param);
            this.setitemindex(-1);
        },
        itemcanceling: function (index, param) {
            this.setitemindex(-1);
        },
        commanding: function (index, cmd, param) {
            this.$emit('commanding', index, cmd, param);
        },
        notifylayoutchang: function () {
            this.$emit('layoutchanged', this.index);
        },
        //end of region event
        setitemindex: function (index) {
            this.editindex = index;

            this.$nextTick(function () {
                this.notifylayoutchang();
            });
        },
        upadeInsertModelByDefault: function (val) {
            if (this.defaultvaluemodel != null && typeof this.defaultvaluemodel !== "undefined") {
                //if insert model is new and default value model exist then do...
                for (var key in val) {
                    if (typeof this.defaultvaluemodel[key] !== "undefined") {
                        val[key] = this.defaultvaluemodel[key];
                    }
                }
            }
        },
        cloneObject: function (obj) {
            return JSON.parse(JSON.stringify(obj));
        },
        notify: function (cmd, index, param) {
            if (cmd == 'insert') {
                this.iteminserting(0, param);
            }
            else if (cmd == 'update') {
                this.itemupdateing(index, param);
            } else if (cmd == 'cancel') {
                this.itemcanceling(index, param);
            } else if (cmd == 'edit') {
                this.itemediting(index, param);
            } else if (cmd == 'delete') {
                this.itemdeleting(index, param);
            }
            else {
                this.commanding(index, cmd, param);
            }
        },
    },
    watch: {
        "insertmodel": function (val, oldVal) {
            this.upadeInsertModelByDefault(val);
        }
    }
}));