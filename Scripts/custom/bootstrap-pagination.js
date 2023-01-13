function getDefaultpagination(pagesize) {
    return {
        total: 0,
        per_page: typeof pagesize == 'undefined' ? 20 : pagesize,    // required
        current_page: 1, // required
        last_page: 0,    // required
    }
}

function getPagination(data, pagesize) {
    if (typeof data == 'undefined') {
        return getDefaultpagination();
    }
    else {
        return {
            total: typeof data.Count == 'undefined' ? 0 : data.Count,
            per_page: typeof pagesize == 'undefined' ? 20 : pagesize,    // required
            current_page: typeof data.Offset == 'undefined' ? 1 : data.Offset, // required
            last_page: typeof data.LastPage == 'undefined' ? 0 : data.LastPage   // required
        }
    }
}

function getDefaultpaginationOptions() {
    return {
        offset: 4,
        previousText: '上一頁',
        nextText: '下一頁',
        firstText: '第一頁',
        lastText: '最末頁',
        alwaysShowPrevNext: true
    }
}

Vue.component('pagination', {
    template: "#paginationTemplate",
    props: {
        pagination: {
            type: Object,
            required: true
        },
        callback: {
            type: Function,
            required: true
        },
        options: {
            type: Object
        },
        size: {
            type: String
        }
    },
    computed: {
        array: function () {
            if (this.pagination.last_page <= 0) {
                return [];
            }

            let from = this.pagination.current_page - this.config.offset;
            if (from < 1) {
                from = 1;
            }

            let to = from + (this.config.offset * 2);
            if (to >= this.pagination.last_page) {
                to = this.pagination.last_page;
            }

            let arr = [];
            while (from <= to) {
                arr.push(from);
                from++;
            }

            return arr;
        },
        config: function () {
            return Object.assign({
                offset: 3,
                ariaPrevious: 'Previous',
                ariaNext: 'Next',
                previousText: '«',
                nextText: '»',
                firstText: '««',
                lastText: '»»',
                alwaysShowPrevNext: false,
                ShowFirstLast: true,
                alwaysShowFirstLast: false
            }, this.options);
        },
        sizeClass: function () {
            if (this.size === 'large') {
                return 'pagination-lg';
            } else if (this.size === 'small') {
                return 'pagination-sm';
            } else {
                return '';
            }
        }
    },
    watch: {
        'pagination.per_page': function (newVal, oldVal) {
            if (+newVal !== +oldVal) {
                this.callback();
            }
        }
    },
    methods: {
        showPrevious: function () {
            return this.config.alwaysShowPrevNext || this.pagination.current_page > 1;
        },
        showNext: function () {
            return this.config.alwaysShowPrevNext || this.pagination.current_page < this.pagination.last_page;
        },
        showFirtst: function () {
            return this.config.ShowFirstLast && (this.config.alwaysShowFirstLast || this.pagination.current_page > 1);
        },
        showLast: function () {
            return this.config.ShowFirstLast && (this.config.alwaysShowFirstLast || this.pagination.current_page < this.pagination.last_page);
        },
        changePage: function (page) {
            if (this.pagination.current_page === page) {
                return;
            }

            this.$set(this.pagination, 'current_page', page);
            this.callback();
        }
    }
});
