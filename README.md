# FixtureManagement

使用MVC + Service +EF 

项目 目录说明

App_Data :sql 脚本 使用sqlserver 执行即可

App_Start ：过滤器注册 及Autofac注册

Common : 辅助类

Conten :css 文件

Controller :控制器

Filter:自定义过滤器


fonts:字体

Model:实体类
Model.Context :数据库上下文管理

Scripts:js 脚本

Service :业务逻辑 服务层 接口 impl 实现类 
         将controller 中的业务逻辑抽离

ViewModels:视图模型 视图所需要的 数据类 不一定与实体类数据一致

Views:视图文件

使用ztree 构造 动态菜单树 而不是固定菜单
