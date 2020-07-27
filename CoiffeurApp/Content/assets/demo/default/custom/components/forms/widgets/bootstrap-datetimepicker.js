var today = new Date();
var BootstrapDatetimepicker = {
    init: function () {
        $("#m_datetimepicker_1_modal").datetimepicker({ todayHighlight: !0, autoclose: !0, format: "yyyy.mm.dd hh:ii" }),
            $("#m_datetimepicker_2, #m_datetimepicker_1_validate, #m_datetimepicker_2_validate, #m_datetimepicker_3_validate").datetimepicker({
                todayHighlight: !0, autoclose: !0, pickerPosition: "bottom-left", format: "yyyy/mm/dd hh:ii"
            }),
            $("#m_datetimepicker_2_modal").datetimepicker({ todayHighlight: !0, autoclose: !0, pickerPosition: "bottom-left", format: "yyyy/mm/dd hh:ii" }),
            $("#m_datetimepicker_3").datetimepicker({
            todayHighlight: !0, autoclose: !0, pickerPosition: "bottom-left", todayBtn: !0, format: "yyyy/mm/dd hh:ii",
              
                    todayHighlight: !0,
                    autoclose: !0,
                    format: "yyyy/mm/dd hh:ii",
                    startDate: today,
                    daysOfWeekDisabled: [0],
                    hoursDisabled: '0,1,2,3,4,5,6,7,18,19,20,21,22,23'

            }),
            $("#m_datetimepicker_3_modal").datetimepicker({
                todayHighlight: !0, autoclose: !0, pickerPosition: "bottom-left", todayBtn: !0, format: "yyyy/mm/dd hh:ii",

            }),
            $("#dtime").datetimepicker({
                
            todayHighlight: !0,
            autoclose: !0,
            format: "yyyy/mm/dd hh:ii",
            startDate: today,
            daysOfWeekDisabled: [0],
            hoursDisabled: '0,1,2,3,4,5,6,7,18,19,20,21,22,23'}),
            $("#m_datetimepicker_4_2").datetimepicker({ todayHighlight: !0, autoclose: !0, pickerPosition: "bottom-right", format: "yyyy/mm/dd hh:ii" }),
            $("#m_datetimepicker_4_3").datetimepicker({ todayHighlight: !0, autoclose: !0, pickerPosition: "top-left", format: "yyyy-mm-dd hh:ii" }),
            $("#m_datetimepicker_4_4").datetimepicker({ todayHighlight: !0, autoclose: !0, pickerPosition: "top-right", format: "yyyy-mm-dd hh:ii" }),
            $("#m_datetimepicker_5").datetimepicker({ format: "dd MM yyyy - HH:ii P", showMeridian: !0, todayHighlight: !0, autoclose: !0, pickerPosition: "bottom-left" }),
            $("#m_datetimepicker_6").datetimepicker({ format: "yyyy/mm/dd", todayHighlight: !0, autoclose: !0, startView: 2, minView: 2, forceParse: 0, pickerPosition: "bottom-left" }),
            $("#m_datetimepicker_7").datetimepicker({ format: "hh:ii", showMeridian: !0, todayHighlight: !0, autoclose: !0, startView: 1, minView: 0, maxView: 1, forceParse: 0, pickerPosition: "bottom-left" })
    }
}; jQuery(document).ready(function () { BootstrapDatetimepicker.init() });
function staffChange(sel) {
    var id = sel.value;


    $.get('/randevu', { id: id }, function (data) {




        $("#m_datetimepicker_1").datetimepicker
            ({
                
                todayHighlight: !0,
                autoclose: !0,
                format: "yyyy/MM/dd hh:ii",
                startDate: today,
                daysOfWeekDisabled: [0],
                datesDisabled: data,
                hoursDisabled: '0,1,2,3,4,5,6,7,18,19,20,21,22,23',

            });

     
    });

}