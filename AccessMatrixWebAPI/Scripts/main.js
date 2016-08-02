$(document).ready(function () {
    Init();
    //get client list
    $("#dd_locations").on('change', function () {
        var l = $("#dd_locations").val();
        
        GetClients(l);
    });

    //get program list
    $("#dd_clients").on('change', function () {
        var l = $("#dd_locations").val();
        var c = $("#dd_clients").val();

        GetPrograms(l, c);
    });

    //get department list
    $("#dd_programs").on('change', function () {
        var l = $("#dd_locations").val();
        var c = $("#dd_clients").val();
        var p = $("#dd_programs").val();


        GetDepartments(l, c, p);
    });

    //get role list
    $("#dd_departments").on('change', function () {
        var l = $("#dd_locations").val();
        var c = $("#dd_clients").val();
        var p = $("#dd_programs").val();
        var d = $("#dd_departments").val();

        GetRoles(l, c, p, d);
    });

    //get profile id and load profile
    $("#dd_roles").on('change', function () {
        var l = $("#dd_locations").val();
        var c = $("#dd_clients").val();
        var p = $("#dd_programs").val();
        var d = $("#dd_departments").val();
        var r = $("#dd_roles").val();

        GetProfile(l, c, p, d, r);
    });

    //save profile changes
    $("#b_save").click(function (e) {
        var Permissions = {
            profileid: $("#profile-id").val(),
            description: $("#profile-desc").val(),
            domainid: $("#ad-domain").val(),
            ou: $("#ad-ou").val() == '' ? '' : $("#ad-ou").val(),
            logonscript: $("#ad-loginscript").val(),
            profiledrive: $("#ad-profiledrive").val(),
            profilepath: $("#ad-profilepath").val(),
            membership: $("#ad-group").val(),
            changepw: $("#ad-changepass").prop('checked'),
            emaildid: $("#email-domain").val(),
            groupsmtp: $("#email-smtp").val(),
            hasemailforwarding: $("#email-email_forwarding").prop('checked'),
            haswebmail: $("#email-webmail").prop('checked'),
            hasactivesync: $("#ad-mobile_activesync").prop('checked'),
            workboothid: $("#others-workbooth").val(),
            vpnid: $("#others-vpn").val(),
            chatid: $("#others-chat").val(),
            hasfederation: $("#others-federation").prop('checked'),
            hasboxaccount: $("#others-box_acct").prop('checked'),
            remarks: $("#remarks").val()
        };
        
        //var json = JSON.stringify({ value: data });
        e.preventDefault();
        ShowBusy(1);

        $.ajax({
            type: "PUT",
            url: "/api/Permissions/" + $("#profile-id").val(),
            //contentType: "application/x-www-form-urlencode",
            data: Permissions,
            success: function (data) {
                ShowBusy(0);
                if(data == 200 )
                    Prompt(200, 'Ok. ', 1);
                else
                    Prompt(data, 'Error. ', 0);
            },
            error: function (jqXHR, exception) {
                Prompt(jqXHR, exception, 0);
                ShowBusy(1);

            }
        });
    });

    //reload form
    $("#b_cancel").click(function () {
        ClearUI();
        GetProfile( $("#dd_locations").val(), 
                    $("#dd_clients").val(), 
                    $("#dd_programs").val(), 
                    $("#dd_departments").val(), 
                    $("#dd_roles").val());
    });

    function ClearUI() {
        $("#profile-id").val("");
        $("#profile-desc").val("");
        $("#ad-domain").val("");
        $("#ad-ou").val("");
        $("#ad-loginscript").val("");
        GetProfileDrive(-1);
        $("#ad-profilepath").val("");
        $("#ad-group").val("");
        $("#ad-changepass").prop('checked', false);
        $("#email-domain").val("");
        $("#email-smtp").val("");
        $("#email-email_forwarding").prop('checked', false);
        $("#email-webmail").prop('checked', false);
        $("#ad-mobile_activesync").prop('checked', false);
        $("#others-workbooth").val("");
        $("#others-vpn").val("");
        $("#others-chat").val("");
        $("#others-federation").prop('checked', false);
        $("#others-box_acct").prop('checked', false);
        $("#remarks").val("");
    }

    function Init() {
        InitSelect();
        ShowBusy(0);
    }

    function InitSelect() {
        $("select").selectpicker({
            size: 8
        });

        //$("#incident-information select").selectpicker();
    }

    function InitTooltips() {
        $(".tooltips").tooltip({
            'trigger': 'hover focus'
        });
    } //inittooltips

    function ClearFilters() {
        $("#dd_clients").empty();
        $("#dd_programs").empty();
        $("#dd_departments").empty();
        $("#dd_roles").empty();
        //GetClients('');
        //GetPrograms('', '');
        //GetDepartments('', '', '');
        //GetRoles('', '', '', '');
    }

    function GetClients(loc) {
        var clients = $("#dd_clients");
        ClearFilters();
        ClearUI();
        if (loc !== "") {
            $.ajax({
                type: "GET",
                url: "/api/GetClients/" + loc,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    var _select = $('<select class="selectpicker">');
                    $.each(data, function (index, elem) {
                        _select.append(
                            $('<option></option>').val(elem.ClientID).html(elem.ClientName)
                        );
                    });
                    
                    clients.append(_select.html());
                    clients.selectpicker('refresh');
                },
                error: function (jqXHR, exception) {
                    Prompt(jqXHR, exception, 0);
                }
            });
        }
    }

    function GetPrograms(loc, cli) {
        var programs = $("#dd_programs");
        
        if ((loc !== "") && (cli !== "")) {

            $.ajax({
                type: "GET",
                url: "/api/Programs/" + loc + "/" + cli,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    var _select = $('<select class="selectpicker">');
                    $.each(data, function (index, elem) {
                        _select.append(
                            $('<option></option>').val(elem.ProgramID).html(elem.ProgramName)
                        );
                    });
                    programs.append(_select.html());
                    programs.selectpicker('refresh');
                },
                error: function (jqXHR, exception) {
                    Prompt(jqXHR, exception, 0);
                }
            });

        }
    }

    function GetDepartments(loc, cli, prog) {
        var depts = $("#dd_departments");
        
        if ((loc !== "") && (cli !== "") && (prog !== "")) {

            $.ajax({
                type: "GET",
                url: "/api/Departments/" + loc + "/" + cli + "/" + prog,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    var _select = $('<select class="selectpicker">');
                    $.each(data, function (index, elem) {
                        _select.append(
                            $('<option></option>').val(elem.DepartmentID).html(elem.DepartmentName)
                        );
                    });
                    depts.append(_select.html());
                    depts.selectpicker('refresh');
                },
                error: function (jqXHR, exception) {
                    Prompt(jqXHR, exception, 0);
                }
            });

        }
    }

    function GetRoles(loc, cli, prog, dept) {
        var roles = $("#dd_roles");

        if ((loc !== "") && (cli !== "") && (prog !== "") && (dept !== "")) {

            $.ajax({
                type: "GET",
                url: "/api/Roles/" + loc + "/" + cli + "/" + prog + "/" + dept,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    var _select = $('<select class="selectpicker">');
                    $.each(data, function (index, elem) {
                        _select.append(
                            $('<option></option>').val(elem.RoleID).html(elem.RoleName)
                        );
                    });
                    roles.append(_select.html());
                    roles.selectpicker('refresh');
                },
                error: function (jqXHR, exception) {
                    Prompt(jqXHR, exception, 0);
                }
            });

        }
    } //getroles end

    function GetProfile(loc, cli, prog, dept, role) {

        ShowBusy(1);
        ClearUI();

        $.ajax({
            type: "GET",
            url: "/api/Profiles/" + loc + "/" + cli + "/" + prog + "/" + dept + "/" + role,
            contentType: 'application/json; charset=utf-8',
            success: function (Profiledata) {
                ProfileGUI(Profiledata);
            },
            error: function (jqXHR, exception) {
                Prompt(jqXHR, exception, 0);
            }
        });
    }

    function GetDomains(DomainID) {
        var domains = $("#ad-domain");

        $.ajax({
            type: "GET",
            url: "/api/Domains/",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                var _select = $('<select class="selectpicker">');
                $.each(data, function (index, elem) {
                    if (elem.DomainID == DomainID)
                        _select.append(
                        $('<option selected></option>').val(elem.DomainID).html(elem.DomainAddress)
                        );
                    else
                        _select.append(
                            $('<option></option>').val(elem.DomainID).html(elem.DomainAddress)
                        );
                });
                domains.append(_select.html());
                domains.selectpicker('refresh');
            },
            error: function (jqXHR, exception) {
                Prompt(jqXHR, exception, 0);
            }
        });
    }

    function GetProfileDrive(ProfileDrive) {
        var profiledrive = $("#ad-profiledrive");
        if(ProfileDrive == -1)
            $('#ad-profiledrive option[value=' + ProfileDrive + ']').attr('selected', 'selected');
        else
            $('#ad-profiledrive option').attr('selected', false);
        profiledrive.selectpicker('refresh');
    }

    function GetEmailDomains(EmailDomainID) {
        var emaildomains = $("#email-domain");

        $.ajax({
            type: "GET",
            url: "/api/EmailDomains/",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                var _select = $('<select class="selectpicker">');
                $.each(data, function (index, elem) {
                    if (elem.EmailID == EmailDomainID)
                        _select.append(
                        $('<option selected></option>').val(elem.EmailID).html(elem.EmailDomain)
                    );
                    else
                        _select.append(
                        $('<option></option>').val(elem.EmailID).html(elem.EmailDomain)
                    );
                });
                emaildomains.append(_select.html());
                emaildomains.selectpicker('refresh');
            },
            error: function (jqXHR, exception) {
                Prompt(jqXHR, exception, 0);
            }
        });
    }

    function GetWorkbooths(WorkboothID) {
        var workbooths = $("#others-workbooth");

        $.ajax({
            type: "GET",
            url: "/api/WorkBooths/",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                var _select = $('<select class="selectpicker">');
                $.each(data, function (index, elem) {
                    if (elem.WorkboothID == WorkboothID)
                        _select.append(
                        $('<option selected></option>').val(elem.WorkboothID).html(elem.WorkboothName)
                    );
                    else
                        _select.append(
                        $('<option></option>').val(elem.WorkboothID).html(elem.WorkboothName)
                    );
                });
                workbooths.append(_select.html());
                workbooths.selectpicker('refresh');
            },
            error: function (jqXHR, exception) {
                Prompt(jqXHR, exception, 0);
            }
        });
    }
    function GetVPNs(VpnID) {
        var vpns = $("#others-vp");

        $.ajax({
            type: "GET",
            url: "/api/VPNs/",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                var _select = $('<select class="selectpicker">');
                $.each(data, function (index, elem) {
                    if (elem.VpnID == VpnID)
                        _select.append(
                        $('<option selected></option>').val(elem.VpnID).html(elem.VpnName)
                    );
                    else
                        _select.append(
                        $('<option></option>').val(elem.VpnID).html(elem.VpnName)
                    );
                });
                vpns.append(_select.html());
                vpns.selectpicker('refresh');
            },
            error: function (jqXHR, exception) {
                Prompt(jqXHR, exception, 0);
            }
        });
    }
    function GetChats(ChatID) {
        var chats = $("#others-chat");

        $.ajax({
            type: "GET",
            url: "/api/Chats/",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                var _select = $('<select class="selectpicker">');
                $.each(data, function (index, elem) {
                    if (elem.ChatID == ChatID)
                        _select.append(
                        $('<option selected></option>').val(elem.ChatID).html(elem.ChatName)
                    );
                    else
                        _select.append(
                        $('<option></option>').val(elem.ChatID).html(elem.ChatName)
                    );
                });
                chats.append(_select.html());
                chats.selectpicker('refresh');
            },
            error: function (jqXHR, exception) {
                Prompt(jqXHR, exception, 0);
            }
        });
    }


    function ProfileGUI(Profiledata) {
        $("#profile-id").val(Profiledata[0].ProfileID)
        $("#profile-desc").val(Profiledata[0].ProfileID)

        GetDomains(-1);
        GetEmailDomains(-1);
        GetWorkbooths(-1);
        GetVPNs(-1);
        GetChats(-1);

        var p_id = $("#profile-id").val();
        if (p_id !== "") {
            // Buttons
            $("#buttons").show();

            $.ajax({
                type: "GET",
                url: "/api/Permissions/" + Profiledata[0].ProfileID,
                contentType: 'application/json; charset=utf-8',
                success: function (Permissionsdata) {

                    $("#profile-desc").val(Permissionsdata[0].Description);

                    ShowBusy(0);
                    
                    // Permissions
                    GetDomains(Permissionsdata[0].DomainID);
                    $("#ad-ou").val(Permissionsdata[0].OU);
                    $("#ad-loginscript").val(Permissionsdata[0].LogonScript);
                    GetProfileDrive(Permissionsdata[0].ProfileDrive);
                    //$("#ad-profiledrive").val(Permissionsdata[0].ProfileDrive);
                    $("#ad-profilepath").val(Permissionsdata[0].ProfilePath);
                    $("#ad-group").val(Permissionsdata[0].Membership);
                    $("#ad-changepass").attr('checked', Permissionsdata[0].ChangePW);

                    // Email
                    GetEmailDomains(Permissionsdata[0].EmailID);
                    $("#email-smtp").val(Permissionsdata[0].GroupSMTP);
                    $("#email-email_forwarding").attr('checked', Permissionsdata[0].HasEmailForwarding);
                    $("#email-webmail").attr('checked', Permissionsdata[0].HasWebmail);
                    $("#ad-mobile_activesync").attr('checked', Permissionsdata[0].HasActiveSync);

                    // Others
                    GetWorkbooths(Permissionsdata[0].WorkboothID);
                    GetVPNs(Permissionsdata[0].VpnID);
                    GetChats(Permissionsdata[0].ChatID);
                    $("#others-federation").attr('checked', Permissionsdata[0].HasFederation);
                    $("#others-box_acct").attr('checked', Permissionsdata[0].HasBoxAccount);

                    // Remarks
                    $("#remarks").val(Permissionsdata[0].Remarks);

                },
                error: function (jqXHR, exception) {
                    Prompt(jqXHR, exception, 0);
                }

            });
        } else {
            $("#buttons").hide();
        }
    }

    function ShowBusy(status) {
        var gears = $("#busy");
        var settings = $("#f_permissions");
        var panel = $("#right-panel");

        if (status == 1) {
            settings.hide();
            panel.css("background-color", "white");
            gears.show();

        } else {
            settings.show();
            panel.css("background-color", "lightgray");
            gears.hide();
        }
    }

    function Prompt(jqXHR, exception, type) {
        if (jqXHR.status === 0) {
            exception += '\nNot connect.\n Verify Network.';
        } else if (jqXHR.status == 404) {
            //msg += '\nRequested page not found. [404]';
            exception += '\nNo data found. [404]';
        } else if (jqXHR.status == 500) {
            exception += '\nInternal Server Error [500].';
        } else if (exception === 'parsererror') {
            exception += '\nRequested JSON parse failed.';
        } else if (exception === 'timeout') {
            exception += '\nTime out error.';
        } else if (exception === 'abort') {
            exception += '\nAjax request aborted.';
        }else if(jqXHR == 200){
            exception += '\nData saved.';
        } else {
            exception += '\nUncaught Error.\n' + jqXHR.responseText;
        } 


        //type = type || 1;

        var msgbox = $("#msg");
        var a = "";
        var z = "</div>";

        if (type == 1) {
            a = '<div class="alert alert-success" role="alert">';
        } else {
            a = '<div class="alert alert-danger" role="alert">';
        }

        msgbox.html(a + exception + z).slideDown();
        window.scrollTo(0, 0);

        setTimeout(function () {
            msgbox.slideUp();

        }, 10000);
        ShowBusy(0);
    }
});