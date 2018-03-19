var markers = [];
var map;
var infoWindow;
var directionsService;
var directionsDisplays = [];
var stepDisplay;
var myLocation;
function initMap() {
    directionsService = new google.maps.DirectionsService;
    stepDisplay = new google.maps.InfoWindow;

    var hcm = { lat: 10.822923, lng: 106.629411 };
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 12,
        center: hcm
    });

    directionsDisplay = new google.maps.DirectionsRenderer({ map: map });
    //directionsDisplay = new google.maps.DirectionsRenderer({ suppressMarkers: true, polylineOptions: polylineOptionsActual });
    infoWindow = new google.maps.InfoWindow;

    // Try HTML5 geolocation.
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            myLocation = pos;
            // infoWindow.setPosition(pos);
            // infoWindow.setContent('Location found.');
            // infoWindow.open(map);
            map.setCenter(pos);
            addMarker(pos);
            
        }, function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }
}
function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
        'Error: The Geolocation service failed.' :
        'Error: Your browser doesn\'t support geolocation.');
    infoWindow.open(map);
}

//markers
function addMarker(location) {
    var marker = new google.maps.Marker({
        position: location,
        map: map
    });
    markers.push(marker);
}
function setMapOnAll(map) {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}
function clearMarkers() {
    setMapOnAll(null);
}
function showMarkers() {
    setMapOnAll(map);
}
function deleteMarkers() {
    clearMarkers();
    markers = [];
}

//show route
function calculateAndDisplayRoute(origin, destination, markerArray, map) {
    for (var i = 0; i < markerArray.length; i++) {
        markerArray[i].setMap(null);
    }
    directionsService.route({
        origin: origin,
        destination: destination,
        travelMode: 'DRIVING'
    }, function (response, status) {
        if (status === 'OK') {
            directionsDisplay.setDirections(response);
            showSteps(response, markerArray, stepDisplay, map);
        } else {
            window.alert('Directions request failed due to ' + status);
        }
    });
}

function calculateAndDisplayRoute(origin, destination, markerArray, directionsDisplay, map) {
    for (var i = 0; i < markerArray.length; i++) {
        markerArray[i].setMap(null);
    }
    directionsService.route({
        origin: origin,
        destination: destination,
        travelMode: 'DRIVING'
    }, function (response, status) {
        if (status === 'OK') {
            directionsDisplay.setDirections(response);
            showSteps(response, markerArray, stepDisplay, map);
        } else {
            window.alert('Directions request failed due to ' + status);
        }
    });
}

function showSteps(directionResult, markerArray, stepDisplay, map) {
    var myRoute = directionResult.routes[0].legs[0];
    for (var i = 0; i < myRoute.steps.length; i++) {
        var marker = markerArray[i] = markerArray[i] || new google.maps.Marker;
        marker.setMap(map);
        marker.setPosition(myRoute.steps[i].start_location);
        attachInstructionText(
            stepDisplay, marker, myRoute.steps[i].instructions, map);
    }
}

function attachInstructionText(stepDisplay, marker, text, map) {
    google.maps.event.addListener(marker, 'click', function () {
        stepDisplay.setContent(text);
        stepDisplay.open(map, marker);
    });
}

//show more route
function calculateAndDisplayRoutes(tripbook) {
    var array = Array.from(tripbook);
    for (var i = 0; i < directionsDisplays.length; i++) {
        directionsDisplays[i].setMap(null);
    }
    directionsDisplays = [];
    for (var i = 1; i < array.length; i++) {
        var tmpDirectionsDisplays = new google.maps.DirectionsRenderer({ map: map });
        directionsDisplays.push(tmpDirectionsDisplays);
        calculateAndDisplayRoute(array[i - 1][1].Pos, array[i][1].Pos, [], tmpDirectionsDisplays, map);
    }
}