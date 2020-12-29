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
                <li onclick="board.load(${v.boardId},'${v.boardName}')" id="board_load__${v.boardId}"
                    class="board-title" style="background-image: url('https://trello-backgrounds.s3.amazonaws.com/SharedBackground/480x320/f83251a75f09041fa31badbdf2cab8d4/photo-1604213410393-89f141bb96b8.jpg');">
                    <div>
                        <span class="board-name" id="board-name__${v.boardId}">${v.boardName}</span>
                        <p><i class="fas fa-trash"  onclick = "board.delete(${v.boardId},'${v.boardName}', event)"></i></p>
                    </div>
                </li>
                <li id="board-form__${v.boardId}" class="board-title add-table">
                     <div>
                        <textarea rows="2" id="edit-board-input__${v.boardId}"></textarea>
                        <div>
                            <a href="#" id="save-board-btn__${v.boardId}">Lưu</a>
                            <span id="close-board-btn__${v.boardId}">X<span>
                        </div>                     
                    </div>      
                </li>
            `);
                board.edit(`board_load__${v.boardId}`,`board-name__${v.boardId}`, `board-form__${v.boardId}`, `edit-board-input__${v.boardId}`, `save-board-btn__${v.boardId}`, `close-board-btn__${v.boardId}`, `${v.boardName}`, v.boardId);
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

        debugger;
        if (boardInput.value.length > 0 && boardInput.value.length <= 50) {
            let saveObj = {};
            saveObj.boardId = parseInt(0);
            saveObj.boardName = boardInput.value;
            saveObj.userId = userid;
            $.ajax({
                url: `/board/save`,
                method: "POST",
                dataType: "JSON",
                contentType: "application/json",
                data: JSON.stringify(saveObj),
                success: function (response) {
                    if (response.data.boardId > 0) {
                        board.drawBoards();
                    } else {
                        alert(response.data.message);
                    }

                }
            })
        } else {
            alert('Tên bảng không được để trống và độ dài không quá 50 ký tự');
        }

    }
}


board.edit = function (board_load__id, board_name_id, board_form_id, board_input_id, save_board_id, close_board_id, boardName, boardId) {
    let boardLoadId = document.querySelector(`#${board_load__id}`);
    let boardNameBtn = document.querySelector(`#${board_name_id}`);
    let boardForm = document.querySelector(`#${board_form_id}`);
    let boardInput = document.querySelector(`#${board_input_id}`);
    let saveBoardBtn = document.querySelector(`#${save_board_id}`);
    let closeBoardBtn = document.querySelector(`#${close_board_id}`);

    boardForm.style.display = 'none';
    //đừng xóa hàm này tránh trường hợp onclick nó qua trang khác;
    boardNameBtn.onclick = function (event) {
        event.stopPropagation();
    }
    boardNameBtn.ondblclick = function (event) {
        event.stopPropagation();
        boardInput.value = boardName;
        boardForm.style.display = 'block';
        boardLoadId.style.display = 'none';
    }
    //chỉnh sửa bảng(lưu)
    saveBoardBtn.onclick = function () {
        let name = boardInput.value;
        if (name.length > 0 && name.length <= 50) {
            let saveObj = {};
            saveObj.boardId = parseInt(boardId);
            saveObj.boardName = name;
            saveObj.userId = userid;
            $.ajax({
                url: `/board/save`,
                method: "POST",
                dataType: "JSON",
                contentType: "application/json",
                data: JSON.stringify(saveObj),
                success: function (response) {
                    if (response.data.boardId > 0) {
                        window.location.href = "/board/Index";
                        alert(response.data.message);
                        boardForm.style.display = 'none';
                        boardLoadId.style.display = 'block';
                    } else {
                        alert(response.data.message);
                        boardForm.style.display = 'block';
                        boardLoadId.style.display = 'none';
                    }

                }
            })
            
            //lưu xong thì gọi tới cái này;
            
           
        } else {
            alert(`Tên bảng không được để trống và không quá 50 kí tự`);
           
            boardForm.style.display = 'block';
            boardLoadId.style.display = 'none';
        }
        
    }

    closeBoardBtn.onclick = function () {
        boardForm.style.display = 'none';
        boardLoadId.style.display = 'block';
    }
}

board.delete = function (boardId, boardName, event) {
    event.stopPropagation();
    bootbox.confirm({
        title: "Cảnh báo!!!",
        message: `<p class=\"text-danger\">Bạn có muốn xóa ${boardName} này không?</p>`,
        buttons: {
            cancel: {
                label: '<i class="fa fa-times mr-1"></i> Không'
            },
            confirm: {
                label: '<i class="fa fa-check mr-1"></i> Có'
            }
        },
        callback: function (result) {
            if (result) {               
                $.ajax({
                    url: `/board/changestatus/${boardId}/${3}/${userid}`,
                    method: "POST",
                    contentType: 'json',
                    success: function (response) {
                        if (response.data.boardId > 0) {
                            window.location.href = "/board/Index";
                            alert(response.data.message);
                        } else {
                            alert(response.data.message);
                        }
                    }
                });
            }
        }
    });
    
}


board.init = function () {
    board.drawBoards();
}
$(document).ready(function () {
    board.init();
});


