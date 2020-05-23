using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CaloriesApi.Models;
using System.Net.Http;
using Newtonsoft.Json;
using CaloriesApi.Services;

namespace CaloriesApi.Controllers
{

    [Route("api/[controller]")]
    public class CalController : Controller
    {

        public Commands commands;
        User user = new User();

        public CalController(Commands command)
        {
            commands = command;
        }
        [HttpPost]
        [Route("nutrition")]
        public async Task<ObjectResult> FindNutrition([FromBody]RequestInfo item)
        {
            string item1 = commands.FindCalories(item);
            using var client = new HttpClient();
            var content = await client.GetStringAsync(item1);
            FoodInfo foodInfo = new FoodInfo();
            foodInfo = JsonConvert.DeserializeObject<FoodInfo>(content);
            foodInfo.foodName = item.Food;
            foodInfo.foodAmount = item.AmountFood;
            return new ObjectResult(foodInfo);
        }

        [HttpPost]
        [Route("recipe")]
        public async Task<ObjectResult> FindRecipeInfo([FromBody] RequestInfo item)
        {
            string item1 = commands.FindRecipe(item);
            using var client = new HttpClient();
            var content = await client.GetStringAsync(item1);
            RecipeInfo result = JsonConvert.DeserializeObject<RecipeInfo>(content);
            return new ObjectResult(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<string> Create([FromBody]RequestInfo requestInfo)
        {
            string item1 = commands.FindCalories(requestInfo);
            using var client = new HttpClient();
            var content = await client.GetStringAsync(item1);
            FoodInfo foodInfo = new FoodInfo();
            foodInfo = JsonConvert.DeserializeObject<FoodInfo>(content);

            foodInfo.foodName = requestInfo.Food;
            foodInfo.foodAmount = requestInfo.AmountFood;
            user.food.Add(foodInfo);
            user.Id = requestInfo.id;
            commands.Create(user);
            return "Note added.";
        }
        [HttpGet]
        [Route("findall")]
        public ActionResult<List<User>> GetAll()
        {
            return commands.GetCollection();
        }
        [HttpGet("{id}")]
        [Route("find")]
        public ActionResult<User> GetById(string id)
        {
            RequestInfo requestInfo = new RequestInfo();
            requestInfo.id = id;
            user = commands.Get(requestInfo.id);
            return user;
        }
        [HttpPut]
        [Route("update")]
        public async Task<string> Update([FromBody]RequestInfo requestInfo)
        {
            var user1 = commands.Get(requestInfo.id);
            string item1 = commands.FindCalories(requestInfo);
            using var client = new HttpClient();
            var content = await client.GetStringAsync(item1);
            user1.Id = requestInfo.id;
            FoodInfo foodInfo = new FoodInfo();
            foodInfo = JsonConvert.DeserializeObject<FoodInfo>(content);
            foodInfo.foodName = requestInfo.Food;
            foodInfo.foodAmount = requestInfo.AmountFood;
            user1.food.Add(foodInfo);
            commands.Update(requestInfo.id, user1);
            return "Note updated.";
        }
        
        [HttpPut]
        [Route("delete")]
        public ActionResult<string> Delete([FromBody]RequestInfo requestInfo)
        {
            user = commands.Get(requestInfo.id);
            if (requestInfo.numberNote < user.food.Count)
            {
                user.food.RemoveAt(requestInfo.numberNote);
                commands.Update(requestInfo.id, user);
                return "Note is deleted.";
            }
            else
            {
                return "Nothing to delete.";
            }
            
        }
    }
}
