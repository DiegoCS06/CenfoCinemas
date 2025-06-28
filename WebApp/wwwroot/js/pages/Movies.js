//JS que maneja todo el comportamiento de la lista de usuarios

//Definir una clase JS usando Prototype

function MoviesViewController() {

    this.ViewName = "Movies";
    this.ApiEndPointName = "Movie";

    //Metodo controlador

    this.InitView = function () {

        console.log("Movie init view --> ok");
        this.LoadTable();

        //Asociar el evento al boton
        $('#btnCreate').click(function () {
            var vc = new MoviesViewController();
            vc.Create();
        })

        $('#btnUpdate').click(function () {
            var vc = new MoviesViewController();
            vc.Update();
        })

        $('#btnDelete').click(function () {
            var vc = new MoviesViewController();
            vc.Delete();
        })
    }

    //Metodo para la carga de una tabla
    this.LoadTable = function () {
        //URL del API a invocar
        //https://localhost:7286/api/Movie/RetrieveAl

        var ca = new ControlActions();
        var service = this.ApiEndPointName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(service);

        /*{
    "title": "The Witcher 1",
    "description": "PRIMERA",
    "releaseDate": "2025-06-21T17:23:28.983",
    "genre": "PRIMERA WITCHER",
    "director": "Geralt de Rivia",
    "id": 1,
    "created": "2025-06-12T18:50:27.67",
    "updated": "2025-06-21T11:26:38.057"
  }
            <tr>
                            <th>Id</th>
                            <th>Title</th>
                            <th>Description</th>
                            <th>ReleaseDate</th>
                            <th>Genre</th>
                            <th>Director</th>
                        </tr>
            */

        var columns = [];
        columns[0] = { 'data': 'id' }
        columns[1] = { 'data': 'title' }
        columns[2] = { 'data': 'description' }
        columns[3] = { 'data': 'releaseDate' }
        columns[4] = { 'data': 'genre' }
        columns[5] = { 'data': 'director' }

        $("#tblMovies").dataTable({
            "ajax": {
                url: urlService,
                "dataSrc": ""
            },
            columns: columns
        });

        //Asignar eventos de carga de datos o binding segun el clic en la tabla
        $('#tblMovies tbody').on('click', 'tr', function () {
            //Extraemos la fila
            var row = $(this).closest('tr');

            //Extraemos el DTO
            //Esto nos devuelve el json de la fila del usuario seleccionado por el usuario
            //Segun data devuelta por el API
            var movieDTO = $("#tblMovies").DataTable().row(row).data();

            //Binding con el form
            $('#txtId').val(movieDTO.id);
            $('#txtTitle').val(movieDTO.title);
            $('#txtDescription').val(movieDTO.description);
            $('#txtGenre').val(movieDTO.genre);
            $('#txtDirector').val(movieDTO.director);

            //Fecha tiene un formato
            var onlyDate = movieDTO.releaseDate.split("T");
            $('#txtReleaseDate').val(onlyDate[0]);
        })
    }

    this.Create = function () {
        var movieDTO = {};
        //Atributos con valores default que son controlados por el API
        movieDTO.id = 0;
        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01";

        //Valores capturados en pantalla
        movieDTO.title = $('#txtTitle').val();
        movieDTO.description = $('#txtDescription').val();
        movieDTO.releaseDate = $('#txtReleaseDate').val();
        movieDTO.genre = $('#txtGenre').val();
        movieDTO.director = $('#txtDirector').val();

        //Enviar data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Create";

        ca.PostToAPI(urlService, movieDTO, function () {
            //Recargo de la tabla
            $('#tblMovies').DataTable().ajax.reload();
        })

    }
    this.Update = function () {
        var movieDTO = {};
        //Atributos con valores default que son controlados por el API
        movieDTO.id = $('#txtId').val();
        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01";

        //Valores capturados en pantalla
        movieDTO.title = $('#txtTitle').val();
        movieDTO.description = $('#txtDescription').val();
        movieDTO.releaseDate = $('#txtReleaseDate').val();
        movieDTO.genre = $('#txtGenre').val();
        movieDTO.director = $('#txtDirector').val();

        //Enviar data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Update";

        ca.PutToAPI(urlService, movieDTO, function () {
            //Recargo de la tabla
            $('#tblMovies').DataTable().ajax.reload();
        })
    }

    this.Delete = function () {
        var movieDTO = {};
        //Atributos con valores default que son controlados por el API
        movieDTO.id = $('#txtId').val();
        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01";

        //Valores capturados en pantalla
        movieDTO.title = $('#txtTitle').val();
        movieDTO.description = $('#txtDescription').val();
        movieDTO.releaseDate = $('#txtReleaseDate').val();
        movieDTO.genre = $('#txtGenre').val();
        movieDTO.director = $('#txtDirector').val();

        //Enviar data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Delete";

        ca.DeleteToAPI(urlService, movieDTO, function () {
            //Recargo de la tabla
            $('#tblMovies').DataTable().ajax.reload();
        })
    }
}

$(document).ready(function () {
    var vc = new MoviesViewController();
    vc.InitView();
})