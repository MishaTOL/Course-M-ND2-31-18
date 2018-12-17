using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class Students
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Firstname")]
        public string Firstname { get; set; }
        [JsonProperty("Lastname")]
        public string Lastname { get; set; }

    }

}