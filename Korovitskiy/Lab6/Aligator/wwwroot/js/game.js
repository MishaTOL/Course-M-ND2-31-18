var groupId = undefined;
let hubUrlGame = 'https://localhost:44398/game';
const hubConnectionGame = new signalR.HubConnectionBuilder()
    .withUrl(hubUrlGame)
    .configureLogging(signalR.LogLevel.Information)
    .build();

hubConnectionGame.on("StartGame", function (group, isYouDrow) {
    groupId = group;
    if (isYouDrow) {
        $(".inputWord").show();
    }
    else {
        $("#drower").off("mousedown");
    }
    alert("Game started");
});

$(".inputWord .inputButton").click(function (data) {
    var word = $(".inputWord .inputText").val();
    hubConnectionGame.invoke("ApplyWord", groupId, word);
    $("#drower").css("pointer-events", "auto")
    $(".inputWord").hide();
})

hubConnectionGame.start().then(function () {
    hubConnectionGame.invoke("AddNewGamer");
});