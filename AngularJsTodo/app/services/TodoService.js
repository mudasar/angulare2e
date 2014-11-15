TodoApp.factory('Todo', function($resource) {
    return $resource('/api/todos/:id', { id: '@id' }, { update: { method: 'PUT' } });
});