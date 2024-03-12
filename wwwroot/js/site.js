function login() {
    let login = document.getElementById("login").value;
    let password = document.getElementById("password").value;

    fetch("https://localhost:7152/Auth/Login", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify({
            login, password
        })
    }).then(res => {
        if (res.ok)
            window.location.href = "/Student";
        else
            console.log("Ошибка при выполнении запроса: " + res.status);

    });
}

function reg() {
    let surname = document.getElementById("surname").value;
    let name = document.getElementById("name").value;
    let patronymic = document.getElementById("patronymic").value;
    let userName = document.getElementById("userName").value;
    let password = document.getElementById("password").value;

    console.log(JSON.stringify({
        surname, name, patronymic, userName, password
    }))

    fetch("https://localhost:7152/Auth/Reg", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify({
            surname, name, patronymic, userName, password
        })
    }).then(res => {
        if (res.ok)
            window.location.href = "/Student";
        else
            console.log("Ошибка при выполнении запроса: " + res.status);

    });
}