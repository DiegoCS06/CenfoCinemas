//JS que maneja todo el comportamiento de la lista de usuarios

//Definir una clase JS usando Prototype

function MoviesViewController() {

    this.ViewName = "Movies";
    this.ApiEndPointName = "Movie";

    //Metodo controlador

    this.InitView = function () {

        console.log("Movie init view --> ok");
        this.LoadTable();
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
    }
}

$(document).ready(function () {
    var vc = new MoviesViewController();
    vc.InitView();
})