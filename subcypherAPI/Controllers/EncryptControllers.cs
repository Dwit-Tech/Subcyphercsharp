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
        public ActionResult<string> Encrypt([FromBody] string stringToEncrypt)
        {
            int jumps = GetfromDatabase;
            string ALPHABET = "abcdefghijklmnopqrstuvwxyz";
            string cypherText = "";

            foreach (char letter in stringToEncrypt)
            {
                if (char.ToLower(letter) is >= 'a' and <= 'z')
                {
                    int num = ALPHABET.IndexOf(char.ToLower(letter));

                    num = (num + jumps) % ALPHABET.Length;

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

            EncryptModel model = new EncryptModel();
            model.PlainText = stringToEncrypt;
            model.Jumps = jumps;
            model.EncryptedText = cypherText;
            model.EncryptionTime = DateTime.Now;

            dbContext.EncryptModels.Add(model);
            dbContext.SaveChanges();

            return cypherText;
        }
    } 
}
