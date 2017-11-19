//Form
function clearForm(idForm) {
    $("#" + idForm).closest('form').find("input[type=text], textarea").val("");
    $("#" + idForm).closest('form').find("input[type=password], textarea").val("");
    $("#" + idForm).closest('form').find("input[type=number], textarea").val("0");
    $("#" + idForm).closest('form').find("input[type=checkbox], textarea").prop('checked', false);
    $("#" + idForm).closest('form').find("span").html("");

    //$("#" + idForm).each(function () {
    //  this.reset();
    //  });
}

//Grid
function UpdateGrid(control, query, div) {

    if (div == null) div = "#divgrid";
    $.post('/' + control + '/CreateGrid', { query: query.toString() , div: div }, function (data) {
        $(div).html(data);
    }).fail(function (xhr, textStatus, errorThrown) {
        ShowInternalError();
    });
};
function SelCheck(box) {
    var selection = new Array();
    if (box == null) box = ".box";

    $(box).each(function () {
        if ($(this).is(":checked")) {
            selection.push($(this).val());
        }
    })

    return selection;
}
function CheckAll(boxHeader, box) {

    if (boxHeader == null) boxHeader = "#allBox";
    if (box == null) box = ".box";

    $(function () {
        $(boxHeader).change(function () {
            if ($(this).is(":checked")) {
                $(box).each(function () {
                    $(this).prop("checked", true);
                    $(this).closest('tr').addClass('info');
                })
            } else {
                $(box).each(function () {
                    $(this).prop("checked", false);
                    $(this).closest('tr').removeClass('info');
                })
            }
        });
    });
}
function CheckClick(box) {
    if (box == null) box = ".box";

    $(box).click(function (e) {
        var checked = $(this).is(":checked");
        if (checked) {
            $(this).closest('tr').addClass('info');
        } else {
            $(this).closest('tr').removeClass('info');
        }
    });
}

//Input Number Positivos
function NumberInt(val, e) {
    var tecla = (window.event) ? e.keyCode : e.which;
    if (tecla >= 48 && tecla <= 57) {
        return tecla;
    } else {
        return false;
    }
}
function NumberFloat(val, e) {
    var tecla = (window.event) ? e.keyCode : e.which;
    if ((tecla >= 46 && tecla <= 57) || tecla == 44) {
        return tecla;
    } else {
        return false;
    }
}


