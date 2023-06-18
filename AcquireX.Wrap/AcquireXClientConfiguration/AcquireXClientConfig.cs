using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcquireX.Wrap.AcquireXClientConfiguration
{
     public sealed partial class AcquireXClientConfigBuilder

    {

        private AcquireXClientConfigBuilder( Uri baseAddress , string accessToken ) {
            ClientBaseAddress = baseAddress;
            AccessToken = accessToken;
        }

        public Uri ClientBaseAddress { get; set; }

        public string AccessToken { get; set; }

    }
}
