
function configurarControles() {
    $('#PessoaFisicaGrid').hide();
    $('#PessoaJuridicaGrid').hide();

    $("#pessoaFisica_CPF").inputmask("mask", { "mask": "999.999.999-99" }, { reverse: true });
    $("#pessoaJuridica_CNPJ").inputmask("mask", { "mask": "99.999.999/9999-99" }, { reverse: true });
    
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


function pesquisaCep() {

    var IdCEP = $("#pessoaFisica_CEP").val();
    if (IdCEP.length == 8)
        $.ajax({
            type: "POST",
            url: "https://viacep.com.br/ws/" + IdCEP + "/json/?callback=?",
            success: retornaCep,
            dataType: "json"
        });
}

//function retornaCep(tipoMovimentosLst)
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
