$(document).ready(function () {
    loadDoctors();

    $("#btnSave").click(function () {
        let doctor = {
            Name: $("#name").val(),
            Contact: $("#contact").val(),
            Specialization: $("#specialization").val()
        };

        $.ajax({
            url: '/Doctor/AddDoctor',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(doctor),
            success: function (response) {
                if (response.success) {
                    alert("Doctor added successfully!");
                    $("#doctorForm")[0].reset();
                    loadDoctors();
                } else {
                    alert("Failed to add doctor.");
                }
            }
        });
    });

    function loadDoctors() {
        $.ajax({
            url: '/Doctor/GetDoctors',
            type: 'GET',
            success: function (data) {
                let table = '';
                $.each(data, function (i, doctor) {
                    table += `<tr>
                                <td>${doctor.name}</td>
                                <td>${doctor.contact}</td>
                                <td>${doctor.specialization}</td>
                                 <td>
                                <button class="btn btn-warning" onclick="editDoctor(${doctor.doctorId}, '${doctor.name}', '${doctor.contact}', '${doctor.specialization}')">Edit</button>
                               <button class="btn btn-danger" onclick="deleteDoctor(${doctor.doctorId})">Delete</button>
                            </td>
                              </tr>`;
                });
                $("#doctorTable").html(table);
            }
        });
    }
    // Delete Doctor Function
    window.deleteDoctor = function (id) {
        if (confirm("Are you sure you want to delete this doctor?")) {
            $.ajax({
                url: '/Doctor/DeleteDoctor',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(id ), // ✅ Correct format
                success: function (response) {
                    if (response.success) {
                        alert("Doctor deleted successfully!");
                        loadDoctors();
                    } else {
                        alert("Error deleting doctor: " + response.message);
                    }
                },
                error: function (xhr) {
                    console.error("AJAX Error:", xhr.responseText);
                    alert("Error while deleting doctor.");
                }
            });
        }
    };

    // Function to open the edit doctor modal and fill in data
    window.editDoctor = function (id, name, contact, specialization) {
        $("#editDoctorId").val(id);
        $("#editName").val(name);
        $("#editContact").val(contact);
        $("#editSpecialization").val(specialization);
        $("#editDoctorModal").modal('show'); // Show modal (Bootstrap)
    };

    // Function to update doctor details via AJAX
    $("#btnUpdate").click(function () {
        let doctor = {
            DoctorId: $("#editDoctorId").val(),
            Name: $("#editName").val(),
            Contact: $("#editContact").val(),
            Specialization: $("#editSpecialization").val()
        };

        $.ajax({
            url: '/Doctor/EditDoctor',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(doctor),
            success: function (response) {
                if (response.success) {
                    alert("Doctor updated successfully!");
                    $("#editDoctorModal").modal('hide'); // Hide modal
                    loadDoctors(); // Refresh doctor list
                } else {
                    alert("Failed to update doctor: " + response.message);
                }
            },
            error: function (xhr) {
                console.error("AJAX Error:", xhr.responseText);
                alert("Error while updating doctor.");
            }
        });
    });



});
