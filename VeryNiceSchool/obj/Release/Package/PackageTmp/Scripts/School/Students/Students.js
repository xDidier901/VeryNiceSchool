$(() => {
    // Variables.
    const genderSelect = $('#genderSelect');

    const studentsTable = $('#studentsTable');
    let dtStudentsTable;

    // Init.
    (function init() {
        setListeners();
        initTable();
        initGenderSelect();
    })();

    // Methods.
    function setListeners() {
        genderSelect.change(getAllStudents);
    }

    function initGenderSelect() {

        $.blockUI({ message: 'Just a moment...' });
        $.get('/Home/GetGenderSelect')
            .always($.unblockUI)
            .then(response => {
                if (response) {
                    response.push({ id: 0, text: "All", selected: true });
                    genderSelect.select2({ data: response });
                    getAllStudents();
                } else {
                    showAlert("Error loading genders.");
                }
            }, error => {
                showAlert(`Error ${error.status} - ${error.statusText}.`);
            });
    }

    function getAllStudents() {

        const gender = genderSelect.val();

        if (gender == null) {
            showAlert('Invalid gender');
            return;
        }

        $.blockUI({ message: 'Just a moment...' });
        $.get('/Students/GetAllStudents', { gender })
            .always($.unblockUI)
            .then(response => {
                if (response.success) {
                    dtStudentsTable.clear().rows.add(response.items).draw();
                } else {
                    showAlert(response.message);
                }
            }, error => {
                showAlert(`Error ${error.status} - ${error.statusText}.`);
            });
    }

    function initTable() {
        dtStudentsTable = studentsTable.DataTable({
            paging: false,
            searching: true,
            columns: [
                { data: 'FirstName', title: 'First Name' },
                { data: 'LastName', title: 'Last Name' },
                { data: 'Gender', title: 'Gender' },
                { data: 'BirthDate', title: 'SSN' },
            ],
            columnDefs: [
                { className: "dt-center", "targets": "_all" }
            ]
        });
    }

});