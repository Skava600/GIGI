using System.ComponentModel.DataAnnotations;

namespace Web_953501_Skavarodnik.Blazor.Client.Helpers
{
    public class HelpModel
    {
        [Range(0, int.MaxValue)]
        public int NewValue { get; set; }
    }
}
