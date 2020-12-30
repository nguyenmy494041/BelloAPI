var userid = localStorage.getItem("userId");
var board = board || {};
board.apiUrl = "https://localhost:44344/";

board.drawBoards = function () {
    debugger;
    $.ajax({
        url: `${board.apiUrl}board/gets/${userid}`,
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#AllBoard').empty()
            $.each(response.data, function (i, v) {
                $('#AllBoard').append(`
                <li onclick="board.load(${v.boardId},'${v.boardName}')"
                    class="board-title" style="background-image: url('https://trello-backgrounds.s3.amazonaws.com/SharedBackground/480x320/f83251a75f09041fa31badbdf2cab8d4/photo-1604213410393-89f141bb96b8.jpg');">
                    <div>
                        <span>${v.boardName}</span>
                    </div>
                </li> 
            `);
            })
            $('#AllBoard').append(` <li class="board-title add-table">
                    <a href="#">Tạo bảng mới</a>
                </li>`);

        }
    });
}
board.load = function (id, nameboard) {
    debugger;
    alert('mnsbjsbxms');
    localStorage.setItem("boardId", id);
    localStorage.setItem("boardName", nameboard);

    window.location.replace(`${board.apiUrl}list/index`);   

    //list.drawList(id);
}







board.init = function () {
    board.drawBoards();
}
$(document).ready(function () {
    board.init();
});


