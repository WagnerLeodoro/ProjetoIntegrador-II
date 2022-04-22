function validaSenha() {
    var valorSenha = document.getElementById("txtSenha").value;
    if (valorSenha.length < 6) {
        alert("Senha precisa ter ao menos 6 caracteres");
        return false;
    }
    else {
        return true;
    }
}

function validaEmail() {
    var email = document.getElementById("txtEmail").value;
    if (email == "" || email.indexOf("@") == -1 || email.substring.indexOf(".") == -1) {
        alert("Email inválido, preencha o campo corretamente");
        return false;
    }
    else {
        return true;
    }
}
