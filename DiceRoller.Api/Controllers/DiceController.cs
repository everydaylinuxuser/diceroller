using Microsoft.AspNetCore.Mvc;

namespace DiceRoller.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiceController : ControllerBase
    {
        /// <summary>
        /// Roll a dice with the specified number of sides
        /// </summary>
        /// <param name="sides">Number of sides on the dice (minimum 2)</param>
        /// <returns>Random integer between 1 and sides (inclusive)</returns>
        [HttpGet("roll/{sides}")]
        public ActionResult<DiceRollResult> Roll(int sides)
        {
            try
            {
                var result = Dice.Roll(sides);
                return Ok(new DiceRollResult { Sides = sides, Result = result });
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Roll multiple dice with the same number of sides
        /// </summary>
        /// <param name="sides">Number of sides on each dice (minimum 2)</param>
        /// <param name="count">Number of dice to roll (minimum 1)</param>
        /// <returns>Array of roll results and total</returns>
        [HttpGet("roll/{sides}/{count}")]
        public ActionResult<MultipleDiceRollResult> RollMultiple(int sides, int count)
        {
            if (count < 1)
                return BadRequest(new { error = "Count must be at least 1" });

            try
            {
                var results = new int[count];
                for (int i = 0; i < count; i++)
                {
                    results[i] = Dice.Roll(sides);
                }

                return Ok(new MultipleDiceRollResult
                {
                    Sides = sides,
                    Count = count,
                    Results = results,
                    Total = results.Sum()
                });
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }

    public class DiceRollResult
    {
        public int Sides { get; set; }
        public int Result { get; set; }
    }

    public class MultipleDiceRollResult
    {
        public int Sides { get; set; }
        public int Count { get; set; }
        public int[] Results { get; set; } = Array.Empty<int>();
        public int Total { get; set; }
    }
}
