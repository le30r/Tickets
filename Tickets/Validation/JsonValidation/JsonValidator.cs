using System.Text.Json.Nodes;
using Json.Schema;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace Tickets.Validation.JsonValidation;

public class JsonValidator
{
    public static string? PathToSchemas { get; set; } = WebApplication
        .CreateBuilder()
        .Configuration
        .GetValue<string>("Validation:SchemasPath");

    protected JsonValidator(string configKey)
    {
        PathToSchemas = WebApplication
            .CreateBuilder()
            .Configuration
            .GetValue<string>(configKey);
    }

    public static bool Validate(JsonNode? json, string name)
    {
        var jsonSchema = JsonSchema.FromFile(PathToSchemas + Path.AltDirectorySeparatorChar + name + ".json");
        return jsonSchema.Validate(json).IsValid;
    }
}