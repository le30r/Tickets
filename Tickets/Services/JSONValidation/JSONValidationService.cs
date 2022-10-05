using System.Configuration;
using System.Text.Json.Nodes;
using Json.Schema;

namespace Tickets.Services.JSONValidation;

public class JSONValidationService
{
    private string saleSchemaPath;
    private string refundSchemaPath;

    public JSONValidationService(IConfiguration configuration)
    {

        this.saleSchemaPath = configuration.GetValue<string>("Validation:SaleSchemaPath");
        this.refundSchemaPath = configuration.GetValue<string>("Validation:RefundSchemaPath");;
    }

    public bool IsValidSell(JsonNode json)
    {
        return Validate(json, saleSchemaPath);
    }
    
    public bool IsValidRefund(JsonNode json)
    {
        return Validate(json, refundSchemaPath);
    }

    public bool Validate(JsonNode json, string path)
    {
        var jsonSchema = JsonSchema.FromFile(path);
        return jsonSchema.Validate(json).IsValid;
    }
}