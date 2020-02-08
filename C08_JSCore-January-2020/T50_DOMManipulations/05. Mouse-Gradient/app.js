function attachGradientEvents() {
    let resultElement = document.getElementById('result');
    let gradientBox = document.getElementById('gradient');

    gradientBox.addEventListener('mousemove', attachPosition);
    gradientBox.addEventListener('mouseout', clearPercentage);

    function attachPosition(e){
        let currentMouseX = e.offsetX;
        let percentage = Math.floor(currentMouseX / this.clientWidth * 100);

        resultElement.textContent = `${percentage}%`;
    }

    function clearPercentage(){
        resultElement.textContent = '';
    }
}