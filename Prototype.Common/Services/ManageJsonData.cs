using Prototype.Common.IServices;
using Prototype.Common.Models;
using Prototype.Common.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Prototype.Model.Models.Response;
using System.Linq;
using Prototype.Model.Models.Request;

namespace Prototype.Common.Services
{
    public class ManageJsonData : IManageJsonData
    {
        public GetParentlistResponse GetJsonDataList(string FilePath)
        {
            DtoParentObject getJsonObject = new DtoParentObject();
            GetParentlistResponse getParentlistResponse = new GetParentlistResponse();
            var stJsonData = CommonMethods.ReadTextFromFile(FilePath);
            getJsonObject = JsonConvert.DeserializeObject<DtoParentObject>(stJsonData);
            if (!string.IsNullOrEmpty(stJsonData))
            {
                getParentlistResponse.stParentObject = stJsonData;
                getParentlistResponse.success = true;
                getParentlistResponse.message = "Data read successfully";
            }
            return getParentlistResponse;
        }

        public UpdateParentlistResponse UpdateParentListData(UpdateParentListRequest updateParentListRequest)
        {
            DtoParentObject getJsonObject = new DtoParentObject();
            UpdateParentlistResponse updateParentlistResponse = new UpdateParentlistResponse();
            var stJsonData = CommonMethods.ReadTextFromFile(updateParentListRequest.stFilePath);
            getJsonObject = JsonConvert.DeserializeObject<DtoParentObject>(stJsonData);
            if (!string.IsNullOrEmpty(stJsonData))
            {
                if (getJsonObject != null)
                {
                    foreach (var item in getJsonObject.Datas)
                    {
                        if (Convert.ToDateTime(updateParentListRequest.SamplingTime) == Convert.ToDateTime(item.SamplingTime))
                        {
                            List<DtoProperty> data = JsonConvert.DeserializeObject<List<DtoProperty>>(updateParentListRequest.Properties.Replace('"', '\''));
                            item.Properties = data;
                        }
                    }
                }
                string JsonString = JsonConvert.SerializeObject(getJsonObject);
                bool IsUpdated = CommonMethods.UpdateTextFromFile(updateParentListRequest.stFilePath, JsonString);
                if (IsUpdated)
                {
                    updateParentlistResponse.success = true;
                    updateParentlistResponse.message = "Data updated successfully.";
                }
                else
                {
                    updateParentlistResponse.success = false;
                    updateParentlistResponse.message = "While updating data getting an error, Please try again.";
                }
            }
            return updateParentlistResponse;
        }
    }
}
