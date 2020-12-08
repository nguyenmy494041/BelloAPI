var list = list || {};
var card = card || {};
var userId = parseInt(1);
list.apiUrl = "https://localhost:44320/api/list";
card.apiUrl = "https://localhost:44320/api/card";

var count = 0;
var arrayListName = [];


// function addList(saveCard, closeCard) {
//     saveCard.style.display = "inline-block";
//     closeCard.style.display = "none";
// }

function addList(saveList, closeList) {
    saveList.style.display = "inline-block";
    closeList.style.display = "none";
}
// có chỉnh
list.drawList = function () {
    count = 0;
    $.ajax({
        url: `list/gets/1`,
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            console.log(response.data);
            count = response.data.length;
            var str = ``;
            var strname = ``;
            for (let i = 0; i < count; i++) {
                strname += `<option value=${response.data[i].listId}>${response.data[i].listName}</option>`;
                str += `<option value=${i + 1}>${i + 1}</option>`;
            }
            $('#Alllist').empty()
            $.each(response.data, function (i, v) {
                $('#Alllist').append(`
                <div class="list" id="list__${v.listId}">
                    <div>
                        <div class="list-header">
                            <div class="list-name">
                                <h3 id="title__${v.listId}" class="list-title">${v.listName}</h3>
                                <input type="text" class="edit-list-title" id="edit-list-title__${v.listId}" style="width: 100%;font-size: 15px; font-weight:bold">
                            </div>
                            <span class="menu-list" id="menu-list__${v.listId}"><i class="fas fa-ellipsis-h"></i>
                        </div>                    
                        <div class="show-menu" style="float: right;">
                            <div id="menu_${v.listId}" class="menu-toggle">
                                <div>
                                    <h4>Thao tác</h4>
                                    <span id="close_menu__${v.listId}"><i class="fas fa-times"></i></span>
                                </div>
                                <hr>
                                <ul>
                                    <li id="add_card__${v.listId}"><a href="#">Thêm thẻ...</a></li>
                                    <li><a href="#">Sao Chép Danh Sách...</a></li>
                                    <li id="move_list_btn__${v.listId}"><a href="#">Di Chuyển Danh Sách...</a></li>
                                    <li>
                                        <div class="move_list_box" id="move_list_box__${v.listId}">
                                            <div>                                                
                                                <select class="form-control" style="font-size:12px;" name="move_list_box_input__${v.listId}" id="move_list_box_input__${v.listId}">
                                                ${str}
                                                </select>
                                                <span id="confirm_btn__${v.listId}"><i class="fas fa-check-square"
                                                        style="color: #46f563;"></i></span>
                                                <span id="not_confirm_btn__${v.listId}"><i class="fas fa-times-circle"></i></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li><a href="#">Theo dõi</a></li>
                                </ul>
                                <hr>
                                <ul>
                                    <li onclick="list.orderbyname(${v.listId})"><a href="#">Sắp xếp theo tên thẻ</a></li>
                                    <li onclick="list.orderbyduedate(${v.listId})"><a href="#">Sắp xếp theo ngày hết hạn</a></li>
                                
                                </ul>
                                <hr>
                                <ul>
                                    <li id="move_alllist_btn__${v.listId}"><a href="#">Di chuyển tất cả thẻ trong danh sách này...</a></li>
                                    <li>
                                        <div class="move_list_box" id="move_alllist_box__${v.listId}">
                                            <div>
                                                
                                                <select class="form-control" style="font-size:13px;" name="move_alllist_box_input__${v.listId}" id="move_alllist_box_input__${v.listId}">
                                                ${strname}
                                                </select>
                                                <span id="allconfirm_btn__${v.listId}"><i class="fas fa-check-square"
                                                        style="color: #46f563;"></i></span>
                                                <span id="not_allconfirm_btn__${v.listId}"><i class="fas fa-times-circle"></i></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li onclick = list.StorageAllCard(${v.listId})><a href="#">Lưu trữ tất cả thẻ trong danh sách này...</a></li>
                                </ul>
                                <hr>
                                <ul>
                                    <li onclick="list.StorageList(${v.listId})"><a href="#">Lưu trữ danh sách này</a></li>
                                </ul>
                            </div>
                        </div>
                        <div id="lists__${v.listId}"> 
                    </div>                       
                </div>
            `);
                card.dragg();
                list.move(`move_list_btn__${v.listId}`, `move_list_box__${v.listId}`, `confirm_btn__${v.listId}`, `not_confirm_btn__${v.listId}`, `move_list_box_input__${v.listId}`);
                list.showMenu(`menu-list__${v.listId}`, `menu_${v.listId}`, `close_menu__${v.listId}`);
                list.updateList(`title__${v.listId}`, `edit-list-title__${v.listId}`);
               
                list.drawCard(`card/gets`, v.listId);
                list.moveallcard(`move_alllist_btn__${v.listId}`, `move_alllist_box__${v.listId}`, `allconfirm_btn__${v.listId}`, `not_allconfirm_btn__${v.listId}`, `move_alllist_box_input__${v.listId}`);
            })

            $('#Alllist ').append(`
            <div class="container ">
                <div id="add-a-list-btn" ><i class="fas fa-plus" aria-hidden="true"> </i> Thêm danh sách mới </div>
                <div id="save-list-box">
                    <input id="list-input-box" placeholder="Thêm danh sách mới..." class="form-control" />
                    <button type="button" id="save-list-btn">Save</button>
                    <span id="closebtn-list"><i class="fas fa-times"></i></span>
                </div>
            </div>
            `);

            let addListBtn = document.getElementById("add-a-list-btn"),
                saveListBtn = document.getElementById("save-list-btn"),
                saveListBox = document.getElementById("save-list-box"),
                listInputBox = document.getElementById("list-input-box"),
                closeaddListBtn = document.getElementById("closebtn-list")

            addListBtn.addEventListener("click", function () {
                addList(saveListBox, addListBtn);
            });
            closeaddListBtn.addEventListener("click", function () {
                saveListBox.style.display = "none";
                addListBtn.style.display = "inline-block";
            });
            saveListBtn.addEventListener("click", function () {
                let listname = listInputBox.value;
                list.saveList(listname, 1);
            });
        }
    });
}
list.StorageList = function (id) {
    $.ajax({
        url: `list/changestatus/${id}/${parseInt(2)}`,
        method: 'POST',
        dataType: 'JSON',
        contentType: 'application/json',
        success: function (response) {
            if (response.data.listId > 0) {
                list.drawList();
            } else {
                alert(response.data.message);
            }
        }
    });
}
list.deleteList = function (id) {
    $.ajax({
        url: `list/changestatus/${id}/${parseInt(3)}`,
        method: 'POST',
        dataType: 'JSON',
        contentType: 'application/json',
        success: function (response) {
            if (response.data.listId > 0) {
                list.drawList();
            } else {
                alert(response.data.message);
            }
        }
    });
}
list.StorageAllCard = function (id) {
    $.ajax({
        url: `list/StorageAllCard/${id}`,
        method: 'POST',
        dataType: 'JSON',
        contentType: 'application/json',
        success: function (response) {
            if (response.data.listId > 0) {
                list.drawCard(`card/gets`, id);

            } else {
                alert(response.data.message);
            }
            document.querySelector(`#menu_${id}`).style.display = 'none';

        }
    });
}
list.drawCard = function (urlapi, listid) {
    debugger;
    $.ajax({
        url: `${urlapi}/${listid}`,
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $(`#lists__${listid}`).empty()
            $(`#lists__${listid}`).append(`<ul class="list-items card__list" id="sortable__${listid}">`)
            $(`#sortable__${listid}`).empty()
            $.each(response.data, function (i, v) {
                console.log(response.data);
                var strpro = "";
                strisdone = "";
                var classpro = "";
                var classisdone = "";
                var classduedate = "";
                (v.priority == 3 ? (strpro = "Thấp", classpro = "card__propriotylow") : v.priority == 2 ? (strpro = "Trung bình", classpro = "card__propriotymedium") : (v.priority == 1 ? (strpro = "Cao", classpro = "card__propriotyhigh") : (strpro = "", classpro = "card__propriotynull")));
                (v.isDone ? (strisdone = "Đã xong", classisdone = "isdone") : (strisdone = "Chưa xong", classisdone = "isnotdone"))
                v.dueDate == "0001-01-01T00:00:00" || v.dueDate == "1799-12-31T17:17:56" ? classduedate = "duedatenull" : classduedate = "duedatenear";
                $(`#sortable__${listid}`).append(`
                <li class="card__item" id="card__item__${v.cardId}" onclick="card.openModal(${v.cardId})">
                <span id="priority" class="card__tag card__tag--browser ${classpro}" value="${v.priority}">${strpro}</span>
                <div>
                <div class="${classisdone}">
                <span  title="Re-Fix">
                <span  >${strisdone}</span></span></div>
                <br>
                </div>
                <h6 class="card__title">${v.cardName}</h6>
                <ol class="card__actions"><i class="far fa-clock"></i>&nbsp;
                    <div class="${classduedate}" id="duedate">
                    ${v.dueDateStr}
                    </div>
                    <ol class="card__avatars">
                        <li class="card__avatars--item">
                            <!-- Photo by Philip Martin on Unsplash -->
                            <img src="https://images.unsplash.com/photo-1521119989659-a83eee488004?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=664&q=80"
                                alt="Man standing near balcony" class="avatar__image">
                        </li>
                    </ol>
                </ol>
            </li>
                `);
            })
            $('#lists').append(`</ul>`);

            $(`#lists__${listid}`).append(`
            <div class="add__card" id="add__card__${listid}">
                <div class="add-a-card-btn" id="add-a-card-btn__${listid}"><i class="fas fa-plus" aria-hidden="true"> </i> Thêm thẻ mới </div>
                <div class="save-card-box" id="save-card-box__${listid}">
                    <textarea class="card-input-box" id="card-input-box__${listid}" placeholder="Thêm thẻ mới..."></textarea>
                    <button type="button" class="save-card-btn" id="save-card-btn__${listid}">Save</button>
                    <span class="closebtn" id="closebtn__${listid}"><i class="fas fa-times"></i></span>
                </div>
            </div>
            `);
            list.createCard(`add-a-card-btn__${listid}`, `save-card-box__${listid}`, `card-input-box__${listid}`, `save-card-btn__${listid}`, `closebtn__${listid}`);
            list.dragg(listid);
        }
    });
}
list.updateList = function (id_h3, id_input) {
    let h3 = document.querySelector(`#${id_h3}`);
    var h32 = h3.textContent;
    let edit = document.querySelector(`#${id_input}`);
    edit.style.display = "none";
    h3.ondblclick = function () {
        edit.value = h3.innerHTML;
        edit.style.display = 'block';
        h3.style.display = 'none';
    }
    edit.onblur = () => {
        let string = document.getElementById(`${id_input}`).value;
        if (string.length > 0) {
            h3.innerHTML = edit.value;
            var saveList = {};
            let list_id = card.cuttingString(`${id_h3}`);
            saveList.listId = parseInt(list_id);
            saveList.listName = string;
            saveList.boardId = parseInt(1);

            $.ajax({
                url: `list/save`,
                method: 'PATCH',
                dataType: 'JSON',
                contentType: 'application/json',
                data: JSON.stringify(saveList),
                success: function (response) {
                    if (response.data.listId <= 0) {
                        alert(response.data.message);
                        h3.innerHTML = h32;
                    }
                }
            });
        }
        edit.style.display = 'none';
        h3.style.display = 'block';
    }
}


