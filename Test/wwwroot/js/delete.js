﻿
$((function () {
    var url;
    var redirectUrl;
    var target;

    $('body').append(`
                    <div class="modal fade" id="deleteModal" tabindex="-1" role="dialog" >
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title" id="myModalLabel">Важно</h4>
                                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body delete-modal-body">
                            
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-danger" data-dismiss="modal" id="confirm-delete">Удалить</button>
                                    <button type="button" class="btn btn-default" data-bs-dismiss="modal">Отмена</button>
                                </div>
                            </div>
                        </div>
                    </div>`);

    //Delete Action
    $(".delete").on('click', (e) => {
        e.preventDefault();

        target = e.target;
        var Id = $(target).data('id');
        var priceId = $(target).data('priceid');
        var controller = $(target).data('controller');
        var action = $(target).data('action');
        var bodyMessage = $(target).data('body-message');
        redirectUrl = $(target).data('redirect-url');

        url = "/" + controller + "/" + action + "?Id=" + Id + "&priceId=" + priceId;
        $(".delete-modal-body").text(bodyMessage);
        $("#deleteModal").modal('show');
    });

    $("#confirm-delete").on('click', () => {
        $.get(url)
            .done((result) => {
                if (!redirectUrl) {
                    return $(target).parent().parent().hide("slow");
                }
                window.location.href = redirectUrl;
            })
            .fail((error) => {
                if (redirectUrl)
                    window.location.href = redirectUrl;
            }).always(() => {
                $("#deleteModal").modal('hide');
            });
    });

}()));