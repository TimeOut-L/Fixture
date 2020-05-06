
/**
 *  初始化 table
 * @param {any} tableId  table id
 * @param {any} requestUrl  初始化 url
 * @param {any} dataColumns  数据列
 */
function BoootstrapTableInit(tableId, requestUrl, rowStyle, dataColumns) {
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
        showFullscreen: true,    // 全屏按钮
        showToggle: true,//显示详细视图和列表
        showColumns: true,
        showRefresh: true, //显示刷新按钮
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
}

/**
 * 获取表格选中数据的 ID
 * 并转化为json 串
 * @param {any} tableId
 */
function getSelectedData(tableId) {
    var rows = $("#" + tableId).bootstrapTable('getSelections');
    //存储数据
    var ItemIDs = new Array();
    //console.log(rows);
    if (rows.length == 0) {// rows 主要是为了判断是否选中，下面的else内容才是主要
        toastr.warning("请先选择要删除的记录!");
        return;
    } else {
        //  声明一个object 存储行某几列数据
        $(rows).each(function () {
            var item = new Object();
            item.ID = this.ID;
            ItemIDs.push(item);
        });
    }
    return JSON.stringify(ItemIDs);
}

/**
 * 删除确认框  可扩展为 通用弹出框 设置参数 传入对应值即可
 * 暂不考虑
 */
function confirmOrCancelDeleteData() {
    swal.fire({
        title: '确定删除吗？',
        text: '你将无法恢复它！ 这可能是非常重要的一条记录！',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: '确定删除！',
        cancelButtonText: '取消删除！',
        confirmButtonClass: 'btn btn-success ',
        cancelButtonClass: 'btn btn-danger',
        buttonsStyling: false
    }).then(function (isConfirm) {
        if (isConfirm.value === true) {
            //确认删除
            return true;
        }
        else if (isConfirm.dismiss == 'cancel') {
            swal.fire(
                '已取消！',
                '这可能会是一个聪明的选择',
                'error'
            );
            return false;
        }
    })
}

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
 * 删除记录
 * @param {any} reuestUrl 请求url
 * @param {any} tableId s表格 id
 * @param {any} ItemIDs  待删除的 数据 id
 */
function DeleteRecords(reuestUrl, tableId, ItemIDs) {
    $.ajax({
        url: reuestUrl,
        type: "post",
        data: ItemIDs,
        success: function (result) {
            if (result.success) {
                RefreshTable(tableId);
                toastr.success('删除成功');
            }
            else {
                toastr.warning('删除失败');
            }
        },
        error: function (e) {
            toastr.error('删除错误');
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