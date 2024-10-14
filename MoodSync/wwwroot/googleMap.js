var map;
function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 53.3498053, lng: -6.2603097 },
        zoom: 12
    });
} function setMapLocation(latitude, longitude, placesJson = [], htmlAttributions = []) {
    const map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: latitude, lng: longitude },
        zoom: 12
    });

    if (Array.isArray(placesJson) && placesJson.length > 0) {  
        placesJson.forEach((place) => {
            const marker = new google.maps.Marker({
                position: { lat: place.geometry.location.lat, lng: place.geometry.location.lng },
                map: map,
                title: place.name,
            });

            const infoWindow = new google.maps.InfoWindow({
                content: `<div>
                            <h4>${place.name}</h4>
                            <p>${place.vicinity}</p>
                          </div>`
            });

            marker.addListener("click", () => {
                infoWindow.open(map, marker);
            });
        });
    } else {
        console.log("No places to display.");
    }
}
