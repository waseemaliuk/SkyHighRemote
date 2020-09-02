function feedback(vibrate = false, makeSound = false, showVisual = false) {

    /// Show the little light at the top of the remote
    var img = document.getElementById('light');
    if (img != null) {
        img.style.display = 'block';
        setTimeout(() => { img.style.display = 'none'; }, 250);
    }

    if (makeSound && Modernizr.audio) {
        var audio = new Audio("sounds/click.mp3");
        audio.play();
    }

    if (vibrate && Modernizr.canVibrate) {
        if (!("vibrate" in navigator)) {
            navigator.vibrate = navigator.mozVibrate;
        }
        navigator.vibrate(100);
    }

    if (showVisual) {
        var pointer = document.getElementById('pointer');
        if (pointer != null) {
            var canvas = document.getElementById('remoteCanvas');
            var pt = canvas.createSVGPoint();
            pt.x = event.clientX;
            pt.y = event.clientY;
            var cursorpt = pt.matrixTransform(canvas.getScreenCTM().inverse());
            pointer.setAttribute("cx", cursorpt.x);
            pointer.setAttribute("cy", cursorpt.y);
            pointer.style.display = 'block';
            setTimeout(() => { pointer.style.display = 'none'; }, 750);
        }
    }

}

function refreshapp() {
    window.location.reload(true);
}







