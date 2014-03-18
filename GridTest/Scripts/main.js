
$(document).ready(function () {
    function populateData() {
        var overFlowLimit = $("#overFlowLimittxt").val();
        //alert(overFlowLimit);
        var serverSide = false;
        $('#example').dataTable({
            "bServerSide": true,
            "sAjaxSource": "Home/AjaxHandler",
            "bProcessing": true,
            "bDestroy": true,        
            "aoColumns": [
                { "sName": "Permit No." },
                { "sName": "Client Name" },
                { "sName": "Application No." },
                { "sName": "Permit Type", "sClass": "center" },
                { "sName": "Account No.", "sClass": "center" }
            ],
            "fnDrawCallback": function (oSettings) {
                if (oSettings.fnRecordsTotal() > overFlowLimit) {
                    oSettings.oFeatures.bServerSide = true;
                }
                else {
                    oSettings.oFeatures.bServerSide = false;
                }
            }
        });
    }
    populateData();
    $("#updateBtn").click(function () {
        populateData();
    });
    });
