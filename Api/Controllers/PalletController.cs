using Api.Data;
using Api.Models;
using Api.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalletController : Controller
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;

        public PalletController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }

        [HttpGet("GetAllPallets")]
        public ResponseDto GetAllPallets() {

            try
            {
                IEnumerable<Pallet> pallets = _context.Pallets;
                _response.Data = pallets;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;

        }

        [HttpGet("GetPalletById/{id}")]
        public ResponseDto GetPalletById(int id)
        {
            try
            {   
                var pallet = _context.Pallets.FirstOrDefault(p => p.Id == id);
                _response.Data = pallet;
            }
            catch (Exception ex)
            { 
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPost("InsertarPallet")]
        public ResponseDto InsertarPallet([FromBody] Pallet pallet)
        {
            try 
            {
                _context.Pallets.Add(pallet);
                _context.SaveChanges();

                _response.Data = pallet;

            } catch (Exception ex) 
            {
                _response.isSuccess = false;
                _response.Message = ex.Message; 
            }
            return _response;
        }
    }
}
