using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalSevice;
        IPaymentService _paymentService;

        public RentalsController(IRentalService rentalSevice,IPaymentService paymentService)
        {
            _rentalSevice = rentalSevice;
            _paymentService = paymentService;
        }
        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalSevice.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _rentalSevice.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getrentaldetails")]
        public IActionResult GetRentalDetails()
        {
            var result = _rentalSevice.GetRentalDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycarid")]

        public IActionResult GetByCarId(int carId)
        {
            var result = _rentalSevice.GetByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("paymentadd")]
        
        public ActionResult PaymentAdd(RentalPaymentDto rentalPaymentDto)
        {
            var paymentResult = _paymentService.ReceivePayment(rentalPaymentDto.Payment);
            if (!paymentResult.Success)
            {
                return BadRequest(paymentResult);
            }
            var result = _rentalSevice.Add(rentalPaymentDto.Rental);

            if (result.Success)
                return Ok(result);
            else
            {
                throw new System.Exception(result.Message);
                //return BadRequest(result);                    
            }
        }

    }
}
