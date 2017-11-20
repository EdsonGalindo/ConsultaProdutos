(function () {
    'use strict';

    var nomeController = 'produtoController';

    angular.module('ProdutoApp').controller(nomeController, ['$scope', '$http', 'produtoFactory', produtoController]);

    function produtoController($scope, $http, produtoFactory)
    {
        $scope.produtos = [];

        produtoFactory.obterProdutosInicio()
            .done(function (data) {
                $scope.produtos = data;
                $scope.$apply() 
            })
            .fail(function (data) {
                alert('Ocorreu um erro ao acessar os dados dos produtos, tente novamente em instantes.');
            });

        $scope.Buscar = function (){
            var nomeProduto = $scope.nomeproduto;
            
            if (nomeProduto.length >= 3)
            {
                produtoFactory.buscarProduto(nomeProduto)
                    .done(
                    function (data) {
                        $scope.produtos = data;
                        $scope.$apply() 
                    })
                    .fail(function (response) {
                        alert('Ocorreu um erro ao buscar o produto desejado, tente novamente em instantes.');
                    });
            } else if (nomeProduto.length == 0) {
                produtoFactory.obterProdutosInicio()
                    .done(function (data) {
                        $scope.produtos = data;
                        $scope.$apply() 
                    })
                    .fail(function (data) {
                        alert('Ocorreu um erro ao acessar os dados dos produtos, tente novamente em instantes.');
                    });
            }
        };
    }

})();