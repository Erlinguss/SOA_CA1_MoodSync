var map;

function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 53.3498053, lng: -6.2603097 },
        zoom: 12
    });
}
function setMapLocation(latitude, longitude, htmlAttributions) {
    const map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: latitude, lng: longitude },
        zoom: 12,
    });

    places.forEach((place) => {
        const marker = new google.maps.Marker({
            position: place.geometry.location,
            map: map,
            title: place.name,
        });

        const infoWindow = new google.maps.InfoWindow({
            content: `<div>
                        <h4>${place.name}</h4>
                        <p>${place.vicinity}</p>
                        <div>Attributions: ${htmlAttributions.join(", ")}</div>
                      </div>`
        });

        marker.addListener("click", () => {
            infoWindow.open(map, marker);
        });
    });
}

