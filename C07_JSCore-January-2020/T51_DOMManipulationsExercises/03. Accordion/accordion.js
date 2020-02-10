function toggle() {
    let $textBlock = document.getElementById('extra');
    let $btn = document.getElementsByTagName('span')[0];
    
    if ($textBlock.style.display === 'none' || $textBlock.style.display === '') {
        $textBlock.style.display = 'block';

        $btn.textContent = 'Less';
    } else {
        $textBlock.style.display = "none";

        $btn.textContent = 'More';
    }
}