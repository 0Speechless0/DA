var autodownload = function (url, linkname) {
    var link = document.createElement('a');
    link.href = url;
    link.setAttribute('download', linkname);
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}