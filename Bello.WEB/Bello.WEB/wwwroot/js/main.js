var userId = parseInt(1);
var menu = menu || {};
menu.cardAPIdUrl = "https://localhost:44320/api/card";
menu.listAPIUrl = "https://localhost:44320/api/list";

let showBtn = document.querySelector('#menu-btn');
let showMenuBoard = document.querySelector('#show-menu-board');
let boardMenuContent = document.querySelector('#board-menu-content');
let closeMenuContent = document.querySelector('#close-menu-content');

let seeMoreMenuHeader = document.querySelector('#add-board-menu-header-btn');
let boardMenuHeader = document.querySelector('#board-menu-header');
let backMenuContent = document.querySelector('#back-menu-content');
let closeMenuHeader = document.querySelector('#close-menu-header');


let storageBtn = document.querySelector('#storage-btn');
let boardMenuStorage = document.querySelector('#board-menu-storage');
let backMenuHeader = document.querySelector('#back-menu-header');
let closeMenuStorage = document.querySelector('#close-menu-storage');


showBtn.onclick = () => {
    showMenuBoard.style.display = 'block';
}
//menuContent
closeMenuContent.onclick = () => {
    showMenuBoard.style.display = 'none';
}
seeMoreMenuHeader.onclick = () => {

    boardMenuHeader.style.display = 'block';
    boardMenuContent.style.display = 'none';
}

//menuHeader
backMenuContent.onclick = () => {
    boardMenuHeader.style.display = 'none';
    boardMenuContent.style.display = 'block';
}

closeMenuHeader.onclick = () => {

    showMenuBoard.style.display = 'none';
    // boardMenuContent.style.display = 'block';
    // boardMenuHeader.style.display = 'none';
}

//Storage
storageBtn.onclick = () => {
    boardMenuStorage.style.display = 'block';
    boardMenuHeader.style.display = 'none';
}
backMenuHeader.onclick = () => {
    boardMenuStorage.style.display = 'none';
    boardMenuHeader.style.display = 'block';
}
closeMenuStorage.onclick = () => {
    showMenuBoard.style.display = 'none';
    boardMenuStorage.style.display = 'none';
    boardMenuContent.style.display = 'block';
}




//storage --> card -- list;
let showStorageCard = document.querySelector('#card-storage');
let storageCardBtn = document.querySelector('#list-storage-btn');
let storageListBtn = document.querySelector('#card-storage-btn')
let showStorageList = document.querySelector('#list-storage');

storageCardBtn.onclick = () => {
    menu.drawList();
    showStorageList.style.display = 'block';
    showStorageCard.style.display = 'none';
}
storageListBtn.onclick = () => {
    showStorageList.style.display = 'none';
    showStorageCard.style.display = 'block';
}

