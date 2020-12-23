var userid = localStorage.getItem("userId");
var board = board || {};
board.apiUrl = "https://localhost:44344/";
var userid = localStorage.getItem("userId");
board.drawBoards = function () {
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
                        <span class="board-name">${v.boardName}</span>
                    </div>
                </li> 
            `);
            })
            $('#AllBoard').append(` <li class="board-title add-table">
                    <div id="add-board-btn">
                         <a href="#" class="add-board">Tạo bảng mới</a>
                    </div>
                    
                    <div id="board-form" class="form-board">
                        <textarea rows="3" id="add-board-input"></textarea>
                        <div>
                            <a href="#" id="save-board-btn">Lưu</a>
                            <span id="close-board-btn">X<span>
                        </div>
                         
                    </div>
                </li>`);
            board.create();

        }
    });
}
board.load = function (id, nameboard) {
    

    localStorage.setItem("boardId", id);
    localStorage.setItem("boardName", nameboard);

    window.location.replace(`${board.apiUrl}list/index`);   

    //list.drawList(id);
}


board.create = function () {
    let addBoardBtn = document.querySelector("#add-board-btn");
    let formBoard = document.querySelector("#board-form");
    let boardInput = document.querySelector("#add-board-input");
    let saveBoard = document.querySelector("#save-board-btn");

    let closeBoardBtn = document.querySelector("#close-board-btn");

    addBoardBtn.onclick = function () {
        formBoard.style.display = "block";
        addBoardBtn.style.display = "none";
    }
    closeBoardBtn.onclick = function () {
        addBoardBtn.style.display = "block";
        formBoard.style.display = "none";

    }
    saveBoard.onclick = function () {
        var saveObj = {};
        saveObj.boardId = parseInt(0);
        saveObj.boardName = boardInput.value;
        saveObj.userId = userid;
        if (boardInput.value > 0) {
            $.ajax({
                url: `/board/save`,
                method: "POST",
                dataType: "JSON",
                contentType: "application/json",
                data: JSON.stringify(saveObj),
                success: function (response) {

                }
            })
        }

    }
}



board.init = function () {
    board.drawBoards();
}
$(document).ready(function () {
    board.init();
});


