var login = login || {}
login.apiUrl = "https://localhost:44344";

login.login = function () {
    if ($('#loginform').valid()) {
        var saveObj = {};
        saveObj.Email = $('#email').val();
        saveObj.Password = $('#password').val();
        $.ajax({
            url: `/account/login`,
            method: 'POST',
            dataType: 'JSON',
            contentType: 'application/json',
            data: JSON.stringify(saveObj),
            success: function (response) {
                console.log(response.data);
                if (response.data.success) {
                    localStorage.setItem("userId", response.data.userId);
                    window.location.replace("https://localhost:44344/board/index")
                } else {
                    alert(`Email hoặc mật khẩu chưa đúng`);
                }
            }
        });
    }
}

login.signup = function () {
    if ($('#signupform').valid()) {
        debugger;
        var saveObj = {};
        saveObj.Email = $('#emailsignup').val();
        saveObj.Password = $('#passwordsignup').val();
        saveObj.FullName = $('#fullname').val();
        $.ajax({
            url: `/account/register`,
            method: 'POST',
            dataType: 'JSON',
            contentType: 'application/json',
            data: JSON.stringify(saveObj),
            success: function (response) {
                console.log(response.data);
                if (response.data.success) {
                    let loginObj = {};
                    debugger;
                    loginObj.Email = $('#emailsignup').val();
                    loginObj.Password = $('#passwordsignup').val();
                    $.ajax({
                        url: `/account/login`,
                        method: 'POST',
                        dataType: 'JSON',
                        contentType: 'application/json',
                        data: JSON.stringify(loginObj),
                        success: function (response) {
                            console.log(response.data);
                            if (response.data.success) {
                                localStorage.setItem("userId", response.data.userId);
                                window.location.replace("https://localhost:44344/board/index")
                            } else {
                                alert(`Email hoặc mật khẩu chưa đúng`);
                            }
                        }
                    });
                } else {
                    alert(`Đăng ký thất bại`);
                }
            }
        });
    }
}





