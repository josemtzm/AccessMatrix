$(function(){

	InitSelect();     //initialize selects
	GetProfile();

	//get client list
	$("#dd_locations").on('change', function(){
		var l = $("#dd_locations").val();

		GetClients(l);
	});

	//get program list
	$("#dd_clients").on('change', function(){
		var l = $("#dd_locations").val();
		var c = $("#dd_clients").val();

		GetPrograms(l, c);
	});

	//get department list
	$("#dd_programs").on('change', function(){
		var l = $("#dd_locations").val();
		var c = $("#dd_clients").val();
		var p = $("#dd_programs").val();


		GetDepartments(l, c, p);
	});

	//get role list
	$("#dd_departments").on('change', function(){
		var l = $("#dd_locations").val();
		var c = $("#dd_clients").val();
		var p = $("#dd_programs").val();
		var d = $("#dd_departments").val();

		GetRoles(l, c, p, d);
	});

	//get profile id and load profile
	$("#dd_roles").on('change', function(){
		var l = $("#dd_locations").val();
		var c = $("#dd_clients").val();
		var p = $("#dd_programs").val();
		var d = $("#dd_departments").val();
		var r = $("#dd_roles").val();

		GetProfile(l, c, p, d, r);
	});

	//save profile changes
	$("#b_save").click(function(e){
		var d = $("#f_permissions").serialize();

		e.preventDefault();
		ShowBusy(1);

		$.ajax({
			type: "POST",
			url: "set/save.php",
			data: d

		}).done(function(html){
			Prompt(html);
			ShowBusy(0);
		});

		
	});

	//reload form
	$("#b_cancel").click(function(){
		GetProfile();
	});

});


function InitSelect(){
	$("select").selectpicker({
		size: 8
	});

	//$("#incident-information select").selectpicker();
}

function InitTooltips(){
	$(".tooltips").tooltip({
		'trigger':'hover focus'
	});
} //inittooltips





function GetClients(l){
	var clients = $("#dd_clients");

	if(l!==""){	
		$.ajax({
			type: "POST",
			url:  "get/clients.php",
			data: {id:l}

		}).done(function(html){
			clients.html(html).selectpicker('refresh');
		});				
	}
} //getclients end

function GetPrograms(l, c){
	var programs = $("#dd_programs");

	if((l!=="")&&(c!=="")){

		$.ajax({
			type: "POST",
			url: "get/programs.php",
			data: {
				location:l,
				client:c
			}

		}).done(function(e){			
			programs.html(e).selectpicker('refresh');
		});		
		
	}
} //getprograms end

function GetDepartments(l, c, p){
	var departments = $("#dd_departments");

	if((l!=="")&&(c!=="")&&(p!=="")){

		$.ajax({
			type: "POST",
			url: "get/departments.php",
			data: {
				location:l,
				client:c,
				program:p
			}

		}).done(function(html){			
			departments.html(html).selectpicker('refresh');
		});		
		
	}
} //getdepartment end

function GetRoles(l, c, p, d){
	var roles = $("#dd_roles");

	if((l!=="")&&(c!=="")&&(p!=="")&&(d!=="")){

		$.ajax({
			type: "POST",
			url: "get/roles.php",
			data: {
				location:l,
				client:c,
				program:p,
				department:d
			}

		}).done(function(html){
			roles.html(html).selectpicker('refresh');
		});		
		
	}
} //getroles end

function GetProfile(l, c, p, d, r){

	ShowBusy(1);

	$.ajax({
		type: "POST",
		url: "get/profile.php",
		data: {
			location:l,
			client:c,
			program:p,
			department:d,
			role:r
		}
	}).done(function(e){
		$("#f_permissions").html(e);

		ShowBusy(0);

		var p_id = $("#profile-id").val();

		if(p_id!==""){
			$("#buttons").show();
		}else{
			$("#buttons").hide();
		}

	}).always(function(e){
		ShowBusy(0);
	});	

	



} //getprofile end




function ShowBusy(status){
	var gears = $("#busy");
	var settings = $("#f_permissions");

	if(status == 1){
		settings.hide();
		gears.show();

	}else{		
		settings.show();
		gears.hide();
	}
} //showbusy end


function Prompt(msg, type){
	type = type || 1;

	var msgbox = $("#msg");
	var a = "";
	var z = "</div>";

	if(type==1){
		a = '<div class="alert alert-success" role="alert">';
	}else{
		a = '<div class="alert alert-danger" role="alert">';
	}

	msgbox.html(a+msg+z).slideDown();
	window.scrollTo(0,0);

	setTimeout(function(){
		msgbox.slideUp();

	}, 10000);
} //prompt end