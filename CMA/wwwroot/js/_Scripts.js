// Check boxes in student attendance trackers﻿
$('#Select_All').on('click', function () {
    let checkboxes = document.getElementsByTagName('input');
    let val = null;
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].type === 'checkbox') {
            if (val == null) {
                val = checkboxes[i].checked;
            }
            else {
                checkboxes[i].checked = val;
            }
        }
    }
});

// Math Attendance
$('#UpdateBtn').on('click', function () {
    let val = [];
    $("input[name='Select_One']:checked").each(function () {
        val.push($(this).val());
    });

    $.ajax({
        type: 'POST',
        url: '/Math_Attendance/Update_Attendance',
        data: { 'ids': val },
        success: function (response) {
            if (response == 'success') {
                location.reload();
            }
        },
        error: function () {

        }
    })

});
//Physics Attendance
$('#Physics_UpdateBtn').on('click', function () {
    let val = [];
    $("input[name='Select_One']:checked").each(function () {
        val.push($(this).val());
    });

    $.ajax({
        type: 'POST',
        url: '/Physics_Attendance/Update_Attendance',
        data: { 'ids': val },
        success: function (response) {
            if (response == 'success') {
                location.reload();
            }
        },
        error: function () {

        }
    })

});
//Chemistry Attendance 
$('#Chemistry_UpdateBtn').on('click', function () {
    let val = [];
    $("input[name='Select_One']:checked").each(function () {
        val.push($(this).val());
    });

    $.ajax({
        type: 'POST',
        url: '/Chemistry_Attendance/Update_Attendance',
        data: { 'ids': val },
        success: function (response) {
            if (response == 'success') {
                location.reload();
            }
        },
        error: function () {

        }
    })

});
//Biology Attendance
$('#Bio_UpdateBtn').on('click', function () {
    let val = [];
    $("input[name='Select_One']:checked").each(function () {
        val.push($(this).val());
    });

    $.ajax({
        type: 'POST',
        url: '/Biology_Attendance/Update_Attendance',
        data: { 'ids': val },
        success: function (response) {
            if (response == 'success') {
                location.reload();
            }
        },
        error: function () {

        }
    })

});
//History Attendance
$('#History_UpdateBtn').on('click', function () {
    let val = [];
    $("input[name='Select_One']:checked").each(function () {
        val.push($(this).val());
    });

    $.ajax({
        type: 'POST',
        url: '/History_Attendance/Update_Attendance',
        data: { 'ids': val },
        success: function (response) {
            if (response == 'success') {
                location.reload();
            }
        },
        error: function () {

        }
    })

});
//Literature Attendance
$('#Lit_UpdateBtn').on('click', function () {
    let val = [];
    $("input[name='Select_One']:checked").each(function () {
        val.push($(this).val());
    });

    $.ajax({
        type: 'POST',
        url: '/Literature_Attendance/Update_Attendance',
        data: { 'ids': val },
        success: function (response) {
            if (response == 'success') {
                location.reload();
            }
        },
        error: function () {

        }
    })

});

$('#Select').on('change', function () {
    var data = $(this).children("option:selected").text();
    switch (data) {
        case "Math Class":
            window.location.href = "/Math_Attendance";
            break;
        case "Physics Class":
            window.location.href = "/Physics_Attendance";
            break;
        case "Chemistry Class":
            window.location.href = "/Chemistry_Attendance";
            break;
        case "Biology Class":
            window.location.href = "/Biology_Attendance";
            break;
        case "History Class":
            window.location.href = "/History_Attendance";
            break;
        case "Literature Class":
            window.location.href = "/Literature_Attendance";
            break;
        default:

    }
})
