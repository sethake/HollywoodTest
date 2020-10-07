function Post(url, data, OnError, OnComplete) {

    var dataJson = JSON.stringify(data);
    $.ajax({
        url: url,
        type: 'POST',
        data: dataJson,
        dataType: 'text',
        contentType: 'application/json; charset=utf-8',
        error: function (jqXHR, testStatus, errorThrown) {
            if (OnError) { OnError(errorThrown); }
        },
        complete: function (result) {
            var apiResponse = JSON.parse(result.responseText);
            if (apiResponse.HttpResponseCode == 307) {
                ShowMessage("Your Session has expired we are redirecting you the login screen. please wait", "Session Expired", "info")
                setTimeout(function () {
                    location.reload();
                }, 6000);
            }
            else {
                if (OnComplete) { OnComplete(apiResponse); }
            }

        },
        timeout: 600000000 
    });
}