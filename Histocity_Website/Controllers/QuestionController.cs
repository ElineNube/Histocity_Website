using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Histocity_Website.Models;
using Microsoft.Extensions.Configuration;

namespace Histocity_Website.Controllers
{
    public class QuestionController : Controller
    { 
        MySqlConnection connection = new MySqlConnection("Database=heroku_9a1fa21f73d10db;Data Source=eu-cdbr-west-03.cleardb.net;User Id=bcfe6ec0812a08;Password=0f9c4546");

        public IActionResult Question()
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select questions.QuestionText, answers.AnswerText from questions INNER JOIN answers ON questions.AnswerID = answers.AnswerID";
            MySqlDataReader reader = command.ExecuteReader();

            var model = new List<Question>();

            while (reader.Read())
            {
                var question = new Question();
                question.QuestionText = reader["questionText"].ToString();
                question.GoodAnswer = reader["answerText"].ToString();

                model.Add(question);
            }
            reader.Close();

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string questionText)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO questions (questionText)VALUES("+ questionText +"); ";
            return View();
        }
    }
}
