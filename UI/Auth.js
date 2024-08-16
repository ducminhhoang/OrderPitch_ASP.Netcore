// Hiển thị form đăng ký
  function showRegisterForm() {
    document.getElementById('login-form').style.display = 'none';
    document.getElementById('register-form').style.display = 'block';
}

// Hủy đăng ký và quay về form đăng nhập
function cancelRegister() {
    document.getElementById('register-form').style.display = 'none';
    document.getElementById('login-form').style.display = 'block';
}

// Xử lý gửi form đăng ký
document.getElementById('register-form-content').addEventListener('submit', async (e) => {
    e.preventDefault();
    
    const name = document.getElementById('register-name').value;
    const email = document.getElementById('register-email').value;
    const phone = document.getElementById('register-phone').value;
    const password = document.getElementById('register-password').value;
    const address = document.getElementById('register-address').value;
    const accountTypeId = 2;
    
    try {
        const response = await fetch('https://localhost:7074/api/Auth/register', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ name, email, phone, password, address, accountTypeId })
        });
        const data = await response.json();
        
        if (response.ok) {
            // Hiển thị thông báo thành công và chuyển hướng về form đăng nhập
            Swal.fire({
                title: 'Thành công!',
                text: data.message,
                icon: 'success',
                timer: 2000, // Hiển thị thông báo trong 2 giây
                showConfirmButton: false
            }).then(() => {
                cancelRegister();
            });
        } else {
            document.getElementById('register-message').textContent = data.message;
        }
    } catch (error) {
        document.getElementById('register-message').textContent = 'Đã xảy ra lỗi trong quá trình đăng ký.';
    }
});
// Xử lý gửi form đăng nhập
document.getElementById('login-form-content').addEventListener('submit', async (e) => {
    e.preventDefault();
    
    const email = document.getElementById('login-email').value;
    const password = document.getElementById('login-password').value;
    
    
    try {
        const response = await fetch('https://localhost:7074/api/Auth/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        });
        
        const data = await response.json();
        
        if (response.ok) {
            localStorage.setItem('userEmail', email);
            setCookie('token', data.token, 1);
            decodeTokenAndRedirect(data.token);
            
            // Chuyển hướng đến trang chính hoặc xử lý sau khi đăng nhập thành công
             // Thay đổi URL theo trang chính của bạn
        } else {
            alert('Đăng nhập không thành công. Vui lòng kiểm tra thông tin.');
        }
        
    } catch (error) {
        console.log(error);
        
        alert('Đã xảy ra lỗi trong quá trình đăng nhập.');
    }
});

function setCookie(name, value, days) {
    let expires = "";
    if (days) {
        const date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "expires=" + date.toUTCString();
    }
    // document.cookie = name + "=" + (value || "") + ";" + expires + ";path=/;Secure;HttpOnly;SameSite=Strict";
    document.cookie = name + "=" + (value || "") + ";" + expires;
    
}

function decodeTokenAndRedirect(token) {
    // Decode the token to extract the email and role
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    const payload = JSON.parse(jsonPayload);
    console.log(payload);
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