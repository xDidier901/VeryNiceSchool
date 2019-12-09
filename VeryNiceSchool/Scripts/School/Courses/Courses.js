$(() => {
    // Variables.
    const coursesTable = $('#coursesTable');
    let dtCoursesTable;

    const newCourseButton = $('#newCourseButton');
    const saveCourseButton = $('#saveCourseButton');

    const courseModal = $('#courseModal');
    const inputCourseName = $('#inputCourseName');
    const inputCourseCredits = $('#inputCourseCredits');
    const instructorSelect = $('#instructorSelect');

    const fullInfoModal = $('#fullInfoModal');
    const inputInfoCourseName = $('#inputInfoCourseName');
    const inputInfoCourseCredits = $('#inputInfoCourseCredits');
    const inputInfoCourseInstructor = $('#inputInfoCourseInstructor');
    const studentsTable = $('#studentsTable');
    let dtStudentsTable;

    const deleteModal = $('#deleteModal');
    const deleteCourseButton = $('#deleteCourseButton');


    let isAdmin;

    // Init.
    (function init() {
        newCourseButton.hide();
        setListeners();
        initCoursesTable();
        initStudentsTable();
        initInstructorSelect();
        getAllCourses();
    })();

    // Methods.
    function setListeners() {
        newCourseButton.click(() => {
            courseModal.modal('show');
        });

        courseModal.on('hidden.bs.modal', () => {
            inputCourseName.val('');
            inputCourseCredits.val('');
            newCourseButton.data().id = 0;
        });

        newCourseButton.data().id = 0;

        saveCourseButton.click(saveCourse);

        deleteCourseButton.click(deleteCourse);
    }

    function initInstructorSelect() {

        $.blockUI({ message: 'Just a moment...' });
        $.get('/Instructors/GetInstructorSelect')
            .always($.unblockUI)
            .then(response => {
                if (response.success) {
                    instructorSelect.select2({ data: response.items });
                } else {
                    showAlert("Error loading instructors.");
                }
            }, error => {
                showAlert(`Error ${error.status} - ${error.statusText}.`);
            });
    }


    function getAllCourses() {
        $.blockUI({ message: 'Just a moment...' });
        $.get('/Courses/GetAllCourses')
            .always($.unblockUI)
            .then(response => {
                if (response.success) {
                    isAdmin = response.isAdmin;
                    dtCoursesTable.clear().rows.add(response.items).draw();

                    isAdmin ? newCourseButton.show(200) : newCourseButton.hide(200);
                } else {
                    showAlert(response.message);
                }
            }, error => {
                showAlert(`Error ${error.status} - ${error.statusText}.`);
            });
    }

    function initCoursesTable() {
        dtCoursesTable = coursesTable.DataTable({
            paging: false,
            searching: true,
            order: [[0, "desc"]],
            columns: [
                { data: 'ID', title: '', visible: false },
                { data: 'Name', title: 'Name' },
                { data: 'Credits', title: 'Credits' },
                {
                    data: 'ID', title: '', render: data => `<button class="btn btn-primary fullInfo" title="See full information"><i class="fas fa-info-circle"></i></button>`

                },
                {
                    data: 'ID', title: '', render: data => {
                        if (isAdmin) {
                            return `<button class="btn btn-primary edit" title="Edit Course"><i class="fas fa-edit"></i></button>`
                        }
                        return ''
                    }
                },
                {
                    data: 'ID', title: '', render: data => {
                        if (isAdmin) {
                            return `<button class="btn btn-primary delete" title="Delete Course"><i class="fas fa-trash-alt"></i></button>`
                        }
                        return ''
                    }
                }
            ],
            columnDefs: [
                { className: "dt-center", "targets": "_all" }
            ],
            initComplete: function (settings) {

                coursesTable.on('click', '.fullInfo', e => {
                    var rowData = dtCoursesTable.row($(e.currentTarget).parents('tr')).data();
                    getFullCourseInfo(rowData.ID, rowData.Name, rowData.Credits);
                });

                coursesTable.on('click', '.edit', e => {
                    var rowData = dtCoursesTable.row($(e.currentTarget).parents('tr')).data();
                    inputCourseName.val(rowData.Name);
                    inputCourseCredits.val(rowData.Credits);
                    instructorSelect.val(rowData.InstructorID).change();
                    newCourseButton.data().id = rowData.ID;
                    courseModal.modal('show');
                });

                coursesTable.on('click', '.delete', e => {
                    var rowData = dtCoursesTable.row($(e.currentTarget).parents('tr')).data();
                    deleteModal.modal('show');
                    deleteCourseButton.data().id = rowData.ID;
                });
            }
        });
    }

    function saveCourse() {

        const name = inputCourseName.val().trim();
        const credits = inputCourseCredits.val();
        const instructorID = instructorSelect.val();

        if (invalidFields(name, +credits, +instructorID)) {
            showAlert('Invalid fields.');
            return;
        }

        const course = {
            Name: name,
            Credits: credits,
            InstructorID: instructorID,
            ID: newCourseButton.data().id
        };

        const isUpdate = course.ID != 0;

        $.blockUI({ message: 'Saving course...' });
        $.post('/Courses/SaveCourse', { course })
            .always($.unblockUI)
            .then(response => {
                if (response.success) {
                    courseModal.modal('hide');
                    showAlert(isUpdate ? 'Course updated!' : 'Course saved!');
                    getAllCourses();
                } else {
                    showAlert("Error while trying to save the course.");
                }
            }, error => {
                showAlert(`Error ${error.status} - ${error.statusText}.`);
            });
    }

    function deleteCourse() {
        const courseID = deleteCourseButton.data().id;

        if (courseID == null || courseID == 0) {
            showAlert('Could not get course information.');
            return;
        }

        $.blockUI({ message: 'Deleting course...' });
        $.post('/Courses/DeleteCourseByID', { courseID })
            .always($.unblockUI)
            .then(response => {
                if (response.success) {
                    deleteModal.modal('hide');
                    showAlert('Course deleted succesfully!');
                    getAllCourses();
                } else {
                    showAlert("Error while trying to delete the course.");
                }
            }, error => {
                showAlert(`Error ${error.status} - ${error.statusText}.`);
            });
    }

    function invalidFields(name, credits, instructorID) {
        return (name == "" || name.length < 4) || (credits == "" || credits <= 0 || credits > 30) || (instructorID == "" || instructorID == 0);
    }

    function initStudentsTable() {
        dtStudentsTable = studentsTable.DataTable({
            paging: false,
            searching: false,
            columns: [
                { data: 'FirstName', title: 'First Name' },
                { data: 'LastName', title: 'Last Name' },
                { data: 'Gender', title: 'Gender' },
                { data: 'BirthDate', title: 'BirthDate' }
            ],
            columnDefs: [
                { className: "dt-center", "targets": "_all" }
            ]
        });
    }

    function getFullCourseInfo(courseID, name, credits) {
        $.blockUI({ message: 'Just a moment...' });
        $.get('/Courses/GetFullCourseInfo', { courseID })
            .always($.unblockUI)
            .then(response => {
                if (response.success) {
                    inputInfoCourseName.val(name);
                    inputInfoCourseCredits.val(credits);
                    inputInfoCourseInstructor.val(response.instructorName);
                    dtStudentsTable.clear().rows.add(response.items).draw();
                    fullInfoModal.modal('show');
                } else {
                    showAlert(response.message);
                }
            }, error => {
                showAlert(`Error ${error.status} - ${error.statusText}.`);
            });
    }

});