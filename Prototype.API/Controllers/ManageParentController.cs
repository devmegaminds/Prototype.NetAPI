using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prototype.Common.IServices;
using Prototype.Common.Models;
using Prototype.Model.Models.Request;
using Prototype.Model.Models.Response;

namespace Prototype.API.Controllers
{
    [Route("api/ManageParent")]
    [ApiController]
    public class ManageParentController : ControllerBase
    {
        private readonly ILogger<ManageParentController> _logger;
        private readonly IManageJsonData _manageJsonData;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ManageParentController(ILogger<ManageParentController> logger
           , IManageJsonData manageJsonData
            , IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _manageJsonData = manageJsonData;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        [Route("GetParentlist")]
        public GetParentlistResponse GetParentlist()
        {
            GetParentlistResponse getParentlistResponse = new GetParentlistResponse();
            string stFilePath = String.Format("{0}{1}", _hostEnvironment.ContentRootPath.ToString(), "\\DataFile\\data.json");
            return  _manageJsonData.GetJsonDataList(stFilePath);
        }

        [HttpPost]
        [Route("UpdateParentList")]
        public UpdateParentlistResponse UpdateParentList([FromBody] UpdateParentListRequest updateParentListRequest)
        {
            UpdateParentlistResponse updateParentlistResponse = new UpdateParentlistResponse();
            updateParentListRequest.stFilePath = String.Format("{0}{1}", _hostEnvironment.ContentRootPath.ToString(), "\\DataFile\\data.json");
            return _manageJsonData.UpdateParentListData(updateParentListRequest);
        }
    }
}
