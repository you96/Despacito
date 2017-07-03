//js获取网站根路径(站点及虚拟目录)
function RootPath() {
    var strFullPath = window.document.location.href;
    var strPath = window.document.location.pathname;
    var pos = strFullPath.indexOf(strPath);
    var prePath = strFullPath.substring(0, pos);
    var postPath = strPath.substring(0, strPath.substr(1).indexOf('/') + 1);
    //return (prePath + postPath);如果发布IIS，有虚假目录用用这句
    return (prePath);
}
//中间加载对话窗
function Loading(bool, text) {
    var ajaxbg = top.$("#loading_background,#loading");
    ajaxbg.css("z-index", "30000");
    if (!!text) {
        top.$("#loading").css("left", (top.$('body').width() - top.$("#loading").width()) / 2);
        top.$("#loading span").html(text);
    } else {
        top.$("#loading").css("left", "42%");
        top.$("#loading span").html("正在拼了命为您加载…");
    }
    if (bool) {
        ajaxbg.show();
    } else {
        ajaxbg.hide();
    }
}
/* 
请求Ajax 带返回值
*/
function GetAjax(url, postData, callBack) {
    jQuery.support.cors = true;
    $.ajax({
        type: 'post',
        dataType: "text",
        url: RootPath() + url,
        data: postData,
        cache: false,
        async: false,
        success: function (data) {
            callBack(data);
            //Loading(false);
        },
        error: function (data) {
            alert("error:" + JSON.stringify(data));
            Loading(false);
        }
    });
}
function AjaxJson(url, postData, callBack) {
    jQuery.support.cors = true;
    $.ajax({
        url: RootPath() + url,
        type: "post",
        data: postData,
        dataType: "json",
        async: false,
        success: function (data) {
            if (data.Code === "-1") {
                Loading(false);
                alertDialogDefault(data.Message);
            } else {
                Loading(false);
                callBack(data);
            }
        },
        error: function (data) {
            Loading(false);
            if (data.responseJSON.Message)
                alertDialogDefault(data.responseJSON.Message);
            else
                alertDialogDefault(data.responseText);
        }
    });
}
function AjaxJsonAsync(url, postData, callBack) {
    jQuery.support.cors = true;
    $.ajax({
        url: RootPath() + url,
        type: "post",
        data: postData,
        dataType: "json",
        async: true,
        success: function (data) {
            if (data.Code === "-1") {
                Loading(false);
                alertDialogDefault(data.Message);
            } else {
                Loading(false);
                callBack(data);
            }
        },
        error: function (data) {
            Loading(false);
            alertDialogDefault(data.responseText);
        }
    });
}
/*关闭对话框*/
function closeDialog() {
    $('#dd').dialog('close');
}
//关闭二级菜单
function closeTwoLevelDialog() {
    $('#dd2').dialog('close');
}
//提示框
function showDialog(title, msg, timeout, width, height) {
    $.messager.show({
        title: title,
        msg: msg,
        timeout: timeout,
        width: width,
        height: height,
        style: {
            right: '',
            top: document.body.scrollTop + document.documentElement.scrollTop,
            bottom: ''
        }

    });
}
function showDialogDefault(msg) {
   $.messager.show({
        title: "提示信息",
        msg: msg,
        timeout: 1000,
        width: 250,
        height: 100,
        style: {
            right: '',
            top: document.body.scrollTop + document.documentElement.scrollTop,
            bottom: ''
        }

    });
}
//警告框
function alertDialog(title, msg, timeout, width, height) {
    $.messager.alert({
        title: title,
        msg: msg,
        width: width,
        height: height
    });
}
//默认警告框
function alertDialogDefault(msg) {
    alertDialog("提示信息", msg, 3000, 300, 105);
}
//确认框
function confirmDialog(title, msg, callback) {
    $.messager.confirm(title, msg, function (result) {
        callback(result);
    });
}

function InitWin(winId,width,height) {
    $('#' + winId).dialog({
        title:"test",
        width: width,
        height: height,
        collapsible: false,
        minimizable: false,
        maximizable: false,
        resizable: false,
        modal: true,
        closed:true
    });
}

function OpenWin(winId, title) {
    $('#' + winId).dialog({ title: title });
    $('#' + winId).dialog('open');
}