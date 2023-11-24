using Microsoft.AspNetCore.Mvc;
using subcypherAPI.Models;
using static subcypherAPI.Logger;


namespace subcypherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptControllers : ControllerBase
    {
        // GET: api/<EncryptControllers>
       private readonly Logger _logger;
        public EncryptControllers(Logger logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<string> Encrypt([FromBody] EncryptModel encryptModel)
        {
            int key = encryptModel.Jumps;
            string ALPHABET = "abcdefghijklmnopqrstuvwxyz";
            string cypherText = "";

            foreach (char letter in encryptModel.PlainText)
            {
                if (char.ToLower(letter) is >= 'a' and <= 'z')
                {
                    int num = ALPHABET.IndexOf(char.ToLower(letter));

                    num = (num + key) % ALPHABET.Length;

                    if (letter == char.ToLower(letter))
                    {
                        cypherText += ALPHABET[num];
                    }
                    else
                    {
                        cypherText += char.ToUpper(ALPHABET[num]);
                    }
                }
                else
                {
                    cypherText += letter;
                }
            }

            _logger.AddLog($"encryption  -  {encryptModel.PlainText}  -  {cypherText}");

            return cypherText;
        }
    } 
}
