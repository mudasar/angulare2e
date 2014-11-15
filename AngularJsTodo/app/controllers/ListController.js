TodoApp.controller('ListController', function($scope, $location, Todo) {

    $scope.items = [];
    $scope.sort_order = 'Priority';
    $scope.is_desc = false;
    $scope.limit = 20;
    $scope.offset = 0;
    $scope.more = true;
    $scope.clear = false;

    $scope.search = function() {
        Todo.query({ q: $scope.query, sort: $scope.sort_order, desc: $scope.is_desc, offset: $scope.offset, limit: $scope.limit }, function (data) {
            //if ($scope.query != '' && $scope.query != undefined) {
            //    $scope.items = [];
            //}
            $scope.items = $scope.items.concat(data);
            $scope.more = data.length === 20;
        });

    };

    $scope.sort = function (col) {
        if ($scope.sort_order === col) {
            $scope.is_desc = !$scope.is_desc;
        } else {
            $scope.sort_order = col;
            $scope.is_desc = false;
        }
        $scope.more = true;
        $scope.offset = 0;
        $scope.items = [];
        $scope.search();
    }

    $scope.show_more = function () {
        $scope.offset += 20;
        $scope.search();
    }

    $scope.has_more = function () {
        return $scope.more;
    }

    $scope.delete = function() {
        var id = this.item.Id;
        Todo.delete({ id: id }, function (data) {
            $('#' + data.Id).fadeOut();
        });
    }

    $scope.search();
});