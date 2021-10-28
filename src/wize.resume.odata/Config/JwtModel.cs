using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wize.resume.odata.Config
{
    public class JwtModel
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
    }
}
