
function SearchText() {
    $(".autosuggest").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Index.aspx/GetNombreCiudades",
                data: "{'pre':'" + document.getElementById('txtBuscar').value + "'}",
                dataType: "json",
                success: function (data) {
                    var array = eval(data.d);
                    response(array);
                },
                error: function (result) {
                    alert("Error");
                }
            });
        }
    });
}

$(document).ready(function () {
    SearchText();
});