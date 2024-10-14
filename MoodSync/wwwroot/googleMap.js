var map;

function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 53.3498053, lng: -6.2603097 },
        zoom: 12
    });
}
function setMapLocation(latitude, longitude, placesJson = [], htmlAttributions = []) {
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

            let placePhoto = "";
            if (place.photos && place.photos.length > 0) {
                const photoReference = place.photos[0].photo_reference; 
                const maxWidth = 400;

                if (photoReference) {
                    placePhoto = `<img src="https://maps.googleapis.com/maps/api/place/photo?maxwidth=${maxWidth}&photoreference=${photoReference}&key=AIzaSyAARniUO27XBpmFtefiEDN2e9twJs4Tb0U" alt="${place.name} Image" />`;
                } else {
                    console.log("No photo reference found for this place.");
                }
            }

            console.log("Place photo HTML: ", placePhoto);

            const infoWindow = new google.maps.InfoWindow({
                content: `<div>
                              ${placePhoto} 
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
