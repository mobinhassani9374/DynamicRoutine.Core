var app = angular.module('myApp', ['chieffancypants.loadingBar','toaster', 'hSweetAlert'])
.config(function (cfpLoadingBarProvider) {
    cfpLoadingBarProvider.includeSpinner = true;
}).controller('loadingBar', function ($scope, $http, $timeout, cfpLoadingBar) {

    var getRandomSubreddit = function () {
        var sub = $scope.subreddits[Math.floor(Math.random() * $scope.subreddits.length)];

        // ensure we get a new subreddit each time.
        if (sub == $scope.subreddit) {
            return getRandomSubreddit();
        }

        return sub;
    };

    $scope.fetch = function () {
        $scope.subreddit = getRandomSubreddit();
        $http.jsonp('http://www.reddit.com/r/' + $scope.subreddit + '.json?limit=50&jsonp=JSON_CALLBACK').success(function (data) {
            $scope.posts = data.data.children;
        });
    };

    $scope.start = function () {
        cfpLoadingBar.start();
    };

    $scope.complete = function () {
        cfpLoadingBar.complete();
    }
    // fake the initial load so first time users can see it right away:
    $scope.start();
    $scope.fakeIntro = true;
    $timeout(function () {
        $scope.complete();
        $scope.fakeIntro = false;
    }, 750);

});