'use strict';

//食品履歷管理 使用
var resumemanagermixin = {
    methods: {
        getNavUrl: function (applicationroot, type, date, productid) {
            switch (type) {
                case 1:
                    return applicationroot + "Picking/Index/1" + (!date || date === "" ? "" : "/" + date + "/" + productid);
                case 2:
                    return applicationroot + "Picking/Index/2" + (!date || date === "" ? "" : "/" + date + "/" + productid);
                case 3:
                    return applicationroot + "Feeding/Index" + (!date || date === "" ? "" : "/" + date + "/" + productid);
                case 4:
                    return applicationroot + "Shipment/Index" + (!date || date === "" ? "" : "/" + date + "/" + productid);
            }
        }
    }
}