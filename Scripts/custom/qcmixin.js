'use strict';

var qcmixin = {
    methods: {
        getQcTypeNavUrl: function (applicationroot, qctype, date) {
            switch (qctype) {
                case "1":
                    return applicationroot + "QC/SemiProductExam" + (!date || date === "" ? "" : "/" + date);
                case "2":
                    return applicationroot + "QC/FinalProductExam" + (!date || date === "" ? "" : "/" + date);
                case "3":
                    return applicationroot + "QC/Index" + (!date || date === "" ? "" : "/" + date);
            }
        }
    }
}