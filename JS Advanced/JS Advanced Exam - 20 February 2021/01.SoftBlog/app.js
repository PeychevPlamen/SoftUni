function solve() {

   const author = document.getElementById('creator');
   const title = document.getElementById('title');
   const category = document.getElementById('category');
   const content = document.getElementById('content');

   const btnCreate = document.querySelector('button');

   btnCreate.addEventListener('click', (e) => {

      e.preventDefault();

      const article = document.createElement('article');
      const h1 = document.createElement('h1');
      h1.textContent = title.value;

      const pCategory = document.createElement('p');
      pCategory.textContent = 'Category: ';

      const strongCategory = document.createElement('strong');
      strongCategory.textContent = category.value;

      const pCreator = document.createElement('p');
      pCreator.textContent = 'Creator: ';

      const strongCreator = document.createElement('strong');
      strongCreator.textContent = author.value;

      const pContent = document.createElement('p');
      pContent.textContent = content.value;

      const posts = document.querySelector('main section');

      const div = document.createElement('div');
      div.className = 'buttons';

      const btnDelete = document.createElement('button');
      btnDelete.className = 'btn delete';
      btnDelete.textContent = 'Delete';
      btnDelete.addEventListener('click', deleteArticle);

      const btnArchive = document.createElement('button');
      btnArchive.className = 'btn archive';
      btnArchive.textContent = 'Archive';
      btnArchive.addEventListener('click', archive);

      pCategory.appendChild(strongCategory);
      pCreator.appendChild(strongCreator);
      div.appendChild(btnDelete);
      div.appendChild(btnArchive);
      article.appendChild(h1);
      article.appendChild(pCategory);
      article.appendChild(pCreator);
      article.appendChild(pContent);
      article.appendChild(div);
      posts.appendChild(article);

      author.value = '';
      title.value = '';
      content.value = '';
      category.value = '';

   });

   function deleteArticle() {
      const article = document.querySelector('article');
      article.remove();
   }

   function archive(e) {

      let title = e.target.parentNode.parentNode.querySelector('h1').textContent;
      deleteArticle(e);

      let newLi = document.createElement('li');
      newLi.textContent = title;

      let olParent = document.querySelector('section.archive-section>ol');
      let allLis = [...document.querySelectorAll('section.archive-section>ol>li')];

      allLis.push(newLi);

      allLis = allLis.sort((a, b) => a.textContent.localeCompare(b.textContent));

      for (let i = 0; i < allLis.length; i++) {
         olParent.appendChild(allLis[i]);
      }

   }
}
