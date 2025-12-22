function updateCounter(el, max) {
    var $el = $(el);
    var id = $el.attr('id');
    var val = $el.val();

    // Cut extra content if pasted
    if (val.length > max) {
        $el.val(val.substring(0, max));
        val = $el.val();
    }

    // Update counter
    $("#" + id + "Counter").text(val.length + ' / ' + max);
}

function enforceMaxLength(e, max) {
    var val = $(e).val();
    var key = e.key;

    // Allow navigation, backspace, delete, etc.
    var allowedKeys = ['Backspace', 'Delete', 'ArrowLeft', 'ArrowRight', 'Tab'];
    if (val.length >= max && !allowedKeys.includes(key)) {
        e.preventDefault(); // This is what actually blocks the typing
    }
}
