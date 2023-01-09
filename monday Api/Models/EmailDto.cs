using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace monday_Api.Models
{
    public class EmailDto
    {
        public string To { get; set; } = string.Empty;
        public string subject { get; set; } = string.Empty;
        public string body { get; set; } = string.Empty;
    }
}
