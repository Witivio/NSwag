using System;
using System.Collections.Generic;
using System.Text;

namespace NSwag.Annotations
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SwaggerOperationBodyAttribute : Attribute
    {
        public Type Body { get; set; }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="body"></param>
        public SwaggerOperationBodyAttribute(Type body)
        {
            this.Body = body;
        }
    }
}