list.dragg = function (listid) {
    $(`#sortable__${listid}`).sortable({
        start: function (e, ui) {
            $(this).attr('data-previndex', ui.item.index());
        },
        stop: function (e, ui) {
            var newIndex = ui.item.index();
            var oldIndex = $(this).attr('data-previndex');
            var element_id = ui.item.attr('id');
            let list_id = document.getElementById(`${element_id}`).parentElement;
            //let listafter = list_id.getAttribute('id');
            //let cardIdarr = (element_id.split('__'));
            //let cardid = parseInt(cardIdarr[cardIdarr.length - 1]);
            let cardid = card.cuttingString(ui.item.attr('id'));
            //let listafterIdarr = (listafter.split('__'));
            //let listafterid = parseInt(listafterIdarr[listafterIdarr.length - 1]);  
            let listafterid = card.cuttingString(list_id.getAttribute('id'));
            card.dropdrap(cardid, listafterid, newIndex + 1);
            $(this).removeAttr('data-previndex');
        },
        connectWith: "ul",
        placeholder: "placeholder",
        delay: 50

    })
    $(`#sortable__${listid}`).disableSelection();
}

card.openModal = function (cardid) {
    $.ajax({
        url: `card/get/${cardid}`,
        method: 'GET',
        dataType: 'JSON',
        contentType: 'application/json',
        success: function (response) {
            console.log(response.data);
            $('#cardIdmodal').val(response.cardId);
            $('#cardname').val(response.cardName);
            $('#description').val(response.description);
            $('#duedatelocal').val(response.dueDate);
            $('#priority111').val(response.priority);
        }
    });
    $('#mymodal').modal("show");
}
card.dropdrap = function (cardId, listIdAfter, positionNew) {
    var saveObj = {};
    saveObj.cardId = parseInt(cardId);
    saveObj.listIdAfter = parseInt(listIdAfter);
    saveObj.positionNew = parseInt(positionNew);
    $.ajax({
        url: `card/drapdrop`,
        method: 'POST',
        dataType: 'JSON',
        contentType: 'application/json',
        data: JSON.stringify(saveObj),
    });
}
card.cuttingString = function (string) {
    let array = string.split('__');
    return parseInt(array[array.length - 1]);
}
card.updateCard = function () {
    let dateinput = document.getElementById("duedatelocal").value;
    let date = (dateinput = new Date("1/1/0001 12:00:00 AM")) ? new Date("1/1/1800 12:00:00 AM") : dateinput;
    let updateCardbox = {};
    updateCardbox.cardId = parseInt(document.getElementById("cardIdmodal").value);
    updateCardbox.cardName = document.getElementById(`cardname`).value;
    updateCardbox.description = document.getElementById("description").value;
    updateCardbox.dueDate = date;
    updateCardbox.priority = parseInt(document.getElementById("priority111").value);
    updateCardbox.modifiedBy = parseInt(1);
    $.ajax({

        url: `card/update`,
        method: 'PATCH',
        dataType: 'JSON',
        contentType: 'application/json',
        data: JSON.stringify(updateCardbox),
        success: function (response) {
            if (response.data.cardId > 0) {
                list.drawCard(`card/gets`, updateCardbox.cardId);
            } else {
                alert(response.data.message);
            }
        }
    });
}
card.completeCard = function () {
    let cardid = parseInt(document.getElementById("cardIdmodal").value);
    $.ajax({
        url: `card/complete/${cardid}`,
        method: 'POST',
        dataType: 'JSON',
        contentType: 'application/json',
        success:
            alert('Đã hoàn thành nhiệm vụ trên thẻ')
    });
}


