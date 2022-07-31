$(document).ready(function () {
    getMainSongList();
    getMainArtList();
});

var Savesong = function () {
    debugger;
    var massage = "";
    $formData = new FormData();
    var Id = $("#txtid").val();
    var name = $("#txtName").val();
    var releasedate = $("#txtd_o_r").val();
    var artId = $("#ddlselect1").val();
    var img = document.getElementById("File1");;
    if (img.files.length > 0) {
        for (var i = 0; i < img.files.length; i++) {
            $formData.append('file-' + i, img.files[i]);
        }
    }
    $formData.append('ArtistId', Id);
    $formData.append('Name', name);
    $formData.append('DateOfRelease', releasedate);
    $formData.append('ArtistId', artId);
    $.ajax({
        url: "/Song/SaveSong",
        method: "post",
        data: $formData,
        contentType: "application/json;charset=utf-8",
        contentType: false,
        processData: false,
        success: function (response) {
            alert("DataSave Successfully");
            getMainSongList();
        }
    });
}



var getMainSongList = function () {
    debugger;

    $.ajax({
        url: "/Song/GetSongList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblsearch tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Name + "</td><td>" + elementValue.DOR + "</td><td><img src='../Content/img/" + elementValue.Image + "' height='100'width='100'/></td><td>" + elementValue.ArtistId + "</td></tr>";
            });
            $("#tblsearch").append(html);

        }
    });
}

var getMainArtList = function () {
    debugger;
    debugger
    $.ajax({
        url:"/Artist/GetArtDDLList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#ddlaerlist tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<option value =" + elementValue.ArtistId + " >" + elementValue.Name + "</option>";
            });
            $("#ddlaerlist").append(html);

        }
    });
}