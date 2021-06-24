function solve() {

    const tasks = document.getElementById('task');
    const description = document.getElementById('description');
    const date = document.getElementById('date');

    const addBtn = document.getElementById('add');

    const sections = document.querySelectorAll('section');

    addBtn.addEventListener('click', add);

    function add(e) {

        e.preventDefault();

        if (tasks.value == '' || description.value == '' || date.value == '') {
            return;
        }

        let startBtn = document.createElement('button');
        startBtn.classList.add('green');
        startBtn.textContent = 'Start';
        startBtn.addEventListener('click', addInProgress);

        let deleteBtn = document.createElement('button');
        deleteBtn.classList.add('red');
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', deleteTask);

        const div = document.createElement('div');
        div.classList.add('flex');
        div.appendChild(startBtn);
        div.appendChild(deleteBtn);

        const pDate = document.createElement('p');
        pDate.textContent = `Due Date: ${date.value}`;

        const pDescription = document.createElement('p');
        pDescription.textContent = `Description: ${description.value}`;

        const h3 = document.createElement('h3');
        h3.textContent = tasks.value;

        const article = document.createElement('article');
        article.appendChild(h3);
        article.appendChild(pDescription);
        article.appendChild(pDate);
        article.appendChild(div);


        const divToAdd = sections[1].children;
        divToAdd[1].appendChild(article);

        tasks.value = '';
        description.value = '';
        date.value = '';


    }

    function addInProgress(e) {

        const article = e.target.parentNode.parentNode;
        
        const divId = document.getElementById('in-progress');

        divId.appendChild(article);
               
        const finishBtn = document.createElement('button');
        finishBtn.textContent = 'Finish';
        finishBtn.classList.add('orange');
        finishBtn.addEventListener('click', finishFunc);
        
        article.lastElementChild.remove();

        let deleteBtn = document.createElement('button');
        deleteBtn.classList.add('red');
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', deleteTask);
       
        const div = document.createElement('div');
        div.classList.add('flex');
        div.appendChild(deleteBtn);
        div.appendChild(finishBtn);

        article.appendChild(div);
                      
    }

    function deleteTask(e) {

        const article = e.target.parentNode.parentNode;
        article.remove();
    }

    function finishFunc(e) {

        const article = e.target.parentNode.parentNode;
        article.lastElementChild.remove();
        
        sections[3].appendChild(article);
        
    }

}