list.saveList = function (stringname, boardId) {
    var saveObj = {};
    saveObj.listId = parseInt(0);
    saveObj.listName = stringname;
    saveObj.boardId = parseInt(boardId);
    if (stringname.length > 0 && stringname.length < 51) {
        $.ajax({
            url: `list/save`,
            method: 'POST',
            dataType: 'JSON',
            contentType: 'application/json',
            data: JSON.stringify(saveObj),
            success: function (response) {
                if (response.data.listId > 0) {
                    list.drawList();
                } else {
                    alert(response.data.message);
                }
            }
        });
    } else {
        alert('Tên danh sách không được để trống và không quá 50 kí tự');
    }
}


list.createCard = (add_card_id, save_card_box_id, input_card_id, save_card_btn_id, close_card_id) => {
    let add_card = document.querySelector(`#${add_card_id}`);
    let save_card_box = document.querySelector(`#${save_card_box_id}`);
    let input_card = document.querySelector(`#${input_card_id}`);
    let save_card_btn = document.querySelector(`#${save_card_btn_id}`);
    let close_card = document.querySelector(`#${close_card_id}`);

    add_card.onclick = () => {
        save_card_box.style.display = 'block';
        add_card.style.display = 'none';
    }
    save_card_btn.onclick = () => {
        let id = card.cuttingString(`${add_card_id}`);
        let cardName = input_card.value;
        let saveCard = {};
        saveCard.listId = parseInt(id);
        saveCard.cardName = cardName;
        saveCard.CreateBy = parseInt(1);
        if (cardName.length > 0) {
            $.ajax({
                url: `card/save`,
                method: 'POST',
                dataType: 'JSON',
                contentType: 'application/json',
                data: JSON.stringify(saveCard),
                success: (response) => {
                    if (response.data.cardId > 0) {
                        list.drawCard(`card/gets`, id);
                    } else {
                        alert(response.data.message);
                    }
                }
            });
        }
    }

    close_card.onclick = () => {
        save_card_box.style.display = 'none';
        add_card.style.display = 'block';
    }

}


