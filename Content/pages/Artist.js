$(document).ready(function () {
    getMainArtList();
});

var Saveartist = function () {
    debugger;
    var name = $("#txtArtName").val();
    var dob = $("#txtd_o_b").val();
    var bio = $("#txtbio").val();
    var sonid = $("#txtsid").val();
    var model = { Name: name, DOB: dob, Bio: bio, SongId: sonid };
    $.ajax({
        url: "/Artist/SaveArtist",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("DataSave Successfully");
            getMainArtList();
        }
    });
}

var getMainArtList = function () {
    debugger;

    $.ajax({
        url: "/Artist/GetArtList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblart tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Name + "</td><td>" + elementValue.dateofbirth + "</td><td>" + elementValue.Bio + "</td></tr > ";
            });
            $("#tblart").append(html);

        }
    });
}
