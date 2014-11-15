TodoApp.controller('CreateController', function($scope, $location, Todo) {
    $scope.save = function() {
        Todo.save($scope.item, function () {
            $location.path('/');
        });
    }
    $scope.action = "Add";
});