function getInfo() {
    let stopId = document.getElementById('stopId');
    let stopName = document.getElementById('stopName');

    let bussesList = document.getElementById('buses');

    stopName.innerText = '';
    bussesList.innerHTML = '';

    let trimmedStopId = stopId.value.trim();
    fetch(`https://judgetests.firebaseio.com/businfo/${trimmedStopId}.json`)
        .then(function(response) {
            if(response.status >= 400){
                throw Error('Error');
            }

            return response;
        })
        .then(response => response.json())
        .then(json => {

            stopName.innerText = json['name'];

            let busses = json['buses'];
            for (const bus in busses) {
                let busItem = document.createElement('li');

                let busInfo = `Bus ${bus} arrives in ${busses[bus]} minutes.`;

                busItem.innerText = busInfo;
                bussesList.appendChild(busItem);
            };
        })
        .catch(error => stopName.innerText = error.message);

    stopId.value = '';
}