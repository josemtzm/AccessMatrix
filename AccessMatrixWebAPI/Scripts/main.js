$(document).ready(function () {
    Init();
    
    //get program list
    $("#dd_clients").on('change', function () {
        var l = $("#dd_locations").val();
        var c = $("#dd_clients").val();

        GetPrograms(l, c);
    });

    //get project list
    $("#dd_programs").on('change', function () {
        var l = $("#dd_locations").val();
        var c = $("#dd_clients").val();
        var p = $("#dd_programs").val();


        GetProjects(l, c, p);
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

    $('.sec_group').on("select2:select", function (data) {
        var itemFound = false;
        var ul = $("#ad-group");
        var li = $('<li/>').text(data.params.data.text).val(data.params.data.SEC_GRP_ID).on("click", function () { $(this).remove() });
        ul.each(function () {
            if ($(this).text() === data.params.data.text)
                itemFound = true;
        });

        if (!itemFound)
            ul.prepend(li);
        else
            Prompt('', 'Security group is already added', 1);
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
        //ShowBusy(1);

        $('#dd_programs').prop('disabled', 'disabled');
        $('#dd_projects').prop('disabled', 'disabled');
        $('#dd_roles').prop('disabled', 'disabled');

        GetChats();
        //GetSecutityGroups();

        var locations = $("#dd_locations");

        $.ajax({
            type: "GET",
            url: "/api/Locations",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                var _select = $('<select class="selectpicker">');
                $.each(data, function (index, elem) {
                    _select.append(
                        $('<option></option>').val(elem.LocationID).html(elem.LocationName)
                    );
                });

                locations.append(_select.html());
                locations.selectpicker('refresh');
            },
            error: function (jqXHR, exception) {
                Prompt(jqXHR, exception, 0);
            }
        });

        var clients = $("#dd_clients");

        $.ajax({
            type: "GET",
            url: "/api/Clients",
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

        var depts = $("#dd_departments");

        $.ajax({
            type: "GET",
            url: "/api/Departments",
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

        $(".sec_group").select2({
            placeholder: "Domain\\Group Name",
            minimumInputLength: 1,
            multiple: true,
            quietMillis: 100,
            ajax: {
                url: "/api/SecurityGroups/",
                dataType: 'json',
                type: 'GET',
                //delay: 250,
                data: function (params) {
                    return {
                        term: params.term, // search term
                        //page: params.page
                    };
                },
                processResults: function (data, params) {
                    // parse the results into the format expected by Select2
                    // since we are using custom formatting functions we do not need to
                    // alter the remote JSON data, except to indicate that infinite
                    // scrolling can be used
                    params.page = params.page || 1;

                    var select2Data = $.map(data, function (obj) {
                        obj.id = obj.SEC_GRP_ID;
                        obj.text = obj.DOMAIN_NAME + '\\' + obj.SEC_GROUP_NAME

                        return obj;
                    });

                    return {
                        results: select2Data,
                        pagination: {
                            more: (params.page * 10) < data.length
                        }
                    };
                },
                cache: true
            },
            //templateResult: formatRepo, 
            templateSelection: formatRepoSelection
        });

        ShowBusy(0);
    }

    //function formatRepo(repo) {
    //    if (repo.loading) return repo.text;

    //    var markup = repo.DOMAIN_NAME + '\\' + repo.SEC_GROUP_NAME;

    //    //var markup = "<div class='select2-result-repository clearfix'>" +
    //    //    repo.DOMAIN_NAME + '\\' + repo.SEC_GROUP_NAME + "</div>";

    //    return markup;
    //}

    function formatRepoSelection(repo) {
        return repo.DOMAIN_NAME || repo.SEC_GROUP_NAME;
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
        //$("#dd_programs-button").tooltip({ items: "span", content: 'This is select' });
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
        
        if (loc !== "" && loc !== undefined) {
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

        //ClearUI();
        programs.empty();

        if ((loc !== "" && loc !== undefined) && (cli !== "" && cli !== undefined)) {

            $.ajax({
                type: "GET",
                url: "/api/Programs/" + loc + "/" + cli,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    programs.prop('disabled', false);
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
        else if (cli !== "" || cli !== undefined) {
            $.ajax({
                type: "GET",
                url: "/api/GetPrograms/" + cli,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    programs.prop('disabled', false);
                    var _select = $('<select class="selectpicker">');
                    $.each(data, function (index, elem) {
                        _select.append(
                            $('<option></option>').val(elem.ProgramID).html(elem.ProgramName)
                        );
                    });li
                    programs.append(_select.html());
                    programs.selectpicker('refresh');
                },
                error: function (jqXHR, exception) {
                    Prompt(jqXHR, exception, 0);
                }
            }); 
        }
        else {
            Prompt('', 'Select a client', 0);
        }
    }

    function GetProjects(loc, cli, prog) {
        var projects = $("#dd_projects");

        projects.empty();

        if ((loc !== "" && loc !== undefined) && (cli !== "" && cli !== undefined) && (prog !== "" && prog !== undefined)) {

            $.ajax({
                type: "GET",
                url: "/api/Projects/" + loc + "/" + cli + "/" + prog,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    projects.prop('disabled', false);
                    var _select = $('<select class="selectpicker">');
                    $.each(data, function (index, elem) {
                        _select.append(
                            $('<option></option>').val(elem.ProjectID).html(elem.ProjectName)
                        );
                    });
                    projects.append(_select.html());
                    projects.selectpicker('refresh');
                },
                error: function (jqXHR, exception) {
                    Prompt(jqXHR, exception, 0);
                }
            });
        }
        else if (prog !== "" || prog !== undefined) {
            $.ajax({
                type: "GET",
                url: "/api/GetProjects/" + prog,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    projects.prop('disabled', false);
                    var _select = $('<select class="selectpicker">');
                    $.each(data, function (index, elem) {
                        _select.append(
                            $('<option></option>').val(elem.ProjectID).html(elem.ProjectName)
                        );
                    });
                    projects.append(_select.html());
                    projects.selectpicker('refresh');
                },
                error: function (jqXHR, exception) {
                    Prompt(jqXHR, exception, 0);
                }
            });
        }
        else {
            Prompt('', 'Select a program', 0);
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

        roles.empty();

        if ((loc !== "" && loc !== undefined) && (cli !== "" && cli !== undefined) && (prog !== "" && prog !== undefined) && (dept !== "" && dept !== undefined)) {

            $.ajax({
                type: "GET",
                url: "/api/Roles/" + loc + "/" + cli + "/" + prog + "/" + dept,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    roles.prop('disabled', false);
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

        } else if (dept !== '' && dept !== undefined) {
            $.ajax({
                type: "GET",
                url: "/api/GetRoles/" + dept,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    roles.prop('disabled', false);
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
        else{
            Prompt('', 'Select a department', 0);
        }
    }

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
            $('#ad-profiledrive option').prop('selected', false);
        else
            $('#ad-profiledrive option[value=' + ProfileDrive + ']').prop('selected', true);
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
        //var _divChat = $("#others-chat");

        //$.ajax({
        //    type: "GET",
        //    url: "/api/Chats/",
        //    contentType: 'application/json; charset=utf-8',
        //    success: function (data) {
        //        $.each(data, function (index, elem) {
        //            if (elem.ChatID == ChatID)
        //                _divChat.append(
        //                $('<input selected id="' + elem.ChatName + '" type="radio" ' + elem.ChatID + '></input>'));
        //            else
        //                _divChat.append(
        //                $('<input id="' + elem.ChatName + '" type="radio" ' + elem.ChatID + '></input>'));
        //        });
        //        _divChat.append(_divChat.html());
        //        _divChat.selectpicker('refresh');
        //    },
        //    error: function (jqXHR, exception) {
        //        Prompt(jqXHR, exception, 0);
        //    }
        //});
    }

    //function GetChats() {
    //    var _divChat = $("#others-chat");

    //    $.ajax({
    //        type: "GET",
    //        url: "/api/Chats/",
    //        contentType: 'application/json; charset=utf-8',
    //        success: function (data) {
    //            $.each(data, function (index, elem) {
    //                    _divChat.append(
    //                    $('<input id="' + elem.ChatName + '" type="checkbox" ' + elem.ChatID + '>' + elem.ChatName + '</input>'));
    //            });
    //        },
    //        error: function (jqXHR, exception) {
    //            Prompt(jqXHR, exception, 0);
    //        }
    //    });
    //}


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
                    $("#ad-changepass").prop('checked', Permissionsdata[0].ChangePW);

                    // Email
                    GetEmailDomains(Permissionsdata[0].EmailID);
                    $("#email-smtp").val(Permissionsdata[0].GroupSMTP);
                    $("#email-email_forwarding").prop('checked', Permissionsdata[0].HasEmailForwarding);
                    $("#email-webmail").prop('checked', Permissionsdata[0].HasWebmail);
                    $("#ad-mobile_activesync").prop('checked', Permissionsdata[0].HasActiveSync);

                    // Others
                    GetWorkbooths(Permissionsdata[0].WorkboothID);
                    GetVPNs(Permissionsdata[0].VpnID);
                    GetChats(Permissionsdata[0].ChatID);
                    $("#others-federation").prop('checked', Permissionsdata[0].HasFederation);
                    $("#others-box_acct").prop('checked', Permissionsdata[0].HasBoxAccount);

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
            panel.css("display", "none");
            panel.css("background-color", "white");
            gears.show();

        } else {
            settings.show();
            panel.css("background-color", "lightgray");
            panel.css("display", "block");
            gears.hide();
        }
    }

    function Prompt(jqXHR, exception, type) {
        exception.toUpperCase();
        if (jqXHR.status === 0) {
            exception += '\nNot connect.\n Verify Network.';
        } else if (jqXHR.status == 404) {
            //msg += '\nRequested page not found. [404]';
            exception += '. \nNo data found. [404]';
        } else if (jqXHR.status == 500) {
            exception += '. \nInternal Server Error [500].';
        } else if (exception === 'parsererror') {
            exception += '. \nRequested JSON parse failed.';
        } else if (exception === 'timeout') {
            exception += '. \nTime out error.';
        } else if (exception === 'abort') {
            exception += '. \nAjax request aborted.';
        }else if(jqXHR == 200){
            exception += '. \nData saved.';
        } else if (jqXHR === '' || jqXHR === undefined) {
            exception += '';
        } else {
            exception += '. \nUncaught Error.\n' + jqXHR.responseText;
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