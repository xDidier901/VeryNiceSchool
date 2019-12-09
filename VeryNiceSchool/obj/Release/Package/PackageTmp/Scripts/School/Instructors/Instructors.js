$(() => {
    // Variables.
    const genderSelect = $('#genderSelect');

    const instructorsTable = $('#instructorsTable');
    let dtInstructorsTable;

    // Init.
    (function init() {
        setListeners();
        initTable();
        initGenderSelect();
    })();

    // Methods.
    function setListeners() {
        genderSelect.change(getAllInstructors);
    }

    function initGenderSelect() {

        $.blockUI({ message: 'Just a moment...' });
        $.get('/Home/GetGenderSelect')
            .always($.unblockUI)
            .then(response => {
                if (response) {
                    response.push({ id: 0, text: "All", selected: true });
                    genderSelect.select2({ data: response });
                    getAllInstructors();
                } else {
                    showAlert("Error loading genders.");
                }
            }, error => {
                showAlert(`Error ${error.status} - ${error.statusText}.`);
            });
    }

    function getAllInstructors() {

        const gender = genderSelect.val();

        if (gender == null) {
            showAlert('Invalid gender');
            return;
        }

        $.blockUI({ message: 'Just a moment...' });
        $.get('/Instructors/GetAllInstructors', { gender })
            .always($.unblockUI)
            .then(response => {
                if (response.success) {
                    dtInstructorsTable.clear().rows.add(response.items).draw();
                } else {
                    showAlert(response.message);
                }
            }, error => {
                showAlert(`Error ${error.status} - ${error.statusText}.`);
            });
    }

    function initTable() {
        dtInstructorsTable = instructorsTable.DataTable({
            paging: false,
            searching: true,
            columns: [
                { data: 'FirstName', title: 'First Name' },
                { data: 'LastName', title: 'Last Name' },
                { data: 'Gender', title: 'Gender' },
                { data: 'SSN', title: 'SSN' },
                { data: 'Salary', title: 'Salary' },
            ],
            columnDefs: [
                { className: "dt-center", "targets": "_all" }
            ]
        });
    }

});