function showCarDetails(carId) {
    fetch(`/Cars/GetCarDetails?id=${carId}`)
        .then(response => response.json())
        .then(data => {
            document.getElementById('carDetails').innerText = data.description; // Make sure your data object has a description property
            document.getElementById('carDetailsModal').style.display = 'flex'; // Show the modal
        })
        .catch(error => console.error('Error:', error));
}

function closeModal() {
    document.getElementById('carDetailsModal').style.display = 'none'; // Hide the modal
}