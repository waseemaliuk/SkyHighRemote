'use strict';

//Sky-Remote Integration
module.exports = function (callback, command, ipAddress) {
    var SkyRemote = require("sky-remote");
    var remoteControl = new SkyRemote(ipAddress);
    remoteControl.press(command);
    callback(/* error */ null, true);
};