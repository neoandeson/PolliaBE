using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Models;
using DataLayer.Repositories;

namespace DataLayer
{
    public class PlaceGDB
    {
        /// <summary>
        /// Get all places
        /// </summary>
        public void Get()
        {
            var driver = GraphDatabase.Driver("bolt://hobby-geefdaeefcom.dbs.graphenedb.com:24786", AuthTokens.Basic("v303", "GtGq5rldxu"), Config.Builder.WithEncryptionLevel(EncryptionLevel.Encrypted).ToConfig());

            using (var session = driver.Session())
            {
                var result = session.Run("MATCH (x:Place) RETURN x");
            }
        }

        /// <summary>
        /// Get place by Id
        /// </summary>
        public void GetPlaceById()
        {

        }

        /// <summary>
        /// Get places that contains name and available (available code is in Enumes)
        /// </summary>
        /// <param name="name"></param>
        public void GetPlacesByName(string name)
        {

        }


        /// <summary>
        /// Get palces by scope
        /// </summary>
        /// <param name="scopeId"></param>
        public void GetPlacesByScopeId(string scopeId)
        {

        }

        /// <summary>
        /// Update tren GraphDB
        /// </summary>
        /// <param name="place"></param>
        public void Set(Place place)
        {

        }

        /// <summary>
        /// Update tren SQLDB, đưa ý tưởng t cung dc.
        /// </summary>
        /// <param name="place"></param>
        public void SetSQL(Place place)
        {

        }

        /// <summary>
        /// Add len tren Graph db
        /// </summary>
        /// <param name="place"></param>
        public void Add(Place place)
        {

        }


        /// <summary>
        /// Add to SQL database
        /// </summary>
        /// <param name="place"></param>
        public void AddSQL(Place place)
        {
            
        }

    }
}
