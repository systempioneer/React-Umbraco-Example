using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace UmbracoReactStarterKit.Models
{
    /// <summary>
    /// Model for the master template.
    /// </summary>
    public class MasterModel : RenderModel
    {
        public MasterModel(IPublishedContent content) : base(content)
        {
        }

        public InitialState InitialState { get; set; }
        public string SiteDescription { get; set; }
    }
}