using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Enums;

namespace WebApplication2.Commands
{
   public class FrameworkNetworkCommand
    {
        public ProjectType ProjectType { get; set; }
        public ScaleDegreesType Scalability { get; set; }
        public ScaleDegreesType Performance { get; set; }
        public ScaleDegreesType CommunitySupport { get; set; }
        public ScaleDegreesType LearningSpeed { get; set; }
        public ScaleDegreesType ImplementationCost { get; set; }
        public ScaleContentType Ecosystem { get; set; }
        public ScaleDegreesType SEO { get; set; }
        public FrameworkUtilityUsage Usage { get; set; }

    }
}