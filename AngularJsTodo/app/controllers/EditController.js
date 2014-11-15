TodoApp.controller('EditController', function ($scope, $location, $routeParams, Todo) {

   $scope.id = $routeParams.editId;
    $scope.item = Todo.get({ id: $scope.id });
    
    $scope.action = 'Update';
    $scope.save = function() {
        Todo.update({ id: $scope.item.Id }, $scope.item, function () {
            $location.path('/');
        });
    }

});