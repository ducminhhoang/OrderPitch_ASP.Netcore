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


function showNotification(mess) {
    const notification = document.getElementById('notification');
    notification.textContent = mess;
    notification.classList.add('show');

    // Tự động ẩn thông báo sau 3 giây
    setTimeout(function() {
        notification.classList.remove('show');
    }, 3000);
}
function logout() {
    deleteCookie('token');
    sessionStorage.clear();
    localStorage.clear();
    window.location.href = 'index.html';
}
function login() {
    window.location.href = 'Auth.html?form=login';
}
function signin() {
    window.location.href = 'Auth.html?form=register';
}
function viewAccount() {
    window.location.href = 'account.html';
}