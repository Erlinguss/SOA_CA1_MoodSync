var map;

function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 53.3498053, lng: -6.2603097 },
        zoom: 12
    });
}

function setMapLocation(latitude, longitude) {
    var position = { lat: latitude, lng: longitude };
    map.setCenter(position);

    var marker = new google.maps.Marker({
        position: position,
        map: map
    });
}
