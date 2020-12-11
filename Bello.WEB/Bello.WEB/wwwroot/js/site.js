
//var list = list || {};
//var card = card || {};

//list.apiUrl = "https://localhost:44320/api";
//card.apiUrl = "https://localhost:44320/api/card";

//list.drawList = function (id) {
//    $.ajax({
//        url: `${list.apiUrl}/gets/${id}`,
//        method: 'GET',
//        dataType: 'JSON',
//        success: function (data) {
//            $('#Alllist').empty()
//            $.each(data, function (i, v) {
//                $('#Alllist').append(`
//            <div class="list" >
//            <h3 class="list-title">${v.listName}</h3>
//            <div id="lists__${v.listId}">
//            </div>
            
//        </div>   
//        `);
//                list.drawCard(v.listId)

//            })

//            $('#Alllist').append(`<div id="container">
//            <div id="add-a-list-btn"><i class="fas fa-plus" aria-hidden="true"> </i> Thêm danh sách mới </div>
//            <div id="save-list-box">
//                <input id="list-input-box" placeholder="Thêm danh sách mới..." class="form-control" />
//                <button type="button" id="save-list-btn">Save</button>
//                <span id="closebtn">X</span>
//            </div>
//        </div>`);

//        }
//    });
//}
//list.drawCard = function (listid) {
//    $.ajax({
//        url: `${card.apiUrl}/gets/${listid}`,
//        method: 'GET',
//        dataType: 'JSON',
//        success: function (data) {
//            $(`#lists__${listid}`).empty()
//            $(`#lists__${listid}`).append(`<ul class="list-items card__list" id="sortable__${listid}">`)
//            $(`#sortable__${listid}`).empty()
//            $.each(data, function (i, v) {
//                $(`#sortable__${listid}`).append(`
//                <li class="card__item" id="card__item__${v.cardId}">
//                    <span class="card__tag card__tag--browser">${v.priority}</span>
//                    <h6 class="card__title">${v.cardName}</h6>
//                    <ol class="card__actions">
//                        <li class="card__actions--wrapper">
//                        </li>
//                        <ol class="card__avatars">
//                            <li class="card__avatars--item">
//                                <!-- Photo by Philip Martin on Unsplash -->
//                                <img src="https://images.unsplash.com/photo-1521119989659-a83eee488004?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=664&q=80"
//                                    alt="Man standing near balcony" class="avatar__image">
//                            </li>
//                        </ol>
//                    </ol>
//                </li>
//                `);

//            })
//            $('#lists').append(`</ul>`)
//            //list.sortlist(listid);
//            list.dragg(listid);

//        }
//    });
//}
//// list.sortlist = function (listid) {

////     // $(`#sortable__${listid}`).sortable();
////     // $(`#sortable__${listid}`).disableSelection();
////     $(`#sortable__${listid}`).sortable({

////         start: function (e, ui) {

////             $(this).attr('data-previndex', ui.item.index());
////         },
////         update: function (e, ui) {
////             var newIndex = ui.item.index();
////             var oldIndex = $(this).attr('data-previndex');
////             var element_id = ui.item.attr('id');
////             alert('id of Item moved = ' + element_id + ' old position = ' + oldIndex + ' new position = ' + newIndex);
////             $(this).removeAttr('data-previndex');
////         }
////     });
////     $(`#sortable__${listid}`).disableSelection();

//// }
//list.dragg = function (listid) {
//    $(`#sortable__${listid}`).sortable({
//        start: function (e, ui) {

//            $(this).attr('data-previndex', ui.item.index());
//        },
//        stop: function (e, ui) {
//            var newIndex = ui.item.index();
//            var oldIndex = $(this).attr('data-previndex');
//            var element_id = ui.item.attr('id');
//            let list_id = document.getElementById(`${element_id}`).parentElement;
//            let listafter = list_id.getAttribute('id');
//            let cardIdarr = (element_id.split('__'));
//            let cardid = parseInt(cardIdarr[cardIdarr.length - 1]);
//            let listafterIdarr = (listafter.split('__'));
//            let listafterid = parseInt(listafterIdarr[listafterIdarr.length - 1]);
//            card.dropdrap(cardid, listafterid, newIndex + 1);
//            //alert('id of Item moved = ' + element_id + ' old position = ' + oldIndex + ' new position = ' + newIndex + 'listafter = ' + listafter);
//            $(this).removeAttr('data-previndex');
//        },
//        connectWith: "ul",
//        placeholder: "placeholder",
//        delay: 50
//    })
//    $(`#sortable__${listid}`).disableSelection();
//}
//card.dropdrap = function (cardId, listIdAfter, positionNew) {
//    var saveObj = {};
//    saveObj.cardId = parseInt(cardId);
//    saveObj.listIdAfter = parseInt(listIdAfter);
//    saveObj.positionNew = parseInt(positionNew);
//    $.ajax({
//        url: `${card.apiUrl}/drapdrop`,
//        method: 'POST',
//        dataType: 'JSON',
//        contentType: 'application/json',
//        data: JSON.stringify(saveObj),
//    });

//}
//list.init = function () {
//    list.drawList();
//}


//$(document).ready(function () {
//    list.init();
//});




