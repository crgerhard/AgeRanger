var personId = 0;

$(document).ready(function () {
    setupForm();
});

function setupForm() {
    $('#btnAdd').click(savePerson);
    $('#btnDelete').click(deletePerson);
    $('#btnSearch').click(searchPerson);
    $('#btnReset').click(resetForm);
    loadPersons();
};

function resetForm() {
    personId = 0;
    $('#txtFirstName').val('');
    $('#txtLastName').val('');
    $('#txtAge').val('');
    $('#txtSearchFirstName').val('');
    $('#txtSearchLastName').val('');
};

function loadPersons() {
    var data = $.ajax({
        type: "POST",
        url: "./Handlers/Person.ashx?m=g",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    }).done(function (data) {
        finishLoadPersons(data);
    });
}

function finishLoadPersons(data) {
    var dynatable = $('#results').dynatable({
        dataset: {
            records: data,
        },
        features: {
            paginate: false,
            recordCount: false,
            sorting: false,
            search: false,
        },
        table: {
            copyHeaderClass: true,

        }
    }).data('dynatable');
    dynatable.settings.dataset.originalRecords = data;
    dynatable.process();

    $('#results').dynatable().on('click', 'tr', function () {
        var data = [];
        $(this).find('td').each(function (i, el) {
            data.push($(el).html());
        });
        personId = data[0];
        $('#txtFirstName').val(data[1]);
        $('#txtLastName').val(data[2]);
        $('#txtAge').val(data[3]);
    });
}

function loadPerson() {
    var data = $.ajax({
        type: "POST",
        url: "./Handlers/Person.ashx?m=g&id=" + personId,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
    }).done(function (data) {
        finishLoadPerson(data);
    });
}

function finishLoadPerson(data) {
    if (data) {
        $('#txtFirstName').val(data.FirstName);
        $('#txtLastName').val(data.LastName);
        $('#txtAge').val(data.Age);
    }
}

var userData = function () {
    var firstName = $('#txtFirstName').val();
    var lastName = $('#txtLastName').val();
    var age = $('#txtAge').val();
    var user = {
        i: personId,
        f: firstName,
        l: lastName,
        a: age
    };
    return user;
}

function checkInputs() {
    var postData = userData();
    var result = true;
    if (postData.a != "" && !$.isNumeric(postData.a))
        result = false;
    return result;
}

function savePerson() {
    if (checkInputs()) {
        var postData = userData()
        var data = $.ajax({
            type: "POST",
            url: "./Handlers/Person.ashx?m=a",
            dataType: "json",
            data: JSON.stringify(postData),
            processData: false,
            contentType: "application/json",
        }).done(function (data) {
            resetForm();
            loadPersons();
        });
    }
}

function deletePerson() {
    var data = $.ajax({
        type: "POST",
        url: "./Handlers/Person.ashx?m=d&i=" + personId,
        dataType: "json",
        processData: false,
        contentType: "application/json",
    }).done(function (data) {
        resetForm();
        loadPersons();
    });
}

var searchUserData = function () {
    var firstName = $('#txtSearchFirstName').val();
    var lastName = $('#txtSearchLastName').val();
    var user = {
        f: firstName,
        l: lastName,
    };
    return user;
}

function searchPerson() {
    var postData = searchUserData()
    var data = $.ajax({
        type: "POST",
        url: "./Handlers/Person.ashx?m=s",
        dataType: "json",
        data: JSON.stringify(postData),
        processData: false,
        contentType: "application/json",
    }).done(function (data) {
        resetForm();
        finishLoadPersons(data);
    });
}


