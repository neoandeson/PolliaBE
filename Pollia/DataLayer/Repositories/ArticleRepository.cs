using DataLayer.Infrastucture;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Article GetById(int? ArticleId)
        {
            if (ArticleId != null)
            {
                Article Article = this.DbContext.Articles.Where(p => p.Id == ArticleId).FirstOrDefault();
                return Article;
            }
            return null;
        }

        public Article GetArticleByAddress(string address)
        {
            Article Article = this.DbContext.Articles.Where(p => p.Place.Address.Contains(address)).FirstOrDefault();
            return Article;
        }

        public Article GetArticleByName(string ArticleName)
        {
            Article Article = this.DbContext.Articles.Where(p => p.Title.Contains(ArticleName)).FirstOrDefault();
            return Article;
        }

        //public List<Article> GetArticleNearBy(float longitude, float latitude, float distance, int scope)
        //{
        //    List<Article> Articles = this.DbContext.Articles.Where(p => ((Math.Abs((p.Longitude - longitude)) < distance) && (Math.Abs((p.Latitude - latitude)) < distance)) && (p.ArticleKindId == scope)).Take(20).ToList();
        //    return Articles;
        //}

        public IEnumerable<Article> GetArticlesByName(string ArticleName, int curr, int take)
        {
            IEnumerable<Article> Articles = this.DbContext.Articles.Where(p => p.Title.Contains(ArticleName)).OrderBy(p => p.DateCreate).Skip(curr).Take(take);
            return Articles;
        }

        public int GetTotalArticle()
        {
            return this.DbContext.Articles.Count();
        }

        public int GetTotalArticlesOf(List<string> args)
        {
            return this.DbContext.Articles.Where(q => args.Contains(q.UserId)).Count();
        }
    }

    public interface IArticleRepository : IRepository<Article>
    {
        Article GetArticleByAddress(string address);
        Article GetArticleByName(string ArticleName);
        IEnumerable<Article> GetArticlesByName(string ArticleName, int curr, int take);
        //List<Article> GetArticleNearBy(float longitude, float latitude, float distance, int scope);
        Article GetById(int? ArticleId);
        int GetTotalArticle();
        int GetTotalArticlesOf(List<string> args);
    }
}
