using Newtonsoft.Json;

namespace Data.Collection.From.Rest.Api.Template.Models.Dtos
{
    public class TemplateDto
    {
        [JsonProperty("full_name")]
        public string Name {get; set; } = null!;
    }
}