//define
Vue.component('modal', {
    template: '#theModal',
    props: {
        //name of modal
        modalid: {
            type: String,
            default: "myModal"
        },
        modalSize: { type: String, default: "modal-md" },
    },
    mounted: function () {
        var that = this;

        //register modal opened event
        $(that.modalidtaget).on('shown.bs.modal', function () {
            that.notify("shown");
        })
    },
    methods: {
        notify: function (cmd) {
            if (cmd === "confirm") {
                $(this.$el).find("[data-id=confirmbtn]").prop("disabled", true);
                this.$emit('confirmed');
            } else if (cmd === "close") {
                this.$emit('closing');
            } else if (cmd === "shown") {
                this.$emit('shown');
            }
        },
        open: function () {
            var that = this;
            $(that.$el).find("[data-type=openbtn]").trigger("click");
        },
        close: function () {
            var that = this;
            $(that.$el).find("[data-dismiss=modal]").trigger("click");
            this.$emit('closing');
        },
        enablebtn: function () {
            $(this.$el).find("[data-id=confirmbtn]").prop("disabled", false);
        }
    },
    computed: {
        modalidtaget: function () {
            return "#" + this.modalid;
        }
    }
});