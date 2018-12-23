var Jwt = Jwt || {};

Jwt.Web = Jwt.Web || {};

Jwt.Web.Greeter = (function () {
    function Greeter(message) {
        this.greeting = message;

        this.goodBye = function () {
            console.log("Good bye, " + this.greeting);
        }
    }
    Greeter.prototype.greet = function () {
        console.log( "Hello, " + this.greeting);
    };
    return Greeter;
}());

Jwt.Web.MainPage = (function(){

    function init() {
        console.log("asd");
    };

    var mainPage = {
        Init: init
    };

    return mainPage;
})();