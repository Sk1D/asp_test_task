app.controller("musicCtrl", function ($scope, musicService) {
    $scope.divAlbum = false;
    $scope.loaded = false;
    GetAllAlbums();

    function GetAllAlbums() {
        // debugger;
        var getAlbumData = musicService.getAlbums();
        getAlbumData.then(function (album) {
            $scope.albums = album.data;
        }, function () {
            alert('Error in getting album records');
        });
    }

    $scope.showTracks = function (albumId) {
        var getTracksData = musicService.getTracks(albumId);
        getTracksData.then(function (_tracks) {
            $scope.tracks = _tracks.data;
            // debugger;
            $scope.divAlbum = false;
            $scope.loaded = true;
        }, function () {
            alert('Error in getting track records');
        });
    }
})