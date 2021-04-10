using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Identity;
using WebApplication2.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace WebApplication2.Services
{
    public class SessionService
    {
        public static List<Product> Products { get; set; } = new List<Product>();
        public void AddToList(Product product)
        {
            Products.Add(product);
        }

    }
}
