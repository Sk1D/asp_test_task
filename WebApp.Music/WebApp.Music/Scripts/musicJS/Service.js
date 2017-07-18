app.service("musicService", function ($http) {
    this.getAlbums = function () {
        //   debugger;
        var response = $http({
            method: "get",
            url: "api/values/GetAlbums",
            headers: { 'Content-Type': 'application/json' }
        });
        return response;
    };
    this.getAlbum = function (albumId) {
        var response = $http({
            method: "post",
            url: "api/values",
            params: {
                id: JSON.stringify(albumId)
            }
        });
        return response;
    };
    this.getTracks = function (albumId) {
        var response = $http({
            method: "get",
            url: "api/values/GetTracks",
            params: {
                id: JSON.stringify(albumId)
            }
        });
        return response;
    };
    this.addAlbum = function (album) {
        var response = $http({
            method: "post",
            url: "api/values/AddAlbum",
            data: JSON.stringify(album),
            dataType: "json"
        });
        return response;
    };
    this.addTrack = function (track) {
        // debugger;
        var response = $http({
            method: "post",
            url: "api/values/AddTrack",
            data: JSON.stringify(track),
            dataType: "json"
        });
        return response;
    };

})