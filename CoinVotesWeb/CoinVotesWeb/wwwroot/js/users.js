// Function to fetch users with pagination
async function fetchUsers(page = 1, pageSize = 10) {
    try {
        const response = await fetch(`/api/UsersApi/GetUsers?page=${page}&pageSize=${pageSize}`);
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();
        return data;
    } catch (error) {
        console.error('Error fetching users:', error);
        throw error;
    }
}

// Function to fetch a single user by ID
async function fetchUserById(id) {
    try {
        const response = await fetch(`/api/UsersApi/GetUser/${id}`);
        if (!response.ok) {
            if (response.status === 404) {
                return null;
            }
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();
        return data;
    } catch (error) {
        console.error('Error fetching user:', error);
        throw error;
    }
}

// Function to render users in a table
function renderUsers(users, containerId) {
    const container = document.getElementById(containerId);
    if (!container) return;

    const table = document.createElement('table');
    table.className = 'table table-dark table-hover';
    
    // Create table header
    const thead = document.createElement('thead');
    thead.innerHTML = `
        <tr>
            <th>ID</th>
            <th>Email</th>
            <th>Create Date</th>
            <th>Device Type</th>
        </tr>
    `;
    table.appendChild(thead);

    // Create table body
    const tbody = document.createElement('tbody');
    users.forEach(user => {
        const tr = document.createElement('tr');
        tr.innerHTML = `
            <td>${user.id}</td>
            <td>${user.email}</td>
            <td>${new Date(user.createDate).toLocaleString()}</td>
            <td>${user.deviceType}</td>
        `;
        tbody.appendChild(tr);
    });
    table.appendChild(tbody);

    // Clear container and append table
    container.innerHTML = '';
    container.appendChild(table);
}

// Function to render pagination controls
function renderPagination(currentPage, totalPages, containerId, onPageChange) {
    const container = document.getElementById(containerId);
    if (!container) return;

    const pagination = document.createElement('nav');
    pagination.setAttribute('aria-label', 'Page navigation');
    
    const ul = document.createElement('ul');
    ul.className = 'pagination justify-content-center';

    // Previous button
    const prevLi = document.createElement('li');
    prevLi.className = `page-item ${currentPage === 1 ? 'disabled' : ''}`;
    prevLi.innerHTML = `
        <a class="page-link" href="#" aria-label="Previous" ${currentPage === 1 ? 'tabindex="-1"' : ''}>
            <span aria-hidden="true">&laquo;</span>
        </a>
    `;
    if (currentPage > 1) {
        prevLi.querySelector('a').addEventListener('click', (e) => {
            e.preventDefault();
            onPageChange(currentPage - 1);
        });
    }
    ul.appendChild(prevLi);

    // Page numbers
    for (let i = 1; i <= totalPages; i++) {
        const li = document.createElement('li');
        li.className = `page-item ${i === currentPage ? 'active' : ''}`;
        li.innerHTML = `<a class="page-link" href="#">${i}</a>`;
        li.querySelector('a').addEventListener('click', (e) => {
            e.preventDefault();
            onPageChange(i);
        });
        ul.appendChild(li);
    }

    // Next button
    const nextLi = document.createElement('li');
    nextLi.className = `page-item ${currentPage === totalPages ? 'disabled' : ''}`;
    nextLi.innerHTML = `
        <a class="page-link" href="#" aria-label="Next" ${currentPage === totalPages ? 'tabindex="-1"' : ''}>
            <span aria-hidden="true">&raquo;</span>
        </a>
    `;
    if (currentPage < totalPages) {
        nextLi.querySelector('a').addEventListener('click', (e) => {
            e.preventDefault();
            onPageChange(currentPage + 1);
        });
    }
    ul.appendChild(nextLi);

    pagination.appendChild(ul);
    container.innerHTML = '';
    container.appendChild(pagination);
}

// Example usage:
// async function loadUsers() {
//     try {
//         const data = await fetchUsers(1, 10);
//         renderUsers(data.items, 'usersTable');
//         renderPagination(data.currentPage, data.totalPages, 'pagination', async (page) => {
//             const newData = await fetchUsers(page, 10);
//             renderUsers(newData.items, 'usersTable');
//             renderPagination(newData.currentPage, newData.totalPages, 'pagination', arguments.callee);
//         });
//     } catch (error) {
//         console.error('Error loading users:', error);
//     }
// } 