function solve() {

    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');

    let info = document.querySelector('.info');

    let currentId = 'depot';
    let currentStop = '';
    let nextStopId = '';

    function disableAll() {
        departBtn.disabled = true;
        arriveBtn.disabled = true;
    }

    function disableDepart(){
        departBtn.disabled = true;
        arriveBtn.disabled = false;
    }

    function disableArrive(){
        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    async function depart() {
        disableAll();

        await fetch(`https://judgetests.firebaseio.com/schedule/${currentId}.json`)
            .then(response => response.json())
            .then(json => {
                currentStop = json['name'];
                nextStopId = json['next'];

                info.innerText = `Next stop ${currentStop}`;
            })
            .catch(RaiseError());

        disableDepart();
    }

    function arrive() {
        disableAll();

        currentId = nextStopId;

        info.innerText = `Arriving at ${currentStop}`;

        disableArrive();
    }

    function RaiseError() {
        return () => {
            info.textContent = "Error";
            departButton.disabled = true;
            arriveButton.disabled = true;
        };
    }

    return {
        depart,
        arrive
    };
}

let result = solve();