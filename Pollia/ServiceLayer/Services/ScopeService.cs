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
    public interface IScopeService
    {
        Scope GetScope(int id);
        void CreateScope(Scope Scope);
        void EditScope(Scope Scope);
        void SaveScope();
        Scope GetScope(int? ScopeId);
        //List<Scope> GetScopesNearBy(float longitude, float latitude, float distance, int scope);
        IEnumerable<Scope> GetScopes();
    }

    public class ScopeService : IScopeService
    {
        private readonly IScopeRepository ScopeRepository;
        private readonly IUnitOfWork unitOfWork;

        public ScopeService(IScopeRepository ScopeRepository, IUnitOfWork unitOfWork)
        {
            this.ScopeRepository = ScopeRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateScope(Scope Scope)
        {
            ScopeRepository.Add(Scope);
            SaveScope();
        }

        public void EditScope(Scope Scope)
        {
            ScopeRepository.Update(Scope);
            SaveScope();
        }

        public Scope GetScope(int id)
        {
            var Scope = ScopeRepository.GetById(id);
            return Scope;
        }

        public Scope GetScope(int? ScopeId)
        {
            if (ScopeId != null)
            {
                var Scope = ScopeRepository.GetById((int)ScopeId);
                return Scope;
            }
            return null;
        }

        public IEnumerable<Scope> GetScopes()
        {
            return ScopeRepository.GetAll();
        }

        //public List<Scope> GetScopesNearBy(float longitude, float latitude, float distance, int scope)
        //{
        //    return ScopeRepository.GetScopeNearBy(longitude, latitude, distance, scope);
        //}

        public void SaveScope()
        {
            unitOfWork.Commit();
        }
    }
}
