﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonlow.Web.Meta
{
    /// <summary>
    /// POCO for the data structure of ApiDescription
    /// </summary>
    public class WebApiDescription
    {
        public string Documentation { get; set; }

        public string ID { get; private set; }

        public ActionDescriptor ActionDescriptor { get; set; }

        public string HttpMethod { get; set; }

        public ParameterDescription[] ParameterDescriptions { get; set; }

        public string RelativePath { get; set; }

        public ResponseDescription ResponseDescription { get; set; }

        public WebApiDescription(string id)
        {
            ID = id;
        }
    }

    public class ActionDescriptor
    {
        public string ActionName { get; set; }

        public Type ReturnType { get; set; }


        public ControllerDescriptor ControllerDescriptor { get; set; }

    }

    public class ControllerDescriptor
    {
        public string ControllerName { get; set; }

        public Type ControllerType { get; set; }

        public override bool Equals(object obj)
        {
            var a = obj as ControllerDescriptor;
            if (a == null)
                return false;

            return a.ControllerName == ControllerName && a.ControllerType == ControllerType;
        }

        public override int GetHashCode()
        {
            return (ControllerType + ControllerType.FullName).GetHashCode();//important for Distinct() of Linq.
        }
    }

    public class ParameterDescription
    {
        public string Documentation { get; set; }

        public string Name { get; set; }

        public ParameterDescriptor ParameterDescriptor { get; set; }
    }

    public class ParameterDescriptor
    {
        public bool IsOptional { get; set; }

        public string ParameterName { get; set; }

        public Type ParameterType { get; set; }

        public string Prefix { get; set; }

        public ParameterBinder ParameterBinder { get; set; }
    }

    public class ResponseDescription
    {
        public Type DeclaredType { get; set; }
        public string Documentation { get; set; }
        public Type ResponseType { get; set; }
    }



    public enum ParameterBinder
    {
        None,
        FromUri,
        FromBody
    }
}