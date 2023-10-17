using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioDotNetBaltaIO.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace tests.DesafioDotNetBaltaIO.API.Tests.Controller
{
    public class LocationApiFactory : WebApplicationFactory<IApiAssemblyMarker>
    {
        
    }
}