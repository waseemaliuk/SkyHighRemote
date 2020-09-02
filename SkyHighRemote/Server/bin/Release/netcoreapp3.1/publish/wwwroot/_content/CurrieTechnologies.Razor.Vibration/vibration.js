"use strict";
var CurrieTechnologies;
(function (CurrieTechnologies) {
    var Razor;
    (function (Razor) {
        var Vibration;
        (function (Vibration) {
            window.CurrieTechnologies = window.CurrieTechnologies || {};
            window.CurrieTechnologies.Razor = window.CurrieTechnologies.Razor || {};
            window.CurrieTechnologies.Razor.Vibration =
                window.CurrieTechnologies.Razor.Vibration || {};
            window.CurrieTechnologies.Razor.Vibration.Vibrate = function (pattern) {
                return window.navigator.vibrate(pattern);
            };
            window.CurrieTechnologies.Razor.Vibration.VibrationSupported = function () {
                return window.navigator.vibrate !== undefined;
            };
        })(Vibration = Razor.Vibration || (Razor.Vibration = {}));
    })(Razor = CurrieTechnologies.Razor || (CurrieTechnologies.Razor = {}));
})(CurrieTechnologies || (CurrieTechnologies = {}));
