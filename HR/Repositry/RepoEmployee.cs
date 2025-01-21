using AutoMapper;
using Azure;
using HR.Data;
using HR.Repositry.Serves;
using HR_Models.Models;
using HR_Models.Models.VM;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.XPath;

namespace HR.Repositry
{
    public class RepoEmployee : RepositryAllModels<Employee,EmployeeSummary>
    {
        private readonly HR_Context context;
        private readonly IMapper mapper;
        private readonly IRepositryAllModels<Employee, EmployeeSummary> repositry;

        public RepoEmployee(HR_Context context,
            IMapper mapper,
            IRepositryAllModels<Employee,EmployeeSummary> repositry
            ) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.repositry = repositry;
        }

       

    }
}







