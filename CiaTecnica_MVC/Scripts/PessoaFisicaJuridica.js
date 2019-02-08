
function configurarControles() {
    $('#PessoaFisicaGrid').hide();
    $('#PessoaJuridicaGrid').hide();

    $("#pessoaFisica_CPF").inputmask("mask", { "mask": "999.999.999-99" }, { reverse: true });
    $("#pessoaJuridica_CNPJ").inputmask("mask", { "mask": "99.999.999/9999-99" }, { reverse: true });

    $("#pessoaFisica_CEP").inputmask("mask", { "mask": "99999999" }, { reverse: true });
    $("#pessoaJuridica_CEP").inputmask("mask", { "mask": "99999999" }, { reverse: true });
}

function FormSeleciona()
{
    var opcao = $("#formopcao").val();

    if (opcao === "1") {
        $('#PessoaFisicaGrid').show();
        $('#PessoaJuridicaGrid').hide();
    } else {
        $('#PessoaFisicaGrid').hide();
        $('#PessoaJuridicaGrid').show();
    }
}

function PesquisaCEP(tipo) {

    var cepVal;

    if (tipo == 1) {
        cepVal = $("#pessoaFisica_CEP").val().replace(/\D/g, '');
    } else {
        cepVal = $("#pessoaJuridica_CEP").val().replace(/\D/g, '');
    }
    
    //Expressão regular para validar o CEP.
    var validacep = /^[0-9]{8}$/;

    //Valida o formato do CEP.
    if (validacep.test(cepVal)) {

        //Consulta o webservice viacep.com.br/
        $.getJSON("https://viacep.com.br/ws/" + cepVal + "/json/?callback=?", function (dados) {

            if (!("erro" in dados)) {

                if (tipo == 1)
                {
                    $("#pessoaFisica_endereco_Logradouro").val(dados.logradouro);
                    $("#pessoaFisica_endereco_Bairro").val(dados.bairro);
                    $("#pessoaFisica_endereco_Cidade").val(dados.localidade);
                } else {
                    $("#pessoaJuridica_endereco_Logradouro").val(dados.logradouro);
                    $("#pessoaJuridica_endereco_Bairro").val(dados.bairro);
                    $("#pessoaJuridica_endereco_Cidade").val(dados.localidade);
                    $("#pessoaJuridica_endereco_UFSigla").val(dados.uf);
                }

                
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

function retornaCep(dadosCEP) {
    
    console.log(dadosCEP);

    if (dadosCEP != null && !jQuery.isEmptyObject(dadosCEP)) {
        
        $("#pessoaFisica_endereco_Logradouro").val(dados.logradouro);
        $("#pessoaFisica_endereco_").val(dados.bairro);
        $("#pessoaFisica_endereco_").val(dados.localidade);
        $("#pessoaFisica_endereco_").val(dados.uf);
        
    } else {
        alert("CEP não encontrado");
    }
    
}
