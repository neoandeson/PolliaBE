using Neo4j.Driver.V1;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pollia.Controllers.FunctionControllers
{
    public class ScopeController : ApiController
    {
        private readonly IScopeService _scopeService;

        public ScopeController(IScopeService scopeService)
        {
            _scopeService = scopeService;
        }

        public IHttpActionResult CreateScope()
        {
            var res = InitScope();
            return Ok();
        }

        public bool InitScope()
        {
            try
            {
                var SQLScopes = _scopeService.GetScopes();

                var driver = GraphDatabase.Driver("bolt://hobby-felgnkmbemaigbkeikdjljal.dbs.graphenedb.com:24786", AuthTokens.Basic("tientp", "b.D5cR13fg9cAl.Uss6t4T5UX0RU8K2"), Config.Builder.WithEncryptionLevel(EncryptionLevel.Encrypted).ToConfig());
                using (var session = driver.Session())
                {
                    //var result = session.Run("MATCH (x:Place) RETURN x");
                    foreach (var item in SQLScopes)
                    {
                        var result = session.Run("CREATE (scope: Scope { "
                            + "Id: " + item.Id
                            + ", StartLongitude: " + item.StartLongitude
                            + ", EndLongitude: " + item.EndLongitude
                            + ", StartLatitude: " + item.StartLatitude
                            + ", EndLatitude: " + item.EndLatitude
                            + "})");
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }
    }
}
