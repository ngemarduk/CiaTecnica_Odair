function pesquisaCep() {

    var IdCEP = $("#idCEP").val();
	if(IdCEP.length == 8)
		$.ajax({
			type: "POST",
			url: "https://viacep.com.br/ws/"+ IdCEP +"/json/?callback=?",
			success: retornaCep,
			dataType: "json"
		});
}
}

//function retornaCep(tipoMovimentosLst)
function retornaCep(dadosCEP) {

    var tipoMovimentoSelect = $('#IdTipoMovimento');
    tipoMovimentoSelect.empty();

    console.log("tipoMovimento: 0");

    if (dadosCEP != null && !jQuery.isEmptyObject(dadosCEP)) {

        if (tipoMovimentosLst.result) {

            //Atualiza os campos com os valores da consulta.
			$("#rua").val(dados.logradouro);
			$("#bairro").val(dados.bairro);
			$("#cidade").val(dados.localidade);
			$("#uf").val(dados.uf);
			$("#ibge").val(dados.ibge);
        } else {
            tipoMovimentoSelect.attr('disabled', true);
            alert("CEP não encontrado");
        }
    }
}