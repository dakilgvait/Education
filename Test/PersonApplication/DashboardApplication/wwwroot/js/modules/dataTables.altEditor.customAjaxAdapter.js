function InitializeCustomAjaxAdapter() {
    $.fn.select2.amd.define('select2/data/customAjaxAdapter', [
        'select2/data/ajax',
        'select2/utils'
    ], function (AjaxAdapter, Utils) {
        function CustomAjaxAdapter($element, options) {
            CustomAjaxAdapter.__super__.constructor.call(this, $element, options);
        }

        Utils.Extend(CustomAjaxAdapter, AjaxAdapter);

        CustomAjaxAdapter.prototype.current = function (callback) {
            var rowData = this.options.get('row')();
            if ($(this.$element).find('option').length == 0 && rowData) {
                var proc = this.convertToOptions([{ id: "-1", text: "processing..." }]);
                this.$element.append(proc);
                var self = this;
                this.query.call(this, { name: rowData.gender }, function (data) {
                    $.extend(data.results[0], { selected: true })
                    var convertedData = self.convertToOptions(data.results);
                    self.$element.append(convertedData);
                    callback(data.results);
                    self.$element.trigger("change");
                });
            }
            else {
                this.__proto__.__proto__.current.call(this, callback);
            }
        };

        return CustomAjaxAdapter;
    });
}