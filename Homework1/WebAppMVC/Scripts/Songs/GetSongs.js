/*/*const { data } = require("jquery");*/

$(document).ready(function () {
    loadData();
});
//მონაცემების გამოჩენა
function loadData() {
    $.ajax({
        url: "https://localhost:44310/api/songs1",
        type: "GET",
        /*contentType: "application/json;charset=utf-8",*/
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        dataType: "json",

        success: function (result) {
            var html = ""
            $.each(result, function (key, item) {
                html += '<tr class="justify-content-center p-1">';
                html += '<td class="p-1">' + item.FirstName + '</td>';
                html += '<td class="p-1">' + item.ID + '</td>';
                html += '<td class="p-1">' + item.LastName + '</td>';
                html += '<td class="p-1">' + item.Released + '</td>';
                html += '<td class="p-1">' + item.SongName + '</td>';
                html += '</tr>';
            })
            $('.mytbody').html(html);
        }
    })
}
//დასამატებელი ინფუთები
function AddSong() { 
    let form = $("#AddSongForm")[0]
    //ვალიდაციისთვის
    if (form.checkValidity() === false) {
        alert("შეიყვანეთ მონაცემი"); //მუშაობს
    }
    //obieqtis sheqmna
    let ObjSong = {
        ID: $("#ID").val(),
        FirstName: $("#FirstName").val(),
        LastName: $("#LastName").val(),
        Released: $("#Released").val(),
        SongName: $("#SongName").val()
    }
    //ობიექტის დამატება - მუშაობს
    $.ajax({
        url: "https://localhost:44310/api/songs1",
        data: JSON.stringify(ObjSong),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        /*dataType: "json",*/
        success: function (result) {
            loadData()
        }
        //error: function (errorMessage) {
        //    alert(errorMessage.responseText);
        //}
    })

}