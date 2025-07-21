using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPIBasics.Domains;
using WebAPIBasics.Model;

namespace WebAPIBasics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        private readonly EmployeesDBContext _employeesDBContext;
        public CRUDController(EmployeesDBContext employeesDBContext)
        {
            _employeesDBContext = employeesDBContext;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TblCrudRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                TblCrudTest tbl = new TblCrudTest
                {
                    Email = request.Email,
                    Name = request.Name
                };

                _employeesDBContext.TblCrudTest.Add(tbl);
                var id = await _employeesDBContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TblCrudResponse>>> GetAll()
        {
            try
            {
                List<TblCrudResponse> responses = new List<TblCrudResponse>();

                var result = _employeesDBContext.TblCrudTest.Where(x => !x.IsDeleted).ToList();

                if (result is not null && result.Any())
                {
                    foreach (var tbl in result)
                    {
                        TblCrudResponse response = new TblCrudResponse()
                        {
                            Email = tbl.Email,
                            Name = tbl.Name,
                            Id = tbl.Id,
                            IsDeleted = tbl.IsDeleted
                        };

                        responses.Add(response);
                    }
                }

                return Ok(responses);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCrudResponse>> GetById(int id)
        {
            try
            {
                TblCrudResponse response = new TblCrudResponse();
                var requestRecord = _employeesDBContext.TblCrudTest.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

                if (requestRecord is not null)
                {                 
                    response.Email = requestRecord.Email;
                    response.Name = requestRecord.Name;
                    response.Id = requestRecord.Id;
                    response.IsDeleted = requestRecord.IsDeleted;                   
                }

                return Ok(response);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TblCrudResponse>> PUT(int id, [FromBody] TblCrudUpdate payload)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(payload.Email) && string.IsNullOrWhiteSpace(payload.Name))
                {
                    return BadRequest("no properties exists for update");
                }

                var requestRecord = _employeesDBContext.TblCrudTest.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
                if (requestRecord is not null)
                {

                    if (!string.IsNullOrWhiteSpace(payload.Email))
                    {
                        requestRecord.Email = payload.Email;
                    }

                    if (!string.IsNullOrWhiteSpace(payload.Name))
                    {
                        requestRecord.Name = payload.Name;
                    }

                    _employeesDBContext.Update(requestRecord);
                    await _employeesDBContext.SaveChangesAsync();

                    var res = new TblCrudResponse()
                    {
                        Email = requestRecord.Email,
                        Name = requestRecord.Name,
                        Id = requestRecord.Id,
                        IsDeleted = requestRecord.IsDeleted
                    };

                    return Ok(res);

                }

                return NotFound("Record not exist.");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                var requestRecord = _employeesDBContext.TblCrudTest.FirstOrDefault(x => x.Id == id);
                if (requestRecord is not null)
                {
                    if (requestRecord.IsDeleted)
                    {
                        return NotFound("Record not exist.");
                    }
                    _employeesDBContext.TblCrudTest.Remove(requestRecord);
                    await _employeesDBContext.SaveChangesAsync();

                    return Ok();
                }
                return NotFound("Record not exist.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
