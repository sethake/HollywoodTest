hollywoodTest.controller("auth", function ($scope) {
    $scope.Authorise = function ($event) {
        var $form = $event.currentTarget.form;
        if (!$form.checkValidity || $form.checkValidity()) {
            $event.preventDefault();
            ShowBusyIndicator('formContent');
            Post("/Account/Authorise", $scope.AuthRequest, function (error) {
                HideBusyIndicator('formContent');
                ShowMessage(error, "error");
            }, function (apiResponse) {
                HideBusyIndicator('formContent');
                if (apiResponse.HttpResponseCode === 200) {
                    var authResponse = JSON.parse(apiResponse.ResponseMessage);
                    if (authResponse.Succeeded === true)
                        location.assign("/");
                    else
                        ShowMessage(authResponse.ResponseMessage, "error");
                }
                else {
                    ShowMessage(apiResponse.ResponseMessage, "error");
                }
            });
        }
    };

});