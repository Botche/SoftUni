function growingWord() {
  let text = document.querySelectorAll("p")[2];
  const colors = ['blue', 'green', 'red'];

  if (text.style.color === "" && text.style.fontSize === "") {
    text.style.fontSize = "2px";
    text.style.color = "blue";
    
    return;
  } else if (text.style.color === "red") {
    text.style.color = "blue";
  } else if (text.style.color === "blue") {
    text.style.color = "green";
  } else if (text.style.color === "green") {
    text.style.color = "red";
  }

  text.style.fontSize = parseInt(text.style.fontSize) * 2 + 'px';
}