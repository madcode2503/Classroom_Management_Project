$('#reset').on('click',function(){
    $.ajax({
        type: 'POST',
        url: "/Grade_Book/Reset_Grade",
        data: {},

        success: function (response) {
            if (response == "success") {
                location.reload();
            }
        }
    })
})