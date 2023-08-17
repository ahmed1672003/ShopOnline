global using System.Data.Common;
global using System.Net;
global using System.Reflection;
global using System.Text.Json;
global using System.Text.Json.Serialization;

global using AutoMapper;

global using Azure.Core;

global using FluentValidation;

global using MediatR;

global using Microsoft.EntityFrameworkCore;

global using ShopOnline.API.Application.Bahaviors;
global using ShopOnline.API.Application.MiddleWare;
global using ShopOnline.API.Application.Responses;
global using ShopOnline.API.Data;
global using ShopOnline.API.Entities;
global using ShopOnline.API.IRepositories;
global using ShopOnline.API.Repositories;
global using ShopOnline.API.Specifications;
global using ShopOnline.Models.Product;


namespace ShopOnline.API;

