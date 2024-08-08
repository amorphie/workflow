using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.workflow.core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace amorphie.workflow.service.Db
{
    public class HumanTaskService
    {
        private readonly WorkflowDBContext _context;
        private readonly IConfiguration _configuration;
        public HumanTaskService(WorkflowDBContext _dbContext,IConfiguration configuration)
        {
            _context = _dbContext;
            _configuration=configuration;
        }
        public async  Task< List<core.Dtos.HumanTasks.HumanTaskDto?>> HumanTaskWithView(List<core.Dtos.HumanTasks.HumanTaskDto?>? taskList,
     string? language, string? role, string? type, CancellationToken token)
    {
        var templateURL = _configuration["templateEngineUrl"]!.ToString();
        List<core.Dtos.HumanTasks.HumanTaskDto?> responseList = new List<core.Dtos.HumanTasks.HumanTaskDto?>();
        foreach (var item in taskList)
        {
            InstanceTransition? lastTransition = await _context.InstanceTransitions.OrderByDescending(o => o.CreatedAt).FirstOrDefaultAsync(f => f.InstanceId == item.InstanceId, token);
            if (lastTransition != null)
            {
                try
                {
                    item.lastEntityData = System.Text.Json.JsonSerializer.Deserialize<dynamic>(lastTransition.EntityData);
                    item.lastAdditionalData = System.Text.Json.JsonSerializer.Deserialize<dynamic>(lastTransition.AdditionalData);
                }
                catch(Exception)
                {
                    item.lastEntityData =new {};
                    item.lastAdditionalData =new {};
                }
            }
            responseList.Add(item);
        }
        return responseList;
    }
   
    }
}