card.dragg = function () {
    $('#Alllist').sortable({
        start: function (e, ui) {
            $(this).attr('data-previndex1', ui.item.index());
        },
        stop: function (e, ui) {
            let newIndex = ui.item.index();
            let oldIndex = $(this).attr('data-previndex1');
            let element_id = ui.item.attr('id');
            let listiddrap = card.cuttingString(element_id);
            list.dropdrap(listiddrap, newIndex + 1);
            //alert('id of Item moved: old position = ' + oldIndex + ' new position = ' + newIndex + 'listId =  '+element_id)
            $(this).removeAttr('data-previndex1');
        },
        connectWith: "div",
        placeholder: "placeholder",
        delay: 50
    })
    $('#Alllist').disableSelection();
}

list.dropdrap = function (listId, positionNew) {
    $.ajax({
        url: `list/drapdroplist/${listId}/${positionNew}`,
        method: 'POST',
        dataType: 'JSON',
        contentType: 'application/json',

    });
}

list.updateCard = (boxCardShow_id, editCardBtn_id, editCardBox_id, inputCard_id, saveCard_id, listId, cardName) => {
    let boxCardShow = document.querySelector(`#${boxCardShow_id}`),
        editCardBtn = document.querySelector(`#${editCardBtn_id}`),
        editCardBox = document.querySelector(`#${editCardBox_id}`),
        inputCard = document.querySelector(`#${inputCard_id}`),
        saveCardBtn = document.querySelector(`#${saveCard_id}`),
        cardId = card.cuttingString(boxCardShow_id);
    editCardBtn.onclick = (event) => {
        boxCardShow.style.display = 'none';
        editCardBox.style.display = 'block';
        inputCard.value = cardName;
        event.stopPropagation();
    }
    inputCard.onblur = () => {
        boxCardShow.style.display = 'block';
        editCardBox.style.display = 'none';
    }
    saveCardBtn.onmousedown = (event) => {
        event.preventDefault();
    }
    saveCardBtn.onclick = () => {

        let cardname = inputCard.value;
        if (cardname.length > 0 && cardname.length < 51) {
            let saveCard = {};
            saveCard.cardId = parseInt(cardId);
            saveCard.cardName = cardname;
            saveCard.modifiedBy = userId;
            $.ajax({
                url: `card/updatename`,
                method: 'PATCH',
                dataType: 'JSON',
                contentType: 'application/json',
                data: JSON.stringify(saveCard),
                success: function (response) {
                    if (response.data.cardId > 0) {
                        list.drawCard(`card/gets`, listId);
                    } else {
                        alert(response.data.message);
                    }
                }
            });
        }
        else {
            alert(`Tên thẻ không được để trống và độ dài không quá 50 kí tự`);
        }

    }
}

