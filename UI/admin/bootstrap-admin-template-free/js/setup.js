var istoken = getCookie('token');
if (istoken == null) window.location.href = '../../../404.html';
var token = decodeToken(istoken);

if (token['role'] != "Admin")
{
    window.location.href = '../../../404.html';
}

document.addEventListener('DOMContentLoaded', async () => {
    const userEmail = localStorage.getItem('userEmail');
    
    if (userEmail) {
        try {
            const response = await fetch(`https://localhost:7074/api/Account/GetByEmail/${userEmail}`);
            const data = await response.json();

            if (response.ok) {
                // Populate the account information fields
                const nameElements = document.querySelectorAll('.nameACC');
                console.log(nameElements);

                // Thay thế nội dung của từng phần tử với 'Hoàng'
                nameElements.forEach(element => {
                    element.textContent = data.name;
            });

            } else {
                alert('Không thể tải thông tin tài khoản.');
            }
        } catch (error) {
            alert('Đã xảy ra lỗi khi tải thông tin tài khoản.');
        }
    } else {
        alert('Bạn chưa đăng nhập.');
        window.location.href = 'login.html'; // Redirect to login if no email is found
    }
});
function logout() {
    deleteCookie('token');
    window.location.href = '../../../AuTh.html';
}
function setCookie(name, value, days) {
    let expires = "";
    if (days) {
        const date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "expires=" + date.toUTCString();
    }
    // document.cookie = name + "=" + (value || "") + ";" + expires + ";path=/;Secure;HttpOnly;SameSite=Strict";
    document.cookie = name + "=" + (value || "") + ";" + expires + "";
}

function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
    return null;
}

function deleteCookie(name) {
    document.cookie = `${name}=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/`;
}

function decodeTokenAndRedirect(token) {
    // Decode the token to extract the email and role
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    const payload = JSON.parse(jsonPayload);
    const role = payload['role']; // Adjust according to your claim type

    switch (role) {
        case 'Admin':
            window.location.href = 'http://127.0.0.1:5500/admin/bootstrap-admin-template-free/index.html'
            break;
        case 'Customer':
            window.location.href = 'index.html';
            break;
        default:
            window.location.href = 'index.html';
            break;
    }
}

function decodeToken(token) {
    // Decode the token to extract the email and role
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    const payload = JSON.parse(jsonPayload);
    return payload
}