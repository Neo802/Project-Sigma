function showCarDetails(carId) {
    fetch(`/Cars/GetCarDetails?id=${carId}`)
        .then(response => response.json())
        .then(data => {
            document.getElementById('carName').innerText = data.manufacturer; // Make sure your data object has a description property
            document.getElementById('carModel').innerText = data.model;
            document.getElementById('carImage').innerHTML = `<img src="${data.image}" alt="Car Image" style="width: 200px; height: auto;">`;
            document.getElementById('carDetails').innerText = data.description;

            document.getElementById('fuel').innerText = data.fuel;
            document.getElementById('fuelCapacity').innerText = data.tankcapacity;
            document.getElementById('gearType').innerText = data.gear;

            // Features
            document.getElementById('f1').innerText = data.f1;
            document.getElementById('f2').innerText = data.f2;
            document.getElementById('f3').innerText = data.f3;
            document.getElementById('f4').innerText = data.f4;
            document.getElementById('f5').innerText = data.f5;
            document.getElementById('f6').innerText = data.f6;
            document.getElementById('f7').innerText = data.f7;
            document.getElementById('f8').innerText = data.f8;
            document.getElementById('f9').innerText = data.f9;
            document.getElementById('f10').innerText = data.f10;
            document.getElementById('f11').innerText = data.f11;
            document.getElementById('f12').innerText = data.f12;

            document.getElementById('carDetailsModal').style.display = 'flex'; // Show the modal
        })
        .catch(error => console.error('Error:', error));
}

function closeModal() {
    document.getElementById('carDetailsModal').style.display = 'none'; // Hide the modal
}