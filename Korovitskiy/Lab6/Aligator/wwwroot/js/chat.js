
$("#cahtInput").keyup(function (event) {
    if (event.keyCode == 13) {
        $("#chatInputButton").click();
    }
});

let hubUrlChat = 'https://localhost:44398/chat';
const hubConnectionChat = new signalR.HubConnectionBuilder()
    .withUrl(hubUrlChat)
    .configureLogging(signalR.LogLevel.Information)
    .build();

hubConnectionChat.on("Send", function (message, isRight) {
    var classSuccess = isRight == true ? " style='color:green'": "";
    $("#messageContainer .messages").append("<div " + classSuccess+">"+message+"</div>");
});

document.getElementById("chatInputButton").addEventListener("click", function (e) {
    var message = $("#cahtInput").val();
    if (message && groupId) {
        hubConnectionChat.invoke("Send", message, groupId);
        $("#cahtInput").val("");
    }
});

hubConnectionChat.start();
