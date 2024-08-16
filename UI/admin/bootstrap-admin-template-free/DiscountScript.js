let rowToDelete = null;
let currentEditingId = null;

document.addEventListener('DOMContentLoaded', function() {
    getDiscounts(); // Tải dữ liệu mã giảm giá khi trang được tải
});

function searchDiscount() {
    const input = document.getElementById('search');
    const filter = input.value.toLowerCase();
    const table = document.getElementById('discountTable');
    const rows = table.getElementsByTagName('tbody')[0].getElementsByTagName('tr');

    for (let i = 0; i < rows.length; i++) {
        const cells = rows[i].getElementsByTagName('td');
        let match = false;
        for (let j = 0; j < cells.length; j++) {
            if (cells[j].innerText.toLowerCase().indexOf(filter) > -1) {
                match = true;
                break;
            }
        }
        rows[i].style.display = match ? '' : 'none';
    }
}
function addOrUpdateDiscount() {
    const code = document.getElementById('discountCode').value;
    const percent = document.getElementById('discountPercent').value;
    const maxDiscount = document.getElementById('maxDiscount').value;
    const expiryDate = document.getElementById('expiryDate').value;

    if (!code || !percent || !expiryDate) {
        alert('Vui lòng nhập đầy đủ thông tin.');
        return;
    }
    if (!code || code.length >50 || code.length <10) {
        alert('Mã giảm giá phải có độ dài từ 10 đến 50 ký tự.');
        return;
    }

    // Kiểm tra phần trăm giảm
    if (!percent || isNaN(percent) || percent < 0 || percent > 100) {
        alert('Phần trăm giảm phải là một số từ 0 đến 100.');
        return;
    }

    // Kiểm tra thời gian hết khuyến mãi
    if (!expiryDate) {
        alert('Vui lòng chọn thời gian hết khuyến mãi.');
        return;
    }
    const discount = {
        id: currentEditingId || undefined,
        code,
        amount: percent,
        usageLimit: maxDiscount || null,
        endDate: expiryDate,
        createdAt: new Date().toISOString(),
        updatedAt: currentEditingId ? new Date().toISOString() : null
    };

    if (currentEditingId === null) {
        // Thêm mã giảm giá mới
        postDiscount(discount);
    } else {
        // Cập nhật mã giảm giá hiện tại
        putDiscount(currentEditingId, discount);
    }
}

function editDiscount(button) {
    const row = button.closest('tr');
    const cells = row.cells;
    const code = cells[0].textContent;
    const percent = cells[1].textContent.replace('%', '');
    const maxDiscount = cells[2].textContent !== 'Không giới hạn' ? cells[2].textContent.replace(' VND', '').replace(/,/g, '') : '';
    const expiryDate = new Date(cells[3].textContent).toISOString().slice(0, 16); // Chuyển đổi định dạng ngày giờ
    const id = row.dataset.id;

    document.getElementById('discountCode').value = code;
    document.getElementById('discountPercent').value = percent;
    document.getElementById('maxDiscount').value = maxDiscount;
    document.getElementById('expiryDate').value = expiryDate;

    document.getElementById('submitButton').textContent = 'Cập Nhật';
    currentEditingId = id;
}

function resetForm() {
    document.getElementById('discountCode').value = '';
    document.getElementById('discountPercent').value = '';
    document.getElementById('maxDiscount').value = '';
    document.getElementById('expiryDate').value = '';
    document.getElementById('submitButton').textContent = 'Thêm';
    currentEditingId = null;
}

function openDeleteModal(button) {
    const row = button.closest('tr');
    rowToDelete = row;
    document.getElementById('deleteModal').classList.add('show');
}

function confirmDelete() {
    if (rowToDelete) {
        deleteDiscount(rowToDelete.dataset.id)
            .then(() => {
                rowToDelete.remove();
                rowToDelete = null;
            });
    }
    closeDeleteModal();
}

function cancelDelete() {
    rowToDelete = null;
    closeDeleteModal();
}

function closeDeleteModal() {
    document.getElementById('deleteModal').classList.remove('show');
}

const apiUrl = 'https://localhost:7074/api/Discount'; // Thay thế với URL API thực tế

async function getDiscounts() {
    try {
        const response = await fetch(apiUrl);
        if (!response.ok) throw new Error('Network response was not ok');
        const discounts = await response.json();
        populateTable(discounts);
    } catch (error) {
        console.error('Error fetching discounts:', error);
    }
}

async function postDiscount(discount) {
    try {
        const response = await fetch(apiUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(discount)
        });

        console.log('Response status:', response.status); // Log status code
        const responseBody = await response.text(); // Get raw response text
        console.log('Response body:', responseBody); // Log response body

        if (!response.ok) {
            throw new Error(`Network response was not ok: ${response.statusText} - ${responseBody}`);
        }

        const newDiscount = JSON.parse(responseBody);
        console.log('Discount added:', newDiscount);
        getDiscounts(); // Refresh the table
        resetForm(); // Reset the form after adding
    } catch (error) {
        console.error('Error posting discount:', error);
    }
}


async function putDiscount(id, discount) {
    try {
        const response = await fetch(`${apiUrl}/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(discount)
        });
        
        if (!response.ok) {
            const errorText = await response.text(); // Lấy thông tin lỗi từ phản hồi
            throw new Error(`Network response was not ok: ${response.statusText} - ${errorText}`);
        }

        console.log('Discount updated');
        getDiscounts(); // Refresh the table
        resetForm(); // Reset the form after updating
    } catch (error) {
        console.error('Error updating discount:', error);
    }
}

async function deleteDiscount(id) {
    try {
        const response = await fetch(`${apiUrl}/${id}`, {
            method: 'DELETE'
        });
        
        if (!response.ok) {
            const errorText = await response.text(); // Lấy thông tin lỗi từ phản hồi
            throw new Error(`Network response was not ok: ${response.statusText} - ${errorText}`);
        }

        console.log('Discount deleted');
    } catch (error) {
        console.error('Error deleting discount:', error);
    }
}

function populateTable(discounts) {
    const tableBody = document.querySelector('#discountTable tbody');
    tableBody.innerHTML = '';

    discounts.forEach(discount => {
        const row = tableBody.insertRow();
        row.dataset.id = discount.id; // Store the discount ID in the row data attribute
        row.innerHTML = `
            <td>${discount.code}</td>
            <td>${discount.amount}%</td>
            <td>${discount.usageLimit ? parseInt(discount.usageLimit).toLocaleString() + ' VND' : 'Không giới hạn'}</td>
            <td>${new Date(discount.endDate).toLocaleString()}</td>
            <td class="action-buttons">
                <button class="edit-button" onclick="editDiscount(this)">Sửa</button>
                <button class="delete-button" onclick="openDeleteModal(this)">Xóa</button>
            </td>
        `;
    });
}
