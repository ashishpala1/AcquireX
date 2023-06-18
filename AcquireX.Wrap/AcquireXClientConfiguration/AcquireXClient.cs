using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcquireX.Wrap.AcquireXClientConfiguration
{
    public class AcquireXClient :HttpClient
    {
        public AcquireXClient(AcquireXClientConfigBuilder config)
        {
            if(config is null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            BaseAddress = config.ClientBaseAddress;
            DefaultRequestHeaders.Add("Authorization", "Bearer " + config.AccessToken);

        }

        internal Task GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