list.showMenu = (menu_list__id, menu_id, close_menu__id) => {

    let spanBtn = document.querySelector(`#${menu_list__id}`);
    let menuShow = document.querySelector(`#${menu_id}`);
    let closeBtn = document.querySelector(`#${close_menu__id}`)
    spanBtn.onclick = () => {
        menuShow.style.display = 'block';
    }
    closeBtn.onclick = () => {
        menuShow.style.display = 'none';
    }

}


list.move = function (move_list_btn__id, move_list_box__id, confirm_btn__id, not_confirm_btn__id, move_list_box_input__id) {

    let elementMovie = document.getElementById(move_list_btn__id);
    let box = document.getElementById(move_list_box__id);
    let confirmBtn = document.getElementById(confirm_btn__id);
    let notConfirmBtn = document.getElementById(not_confirm_btn__id);
    let number = document.getElementById(move_list_box_input__id);


    elementMovie.onclick = () => {
        box.style.display = 'block';
        // elementMovie.style.display = 'none';        
    }

    confirmBtn.onclick = () => {
        $.ajax({
            url: `list/drapdroplist/${card.cuttingString(move_list_btn__id)}/${number.value}`,
            method: 'POST',
            dataType: 'JSON',
            contentType: 'application/json',
            success: function (response) {
                list.drawList();
            }
        });
    }

    notConfirmBtn.onclick = () => {
        box.style.display = 'none';
        elementMovie.style.display = 'block';

    }
}


