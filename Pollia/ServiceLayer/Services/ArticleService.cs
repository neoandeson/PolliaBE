using DataLayer.Infrastucture;
using DataLayer.Repositories;
using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IArticleService
    {
        IEnumerable<Article> GetArticles(string name = null);
        Article GetArticle(int id);
        Article GetArticle(string name);
        Article GetArticleByAddress(string address);
        void CreateArticle(Article Article);
        void EditArticle(Article Article);
        void RemoveArticle(int id);
        void SaveArticle();
        void UnRemoveArticle(int id);
        Article GetArticle(int? ArticleId);
        //List<Article> GetArticlesNearBy(float longitude, float latitude, float distance, int scope);
        IEnumerable<Article> GetArticlesByName(string name, int curr, int take);
        int GetTotalArticles();
        int GetTotalArticlesOf(List<string> args);
    }

    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository ArticleRepository;
        private readonly IUnitOfWork unitOfWork;

        public ArticleService(IArticleRepository ArticleRepository, IUnitOfWork unitOfWork)
        {
            this.ArticleRepository = ArticleRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateArticle(Article Article)
        {
            ArticleRepository.Add(Article);
            SaveArticle();
        }

        public void EditArticle(Article Article)
        {
            ArticleRepository.Update(Article);
            SaveArticle();
        }

        public Article GetArticle(int id)
        {
            var Article = ArticleRepository.GetById(id);
            return Article;
        }

        public Article GetArticle(string name)
        {
            var Article = ArticleRepository.GetArticleByName(name);
            return Article;
        }

        public Article GetArticle(int? ArticleId)
        {
            if (ArticleId != null)
            {
                var Article = ArticleRepository.GetById((int)ArticleId);
                return Article;
            }
            return null;
        }

        public Article GetArticleByAddress(string address)
        {
            Article Article = ArticleRepository.GetArticleByAddress(address);
            return Article;
        }

        public IEnumerable<Article> GetArticles(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return ArticleRepository.GetAll();
            else
                return ArticleRepository.GetAll().Where(c => c.Title.Contains(name));
        }

        public IEnumerable<Article> GetArticlesByName(string name, int curr, int take)
        {
            if (string.IsNullOrEmpty(name))
                return null;
            else
                return ArticleRepository.GetArticlesByName(name, curr, take);
        }

        //public List<Article> GetArticlesNearBy(float longitude, float latitude, float distance, int scope)
        //{
        //    return ArticleRepository.GetArticleNearBy(longitude, latitude, distance, scope);
        //}

        public void RemoveArticle(int id)
        {
            Article p = ArticleRepository.GetById(id);
            p.IsEnable = false;
            ArticleRepository.Update(p);
            SaveArticle();
        }

        public void SaveArticle()
        {
            unitOfWork.Commit();
        }

        public void UnRemoveArticle(int id)
        {
            Article p = ArticleRepository.GetById(id);
            p.IsEnable = true;
            ArticleRepository.Update(p);
            SaveArticle();
        }

        public int GetTotalArticles()
        {
            return ArticleRepository.GetTotalArticle();
        }

        public int GetTotalArticlesOf(List<string> args)
        {
            return ArticleRepository.GetTotalArticlesOf(args);
        }
    }
}
