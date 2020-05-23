using CaloriesApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CaloriesApi.Services
{
    public class Commands
    {
        public IMongoCollection<User> diary;
        public Commands()
        {
            var client = new MongoClient("mongodb+srv://Eleonora:Eleonora@cluster0-nkuob.azure.mongodb.net/test?retryWrites=true&w=majority");
            var database = client.GetDatabase("CaloriesDiary");
            diary = database.GetCollection<User>("Diary");
        }
        public List<User> GetCollection()
        {
            var list = diary.Find(user => true).ToList();

            return list;
        }

        public User Get(string id) =>
            diary.Find<User>(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            diary.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
            diary.ReplaceOne(user => user.Id == id, userIn);

       

        public string FindCalories(RequestInfo item)
        {
            string pattern = @"\s+";
            string target = "%20";
            Regex regex = new Regex(pattern);
            string name = regex.Replace(item.Food, target);
            item.link = $"https://api.edamam.com/api/nutrition-data?app_id=dee4523c&app_key=0766bed21c718f52331888c1a101fc4c&ingr={item.AmountFood}%{name}";
            return item.link;
        }
        public string FindRecipe(RequestInfo item)
        {
            string pattern = @"\s+";
            string target = "%20";
            Regex regex = new Regex(pattern);
            string name = regex.Replace(item.Recipe, target);
            item.link = $"https://api.edamam.com/search?q={name}&app_id=75e237ee&app_key=27bdce8be4539c40c312d74f87bcb032&from=0&to={item.AmountRecipe}";
            return item.link;
        }
    }
}
