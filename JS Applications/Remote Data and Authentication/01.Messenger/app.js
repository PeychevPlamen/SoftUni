function attachEvents() {

    let messagesTextarea = document.getElementById('messages');
    let author = document.getElementById('author');
    let message = document.getElementById('content');

    let submitBtn = document.getElementById('submit');
    let refreshBtn = document.getElementById('refresh');

    refreshBtn.addEventListener('click', getAllMessages);
    submitBtn.addEventListener('click', submitMsg);

    let url = 'http://localhost:3030/jsonstore/messenger';

    async function getAllMessages() {
        try {
            let allMsgResult = await fetch(url);
            let allMsg = await allMsgResult.json();

            // console.log(allMsg);

            let msgString = Object.values(allMsg)
                .map(msg => `${msg.author}: ${msg.content}`)
                .join('\n');

            // console.log(msgString);

            messagesTextarea.value = msgString;
        } catch (error) {
            console.error(error);
        }

    }

    async function submitMsg() {

        try {
            let msgToSubmit = {
                author: author.value,
                content: message.value
            };

            let createResponse = await fetch(url, {
                method: 'Post',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(msgToSubmit)
            });

            let createResult = await createResponse.json();

            // console.log(createResult);

            let createdMsg = `${createResult.author}: ${createResult.content}`;
            messagesTextarea.value += `\n${createdMsg}`;
            author.value = '';
            message.value = '';
        } catch (error) {
            console.error(error);
        }
    }
}

attachEvents();