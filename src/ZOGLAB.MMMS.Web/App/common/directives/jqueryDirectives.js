(function () {
    appModule.directive('multiSelect', ['$timeout','abp.services.app.receive',
        function ($timeout,receiveService) {
            return {
                restrict: 'A',
                link: function ($scope, element, attrs) {
                    $scope.intsts = [];

                    //获取属性设置字段
                    $(element).multiSelect($scope.$eval(attrs.multiSelect));

                    receiveService.getInstrumentTestsForSelection()
                        .then(function (result) {
                            $scope.intsts = result.data;
                            angular.forEach($scope.intsts, function (intst, _index) {
                                $(element).multiSelect('addOption', { value: intst.id, text: intst.instrumentTest, index: _index });
                            });

                            $timeout(function () {
                                $(element).multiSelect('refresh');
                            });
                        });

                    //设置事件
                    $(element).multiSelect({
                        afterSelect: function (values) {
                            alert("Select value: " + values);
                        },
                        afterDeselect: function (values) {
                            alert("Deselect value: " + values);
                        }
                    }
                    );
                }
            };
        }
    ]);
})();