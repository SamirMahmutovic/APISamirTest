using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webClient.Models
{
    [JsonObject]
     public partial class CSUser
     {
            public int CSUserID { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }

            public string Password { get; set; }
    }
}
