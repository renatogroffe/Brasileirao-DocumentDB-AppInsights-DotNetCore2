using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents.Client;

namespace APIDadosBrasileirao.Controllers
{
    [Route("api/[controller]")]
    public class BrasileiraoController : Controller
    {
        [HttpGet]
        public IActionResult Get(
            [FromServices]DocumentDBConfigurations configurations)
        {
            using (var client = new DocumentClient(
                new Uri(configurations.EndpointUri),
                        configurations.PrimaryKey))
            {
                FeedOptions queryOptions =
                    new FeedOptions { MaxItemCount = -1 };

                return new ObjectResult(
                    client.CreateDocumentQuery(
                        UriFactory.CreateDocumentCollectionUri(
                            configurations.Database,
                            configurations.Collection),
                        "SELECT c.id, c.NomeCampeonato, c.Esporte, c.Pais, " +
                        "c.Equipes[0].Nome AS Lider, c.Equipes[19].Nome AS Ultimo " +
                        "FROM c " +
                        "WHERE c.NomeCampeonato = 'Brasileirão'",
                        queryOptions).ToList());
            }
        }
    }
}