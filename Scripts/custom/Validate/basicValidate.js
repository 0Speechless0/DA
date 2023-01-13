//
//	Basic check undefined or null value
//
function isUndefineOrNullOrEmpty(value){
	return typeof value === "undefined" || value === null || value === "";
}

//
//	 
//
//obj: target object
//checkDef: Define fields of target object to check  
function checkObject(obj, checkDef){
    var defLength = checkDef.length;
    var msg = "";
	for(var i = 0; i < defLength; i++){
	    if (checkDef[i].Type == 1) {
	        if (isUndefineOrNullOrEmpty(obj[checkDef[i].Name])) {
	            msg = checkDef[i].ChiName;
	            break;
	        }
	    }else if (checkDef[i].Type == 2) {
            if (obj[checkDef[i].Name] === "" || obj[checkDef[i].Name] === "-1" || typeof obj[checkDef[i].Name] == "undefined") {
	            msg = checkDef[i].ChiName;
	            break;
	        }
	   } else if (checkDef[i].Type == 3) {
	       if (obj[checkDef[i].Name] == null || obj[checkDef[i].Name].length === 0) {
	           msg = checkDef[i].ChiName;
	           break;
	       }
	   }
	}
	return msg;
}
