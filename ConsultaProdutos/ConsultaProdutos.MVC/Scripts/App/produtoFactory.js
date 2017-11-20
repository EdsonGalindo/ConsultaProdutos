(function () {
    'use strict';

    var nomeFactory = 'produtoFactory';

    angular.module('ProdutoApp').factory(nomeFactory, ['$http', produtoFactory]);

    function produtoFactory($http)
    {
        var retorno = [];
        function obterProdutosInicio()
        {
            return $.ajax({
                url: 'Produto/Lista',
                type: 'GET',
                async: true
            });
        }

        function buscarProduto(nomeProduto) {
            return $.ajax({
                url: ('http://localhost:51115/Produto/ListarProdutosPorNome?nomeProduto=' + nomeProduto),
                type: 'GET',
                async: true
            });
        }

        var service = {
            obterProdutosInicio: obterProdutosInicio,
            buscarProduto: buscarProduto
        };

        return service;
    }
})();