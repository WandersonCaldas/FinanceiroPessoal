function go(obj) {
    var txt_pagina = obj.value;
    obj.selectedIndex = 0;
    obj.disabled = true;

    self.location.href = txt_pagina;
    obj.disabled = false;
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function Tinymce() {
    tinymce.init({
        selector: 'textarea',
        language: 'pt_BR',
        height: 100,
        plugins: [
          'advlist autolink lists link image charmap print preview anchor',
          'searchreplace visualblocks code fullscreen',
          'insertdatetime media table contextmenu paste code'
        ],
        toolbar: 'insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
        content_css: '//www.tinymce.com/css/codepen.min.css'
    });
}