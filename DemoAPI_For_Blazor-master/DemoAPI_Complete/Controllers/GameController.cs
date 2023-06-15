using DAL.Repositories;
using DemoAPI_Complete.DTO;
using DemoAPI_Complete.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ListHub = DemoAPI_Complete.Hubs.ChatHub;

namespace DemoAPI_Complete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository gameService;
        private readonly IHubContext<ListHub> _hubContext;

        public GameController(IGameRepository gameService, IHubContext<ListHub> hubContext)
        {
            this.gameService = gameService;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return  Ok(await gameService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await gameService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]GameDTO game)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await gameService.CreateGame(game.ToDal());
            await _hubContext.Clients.All.SendAsync("newGameList");
            return Ok();
        }
    }
}

