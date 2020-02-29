function solve() {
   let createBtn = document.querySelector('form button');
   let articlesSection = document.querySelector('main section');

   createBtn.addEventListener('click', createArticle);

   function createArticle(e) {
      e.preventDefault();

      let authorElement = document.getElementById('creator');
      let titleElement = document.getElementById('title');
      let categoryElement = document.getElementById('category');
      let contentElement = document.getElementById('content');

      let headingElement = createElement('h1', titleElement.value);

      let categoryStrongElement = createElement('strong', categoryElement.value);
      let categoryParagraph = createElement('p', 'Category:');

      categoryParagraph.appendChild(categoryStrongElement);

      let authorStrongElement = createElement('strong', authorElement.value);
      let authorParagraph = createElement('p', 'Creator:');

      authorParagraph.appendChild(authorStrongElement);

      let contentParagraph = createElement('p', contentElement.value);

      let deleteBtn = createElement('button', 'Delete', ['btn', 'delete']);
      let archiveBtn = createElement('button', 'Archive', ['btn', 'archive']);
      let buttonsArea = createElement('div', null, ['buttons']);

      deleteBtn.addEventListener('click', deleteArticle);
      archiveBtn.addEventListener('click', archiveArticle);

      buttonsArea.appendChild(deleteBtn);
      buttonsArea.appendChild(archiveBtn);

      let article = createElement('article');

      article.appendChild(headingElement);
      article.appendChild(categoryParagraph);
      article.appendChild(authorParagraph);
      article.appendChild(contentParagraph);
      article.appendChild(buttonsArea);

      articlesSection.appendChild(article);


      authorElement.value = '';
      titleElement.value = '';
      categoryElement.value = '';
      contentElement.value = '';
   }

   function deleteArticle(e) {
      e.preventDefault();
      let article = e.target.parentNode.parentNode;

      articlesSection.removeChild(article);
   }

   function archiveArticle(e) {
      e.preventDefault();
      let article = e.target.parentNode.parentNode;

      let articleHeading = article.getElementsByTagName('h1')[0];

      let archiveArticleList = document.querySelector('.archive-section ul');
      archiveArticle.textContent = '';

      let listItem = createElement('li', articleHeading.textContent);

      archiveArticleList.appendChild(listItem);

      let newList = Array.from(archiveArticleList.getElementsByTagName("li"))
         .sort((a, b) => a.textContent.localeCompare(b.textContent));

      archiveArticleList.innerHTML = "";

      for (const li of newList) {
         archiveArticleList.appendChild(li);
      }

      articlesSection.removeChild(article);
   }

   /**
   * @param {string} type Type of the DOM element
   * @param {string} text Text of the DOM element
   * @param {Array} classes Array of all DOM classes
   * @param {Number} id Od of the DOM element
   */
   function createElement(type, text, classes, id) {
      let element = document.createElement(type);

      if (text) {
         element.textContent = text;
      }

      if (classes) {
         element.classList.add(...classes);
      }

      if (id) {
         element.id = id;
      }

      return element;
   }
} 