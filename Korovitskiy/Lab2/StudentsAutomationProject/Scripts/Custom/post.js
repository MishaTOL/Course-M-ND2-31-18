var editPost = function () {
    $("#postContent").removeAttr("disabled");
    $("#postContent").removeAttr("readonly");
    $("#btn_edit_post").css("display", "none");
    $("#btn_apply_post").css("display", "inline-block");
}

var applyPost = function () {
    var id = $("#post_id").val();
    var content = $("#postContent").val();
    $.post("/Board/UpdatePost", { Id: id, Content: content }, function () {
        debugger;
        $("#postContent").attr("disabled", "");
        $("#postContent").attr("readonly", "");
        $("#btn_edit_post").css("display", "inline-block");
        $("#btn_apply_post").css("display", "none");
    });
}
var editComment = function (commentId) {
    debugger;
    $('#comment_' + commentId +' textarea').removeAttr("disabled");
    $('#comment_' + commentId +' textarea').removeAttr("readonly");
    $('#comment_' + commentId +' .btn_edit_comment').css("display", "none");
    $('#comment_' + commentId +' .btn_apply_comment').css("display", "inline-block");
}

var applyComment = function (commentId) {
    debugger;

    $('#comment_1 textarea').val()
    var content = $('#comment_' + commentId + ' textarea').val();
    $.post("/Board/UpdateComment", { Id: commentId, Content: content }, function () {
        $('#comment_' + commentId + ' textarea').attr("disabled", "");
        $('#comment_' + commentId + ' textarea').attr("readonly", "");
        $('#comment_' + commentId + ' .btn_edit_comment').css("display", "inline-block");
        $('#comment_' + commentId + ' .btn_apply_comment').css("display", "none");
    });
}

var deletePost = function (id) {
    $.post("/Board/deletePost", { Id: id }, function (data) {
        window.location = "/board/OnBoard/";
    });
}

var deleteComment = function (id) {
    $.post("/Board/deleteComment", { Id: id }, function (data) {
        debugger;
        $("#comment_" + id).remove();
    });
}