﻿using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Domain.Services;
using BeatClub.API.BeatClub.Resources;
using BeatClub.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BeatClub.API.BeatClub.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag("Create, read, update and delete Payments")]
    public class PaymentsController: ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentsController(IMapper mapper, IPaymentService paymentService)
        {
            _mapper = mapper;
            _paymentService = paymentService;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PaymentResource>),200)]
        public async Task<IEnumerable<PaymentResource>> GetAllAsync()
        {
            var payments = await _paymentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(payments);

            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaymentResource),201)]
        [ProducesResponseType(typeof(List<string>),400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostAsync([FromBody] SavePaymentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var payment = _mapper.Map<SavePaymentResource, Payment>(resource);

            var result = await _paymentService.SaveAsync(payment);

            if (!result.Success)
                return BadRequest(result.Message);

            var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);

            return Created(nameof(PostAsync),paymentResource);
            
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePaymentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var publication = _mapper.Map<SavePaymentResource, Payment>(resource);

            var result = await _paymentService.UpdateAsync(id, publication);

            if (!result.Success)
                return BadRequest(result.Message);

            var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);

            return Ok(paymentResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _paymentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);

            return Ok(paymentResource);

        }
        
    }
}