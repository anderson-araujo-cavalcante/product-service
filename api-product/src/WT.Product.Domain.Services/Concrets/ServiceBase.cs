using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WT.Product.Data.Entities;
using WT.Product.Data.Repositories.Concrets;
using WT.Product.Data.Repositories.Interfaces;
using WT.Product.Domain.Services.Interfaces;

//namespace WT.Product.Domain.Services.Concrets
//{
//    public abstract class ServiceBase<TEntity> : ServiceBase, IServiceBase<TEntity> where TEntity : class
//    {
//        //protected IBaseRepository<TEntity> _repository;
//        public ServiceBase(IBaseRepository<TEntity> repository) : base(repository)
//        {
//           // _repository = repository;
//        }
//    }

//    public class ServiceBase : IServiceBase
//    {
//        private IBaseRepository<TEntity> _repository;

//        public ServiceBase(IBaseRepository<TEntity> repository)
//        {
//            _repository = repository;
//        }

//        //public Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
//        //    => _repository.QueryAsync<T>(sql, param);

//        #region IDisposable Members

//        private bool _disposed;

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!_disposed)
//            {
//                if (disposing)
//                {
//                    if (_repository != null)
//                    {
//                        _repository.Dispose();
//                        _repository = null;
//                    }
//                }
//            }

//            _disposed = true;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        #endregion IDisposable Members
//    }
//}
//    }
//}
