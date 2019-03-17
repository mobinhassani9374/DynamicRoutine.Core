app.factory('myService', function ($http) {
    var component = {
        'Content-Type': undefined
    }
    return {
        getItem:function(){
            return $http({
                url:'',
                method:'get'
            })
        }
    }
})