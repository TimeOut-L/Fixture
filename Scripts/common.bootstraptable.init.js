
/**
 *  初始化 table
 * @param {any} tableId  table id
 * @param {any} requestUrl  初始化 url
 * @param {any} dataColumns  数据列
 */
function BoootstrapTableInit(tableId, requestUrl, rowStyle,dataColumns) {
    $("#" + tableId).bootstrapTable({
        url: requestUrl,
        method: 'post',
        toolbar: '#toolbar',//工具列
        rowStyle: rowStyle,
        theadClasses: "thead-blue",  //设置thead-blue为表头样式
        cache: false, //禁用缓存
        pagination: true,//关闭分页
        showFooter: false,//是否显示列脚
        showPaginationSwitch: false, //是否显示 数据条数选择框
        sortable: true,                      //是否启用排序
        sortOrder: "asc",                    //排序方式
        search: true, //启用搜索
        showSearchButton: true,  //
        showFullscreen: true,   // 全屏按钮
        showToggle: true,//显示详细视图和列表
        showColumns: true,
        showRefresh: true,//显示刷新按钮
        clickToSelect: true,  //点击选中 checkbox
        pageNumber: 1,  //初始化加载第一页，默认第一页
        pageSize: 7,    //每页的记录行数
        pageList: [3, 5, 7, 9, 'ALL'],   //可供选择的页面显示条数
        maintainSelected: true,  //记住选中项即使翻页
        paginationPreText: "上一页",
        paginationNextText: "下一页",
        paginationFirstText: "First",
        paginationLastText: "Last",
        //clickToSelect: false ,
        Icons: 'glyphicon-export ',
        columns: dataColumns
    });
}

/**
 * 日期格式化
 * @param {any} cellval  时间点
 */
function changeDateFormat(cellval) {
    if (cellval != null) {
        var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();

        var seconds = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();

        return date.getFullYear() + "-" + month + "-" + currentDate + " " + hours + ":" + minutes + ":" + seconds;

    }
};
/**
 *  添加记录
 * @param {any} formId  添加记录表单 的 id  
 * @param {any} requestUrl   请求  url
 * @param {any} modalIdOfForm  表单所在模态框
 * @param {any} tableId    记录 的 table id
 */
function AddRecord(formId, requestUrl, modalIdOfForm, tableId) {
    
    $.ajax({
        type: "POST",//方法类型
        url: requestUrl,//url
        data: $('#' + formId).serialize(),
        success: function (result) {
            if (result.success) {            
                $("#" + modalIdOfForm).modal('hide');
                ResetForm(formId);
                RefreshTable(tableId);
                toastr.success('添加成功');
            }
            else {
                toastr.warning(result.msg);             
            }
        },
        error: function (e) {
            toastr.error('添加错误');
        }
    });

}

/**
 * 清除表单输入数据
 * @param {any} formId
 */
function ResetForm(formId) {
    $("#" + formId)[0].reset();
}

/**
 * 刷新 table  
 * @param {any} tableId table id
 */
function RefreshTable(tableId) {
    $("#" + tableId).bootstrapTable('refresh');
}