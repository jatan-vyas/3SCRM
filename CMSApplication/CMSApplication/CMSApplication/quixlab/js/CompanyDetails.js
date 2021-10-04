$(document).ready(function () {
    EmployeeTab();
    PartnerTab();
    PartnerFamilyTab();
    MiscTab();
    var prevPageURL = document.referrer;
    // tab-one - General
    // tab-two - Partner
    // tab-three - Employee
    // tab-four - Partner Family
    // tab-five - Misc
    if (prevPageURL && prevPageURL.toLowerCase().trim().includes("employeedetails")) {
        $("#tab-three")[0].checked = true;
    }
    else if (prevPageURL && prevPageURL.toLowerCase().trim().includes("partnerdetails")) {
        $("#tab-two")[0].checked = true;
    }
    else if (prevPageURL && prevPageURL.toLowerCase().trim().includes("partnerfamilydetails")) {
        $("#tab-four")[0].checked = true;
    }
    else if (prevPageURL && prevPageURL.toLowerCase().trim().includes("partnermiscdetails")) {
        $("#tab-five")[0].checked = true;
    }
    else {
        $("#tab-one")[0].checked = true;
    }
});

function getParameterByName(name, url = window.location.href) {
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

// Employee Datatable Binding
function EmployeeTab() {
    var obj = {};
    obj.companyID = getParameterByName("id");

    $.ajax({
        type: "POST",
        url: "CompanyDetails.aspx/GetEmployeeDetails",
        //data: '{}',
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnEmployeeSuccess,
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d);
        }
    });

    function OnEmployeeSuccess(response) {
        var _id = getParameterByName("id"); 
        $("[id=MainContent_gvEmployeeDetails]").DataTable(
            {
                destroy: true,
                bLengthChange: true,
                lengthMenu: [[10, 15, -1], [10, 15, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true,
                data: response.d,
                columns: [
                    { 'data': 'Emp_name' },
                    { 'data': 'Emp_mobile' },
                    { 'data': 'Emp_passport_exp', render: function (d) { if (d) { return moment(d).format("DD-MMM-YYYY"); } else { return '' } } },
                    { 'data': 'Emp_insurance_exp', render: function (d) { if (d) { return moment(d).format("DD-MMM-YYYY"); } else { return '' } } },
                    { 'data': 'Emp_visa_exp', render: function (d) { if (d) { return moment(d).format("DD-MMM-YYYY"); } else { return '' } } },
                    { 'data': 'Emp_labor_card_exp', render: function (d) { if (d) { return moment(d).format("DD-MMM-YYYY"); } else { return '' } } },
                    {
                        'data': 'Is_active',
                        'render': function (data, type, row) {
                            return (data == true) ? '<span><img src="https://cdn1.iconfinder.com/data/icons/e-commerce-flat/512/Correct-128.png" height="20px" weidth="20px" </span> '
                                : ' <img src="https://cdn3.iconfinder.com/data/icons/flat-actions-icons-9/792/Close_Icon-128.png" height="20px" width=20px">';
                        }
                    },
                    {
                        "mRender": function (data, type, row) {
                            return '<a href=EmployeeDetails.aspx?op=edit&empid=' + row.Pk_employeeid + '&id=' + _id +'><i class="fa fa-edit"></i></a>';
                        }
                    },
                    {
                        "mRender": function (data, type, row) {
                            return '<a href="#" onclick="deleteEmployee(this)" id=' + row.Pk_employeeid + '><i class="fa fa-trash"></i></a>';
                        }   
                    }
                ]
            });
    };
}
function deleteEmployee(employeeID) {
    $('#deleteEmployeeModal').modal('show');
    $("#MainContent_hdnEmployeeID").val(employeeID.attributes['id'].value)
}
// Partner Datatable Binding
function PartnerTab() {
    var obj = {};
    obj.companyID = getParameterByName("id");
    $(function () {
        $.ajax({
            type: "POST",
            url: "CompanyDetails.aspx/GetPartnerDetails",
            //data: '{}',
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnPartnerSuccess,
            failure: function (response) {
                alert(response.d);
            },
            error: function (response) {
                alert(response.d);
            }
        });
    });
    function OnPartnerSuccess(response) {
        var _id = getParameterByName("id")
        $("[id=MainContent_gvPartnerDetails]").DataTable(
            {
                destroy: true,
                bLengthChange: true,
                lengthMenu: [[10, 15, -1], [10, 15, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true,
                data: response.d,
                columns: [
                    { 'data': 'Par_name' },
                    { 'data': 'Par_mobile' },
                    { 'data': 'Par_passport_exp', render: function (d) { if (d) { return moment(d).format("DD-MMM-YYYY"); } else { return '' } } },
                    { 'data': 'Par_insurance_exp', render: function (d) { if (d) { return moment(d).format("DD-MMM-YYYY"); } else { return '' } } },
                    { 'data': 'Par_visa_exp', render: function (d) { if (d) { return moment(d).format("DD-MMM-YYYY"); } else { return '' } } },
                    {
                        'data': 'Is_active',
                        'render': function (data, type, row) {
                            return (data == true) ? '<span><img src="https://cdn1.iconfinder.com/data/icons/e-commerce-flat/512/Correct-128.png" height="20px" weidth="20px" </span> '
                                : ' <img src="https://cdn3.iconfinder.com/data/icons/flat-actions-icons-9/792/Close_Icon-128.png" height="20px" width=20px">';
                        }
                    },
                    {
                        "mRender": function (data, type, row) {
                            return '<a href=PartnerDetails.aspx?op=edit&parid=' + row.Pk_partnerid + '&id=' + _id +'><i class="fa fa-edit"></i></a>';
                        }
                    },
                    {
                        "mRender": function (data, type, row) {
                            return '<a href="#" onclick="deletePartner(this)" id=' + row.Pk_partnerid + '><i class="fa fa-trash"></i></a>';
                        }   
                    }
                ]
            });
    };
}
function deletePartner(partnerID) {
    $('#deletePartnerModal').modal('show');
    $("#MainContent_hdnPartnerID").val(partnerID.attributes['id'].value)
}
// Partner Family Datatable Binding
function PartnerFamilyTab() {
    var obj = {};
    obj.companyID = getParameterByName("id");

    $(function () {
        $.ajax({
            type: "POST",
            url: "CompanyDetails.aspx/GetPartnerFamilyDetails",
            //data: '{}',
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnPartnerFamilySuccess,
            failure: function (response) {
                alert(response.d);
            },
            error: function (response) {
                alert(response.d);
            }
        });
    });
    function OnPartnerFamilySuccess(response) {
        var _id = getParameterByName("id")
        $("[id=MainContent_gvPartnerFamilyDetails]").DataTable(
            {
                destroy: true,
                bLengthChange: true,
                lengthMenu: [[10, 15, -1], [10, 15, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true,
                data: response.d,
                columns: [
                    { 'data': 'Fml_name' },
                    { 'data': 'Par_name' },
                    { 'data': 'Par_mobile' },
                    { 'data': 'Fml_relation' },
                    { 'data': 'Fml_passport_exp', render: function (d) { if (d) { return moment(d).format("DD-MMM-YYYY"); } else { return '' } } },
                    { 'data': 'Fml_insurance_exp', render: function (d) { if (d) { return moment(d).format("DD-MMM-YYYY"); } else { return '' } } },
                    { 'data': 'Fml_visa_exp', render: function (d) { if (d) { return moment(d).format("DD-MMM-YYYY"); } else { return '' } } },
                    {
                        'data': 'Is_active',
                        'render': function (data, type, row) {
                            return (data == true) ? '<span><img src="https://cdn1.iconfinder.com/data/icons/e-commerce-flat/512/Correct-128.png" height="20px" weidth="20px" </span> '
                                : ' <img src="https://cdn3.iconfinder.com/data/icons/flat-actions-icons-9/792/Close_Icon-128.png" height="20px" width=20px">';
                        }
                    },
                    {
                        "mRender": function (data, type, row) {
                            return '<a href=PartnerFamilyDetails.aspx?op=edit&parfamid=' + row.Pk_familyid + '&id=' + _id + '><i class="fa fa-edit"></i></a>';
                        }
                    },
                    {
                        "mRender": function (data, type, row) {
                            return '<a href="#" onclick="deleteFamily(this)" id=' + row.Pk_familyid + '><i class="fa fa-trash"></i></a>';
                        }   
                    }
                ]
            });
    };
}
function deleteFamily(familyID) {
    $('#deleteFamilyModal').modal('show');
    $("#MainContent_hdnPartnerFamilyID").val(familyID.attributes['id'].value)
}
// Partner MISC  Datatable Binding
function MiscTab() {
    var obj = {};
    obj.companyID = getParameterByName("id");

    $(function () {
        $.ajax({
            type: "POST",
            url: "CompanyDetails.aspx/GetPartnerMiscDetails",
            //data: '{}',
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnMiscSuccess,
            failure: function (response) {
                alert(response.d);
            },
            error: function (response) {
                alert(response.d);
            }
        });
    });
    function OnMiscSuccess(response) {
        var _id = getParameterByName("id")
        $("[id=MainContent_gvMiscDetails]").DataTable(
            {
                destroy: true,
                bLengthChange: true,
                lengthMenu: [[10, 15, -1], [10, 15, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true,
                data: response.d,
                columns: [
                    { 'data': 'Misc_name' },
                    { 'data': 'Misc_exp_date', render: function (d) { if (d) { return moment(d).format("DD-MMM-YYYY"); } else { return '' } } },
                    {
                        'data': 'Is_active',
                        'render': function (data, type, row) {
                            return (data == true) ? '<span><img src="https://cdn1.iconfinder.com/data/icons/e-commerce-flat/512/Correct-128.png" height="20px" weidth="20px" </span> '
                                : ' <img src="https://cdn3.iconfinder.com/data/icons/flat-actions-icons-9/792/Close_Icon-128.png" height="20px" width=20px">';
                        }
                    },
                    {
                        "mRender": function (data, type, row) {
                            return '<a href=PartnerMiscDetails.aspx?op=edit&miscid=' + row.Pk_miscid + '&id=' + _id +'><i class="fa fa-edit"></i></a>';
                        }
                    },
                    {
                        "mRender": function (data, type, row) {
                            return '<a href="#" onclick="deleteMisc(this)" id=' + row.Pk_miscid + '><i class="fa fa-trash"></i></a>';
                        }   
                    }
                ]
            });
    };
}
function deleteMisc(miscID) {
    $('#deleteMiscModal').modal('show');
    $("#MainContent_hdnMiscID").val(miscID.attributes['id'].value)
}