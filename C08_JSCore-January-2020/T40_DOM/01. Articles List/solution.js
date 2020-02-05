function createArticle() {
	let articles = document.getElementById('articles');
	let title = document.getElementById('createTitle').value;
	let content = document.getElementById('createContent').value;

	if(title == '' || content === ''){
		return;
	}

	let titleElement = document.createElement('h3');
	titleElement.textContent = title;

	let contentElement = document.createElement('p');
	contentElement.textContent = content;

	let articleElement = document.createElement('article');
	articleElement.innerHTML = titleElement.outerHTML + contentElement.outerHTML;

	articles.appendChild(articleElement);

	document.getElementById('createTitle').value = '';
	document.getElementById('createContent').value = '';
}