using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Web;

namespace Validation
{
    public class LocalizationService
    {

        public string Localize(string key)
        {
            Thread.CurrentPrincipal.
            var manager = new ResourceManager("Validation.Resource", GetType().Assembly);
            var value = manager.GetString(key);

            if(value == null)
            {
                return "ResourceNotFound";
            }

            return value;
        }
    }
}