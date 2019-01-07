(function () {
    // =========================================================================
    // enumServiece
    // =========================================================================
    appModule.factory('enumService', function () {
        var factory = {};
        factory = {
            test_VMType: [
                { name: '实验室检定', value: 0 },
                { name: '实验室校准', value: 1 },
                { name: '现场校准', value: 2 },
                { name: '现场核查', value: 3 }
            ]
        };
        return factory;
    });
})();
