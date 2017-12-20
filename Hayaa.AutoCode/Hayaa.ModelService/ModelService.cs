using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.BaseModel;

namespace Hayaa.CodeTool.Service
{
   public interface ModelService
    {
        /// <summary>
        /// 创建业务模型
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        FunctionResult<BussinessModel> Create(BussinessModel info);
        /// <summary>
        /// 根据主键更新业务模型
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        BaseFunctionResult UpdateByID(BussinessModel info);
        /// <summary>
        /// 根据主键删除模型
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        BaseFunctionResult DeleteByID(int ID);
        /// <summary>
        /// 分页获取模型数据
        /// </summary>
        /// <param name="searchParam"></param>
        /// <returns></returns>
        GridPager<BussinessModel> GetPager(GridPagerPamater<ModelGridPagerSearch> searchParam);
    }
}
