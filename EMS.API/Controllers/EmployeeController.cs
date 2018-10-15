﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EMS.API.Controllers
{

    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {

        private readonly EMSContext _context;
        private readonly EmployeeServices _service;
        public EmployeeController(EMSContext context)
        {
            _context = context;
            _service = new EmployeeServices(_context);
        }



        [Produces("application/json")]
        [HttpGet("test")]
        public IEnumerable<Test> FindAl()
        {
            string id = "1";
            var test = _context.Employees
                //.Where(c => c.EmpId == id)
                .Join(_context.Departments,
                e => e.DepartmentDprtId, d => d.DprtId, (e, d) =>
                   new { e, d })
                .Join(_context.Positions,
                    e2 => e2.e.PositionPId, p => p.PositionId, (e2, p)
                         => new Test { EmpName = e2.e.EmpName }).ToList()


                   ;
            //.Where(c => c.EmpId == id)
            //.Select(c => c.EmpId)
            //.FirstOrDefault(); 
            //if (String.IsNullOrEmpty(id))


            return test;


        }

        [Produces("application/json")]
        [HttpGet("")]
        //  [Authorize(Roles = "Administrator")]
        public IEnumerable<Employee> FindAll()
        {
            return _service.GetAll();

        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("getall")]
        public IActionResult GetEmployeesDetails()
        {


            var result = _service.GetEmployeesDetails();
            return Ok(result);


        }

        [Produces("application/json")]
        [HttpGet("getall/{id}")]
        public IActionResult GetEmployeeDetails(string id)
        {


            var result = _service.GetEmployeeDetails(id);
            return Ok(result);


        }

        [Produces("application/json")]
        [HttpGet("{id}")]

        public Employee GetEmployeeById(string id)
        {
            return _service.GetEmployeeById(id);

        }

        [Produces("application/json")]
        [HttpGet("getdepartment/{id}")]

        public Department GetDepartmentId(string id)
        {
            return _service.GetDepartmentById(id);

        }

        [Produces("application/json")]
        [HttpGet("getposition/{id}")]

        public Position GetPositonById(string id)
        {
            return _service.GetPositionById(id);

        }

        [Produces("application/json")]
        [HttpGet("email/{id}")]

        public Employee GetEmployeeByEmail(string email)
        {
            return _service.GetEmployeeByEmail(email);

        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody]Employee emp)
        {

            if (_service.AddEmployee(emp))
            {

                return Ok(emp);
            }
            else
            {
                return BadRequest("there error");
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("createdepartment")]
        public IActionResult CreateDepartment([FromBody]Department dprt)
        {

            if (_service.AddDepartment(dprt))
            {

                return Ok(dprt);
            }
            else
            {
                return BadRequest("there error");
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("createposition")]
        public IActionResult Createposition([FromBody]Position pos)
        {

            if (_service.AddPosition(pos))
            {

                return Ok(pos);
            }
            else
            {
                return BadRequest("there error");
            }
        }


        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("updateemployee")]
        public IActionResult UpdateEmployee([FromBody]Employee emp)
        {

            if (_service.UpdateEmployee(emp))
            {

                return Ok(emp);
            }
            else
            {
                return BadRequest("there error");
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("updatedepartment")]
        public IActionResult UpdateDepartment([FromBody]Department dprt)
        {

            if (_service.UpdateDepartment(dprt))
            {

                return Ok(dprt);
            }
            else
            {
                return BadRequest("there error");
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("updatePosition")]
        public IActionResult UpdatePosition([FromBody]Position role)
        {

            if (_service.UpdatePosition(role))
            {

                return Ok(role);
            }
            else
            {
                return BadRequest("there error");
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("login")]
        public IActionResult loginId([FromBody]LoginId logins)
        {


            if (_service.LoginId(logins))
            {
                var data = _service.GetEmployeeById(logins.EmpId);
                var Emprole = data.PositionPId;
                var Empid = data.EmpId;

                //    var claims = new[]
                //{
                //    new Claim(JwtRegisteredClaimNames.Sub,datas),
                //    new Claim(JwtRegisteredClaimNames.Email, logins.EmpId),
                //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

                //};

                //    var signingkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("creativesoftware@12345moratuwaproject"));

                //    var token = new JwtSecurityToken(
                //        issuer: "http://oec.com",
                //        audience: "http://oec.com",
                //        expires: DateTime.UtcNow.AddHours(1),
                //        claims: claims,
                //        signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signingkey, SecurityAlgorithms.HmacSha256)



                //        );

                //    return Ok(new
                //    {
                //        token = new JwtSecurityTokenHandler().WriteToken(token),
                //        expiration = token.ValidTo
                //    });


                GetTokenModel token = GetToken.getToken(Emprole, Empid);

                return Ok(new
                {
                    token = token.Token,
                    expiration = token.Expiretion
                });

            }
            else
            {
                return BadRequest("there error");
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("loginEmail")]
        public IActionResult loginEmail([FromBody]LoginEmail logins)
        {
            if (_service.LoginEmail(logins))
            {
                var data = _service.GetEmployeeByEmail(logins.EmpEmail);
                var Emprole = data.PositionPId;
                var Empid = data.EmpId;

                GetTokenModel token = GetToken.getToken(Emprole, Empid);

                return Ok(new
                {
                    token = token.Token,
                    expiration = token.Expiretion
                });

            }
            else
            {
                return BadRequest("there error");
            }


        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("getdepartments")]
        public IActionResult GetDepartments()
        {

           var res = _service.GetDepartments();

            try { return Ok(res); } catch { return BadRequest("error get departments!"); }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("getroles")]
        public IActionResult GetRoles()
        {

            var res = _service.GetRoles();

            try { return Ok(res); } catch { return BadRequest("error get roles!"); }
        }


    }
}