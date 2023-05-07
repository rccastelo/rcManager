using rcManagerUserDomain;
using rcManagerUserRepository.Interfaces;
using System.Collections.Generic;

namespace rcManagerUserRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserData _userData;

        public UserRepository(IUserData userData)
        {
            this._userData = userData;
        }

        public UserModel Get(long id)
        {
            UserModel ret = _userData.Get(id);

            return ret;
        }

        public IList<UserModel> List()
        {
            IList<UserModel> ret = _userData.List();

            return ret;
        }

        public UserModel Insert(UserModel model)
        {
            UserModel ret = _userData.Insert(model);

            _userData.Save();

            return ret;
        }

        public UserModel Update(UserModel model)
        {
            UserModel ret = _userData.Update(model);

            _userData.Save();

            return ret;
        }

        public UserModel Delete(UserModel model)
        {
            UserModel ret = _userData.Delete(model);

            _userData.Save();

            return ret;
        }
    }
}
