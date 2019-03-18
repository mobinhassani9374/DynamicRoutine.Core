app.controller('myController', function ($scope,  toaster, sweet , myService) {
    $scope.name="مهدی حسنی "

    toaster.pop('error', 'خطا', 'فایلی انتخاب نکرده اید');
})