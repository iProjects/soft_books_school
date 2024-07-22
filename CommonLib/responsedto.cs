﻿/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/09/2018
 * Time: 21:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Serialization;

namespace CommonLib
{
    [DataContract]
    public class responsedto
    {
        [DataMember]
        public string responsesuccessmessage { get; set; }
        [DataMember]
        public string responseerrormessage { get; set; }
        [DataMember]
        public string responsemethod { get; set; }
        [DataMember]
        public string responseclass { get; set; }
        [DataMember]
        public bool isresponseresultsuccessful { get; set; }
        [DataMember]
        public object responseresultobject { get; set; }
    }

    [DataContract]
    public class error_logger_dto
    {
        [DataMember]
        public string error_id { get; set; }
        [DataMember]
        public string error_description { get; set; }
        [DataMember]
        public string error_date { get; set; }
        [DataMember]
        public string error_category { get; set; }
        [DataMember]
        public string created_date { get; set; }
        [DataMember]
        public string error_source { get; set; }

    }
}
