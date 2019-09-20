function LookupModule(dom) {
    function Lookup(name, template) {
        this.name = name;
        this.url = template.replace('{0}', name);
    }

    var controllerUrl = $(dom).attr("action-lookup");
    var lookups = {
        genders: new Lookup('Genders', controllerUrl)
    };
    var fnInitialize = function (callback, scope) {
        callback.call(scope || this, lookups);
    }
    return {
        onInitialized: fnInitialize
    };
}