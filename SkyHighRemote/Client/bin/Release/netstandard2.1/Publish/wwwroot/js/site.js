function vibrate() {
    var isIOS = /iPad|iPhone|iPod/.test(navigator.userAgent) && !window.MSStream;
    if (isIOS) {
        // Do nothing
    } else {
        var canVibrate = "vibrate" in navigator || "mozVibrate" in navigator;
        if (canVibrate && !("vibrate" in navigator)) {
            navigator.vibrate = navigator.mozVibrate;
            navigator.vibrate(100);
        }
    }
}