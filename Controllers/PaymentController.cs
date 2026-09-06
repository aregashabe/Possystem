using Microsoft.AspNetCore.Mvc;
using POSsystem.DTOs;
using POSsystem.Services;

namespace POSsystem.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    // GET: api/payments
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var payments = await _paymentService.GetAllAsync();

        return Ok(payments);
    }

    // GET: api/payments/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var payment = await _paymentService.GetByIdAsync(id);

        if (payment == null)
            return NotFound(new
            {
                message = "Payment not found."
            });

        return Ok(payment);
    }

    // POST: api/payments
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PaymentDto dto)
    {
        try
        {
            var payment = await _paymentService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = payment.Id },
                payment
            );
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }

    // PUT: api/payments/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] PaymentDto dto)
    {
        try
        {
            var updated = await _paymentService.UpdateAsync(id, dto);

            if (!updated)
                return NotFound(new
                {
                    message = "Payment not found."
                });

            return Ok(new
            {
                message = "Payment updated successfully."
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }

    // DELETE: api/payments/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _paymentService.DeleteAsync(id);

        if (!deleted)
            return NotFound(new
            {
                message = "Payment not found."
            });

        return Ok(new
        {
            message = "Payment deleted successfully."
        });
    }
}