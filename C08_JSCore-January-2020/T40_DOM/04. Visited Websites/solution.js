function solve() {
  const links = document.querySelectorAll('a');
  const visits = document.querySelectorAll("p");

  for (let i = 0; i < links.length; i++) {
    updateVisitors(links[i], visits[i]);
  }

  function updateVisitors(link, visits) {
    link.addEventListener("click", function (e) {
      e.preventDefault();

      let count = parseInt(visits.innerHTML.replace(/^\D+/g, ''));
      visits.innerHTML = `visited ${++count} times`;
    })
  }
}