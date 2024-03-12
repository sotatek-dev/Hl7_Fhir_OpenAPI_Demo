using System.Diagnostics.CodeAnalysis;

namespace Sotatek.Hl7.Fhir.OpenAPI.Services.Options
{
    [ExcludeFromCodeCoverage]
    public class FhirOptions
    {
        public string Endpoint { get; set; }

        public string ManagingOrganization { get; set; }

        public string BearerToken { get; set; }
   }
}