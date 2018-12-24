(function () {
    appModule.controller('common.views.qs.workload.index', [
        '$scope',
        function ($scope) {
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });
            vm.loading = false;

            vm.dateRangeOptions = app.createDateRangePickerOptions();
            vm.dateRangeModel = {
                startDate: moment().startOf('day'),
                endDate: moment().endOf('day')
            };

            vm.initSparklineCharts = function () {
                //if (!jQuery().sparkline) {
                //    return;
                //}
                $("#sparkline_bar").sparkline([8, 9, 10, 11, 10, 10, 12, 10, 10, 11, 9, 12, 11, 10, 9, 11, 13, 13, 12], {
                    type: 'bar',
                    width: '100',
                    barWidth: 5,
                    height: '55',
                    barColor: '#f36a5b',
                    negBarColor: '#e02222'
                });

                $("#sparkline_bar2").sparkline([9, 11, 12, 13, 12, 13, 10, 14, 13, 11, 11, 12, 11, 11, 10, 12, 11, 10], {
                    type: 'bar',
                    width: '100',
                    barWidth: 5,
                    height: '55',
                    barColor: '#5c9bd1',
                    negBarColor: '#e02222'
                });

                $("#sparkline_bar5").sparkline([8, 9, 10, 11, 10, 10, 12, 10, 10, 11, 9, 12, 11, 10, 9, 11, 13, 13, 12], {
                    type: 'bar',
                    width: '100',
                    barWidth: 5,
                    height: '55',
                    barColor: '#35aa47',
                    negBarColor: '#e02222'
                });

                $("#sparkline_bar6").sparkline([9, 11, 12, 13, 12, 13, 10, 14, 13, 11, 11, 12, 11, 11, 10, 12, 11, 10], {
                    type: 'bar',
                    width: '100',
                    barWidth: 5,
                    height: '55',
                    barColor: '#ffb848',
                    negBarColor: '#e02222'
                });

                $("#sparkline_line").sparkline([9, 10, 9, 10, 10, 11, 12, 10, 10, 11, 11, 12, 11, 10, 12, 11, 10, 12], {
                    type: 'line',
                    width: '100',
                    height: '55',
                    lineColor: '#ffb848'
                });
            }
            //...
            vm.initSparklineCharts();
            //vm.init();

        }]);
})();
