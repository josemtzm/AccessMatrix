$(document).ready(function () {
    var Profile = {
        ProfileID: -1,
        LocationID: "",
        LocationName: "",
        ClientID: "",
        ClientName: "",
        ProjectID: "",
        ProjectName: "",
        DepartmentID: "",
        DepartmentName: "",
        RoleID: "",
        RoleName: "",
    };
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
        var d = $("#f_permissions").serialize();

        e.preventDefault();
        ShowBusy(1);

        $.ajax({
            type: "POST",
            url: "set/save.php",
            data: d

        }).done(function (html) {
            Prompt(html);
            ShowBusy(0);
        });

    });

    //reload form
    $("#b_cancel").click(function () {
        GetProfile();
    });

    function Init() {
        InitSelect();
    }

    function FillPermissions() {

    }

    function FillProfile() {

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

    function GetClients(loc) {
        var clients = $("#dd_clients");

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
                }
            });

        }
    } //getroles end

    function GetProfile(loc, cli, prog, dept, role) {

        ShowBusy(1);

        var Profile = {
            ProfileID: -1,
            LocationID: "",
            LocationName: "",
            ClientID: "",
            ClientName: "",
            ProjectID: "",
            ProjectName: "",
            DepartmentID: "",
            DepartmentName: "",
            RoleID: "",
            RoleName: ""
        };

        $.ajax({
            type: "GET",
            url: "/api/Profiles/" + loc + "/" + cli + "/" + prog + "/" + dept + "/" + role,
            contentType: 'application/json; charset=utf-8',
            success: function (Profiledata) {
                Profile = {
                    ProfileID: Profiledata[0].ProfileID,
                    LocationID: Profiledata[0].LocationID,
                    LocationName: Profiledata[0].LocationName,
                    ClientID: Profiledata[0].ClientID,
                    ClientName: Profiledata[0].ClientName,
                    ProjectID: Profiledata[0].ProjectID,
                    ProjectName: Profiledata[0].ProjectName,
                    DepartmentID: Profiledata[0].DepartmentID,
                    DepartmentName: Profiledata[0].DepartmentName,
                    RoleID: Profiledata[0].RoleID,
                    RoleName: Profiledata[0].RoleName,
                };
                $.ajax({
                    type: "GET",
                    url: "/api/Permissions/" + Profile.ProfileID,
                    contentType: 'application/json; charset=utf-8',
                    success: function (Permissionsdata) {

                        $("#f_permissions").html(Permissionsdata);
                        ShowBusy(0);
                        var p_id = $("#profile-id").val();

                        if (p_id !== "") {
                            $("#buttons").show();
                        } else {
                            $("#buttons").hide();
                        }
                    }
                });

                //$("#f_permissions").html(data);
                //ShowBusy(0);
                //var p_id = $("#profile-id").val();

                //if (p_id !== "") {
                //    $("#buttons").show();
                //} else {
                //    $("#buttons").hide();
                //}
            }
        });

        //$.ajax({
        //    type: "GET",
        //    url: "/api/Permissions/" + profile,
        //    contentType: 'application/json; charset=utf-8',
        //    success: function (data) {
        //        $("#f_permissions").html(data);
        //        ShowBusy(0);
        //        var p_id = $("#profile-id").val();

        //        if (p_id !== "") {
        //            $("#buttons").show();
        //        } else {
        //            $("#buttons").hide();
        //        }
        //    }
        //});

        //$.ajax({
        //    type: "POST",
        //    url: "get/profile.php",
        //    data: {
        //        location: l,
        //        client: c,
        //        program: p,
        //        department: d,
        //        role: r
        //    }
        //}).done(function (e) {
        //    $("#f_permissions").html(e);

        //    ShowBusy(0);

        //    var p_id = $("#profile-id").val();

        //    if (p_id !== "") {
        //        $("#buttons").show();
        //    } else {
        //        $("#buttons").hide();
        //    }

        //}).always(function (e) {
        //    ShowBusy(0);
        //});


    } //getprofile end

    function ShowBusy(status) {
        var gears = $("#busy");
        var settings = $("#f_permissions");

        if (status == 1) {
            settings.hide();
            gears.show();

        } else {
            settings.show();
            gears.hide();
        }
    }

    function Prompt(msg, type) {
        type = type || 1;

        var msgbox = $("#msg");
        var a = "";
        var z = "</div>";

        if (type == 1) {
            a = '<div class="alert alert-success" role="alert">';
        } else {
            a = '<div class="alert alert-danger" role="alert">';
        }

        msgbox.html(a + msg + z).slideDown();
        window.scrollTo(0, 0);

        setTimeout(function () {
            msgbox.slideUp();

        }, 10000);
    }
});