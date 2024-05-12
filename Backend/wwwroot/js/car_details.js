function showCarDetails(carId) {
    fetch(`/Cars/GetCarDetails?id=${carId}`)
        .then(response => response.json())
        .then(data => {
            document.getElementById('carName').innerText = data.manufacturer; // Make sure your data object has a description property
            document.getElementById('carModel').innerText = data.model; // Make sure your data object has a description property
            document.getElementById('carImage').pic = data.image; // Make sure your data object has a description property
            document.getElementById('carDetails').innerText = data.description; // Make sure your data object has a description property
            document.getElementById('fuel').innerText = data.fuel; // Make sure your data object has a description property
            document.getElementById('fuelCapacity').innerText = data.tankCapacity; // Make sure your data object has a description property
            document.getElementById('gearType').innerText = data.gear; // Make sure your data object has a description property
            document.getElementById('doorsCount').innerText = data.doors; // Make sure your data object has a description property
            document.getElementById('carDetailsModal').style.display = 'flex'; // Show the modal
        })
        .catch(error => console.error('Error:', error));
}

function closeModal() {
    document.getElementById('carDetailsModal').style.display = 'none'; // Hide the modal
}