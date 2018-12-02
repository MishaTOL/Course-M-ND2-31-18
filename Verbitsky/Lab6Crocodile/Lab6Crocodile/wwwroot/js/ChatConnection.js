const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chat")
    .build();

connection.start().catch(err => console.error(err.toString()));

connection.on('Send', (name, message) => {
    let nameElement = document.createElement('strong');
    nameElement.innerText = `${name}:`;

    let msgElement = document.createElement('em');
    msgElement.innerText = ` ${message}`;

    let li = document.createElement('li');
    li.appendChild(nameElement);
    li.appendChild(msgElement);

    $('#messages').append(li);
});

document.getElementById('frm-send-message').addEventListener('submit', event => {
    let name = $('#spn-name').text();
    let message = $('#message').val();

    $('#message').val('');

    connection.invoke('Send', name, message);
    event.preventDefault();
});
