function solve() {

   let author = document.getElementById('creator');
   let title = document.getElementById('title');
   let category = document.getElementById('category');
   let content = document.getElementById('content');

   let btn = document.querySelector('.btn.create');
  
   btn.addEventListener('click', createPost);

   function createPost(e) {

      e.preventDefault();

      const siteContent = document.querySelector('.site-content main section');

      const article = document.createElement('article');

      const h1 = document.createElement('h1');
      h1.textContent = title.value;

      const pCat = document.createElement('p');
      pCat.textContent = 'Category: ';
      const strongCat = document.createElement('strong');
      strongCat.textContent = category.value;

      const pCreator = document.createElement('p');
      pCreator.textContent = 'Creator: ';
      const strongCreator = document.createElement('strong');
      strongCreator.textContent = author.value;

      const p = document.createElement('p');
      p.textContent = content.value;

      const div = document.createElement('div');
      div.classList.add('buttons');

      const btnDelete = document.createElement('button');
      btnDelete.classList.add('btn');
      btnDelete.classList.add('delete');
      btnDelete.textContent = 'Delete';
      btnDelete.addEventListener('click', deletePost);

      const btnArchive = document.createElement('button');
      btnArchive.classList.add('btn');
      btnArchive.classList.add('archive');
      btnArchive.textContent = 'Archive';
      btnArchive.addEventListener('click', archivePost);

      div.appendChild(btnDelete);
      div.appendChild(btnArchive);
      pCat.appendChild(strongCat);
      pCreator.appendChild(strongCreator);

      article.appendChild(h1);
      article.appendChild(pCat);
      article.appendChild(pCreator);
      article.appendChild(p);
      article.appendChild(div);

      siteContent.appendChild(article);

      author.value = '';
      title.value = '';
      category.value = '';
      content.value = '';

   }

   function deletePost(e) {

      let articleToDelete = e.target.parentNode.parentNode;

      articleToDelete.remove();

   }

   function archivePost(e) {

      let articleToArchive = e.target.parentNode.parentNode;

      const titleToArchive = articleToArchive.firstChild;
      
      const ol = document.querySelector('.archive-section ol');
      const li = document.createElement('li');

      const sortedLis = Array.from(ol.querySelectorAll('li'));
      li.textContent = titleToArchive.textContent;
          
      sortedLis.push(li);
      sortedLis.sort((a, b) => a.textContent.localeCompare(b.textContent));
      
      articleToArchive.remove();

      for (const li of sortedLis) {
         ol.appendChild(li);
      }
      
   }
}
