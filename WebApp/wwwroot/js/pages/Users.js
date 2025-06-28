//JS que maneja todo el comportamiento de la lista de usuarios

//Definir una clase JS usando Prototype

function UsersViewController() {

    this.ViewName = "Users";
    this.ApiEndPointName = "User";

    //Metodo controlador

    this.InitView = function () {

        console.log("User init view --> ok");
        this.LoadTable();

        //Asociar el evento al boton
        $('#btnCreate').click(function () {
            var vc = new UsersViewController();
            vc.Create();
        })

        $('#btnUpdate').click(function () {
            var vc = new UsersViewController();
            vc.Update();
        })

        $('#btnDelete').click(function () {
            var vc = new UsersViewController();
            vc.Delete();
        })


    }

    //Metodo para la carga de una tabla
    this.LoadTable = function () {
        //URL del API a invocar
        //https://localhost:7286/api/User/RetrieveAll

        var ca = new ControlActions();
        var service = this.ApiEndPointName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(service);

        /*{
            "userCode": "dcalvos",
            "name": "Diego",
            "email": "dcalvos@ucenfotec.ac.cr       ",
            "password": "Diego123                                          ",
            "birthDate": "2025-06-07T12:13:58.673",
            "status": "AC",
            "id": 1,
            "created": "2025-06-07T12:13:58.98",
            "updated": "0001-01-01T00:00:00"
            }
            <tr>
                                    <th>Id</th>
                                    <th>User Code</th>
                                    <th>Name</th>
                                    <th>Email</th>
                                    <th>Birth Date</th>
                                    <th>Status</th>
                                </tr>
            */

        var columns = [];
        columns[0] = { 'data': 'id' }
        columns[1] = { 'data': 'userCode' }
        columns[2] = { 'data': 'name' }
        columns[3] = { 'data': 'email' }
        columns[4] = { 'data': 'birthDate' }
        columns[5] = { 'data': 'status' }

        $("#tblUsers").dataTable({
            "ajax": {
                url: urlService,
                "dataSrc": ""
            },
            columns: columns
        });

        //Asignar eventos de carga de datos o binding segun el clic en la tabla
        $('#tblUsers tbody').on('click', 'tr', function () {
            //Extraemos la fila
            var row = $(this).closest('tr');

            //Extraemos el DTO
            //Esto nos devuelve el json de la fila del usuario seleccionado por el usuario
            //Segun data devuelta por el API
            var userDTO = $("#tblUsers").DataTable().row(row).data();

            //Binding con el form
            $('#txtId').val(userDTO.id);
            $('#txtUserCode').val(userDTO.userCode);
            $('#txtName').val(userDTO.name);
            $('#txtEmail').val(userDTO.email);
            $('#txtStatus').val(userDTO.status);

            //Fecha tiene un formato
            var onlyDate = userDTO.birthDate.split("T");
            $('#txtBirthDate').val(onlyDate[0]);
        })
    }

    this.Create = function () {
        var userDTO = {};
        //Atributos con valores default que son controlados por el API
        userDTO.id = 0;
        userDTO.created = "2025-01-01";
        userDTO.updated = "2025-01-01";

        //Valores capturados en pantalla
        userDTO.userCode = $('#txtUserCode').val();
        userDTO.name = $('#txtName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.password = $('#txtPassword').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.password = $('#txtPassword').val();

        //Enviar data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Create";

        ca.PostToAPI(urlService, userDTO, function () {
            //Recargo de la tabla
            $('#tblUsers').DataTable().ajax.reload();
        })

    }
        this.Update = function () {
            var userDTO = {};
            //Atributos con valores default que son controlados por el API
            userDTO.id = $('#txtId').val();
            userDTO.created = "2025-01-01";
            userDTO.updated = "2025-01-01";

            //Valores capturados en pantalla
            userDTO.userCode = $('#txtUserCode').val();
            userDTO.name = $('#txtName').val();
            userDTO.email = $('#txtEmail').val();
            userDTO.password = $('#txtPassword').val();
            userDTO.birthDate = $('#txtBirthDate').val();
            userDTO.status = $('#txtStatus').val();
            userDTO.password = $('#txtPassword').val();

            //Enviar data al API
            var ca = new ControlActions();
            var urlService = this.ApiEndPointName + "/Update";

            ca.PutToAPI(urlService, userDTO, function () {
                //Recargo de la tabla
                $('#tblUsers').DataTable().ajax.reload();
            })
        }

        this.Delete = function () {
            var userDTO = {};
            //Atributos con valores default que son controlados por el API
            userDTO.id = $('#txtId').val();
            userDTO.created = "2025-01-01";
            userDTO.updated = "2025-01-01";

            //Valores capturados en pantalla
            userDTO.userCode = $('#txtUserCode').val();
            userDTO.name = $('#txtName').val();
            userDTO.email = $('#txtEmail').val();
            userDTO.password = $('#txtPassword').val();
            userDTO.birthDate = $('#txtBirthDate').val();
            userDTO.status = $('#txtStatus').val();
            userDTO.password = $('#txtPassword').val();

            //Enviar data al API
            var ca = new ControlActions();
            var urlService = this.ApiEndPointName + "/Delete";

            ca.DeleteToAPI(urlService, userDTO, function () {
                //Recargo de la tabla
                $('#tblUsers').DataTable().ajax.reload();
            })
        }
    }

    $(document).ready(function () {
        var vc = new UsersViewController();
        vc.InitView();
    })