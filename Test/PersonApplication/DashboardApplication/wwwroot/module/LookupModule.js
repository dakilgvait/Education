function LookupModule(dom) {
    function fnInitialize(callback, scope) {
        callback.call(scope || this, lookups);
    }
    function getUrl(action) {
        return controllerUrl.replace('{0}', action);
    }
    var controllerUrl = $(dom).attr("action-lookup");
    var lookups = {
        genders: {
            url: getUrl("Genders"),
            values: []
        }
    };
    return {
        onInitialized: fnInitialize
    };
}