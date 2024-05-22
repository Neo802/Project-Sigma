function showCarDetails(carId) {
    fetch(`/Cars/GetCarDetails?id=${carId}`)
        .then(response => response.json())
        .then(data => {
            // Populate the features list
            var featuresList = document.getElementById('carFeatures');
            featuresList.innerHTML = ""; // Clear existing features
            if (data.features) {
                data.features.forEach(feature => {
                    for (var key in feature) {
                        if (feature.hasOwnProperty(key)) {
                            var li = document.createElement('li');
                            li.innerText = key + ": " + feature[key];
                            featuresList.appendChild(li);
                        }
                    }
                });
            }

            document.getElementById('carDetailsModal').style.display = 'flex'; // Show the modal
        })
        .catch(error => console.error('Error:', error));
}

function closeModal() {
    document.getElementById('carDetailsModal').style.display = 'none'; // Hide the modal
}