list.orderbyname = function (listid) {
    list.drawCard(`card/orderbyname`, listid);
    let menuShow = document.getElementById(`menu_${listid}`);
    menuShow.style.display = 'none';
}
list.orderbyduedate = function (listid) {
    list.drawCard(`card/orderbyduedate`, listid);
    let menuShow = document.getElementById(`menu_${listid}`);
    menuShow.style.display = 'none';
}


list.moveallcard = function (move_list_btn__id, move_list_box__id, confirm_btn__id, not_confirm_btn__id, move_list_box_input__id) {

    let elementMovie = document.getElementById(move_list_btn__id);
    let box = document.getElementById(move_list_box__id);
    let confirmBtn = document.getElementById(confirm_btn__id);
    let notConfirmBtn = document.getElementById(not_confirm_btn__id);
    let number = document.getElementById(move_list_box_input__id);

    let id = card.cuttingString(move_list_btn__id);
    let menuShow = document.querySelector(`#menu_${id}`);
    elementMovie.onclick = () => {
        box.style.display = 'block';
        // elementMovie.style.display = 'none';        
    }

    confirmBtn.onclick = () => {
        //alert(number.value);
        //alert(card.cuttingString(move_list_btn__id));
        $.ajax({
            url: `list/moveAllList/${card.cuttingString(move_list_btn__id)}/${number.value}`,
            method: 'POST',
            dataType: 'JSON',
            contentType: 'application/json',
            success: function (response) {
                if (response.data.listId > 0) {
                    list.drawList();
                } else {
                    alert(response.data.message);
                }
            }
        });
    }

    notConfirmBtn.onclick = () => {
        box.style.display = 'none';
        elementMovie.style.display = 'block';
        menuShow.style.display = 'none';
    }


}

list.init = function () {
    list.drawList();
}
$(document).ready(function () {
    list.init();
});
