using System.Linq;
using VirtualPool.Data;

namespace VirtualPool.Manager.Data
{
    public class PoolManager : IPoolManager
    {
        public PoolManager()
        {
            this.VirtualPoolContext = new virtualpoolEntities();
        }

        public string Login(string userId, string password)
        {
            client_user user = this.VirtualPoolContext.client_user.Find(userId);

            return user != null && user.Password.Equals(password) ? userId : null;
        }

        public void Logout(string userId)
        {
            foreach (product blockedProduct in this.VirtualPoolContext.product.Where(p => userId.Equals(p.Blocking_User_Id)))
            {
                blockedProduct.Blocking_User_Id = null;
            }

            this.VirtualPoolContext.SaveChanges();
        }

        public bool BlockArticle(string userId, string articleId)
        {
            article article = this.VirtualPoolContext.article.Find(articleId);

            if (article == null || article.Active)
            {
                return false;
            }

            client_user user = this.VirtualPoolContext.client_user.Find(userId);

            if (user == null)
            {
                return false;
            }

            product product = this.VirtualPoolContext.product.Find(article.Product_Id);

            if (product == null ||
                product.Blocking_User_Id != null ||
                !product.Category_Id.Equals(user.Product_Category_Id))
            {
                return false;
            }

            product.Blocking_User_Id = userId;

            this.VirtualPoolContext.SaveChanges();

            return true;
        }

        public bool ReleaseArticle(string userId, string articleId)
        {
            article article = this.VirtualPoolContext.article.Find(articleId);

            if (article == null)
            {
                return false;
            }

            product product = this.VirtualPoolContext.product.Find(article.Product_Id);

            if (product == null || !userId.Equals(product.Blocking_User_Id))
            {
                return false;
            }

            product.Blocking_User_Id = null;

            this.VirtualPoolContext.SaveChanges();

            return true;
        }

        /// <summary>
        /// virtualpoolEntities
        /// </summary>
        private virtualpoolEntities VirtualPoolContext;
    }
}
