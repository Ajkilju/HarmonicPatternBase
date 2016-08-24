$("#userAvatar").on('change', function () {

    var countFiles = $(this)[0].files.length;

    var imgPath = $(this)[0].value;
    var extn = imgPath.substring(imgPath.lastIndexOf('.') + 1).toLowerCase();
    var newUserAvatarHolder = $("#newUserAvatarHolder");
    newUserAvatarHolder.empty();

    var filesize = document.getElementById('userAvatar').files[0].size;

    var userAvatar = $("#userAvatar");

    if (filesize > 50000) {
        alert("Za duzy obrazek. Dopuszczalna wielkość do 50KB");

        userAvatar.replaceWith(userAvatar = userAvatar.clone(true));

        return;
    }

    if (extn == "gif" || extn == "png" || extn == "jpg" || extn == "jpeg") {
        if (typeof (FileReader) != "undefined") {

            //loop for each file selected for uploaded.
            for (var i = 0; i < countFiles; i++) {

                var reader = new FileReader();
                reader.onload = function (e) {
                    $("<img />", {
                        "src": e.target.result,
                        "class": "img-circle",
                        "style": "margin-bottom:15px; height:150px; width:150px;"
                    }).appendTo(newUserAvatarHolder);

                }

                newUserAvatarHolder.show();
                $("#userAvatarHolder").hide();
                reader.readAsDataURL($(this)[0].files[i]);
            }

        } else {
            alert("Ta przeglądarka nie obsługuje FileReader.");
        }
    } else {
        alert("Dodany plik nie jest obrazkiem");
    }

});