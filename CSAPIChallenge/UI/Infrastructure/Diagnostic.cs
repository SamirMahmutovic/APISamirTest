using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Infrastructure
{
    public class Diagnostic
    {
        [Key]
        public Guid DiagnosticID { get; set; }
        public string ApplicationName { get; set; }
        public DateTime DiagnosticTime { get; set; }
        public string WebServer { get; set; }
        public string Browser { get; set; }
        public string TargetController { get; set; }
        public string TargetAction { get; set; }
        public long ExecutionTime { get; set; }
    }

}