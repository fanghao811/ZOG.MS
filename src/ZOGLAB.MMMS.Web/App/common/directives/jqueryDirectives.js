(function () {
    appModule.directive('multiSelect', ['$timeout', 'abp.services.app.receive',
        function ($timeout, receiveService) {
            return {
                restrict: 'A',
                scope: true,
                link: function ($scope, element, attrs) {
                    receiveService.getInstrumentTestsForSelection({ id: $scope.test_Id })
                        .then(function (result) {
                            var unCheckedItems = result.data.unCheckedItems;
                            var checkedItems = result.data.checkedItems;
                            var items = _.union(unCheckedItems, checkedItems);
                            angular.forEach(items, function (item, _index) {
                                $(element).multiSelect('addOption', { value: item.id, text: item.instrumentTest, index: _index });
                            });
                            var checkedIds = _.pluck(checkedItems, 'id');
                            $(element).val(checkedIds);
                            $timeout(function () {
                                $(element).multiSelect('refresh');
                            });                           
                        });
                }
            };
        }
    ]);
})();