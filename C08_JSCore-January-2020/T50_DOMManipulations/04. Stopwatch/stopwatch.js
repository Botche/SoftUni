function stopwatch() {
    let startBtn = document.getElementById('startBtn');
    let stopBtn = document.getElementById('stopBtn');
    let time = document.getElementById('time');

    startBtn.addEventListener('click', startTimer);
    stopBtn.addEventListener('click', stopTimer);

    let timer = null;
    function startTimer(e){
        startBtn.disabled = true;
        stopBtn.disabled = false;

        let seconds = 0;
        setInterval(tick, 1000);

        time.textContent = '00:00';

        function tick() {
            seconds++;

            let currentMinute = ('0' + Math.floor(seconds / 60)).slice(-2);
            let currentSecond = ('0' + seconds % 60).slice(-2);

            time.textContent = `${currentMinute}:${currentSecond}`;
        }
    }

    function stopTimer(e){
        startBtn.disabled = false;
        stopBtn.disabled = true;

        clearInterval(timer)
    }
}