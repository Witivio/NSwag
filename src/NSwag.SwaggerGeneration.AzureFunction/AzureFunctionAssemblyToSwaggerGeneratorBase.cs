﻿//-----------------------------------------------------------------------
// <copyright file="WebApiAssemblyToSwaggerGeneratorBase.cs" company="NSwag">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>https://github.com/NSwag/NSwag/blob/master/LICENSE.md</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSwag.SwaggerGeneration.AzureFunction
{
    /// <summary></summary>
    public abstract class AzureFunctionAssemblyToSwaggerGeneratorBase
    {
        /// <summary>Initializes a new instance of the <see cref="AzureFunctionAssemblyToSwaggerGeneratorBase"/> class.</summary>
        /// <param name="settings">The generator settings.</param>
        protected AzureFunctionAssemblyToSwaggerGeneratorBase(AzureFunctionAssemblyToSwaggerGeneratorSettings settings)
        {
            Settings = settings;
        }

        /// <summary>Gets or sets the settings.</summary>
        public AzureFunctionAssemblyToSwaggerGeneratorSettings Settings { get; protected set; }

        /// <summary>Generates for controllers.</summary>
        /// <param name="controllerClassNames">The controller class names.</param>
        /// <returns>The Swagger document.</returns>
        public abstract Task<SwaggerDocument> GenerateForFunctionsAsync(IEnumerable<string> controllerClassNames);

        /// <summary>Gets the controller classes.</summary>
        /// <returns>The controller class names.</returns>
        public abstract string[] GetControllerClasses();
    }
}