function ShowBusyIndicator(divId) {
    if (divId == null || divId == undefined)
        divId = "main";
    try {
        $('#' + divId).waitMe({});
    }
    catch (err) {
        console.log(err);
    }

}
function HideBusyIndicator(divId) {
    if (divId == null || divId == undefined)
        divId = "main";
    try {
        $('#' + divId).waitMe('hide');
    }
    catch (err) {
        console.log(err);
    }

}
function ShowMessage(message, type, yesCallBack, NoCallBack) {
    if (type === "error")
        alertify.error(message);
    if (type === "success")
        alertify.success(message);
    if (type === "info")
        alertify.notify(message);
    if (type === "confirm") {
        // confirm dialog
        alertify.confirm("Hollywood Test", message,
            function () {
                if (yesCallBack)
                    yesCallBack();
            },
            function () {
                if (NoCallBack)
                    NoCallBack();
            });
    }
}