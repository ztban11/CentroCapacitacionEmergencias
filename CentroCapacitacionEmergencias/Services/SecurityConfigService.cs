using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using Newtonsoft.Json;

namespace CentroCapacitacionEmergencias.Services
{
    public class SecurityConfig
    {
        public int iMaxIntentosLogin { get; set; }
        public int iMinutosBloqueo { get; set; }
    }
    public class SecurityConfigService
    {
        public static SecurityConfig GetConfig()
        {
            string sPath = HttpContext.Current.Server.MapPath("~/Config/security.json");
            string sJson = File.ReadAllText(sPath);
            return JsonConvert.DeserializeObject<SecurityConfig>(sJson);
        }
    }
}