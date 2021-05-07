using Prototype.Common.Models;
using Prototype.Model.Models.Request;
using Prototype.Model.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Common.IServices
{
    public interface IManageJsonData
    {
        GetParentlistResponse GetJsonDataList(string FilePath);
        UpdateParentlistResponse UpdateParentListData(UpdateParentListRequest updateParentListRequest);
    }
}
