export default {
    //日期輸入檢查
    verifyDate: function (d1, d2) {
        var d2Array = d2.split('-'); // yyyy-mm-dd
        var d1Array = d1.split('-'); // yyyy-mm-dd
        if (d1Array.length != 3) {
            d1Array = d1.split('/'); // yyyy/mm/dd
            if (d1Array.length != 3) return false;
        }
        if (d1Array.length != d2Array.length) return false;
        if (d1Array[0] != d2Array[0]) return false;
        if (parseInt(d1Array[1]) != parseInt(d2Array[1])) return false;
        if (parseInt(d1Array[2]) != parseInt(d2Array[2])) return false;
        return true;
    }
}