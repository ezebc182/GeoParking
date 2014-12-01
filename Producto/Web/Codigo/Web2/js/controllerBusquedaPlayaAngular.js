//aplicacion angular con modulo de ng-grid
var app = angular.module('myApp', ['ngGrid']);

//controlador de la aplicacion (busqueda playa)
app.controller('MyCtrl', function ($scope, $http) {

    //playas de la BD de la ciudad buscada
    $scope.playasBD = [];

    $scope.mostrarGrilla = false;

    //opciones de la grilla
    $scope.filterOptions = {
        filterText: ''
        // useExternalFilter: true
    };
    $scope.totalServerItems = 0;
    $scope.pagingOptions = {
        pageSizes: [5, 10, 20],
        pageSize: 5,
        currentPage: 1
    };

    /*seteo de la paginacion por cambio de pagina*/
    $scope.setPagingData = function (data, page, pageSize) {
        var pagedData = data.slice((page - 1) * pageSize, page * pageSize);
        $scope.myData = pagedData;
        $scope.totalServerItems = data.length;
        if (!$scope.$$phase) {
            $scope.$apply();
        }
    };

    /*sincronizacion con los datos*/
    $scope.getPagedDataAsync = function (pageSize, page, searchText) {
        setTimeout(function () {
            var data;
            if (searchText) {
                var ft = searchText.toLowerCase();
                $http({
                    url: "reclamos.php",//mi pagina de begin
                    method: "POST",
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                    data: $.param({
                        ciudad: $scope.ciudad //ciudad guardada en el modelo (textbox)
                    })
                }).success(function (largeLoad, status, headers, config) {
                    datos = eval(JSON.stringify(largeLoad));

                    data = datos.filter(function (item) {
                        return JSON.stringify(item).toLowerCase().indexOf(ft) != -1;
                    });
                    $scope.setPagingData(data, page, pageSize);
                }).error(function (data, status, headers, config) {
                    alert(status);
                });

            }
            else {

                datos = [{ 'id': "1", 'nombre': "Playa Patio Olmos", 'tipoPlaya': "techada", 'direccion': "Bv San Juan 298", 'vehiculos': "Autos y motos", 'precios': "$9" },
                            { 'id': "2", 'nombre': "Playa Verde", 'tipoPlaya': "descubierta", 'direccion': "Bv San Juan 298", 'vehiculos': "Autos, motos y bicis", 'precios': "$12" },
                            { 'id': "3", 'nombre': "Playa Dean Funes", 'tipoPlaya': "techada", 'direccion': "Bv San Juan 298", 'vehiculos': "Autos y motos", 'precios': "$19" },
                            { 'id': "4", 'nombre': "Estrada Panking", 'tipoPlaya': "descubierta", 'direccion': "Bv San Juan 298", 'vehiculos': "Autos", 'precios': "$14" },
                            { 'id': "5", 'nombre': "Playa Bolivar", 'tipoPlaya': "techada", 'direccion': "Bv San Juan 298", 'vehiculos': "Autos", 'precios': "$16" },
                            { 'id': "6", 'nombre': "Playa Mitre", 'tipoPlaya': "subterranea", 'direccion': "Bv San Juan 298", 'vehiculos': "Autos y motos", 'precios': "$14" },
                            { 'id': "7", 'nombre': "Playa Azul", 'tipoPlaya': "techada", 'direccion': "Bv San Juan 298", 'vehiculos': "Autos, motos y bicis", 'precios': "$23" }];
                $scope.setPagingData(datos, page, pageSize);

                $http({
                    url: "reclamos.php",//mi pagina de begin
                    method: "POST",
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                    data: $.param({
                        ciudad: $scope.ciudad //ciudad guardada en el modelo (textbox)
                    })
                }).success(function (largeLoad, status, headers, config) {

                    datos = eval(JSON.stringify(largeLoad));
                    $scope.setPagingData(datos, page, pageSize);

                }).error(function (data, status, headers, config) {
                    alert(status);
                });
            }
        }, 100);
    };

    //sincronizacion al inicio de la aplicacion
    $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage);

    //escucha de los cambios de paginacion
    $scope.$watch('pagingOptions', function (newVal, oldVal) {
        if (newVal !== oldVal && newVal.currentPage !== oldVal.currentPage) {
            $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage, $scope.filterOptions.filterText);
        }
    }, true);

    //escucha de los cambios en los filtros
    $scope.$watch('filterOptions', function (newVal, oldVal) {
        if (newVal !== oldVal) {
            $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage, $scope.filterOptions.filterText);
        }
    }, true);

    //boton para ir a la playa en el mapa
    $scope.btnOption = '<div style="text-align:center;"><button id="editBtn" type="button" ng-click="ir(row)"><span class="glyphicon glyphicon-search"></span></span></button></div>';

    //opciones de la grilla
    $scope.gridOptions = {
        data: 'myData',
        enablePaging: true,
        showFooter: true,
        totalServerItems: 'totalServerItems',
        pagingOptions: $scope.pagingOptions,
        filterOptions: $scope.filterOptions,
        showGroupPanel: true,
        enableFiltering: true,
        multiSelect: false,
        columnDefs://definir las columnas a tener en la grilla
        [
        { field: 'id', displayName: 'Id' },
        { field: 'nombre', displayName: 'Nombre',  },
        { field: 'tipoPlaya', displayName: 'Tipo Playa' },
        { field: 'direccion', displayName: 'Direccion' },
        { field: 'vehiculos', displayName: 'Vehiculos' },
        { field: 'precios', displayName: 'Precio X Hora' },
        { displayName: "Ver", cellTemplate: $scope.btnOption, width: "50px"}

        ]

    };

    /*permite mostrar la playa seleccionada en el mapa*/
    $scope.ir = function (row) {

        //entidad seleccionada
        var playa = row.entity;

        alert("voy a playa de estacionamiento")
    };


    /*Muestra la grilla o la esconde si esta activa*/
    $scope.listar = function () {

        if ($scope.mostrarGrilla == false)
            $scope.mostrarGrilla = true;
        else
            $scope.mostrarGrilla = false;
    }



});