using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pagination_Core_Api.Helpers;
using Pagination_Core_Api.interfaces;
using Pagination_Core_Api.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination_Core_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly DemoContact _context;
        private readonly IUriService _uriService;

        public CustomerController(DemoContact context, IUriService uriService)
        {
            this._context = context;

            // This is Using to Generate the Urls of First, page, next and Previous page
            this._uriService = uriService;
        }



        //[HttpGet]

        //public IActionResult Get()
        //{
        //    var data = _context.Customers.ToList();

        //    return Ok(data);
        //}

        [HttpGet]

        public async Task<IActionResult> Get([FromQuery] PaginationFilter filter)
        {
            var route  = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            //var response =await  _context.Customers.ToListAsync();

            var pagedData = await _context.Customers
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();

            var totalRecors = await _context.Customers.CountAsync();

            var pagedReponse = PaginationHelper.CreatePagedReponse<Customer>(pagedData, validFilter, totalRecors, _uriService, route);
            //return Ok(new PagedResponse<List<Customer>>(pagedData,validFilter.PageNumber,validFilter.PageSize));

            return Ok(pagedReponse);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetCustomer (int id)
        {
            var customer =await _context.Customers.Where(s => s.Id == id).FirstOrDefaultAsync();

            return Ok(new Response<Customer>(customer));
        }
    }
}
