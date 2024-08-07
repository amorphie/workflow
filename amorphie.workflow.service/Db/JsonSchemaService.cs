using amorphie.workflow.core.Models;
using Microsoft.EntityFrameworkCore;

namespace amorphie.workflow.service.Db;
public class JsonSchemaService
{
    private readonly DbSet<JsonSchema> _dbSet;
    private NJsonSchema.JsonSchema _jsonSchema;

    public JsonSchemaService(WorkflowDBContext dbContext, NJsonSchema.JsonSchema jsonSchema)
    {
        _dbSet = dbContext.Set<JsonSchema>();
        _jsonSchema = jsonSchema;

    }

    public async Task<NJsonSchema.JsonSchema?> GetNjsonSchemaAsync(string subjectName)
    {
        if (_jsonSchema.Properties.Count() > 0)
        {
            return _jsonSchema;
        }
        else
        {
            var jsonSchemaEntity = await _dbSet.FirstOrDefaultAsync(p => p.SubjectName == subjectName);
            if (jsonSchemaEntity != null)
            {
                //Schema validation
                var theSchema = await NJsonSchema.JsonSchema.FromJsonAsync(jsonSchemaEntity.Schema);
                _jsonSchema = theSchema;
                return _jsonSchema;
            }
        }
        return null;
    }
}