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
    this.updateAlbum = function (album, albumId) {
        var response = $http({
            method: "put",
            url: "api/values/UpdateAlbum",
            params: {
                id: JSON.stringify(albumId)
            },
            data: JSON.stringify(album),
            dataType: "json"
        });
        return response;
    };
    this.updateTrack = function (track) {
        var response = $http({
            method: "put",
            url: "api/values/UpdateTrack",
            data: JSON.stringify(track),
            dataType: "json"
        });
        return response;
    };
})