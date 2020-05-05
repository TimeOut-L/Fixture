/**
 * 表单为空验证
 * 如 checkFormNull("test")
 * @param {any} form  form=>表单的 id 
 */
function CheckFormNull(form) {
    var pass = true;
    var str = "";
    $("#" + form + " input[type$='text'],[type$='password']").each(function (n) {
        if ($(this).val() == "") {
            pass = false;
            //获取关联label元素
            str += $('label[for=' + $(this).attr('id') + ']').html() + "不能为空！\r\n";
            toastr.error(str);
            return pass;
        }
    });
    return pass;
}