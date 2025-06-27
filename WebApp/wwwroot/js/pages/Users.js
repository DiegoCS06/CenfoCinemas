//JS que maneja todo el comportamiento de la lista de usuarios

//Definir una clase JS usando Prototype

function UsersViewController() {

    this.ViewName = "Users";
    this.ApiEndPointName = "User";

    //Metodo controlador

    this.InitView = function () {

        console.log("User init view --> ok");
        this.LoadTable();
    }

    //Metodo para la carga de una tabla
    this.LoadTable = function () {
        //URL del API a invocar
        //https://localhost:7286/api/User/RetrieveAl

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
    }
}

$(document).ready(function () {
    var vc = new UsersViewController();
    vc.InitView();
})