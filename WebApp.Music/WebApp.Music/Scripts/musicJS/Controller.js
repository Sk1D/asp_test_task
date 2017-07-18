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

    $scope.AddAlbumDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.divAlbum = true;
        $scope.loaded = false;
    }
    $scope.AddUpdateAlbum = function (_updateTrack) {
        var Album = {
            Id: $scope.albumId,
            Name: $scope.albumName,
            Year: $scope.albumYear
        };
        var getAlbumAction = $scope.Action;
        if (getAlbumAction == "Update") {
            //update 
        }
        else {
            //add
            var getAlbumData = musicService.addAlbum(Album);
            getAlbumData.then(function (id) {
                //debugger;
                _updateTrack.forEach(function (item, i, _updateTrack) {
                    //  debugger;
                    item.albumId = id.data;
                    var getTrackData = musicService.addTrack(item);
                    getTrackData.then(function (msg) {
                        // alert(msg.data);
                    }, function () {
                        alert('Error in adding track record');
                    });
                });
                GetAllAlbums();
                $scope.divAlbum = false;
                $scope.loaded = false;
            }, function () {
                alert('Error in adding album record');
            });
        }
    }

    function ClearFields() {
        $scope.albumId = "";
        $scope.albumName = "";
        $scope.albumYear = "";
        $scope.tracks = [
            {
                'Id': '',
                'Artist': '',
                'Title': '',
                'Time': '',
                'AlbumId': '',
                'Album': ''
            }
        ];
    }
    $scope.addNewEmptyTrack = function () {
        $scope.tracks.push({
            'Id': '',
            'Artist': '',
            'Title': '',
            'Time': '',
            'AlbumId': '',
            'Album': ''
        });
    }

    $scope.Cancel = function () {
        GetAllAlbums();
        $scope.divAlbum = false;
        $scope.loaded = false;

    };
})