menu.drawCard = function () {
    $.ajax({
        url: `${menu.cardAPIdUrl}/GetCardSaved`,
        method: 'GET',
        dataType: 'JSON',
        success: function (data) {
            $(`#getCardSave`).empty();
            $(`#getCardSave`).append(`<ul class="list-items card__list" id="sortable__cardSave">`);
            $.each(data, function (i, v) {
                console.log(data);
                var strpro = "";
                strisdone = "";
                var classpro = "";
                var classisdone = "";
                var classduedate = "";
                (v.priority == 3 ? (strpro = "Thấp", classpro = "card__propriotylow") : v.priority == 2 ? (strpro = "Trung bình", classpro = "card__propriotymedium") : (v.priority == 1 ? (strpro = "Cao", classpro = "card__propriotyhigh") : (strpro = "", classpro = "card__propriotynull")));
                (v.isDone ? (strisdone = "Đã xong", classisdone = "isdone") : (strisdone = "Chưa xong", classisdone = "isnotdone"))
                v.dueDate == "0001-01-01T00:00:00" || v.dueDate == "1799-12-31T17:17:56" ? classduedate = "duedatenull" : classduedate = "duedatenear";
                $(`#sortable__cardSave`).append(`
                <li class="card__item" style="width: 80%;margin: auto;">
                <span  class="card__tag card__tag--browser ${classpro}" value="${v.priority}">${strpro}</span>
                <div>
                <div class="${classisdone}">
                <span  title="Re-Fix">
                <span  >${strisdone}</span></span></div>
                <br>
                </div>
                <h6 class="card__title" style="float:left;">${v.cardName}</h6>
                <ol class="card__actions" style="width: 100%;"><i class="far fa-clock"></i>&nbsp;
                    <div class="${classduedate}">
                    ${v.dueDateStr}
                    </div>
                    <ol class="card__avatars">
                        <li class="card__avatars--item" style="width:30px;height: 30px; display: flex;align-items: center; margin-right: 6px;">
                            <!-- Photo by Philip Martin on Unsplash -->
                            <img src="https://images.unsplash.com/photo-1521119989659-a83eee488004?ixlib=rb-1.2.1&amp;ixid=eyJhcHBfaWQiOjEyMDd9&amp;auto=format&amp;fit=crop&amp;w=664&amp;q=80" alt="Man standing near balcony" class="avatar__image" style="height: 16px; width:14px;">
                        </li>
                    </ol>
                </ol>
            </li>
                        <div class="return-card">
                            <a href="#" onclick="menu.undoCard(${v.cardId})" id="to-return__${v.cardId}">Hoàn trả vào bảng</a>
                            <p>-</p>
                            <a href="#" onclick="menu.deleteCard(${v.cardId})" id="delete__${v.cardId}">Xóa</a>
                        </div>
                `);
            });
            $(`#sortable__cardSave`).append(`</ul`);
        }
    });
}

menu.undoCard = function (id) {
    $.ajax({
        url: `${menu.cardAPIdUrl}/changestatus/${id}/${1}`,
        method: 'POST',
        dataType: 'JSON',
        contentType: 'application/json',
        success: function (data) {

            if (data.cardId > 0) {
                menu.drawCard();
                list.drawList();
            } else {
                alert(data.message);
            }
        }
    });
}
menu.deleteCard = function (id) {
    $.ajax({
        url: `${menu.cardAPIdUrl}/changestatus/${id}/${3}`,
        method: 'POST',
        dataType: 'JSON',
        contentType: 'application/json',
        success: function (data) {

            if (data.cardId > 0) {
                menu.drawCard();
            } else {
                alert(data.message);
            }
        }
    });
}
menu.undoList = function (id) {
    $.ajax({
        url: `${menu.listAPIUrl}/changestatus/${id}/${1}`,
        method: 'POST',
        dataType: 'JSON',
        contentType: 'application/json',
        success: function (data) {
            if (data.listId > 0) {
                list.drawList();
                menu.drawList();
            } else {
                alert(data.message);
            }
        }
    });
}
menu.deleteList = function (id) {
    $.ajax({
        url: `${menu.listAPIUrl}/changestatus/${id}/${3}`,
        method: 'POST',
        dataType: 'JSON',
        contentType: 'application/json',
        success: function (data) {
            if (data.listId > 0) {
                menu.drawList();
            } else {
                alert(data.message);
            }
        }
    });
}
menu.drawList = function () {
    $.ajax({
        url: `${menu.listAPIUrl}/GetListSaved`,
        method: 'GET',
        dataType: 'JSON',
        success: function (data) {
            $(`#drapListSave`).empty();
            $.each(data, function (i, v) {
                $(`#drapListSave`).append(`<div class="return-list">
                    <span>${v.listName}</span>
                    <div>
                        <a onclick="menu.undoList(${v.listId})" href="#" id="return-list__${v.listId}"><i class="fas fa-undo-alt"></i>
                            Hoàn trả vào bảng
                        </a>  
                        <a onclick="menu.deleteList(${v.listId})" href="#" id="delete-list__${v.listId}">
                            Xóa
                        </a>  
                    </div>            
                </div>`);
            })
        }
    });
}