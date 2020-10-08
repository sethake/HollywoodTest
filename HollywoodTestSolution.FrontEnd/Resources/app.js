
hollywoodTest.controller("main", function ($scope) {
    $scope.AddNewTournament = function ($event) {
        var $form = $event.currentTarget.form;
        if (!$form.checkValidity || $form.checkValidity()) {
            $event.preventDefault();
            ShowBusyIndicator();
            var requestUrl = "/Home/AddTournament";
            if ($scope.NewTournament.TournamentID > 0)
                requestUrl = "/Home/UpdateTournament";
            Post(requestUrl, $scope.NewTournament, function (error) {
                HideBusyIndicator();
                ShowMessage(error, "error");
            }, function (apiResponse) {
                HideBusyIndicator();
                if (apiResponse.HttpResponseCode == 200) {
                    ShowMessage(apiResponse.ResponseMessage, "success", null, null);
                    if (requestUrl == "/Home/UpdateTournament") {
                        $scope.CancelTournamentEditMode();
                        $scope.GetTournaments();
                    }
                    else {
                        $scope.NewTournament = { TournamentID:0};
                        $("#TournamentModal").modal("hide");
                    }
                }
                else {
                    ShowMessage(apiResponse.ResponseMessage, "error");
                }
            });
        }
    };
    $scope.GetTournaments = function (OnComplete) {
            ShowBusyIndicator();
            Post("/Home/GetTournaments", null, function (error) {
                HideBusyIndicator();
                ShowMessage(error, "error");
            }, function (apiResponse) {
                HideBusyIndicator();
                    if (apiResponse.HttpResponseCode == 200) {
                        if (OnComplete) { OnComplete(JSON.parse(apiResponse.ResponseMessage)); }
                        else {
                            $scope.Tournaments = JSON.parse(apiResponse.ResponseMessage);
                            $scope.$digest();
                        }
                }
                else {
                    ShowMessage(apiResponse.ResponseMessage, "error");
                }
            });
    };
    $scope.DeleteTournament = function (tournament) {
        ShowMessage("Are you sure you want to delete this tournament ? this cannot be undone", "confirm", function () {
            ShowBusyIndicator();
            Post("/Home/DeleteTournament?tournamentId=" + tournament.TournamentID, null, function (error) {
                HideBusyIndicator();
                ShowMessage(error, "error");
            }, function (apiResponse) {
                HideBusyIndicator();
                if (apiResponse.HttpResponseCode == 200) {
                    ShowMessage(apiResponse.ResponseMessage, "confirm", function () { $scope.GetTournaments();}, function () {  $scope.GetTournaments();});
                }
                else {
                    ShowMessage(apiResponse.ResponseMessage, "error");
                }
            });
        }, null);
    };
    $scope.LaunchAddNewTournamentDialog = function () {
        $scope.NewTournament = { TournamentID:0};
        $scope.SearchTournament = "";
        $scope.TournamentaddEditMode = true;
        $("#TournamentModal").modal("show");
    };
    $scope.CancelTournamentEditMode = function () {
        $scope.NewTournament = {};
        $scope.SearchTournament = "";
        $scope.TournamentaddEditMode = false;
    };
    $scope.EditTournament = function (tournament) {
        $scope.NewTournament = {};
        Object.assign($scope.NewTournament, tournament);
        $scope.SearchTournament = "";
        $scope.TournamentaddEditMode = true;
        $("#TournamentModal").modal("show");
    };
    $scope.LaunchViewTournaments = function () {
        $scope.NewTournament = {};
        $scope.SearchTournament = "";
        $scope.TournamentaddEditMode = false;
        $scope.Tournaments = [];
        $("#TournamentModal").modal("show");
        $scope.GetTournaments(function (tournaments) {
            $scope.Tournaments = tournaments;
            $scope.$digest();
        });
    };

    //***************Events**********************************
    $scope.AddNewEvent = function ($event) {
        var $form = $event.currentTarget.form;
        if (!$form.checkValidity || $form.checkValidity()) {
            $event.preventDefault();
            ShowBusyIndicator();
            var requestUrl = "/Home/AddEvent";
            if ($scope.NewEvent.EventID > 0)
                requestUrl = "/Home/UpdateEvent";
            Post(requestUrl, $scope.NewEvent, function (error) {
                HideBusyIndicator();
                ShowMessage(error, "error");
            }, function (apiResponse) {
                HideBusyIndicator();
                if (apiResponse.HttpResponseCode == 200) {
                    ShowMessage(apiResponse.ResponseMessage, "success", null, null);
                    if (requestUrl == "/Home/UpdateEvent") {
                        $scope.CancelEventEditMode();
                        $scope.GetEvents();
                    }
                    else {
                        $scope.NewEvent = { EventID: 0 };
                        $("#EventModal").modal("hide");
                    }
                }
                else {
                    ShowMessage(apiResponse.ResponseMessage, "error");
                }
            });
        }
    };
    $scope.GetEvents = function (OnComplete, tournamentId) {
        if (tournamentId == null || tournamentId === undefined)
            tournamentId = 0;
        ShowBusyIndicator();
        Post("/Home/GetEvents?tournamentId=" + tournamentId, null, function (error) {
            HideBusyIndicator();
            ShowMessage(error, "error");
        }, function (apiResponse) {
            HideBusyIndicator();
            if (apiResponse.HttpResponseCode == 200) {
                if (OnComplete) { OnComplete(JSON.parse(apiResponse.ResponseMessage)); }
                else {
                    $scope.Events = JSON.parse(apiResponse.ResponseMessage);
                    $scope.$digest();
                }
            }
            else {
                ShowMessage(apiResponse.ResponseMessage, "error");
            }
        });
    };
    $scope.DeleteEvent = function (Event) {
        ShowMessage("Are you sure you want to delete this Event ? this cannot be undone", "confirm", function () {
            ShowBusyIndicator();
            Post("/Home/DeleteEvent?EventId=" + Event.EventID, null, function (error) {
                HideBusyIndicator();
                ShowMessage(error, "error");
            }, function (apiResponse) {
                HideBusyIndicator();
                if (apiResponse.HttpResponseCode == 200) {
                    ShowMessage(apiResponse.ResponseMessage, "confirm", function () { $scope.GetEvents(); }, function () { $scope.GetEvents(); });
                }
                else {
                    ShowMessage(apiResponse.ResponseMessage, "error");
                }
            });
        }, null);
    };
    $scope.LaunchAddNewEventDialog = function () {
        $scope.NewEvent = { EventID: 0 };
        $scope.SearchEvent = "";
        $scope.EventaddEditMode = true;
        $scope.Tournaments = [];
        $("#EventModal").modal("show");
        $scope.GetTournaments(function (tournaments) {
            $scope.Tournaments = tournaments;
            $scope.$digest();
        });
    };
    $scope.CancelEventEditMode = function () {
        $scope.NewEvent = {};
        $scope.SearchEvent = "";
        $scope.EventaddEditMode = false;
    };
    $scope.EditEvent = function (Event) {
        $scope.NewEvent = {}; 
        Object.assign($scope.NewEvent, Event);
        
        $scope.SearchEvent = "";
        $scope.EventaddEditMode = true;
        $("#EventModal").modal("show");
        $scope.GetTournaments(function (tournaments) {
            $scope.Tournaments = tournaments;
            $("#EventDateTime").val(Event.EventDateTime);
            $("#EventEndDateTime").val(Event.EventEndDateTime);
            $scope.$digest();
        });
    };
    $scope.LaunchViewEvents = function () {
        $scope.NewEvent = {};
        $scope.SearchEvent = "";
        $scope.EventaddEditMode = false;
        $scope.Events = [];
        $("#EventModal").modal("show");
        $scope.GetEvents(function (Events) {
            $scope.Events = Events;
            $scope.$digest();
        });
    };
   //******************Event Detail
    $scope.AddNewEventDetail = function ($event) {
        var $form = $event.currentTarget.form;
        if (!$form.checkValidity || $form.checkValidity()) {
            $event.preventDefault();
            ShowBusyIndicator();
            var requestUrl = "/Home/AddEventDetail";
            if ($scope.NewEventDetail.EventDetailID > 0)
                requestUrl = "/Home/UpdateEventDetail";
            Post(requestUrl, $scope.NewEventDetail, function (error) {
                HideBusyIndicator();
                ShowMessage(error, "error");
            }, function (apiResponse) {
                HideBusyIndicator();
                if (apiResponse.HttpResponseCode == 200) {
                    ShowMessage(apiResponse.ResponseMessage, "success", null, null);
                    if (requestUrl == "/Home/UpdateEventDetail") {
                        $scope.CancelEventDetailEditMode();
                        $scope.GetEventDetails();
                    }
                    else {
                        $scope.NewEventDetail = { EventDetailID: 0 };
                        $("#EventDetailModal").modal("hide");
                    }
                }
                else {
                    ShowMessage(apiResponse.ResponseMessage, "error");
                }
            });
        }
    };
    $scope.GetEventDetails = function (OnComplete, eventId) {
        if (eventId === null || eventId === undefined)
            eventId = 0;
        ShowBusyIndicator();
        Post("/Home/GetEventDetails?eventId=" + eventId, null, function (error) {
            HideBusyIndicator();
            ShowMessage(error, "error");
        }, function (apiResponse) {
            HideBusyIndicator();
            if (apiResponse.HttpResponseCode == 200) {
                if (OnComplete) { OnComplete(JSON.parse(apiResponse.ResponseMessage)); }
                else {
                    $scope.EventDetails = JSON.parse(apiResponse.ResponseMessage);
                    $scope.$digest();
                }
            }
            else {
                ShowMessage(apiResponse.ResponseMessage, "error");
            }
        });
    };
    $scope.DeleteEventDetail = function (EventDetail) {
        ShowMessage("Are you sure you want to delete this EventDetail ? this cannot be undone", "confirm", function () {
            ShowBusyIndicator();
            Post("/Home/DeleteEventDetail?EventDetailId=" + EventDetail.EventDetailID, null, function (error) {
                HideBusyIndicator();
                ShowMessage(error, "error");
            }, function (apiResponse) {
                HideBusyIndicator();
                if (apiResponse.HttpResponseCode == 200) {
                    ShowMessage(apiResponse.ResponseMessage, "confirm", function () { $scope.GetEventDetails(); }, function () { $scope.GetEventDetails(); });
                }
                else {
                    ShowMessage(apiResponse.ResponseMessage, "error");
                }
            });
        }, null);
    };
    $scope.LaunchAddNewEventDetailDialog = function () {
        $scope.NewEventDetail = { EventDetailID: 0 };
        $scope.SearchEventDetail = "";
        $scope.EventDetailaddEditMode = true;
        $scope.Tournaments = [];
        $scope.Events = [];
        $("#EventDetailModal").modal("show");
        $scope.GetTournaments(function (tournaments) {
            $scope.Tournaments = tournaments;
            $scope.GetEventDetailStatuses(function (eventDetailStatuses) {
                $scope.EventDetailStatuses = eventDetailStatuses;
                $scope.$digest();
            });
            
        });
    };
   
    $scope.CancelEventDetailEditMode = function () {
        $scope.NewEventDetail = {};
        $scope.SearchEventDetail = "";
        $scope.EventDetailaddEditMode = false;
    };
    $scope.EditEventDetail = function (EventDetail) {
        $scope.NewEventDetail = {};
        Object.assign($scope.NewEventDetail, EventDetail);
        
        $scope.SearchEventDetail = "";
        $scope.EventDetailaddEditMode = true;
        $("#EventDetailModal").modal("show");
        $scope.GetTournaments();
        $scope.GetEventDetailStatuses(function (eventDetailStatuses) {
            $scope.EventDetailStatuses = eventDetailStatuses;
            $scope.GetEvents(null, $scope.NewEventDetail.FK_TournamentID);
            $scope.$digest();
        });
    };
    $scope.LaunchViewEventDetails = function () {
        $scope.NewEventDetail = {};
        $scope.SearchEventDetail = "";
        $scope.EventDetailaddEditMode = false;
        $scope.EventDetails = [];
        $("#EventDetailModal").modal("show");
        $scope.GetEventDetails(function (EventDetails) {
            $scope.EventDetails = EventDetails;
            $scope.$digest();
        });
    };
    //**********************Event Detail Status
    $scope.AddNewEventDetailStatus = function ($event) {
        var $form = $event.currentTarget.form;
        if (!$form.checkValidity || $form.checkValidity()) {
            $event.preventDefault();
            ShowBusyIndicator();
            var requestUrl = "/Home/AddEventDetailStatus";
            if ($scope.NewEventDetailStatus.EventDetailStatusID > 0)
                requestUrl = "/Home/UpdateEventDetailStatus";
            Post(requestUrl, $scope.NewEventDetailStatus, function (error) {
                HideBusyIndicator();
                ShowMessage(error, "error");
            }, function (apiResponse) {
                HideBusyIndicator();
                if (apiResponse.HttpResponseCode == 200) {
                    ShowMessage(apiResponse.ResponseMessage, "success", null, null);
                    if (requestUrl == "/Home/UpdateEventDetailStatus") {
                        $scope.CancelEventDetailStatusEditMode();
                        $scope.GetEventDetailStatuses();
                    }
                    else {
                        $scope.NewEventDetailStatus = { EventDetailStatusID: 0 };
                        $("#EventDetailStatusModal").modal("hide");
                    }
                }
                else {
                    ShowMessage(apiResponse.ResponseMessage, "error");
                }
            });
        }
    };
    $scope.GetEventDetailStatuses = function (OnComplete) {
        ShowBusyIndicator();
        Post("/Home/GetEventDetailStatuses", null, function (error) {
            HideBusyIndicator();
            ShowMessage(error, "error");
        }, function (apiResponse) {
            HideBusyIndicator();
            if (apiResponse.HttpResponseCode == 200) {
                if (OnComplete) { OnComplete(JSON.parse(apiResponse.ResponseMessage)); }
                else {
                    $scope.EventDetailStatuses = JSON.parse(apiResponse.ResponseMessage);
                    $scope.$digest();
                }
            }
            else {
                ShowMessage(apiResponse.ResponseMessage, "error");
            }
        });
    };
    $scope.DeleteEventDetailStatus = function (EventDetailStatus) {
        ShowMessage("Are you sure you want to delete this EventDetailStatus ? this cannot be undone", "confirm", function () {
            ShowBusyIndicator();
            Post("/Home/DeleteEventDetailStatus?EventDetailStatusId=" + EventDetailStatus.EventDetailStatusID, null, function (error) {
                HideBusyIndicator();
                ShowMessage(error, "error");
            }, function (apiResponse) {
                HideBusyIndicator();
                    if (apiResponse.HttpResponseCode == 200) {
                        ShowMessage(apiResponse.ResponseMessage, "confirm", function () { $scope.GetEventDetailStatuses(); }, function () { $scope.GetEventDetailStatuses(); });
                }
                else {
                    ShowMessage(apiResponse.ResponseMessage, "error");
                }
            });
        }, null);
    };
    $scope.LaunchAddNewEventDetailStatusDialog = function () {
        $scope.NewEventDetailStatus = { EventDetailStatusID: 0 };
        $scope.SearchEventDetailStatus = "";
        $scope.EventDetailStatusaddEditMode = true;
        $("#EventDetailStatusModal").modal("show");
    };
    $scope.CancelEventDetailStatusEditMode = function () {
        $scope.NewEventDetailStatus = {};
        $scope.SearchEventDetailStatus = "";
        $scope.EventDetailStatusaddEditMode = false;
    };
    $scope.EditEventDetailStatus = function (EventDetailStatus) {
        $scope.NewEventDetailStatus = {};
        Object.assign($scope.NewEventDetailStatus, EventDetailStatus);
        $scope.SearchEventDetailStatus = "";
        $scope.EventDetailStatusaddEditMode = true;
        $("#EventDetailStatusModal").modal("show");
    };
    $scope.LaunchViewEventDetailStatuses = function () {
        $scope.NewEventDetailStatus = {};
        $scope.SearchEventDetailStatus = "";
        $scope.EventDetailStatusaddEditMode = false;
        $scope.EventDetailStatuss = [];
        $("#EventDetailStatusModal").modal("show");
        $scope.GetEventDetailStatuses(function (EventDetailStatuses) {
            $scope.EventDetailStatuses = EventDetailStatuses;
            $scope.$digest();
        });
    };
    
});