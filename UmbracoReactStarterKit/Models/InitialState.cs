using System.Collections.Generic;

namespace UmbracoReactStarterKit.Models
{
    /// <summary>
    /// Represents the initial state for the React app.
    /// </summary>
    public class InitialState
    {
        public Dictionary<string, Content> content { get; set; }
        public string homeUrl { get; set; }
        public string siteLogo { get; set; }
        public string siteTitle { get; set; }
        public string location { get; set; }
        public CurrentContent currentContent { get; set; }
        public string currentPageName { get; set; }
        public string mainNavigation { get; set; }
        public string bottomNavigation { get; set; }

        /// <summary>
        /// Basic representation of an Umbraco node.
        /// </summary>
        public class Content
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        /// <summary>
        /// Represents the current content with its view rendered as a string.
        /// </summary>
        public class CurrentContent
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public string Content { get; set; }
        }
    }
}