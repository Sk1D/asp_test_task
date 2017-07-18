﻿app.controller("musicCtrl", function ($scope, musicService) {
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
})