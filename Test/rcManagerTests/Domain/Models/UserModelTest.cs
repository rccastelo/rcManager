using rcManagerUserDomain;
using System;
using Xunit;

namespace rcManagerTests.Domain.Models
{
    public class UserModelTest
    {
        [Fact]
        public void convertNullUserEntityToModel()
        {
            UserEntity userEntity = null;
            UserModel userModel = null;

            try {
                userModel = new UserModel(userEntity);
            } catch (Exception ex) {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("[User] não pode ser nulo (Parameter 'User')", ex.Message);
            }

            Assert.Null(userEntity);
            Assert.Null(userModel);
        }

        [Fact]
        public void convertEmptyUserEntityToModel()
        {
            UserEntity userEntity = null;
            UserModel userModel = null;

            try {
                userEntity = new UserEntity();
                userModel = new UserModel(userEntity);
            } catch (Exception ex) {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo [name] deve estar preenchido (Parameter 'name')", ex.Message);
            }

            Assert.NotNull(userEntity);
            Assert.Equal(0, userEntity.Id);
            Assert.Null(userEntity.Name);
            Assert.Null(userEntity.Description);
            Assert.False(userEntity.Status);
            Assert.Null(userModel);
        }

        [Fact]
        public void convertUserEntityWithInvalidIdToModel()
        {
            UserEntity userEntity = null;
            UserModel userModel = null;

            try {
                userEntity = new UserEntity();
                userEntity.Id = -1;
                userModel = new UserModel(userEntity);
            } catch (Exception ex) {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo [id] deve ser maior ou igual a zero (Parameter 'id')", ex.Message);
            }

            Assert.NotNull(userEntity);
            Assert.Equal(-1, userEntity.Id);
            Assert.Null(userEntity.Name);
            Assert.Null(userEntity.Description);
            Assert.False(userEntity.Status);
            Assert.Null(userModel);
        }

        [Fact]
        public void convertUserEntityWithNullNameToModel()
        {
            UserEntity userEntity = null;
            UserModel userModel = null;

            try {
                userEntity = new UserEntity();
                userEntity.Id = 1;
                userEntity.Name = null;
                userModel = new UserModel(userEntity);
            } catch (Exception ex) {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo [name] deve estar preenchido (Parameter 'name')", ex.Message);
            }

            Assert.NotNull(userEntity);
            Assert.Equal(1, userEntity.Id);
            Assert.Null(userEntity.Name);
            Assert.Null(userEntity.Description);
            Assert.False(userEntity.Status);
            Assert.Null(userModel);
        }

        [Fact]
        public void convertUserEntityWithInvalidNameToModel()
        {
            UserEntity userEntity = null;
            UserModel userModel = null;

            try {
                userEntity = new UserEntity();
                userEntity.Id = 1;
                userEntity.Name = "    ";
                userModel = new UserModel(userEntity);
            } catch (Exception ex) {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo [name] deve estar preenchido (Parameter 'name')", ex.Message);
            }

            Assert.NotNull(userEntity);
            Assert.Equal(1, userEntity.Id);
            Assert.NotNull(userEntity.Name);
            Assert.Equal("    ", userEntity.Name);
            Assert.Null(userEntity.Description);
            Assert.False(userEntity.Status);
            Assert.Null(userModel);
        }

        [Fact]
        public void convertUserEntityWithShortNameToModel()
        {
            UserEntity userEntity = null;
            UserModel userModel = null;

            try {
                userEntity = new UserEntity();
                userEntity.Id = 1;
                userEntity.Name = "xx";
                userModel = new UserModel(userEntity);
            } catch (Exception ex) {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo [name] deve possuir no mínimo 3 caracteres (Parameter 'name')", ex.Message);
            }

            Assert.NotNull(userEntity);
            Assert.Equal(1, userEntity.Id);
            Assert.NotNull(userEntity.Name);
            Assert.Equal("xx", userEntity.Name);
            Assert.Null(userEntity.Description);
            Assert.False(userEntity.Status);
            Assert.Null(userModel);
        }

        [Fact]
        public void convertUserEntityWithShortDescriptionToModel()
        {
            UserEntity userEntity = null;
            UserModel userModel = null;

            try {
                userEntity = new UserEntity();
                userEntity.Id = 2345;
                userEntity.Name = "name";
                userEntity.Description = "xx";
                userModel = new UserModel(userEntity);
            } catch (Exception ex) {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo [description] deve possuir no mínimo 3 caracteres (Parameter 'description')", ex.Message);
            }

            Assert.NotNull(userEntity);
            Assert.Equal(2345, userEntity.Id);
            Assert.NotNull(userEntity.Name);
            Assert.Equal("name", userEntity.Name);
            Assert.NotNull(userEntity.Description);
            Assert.Equal("xx", userEntity.Description);
            Assert.False(userEntity.Status);
            Assert.Null(userModel);
        }

        [Fact]
        public void convertUserEntityWithNullDescriptionToModel()
        {
            UserEntity userEntity = null;
            UserModel userModel = null;

            try {
                userEntity = new UserEntity();
                userEntity.Id = 23456;
                userEntity.Name = "name";
                userEntity.Description = null;
                userModel = new UserModel(userEntity);
            } catch (Exception ex) {
                Assert.Null(ex);
            }

            Assert.NotNull(userEntity);
            Assert.Equal(23456, userEntity.Id);
            Assert.NotNull(userEntity.Name);
            Assert.Equal("name", userEntity.Name);
            Assert.Null(userEntity.Description);
            Assert.False(userEntity.Status);
            Assert.NotNull(userModel);
            Assert.Equal(23456, userModel.Id);
            Assert.NotNull(userModel.Name);
            Assert.Equal("name", userModel.Name);
            Assert.Null(userModel.Description);
            Assert.False(userModel.Status);
        }

        [Fact]
        public void convertValidUserEntityToModel()
        {
            UserEntity userEntity = null;
            UserModel userModel = null;

            try {
                userEntity = new UserEntity();
                userEntity.Id = long.MaxValue;
                userEntity.Name = "name";
                userEntity.Description = "description";
                userEntity.Status = true;
                userModel = new UserModel(userEntity);
            } catch (Exception ex) {
                Assert.Null(ex);
            }

            Assert.NotNull(userEntity);
            Assert.Equal(long.MaxValue, userEntity.Id);
            Assert.NotNull(userEntity.Name);
            Assert.Equal("name", userEntity.Name);
            Assert.NotNull(userEntity.Description);
            Assert.Equal("description", userEntity.Description);
            Assert.True(userEntity.Status);
            Assert.NotNull(userModel);
            Assert.Equal(long.MaxValue, userModel.Id);
            Assert.NotNull(userModel.Name);
            Assert.Equal("name", userModel.Name);
            Assert.NotNull(userModel.Description);
            Assert.Equal("description", userModel.Description);
            Assert.True(userModel.Status);
        }
    }
}
