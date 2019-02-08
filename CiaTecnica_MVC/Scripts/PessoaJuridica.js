
function configurarControles() {
    $("#CPF").inputmask("mask", { "mask": "999.999.999-99" }, { reverse: true });
    $("#CEP").inputmask("mask", { "mask": "99999999" }, { reverse: true });
}

function PesquisaCEP() {

    var cepVal;

    cepVal = $("#CEP").val().replace(/\D/g, '');

    //Expressão regular para validar o CEP.
    var validacep = /^[0-9]{8}$/;

    //Valida o formato do CEP.
    if (validacep.test(cepVal)) {

        //Consulta o webservice viacep.com.br/
        $.getJSON("https://viacep.com.br/ws/" + cepVal + "/json/?callback=?", function (dados) {

            if (!("erro" in dados)) {

                $("#endereco_Logradouro").val(dados.logradouro);
                $("#endereco_Bairro").val(dados.bairro);
                $("#endereco_Cidade").val(dados.localidade);

            }
            else {
                //CEP pesquisado não foi encontrado.
                alert("CEP não encontrado.");
            }
        });


    } else {
        //cep é inválido.
        alert("Formato de CEP inválido.");
    }
}
