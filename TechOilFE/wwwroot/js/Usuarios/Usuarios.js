var token = getCookie("Token");
let table = new DataTable('#usuarios', {
    ajax: {
        url: `https://localhost:7201/api/Usuario`,
        dataSrc: "data.items",
        headers: { "Authorization": "Bearer " + token }
    },
    columns: [
        { data: 'codUsuario', title: 'CodUusuario' },
        { data: 'nombre', title: 'Nombre' },
        { data: 'dni', title: 'DNI' },
        { data: 'email', title: 'Mail' },
        { data: 'codRol', title: 'Rol' },
        { data: 'activo', title: 'Activo' },
        {
            data: function (data) {
                var botones =
                    `<td><a href='javascript:EditarUsuario(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square editarUsuario"></i></td>` +
                    `<td><a href='javascript:EliminarUsuario(${JSON.stringify(data)})'><i class="fa-solid fa-trash eliminarUsuario"></i></td>`
                return botones;
            }
        }

    ]
});

function AgregarUsuario() {
    $.ajax({
        type: "GET",
        url: "/Usuarios/UsuariosAddPartial",
        data: "",
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado);
            $('#usuarioModal').modal('show');
        }

    });
}

function EditarUsuario(data) {
    $.ajax({
        type: "POST",
        url: "/Usuarios/UsuariosUpdPartial",
        data: JSON.stringify(data),
        contentType: 'application/json',
        'dataType': "html",
        success: function (resultado) {
            $('#usuariosUpdPartial').html(resultado);
            $('#usuarioModal').modal('show');
        }

    });
}

function EliminarUsuario(data) {
    debugger;
    var jsonString = JSON.stringify(data); // Convierte el objeto en una cadena JSON
    var jsonObject = JSON.parse(jsonString); // Convierte la cadena JSON en un objeto JavaScript
    var valorCodUsuario = jsonObject.codUsuario;

    $.ajax({
        type: "DELETE",
        url: "/Usuarios/EliminarUsuario/" + valorCodUsuario, // Agrega el valor de codUsuario a la URL
        success: function (resultado) {
            // Maneja la respuesta si es necesario
        },
        error: function (error) {
            // Maneja los errores si es necesario
        }
    });
}