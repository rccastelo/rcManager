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
            Assert.Equal(0, userEntity.id);
            Assert.Null(userEntity.name);
            Assert.Null(userEntity.description);
            Assert.False(userEntity.status);
            Assert.Null(userModel);
        }

        [Fact]
        public void convertUserEntityWithInvalidIdToModel()
        {
            UserEntity userEntity = null;
            UserModel userModel = null;

            try {
                userEntity = new UserEntity();
                userEntity.id = -1;
                userModel = new UserModel(userEntity);
            } catch (Exception ex) {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo [id] deve ser maior ou igual a zero (Parameter 'id')", ex.Message);
            }

            Assert.NotNull(userEntity);
            Assert.Equal(-1, userEntity.id);
            Assert.Null(userEntity.name);
            Assert.Null(userEntity.description);
            Assert.False(userEntity.status);
            Assert.Null(userModel);
        }

        [Fact]
        public void convertUserEntityWithNullNameToModel()
        {
            UserEntity userEntity = null;
            UserModel userModel = null;

            try {
                userEntity = new UserEntity();
                userEntity.id = 1;
                userEntity.name = null;
                userModel = new UserModel(userEntity);
            } catch (Exception ex) {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo [name] deve estar preenchido (Parameter 'name')", ex.Message);
            }

            Assert.NotNull(userEntity);
            Assert.Equal(1, userEntity.id);
            Assert.Null(userEntity.name);
            Assert.Null(userEntity.description);
            Assert.False(userEntity.status);
            Assert.Null(userModel);
        }

        [Fact]
        public void convertUserEntityWithInvalidNameToModel()
        {
            UserEntity userEntity = null;
            UserModel userModel = null;

            try {
                userEntity = new UserEntity();
                userEntity.id = 1;
                userEntity.name = "    ";
                userModel = new UserModel(userEntity);
            } catch (Exception ex) {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo [name] deve estar preenchido (Parameter 'name')", ex.Message);
            }

            Assert.NotNull(userEntity);
            Assert.Equal(1, userEntity.id);
            Assert.NotNull(userEntity.name);
            Assert.Equal("    ", userEntity.name);
            Assert.Null(userEntity.description);
            Assert.False(userEntity.status);
            Assert.Null(userModel);
        }

        [Fact]
        public void convertUserEntityWithShortNameToModel()
        {
            UserEntity userEntity = null;
            UserModel userModel = null;

            try {
                userEntity = new UserEntity();
                userEntity.id = 1;
                userEntity.name = "xx";
                userModel = new UserModel(userEntity);
            } catch (Exception ex) {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo [name] deve possuir no mínimo 3 caracteres (Parameter 'name')", ex.Message);
            }

            Assert.NotNull(userEntity);
            Assert.Equal(1, userEntity.id);
            Assert.NotNull(userEntity.name);
            Assert.Equal("xx", userEntity.name);
            Assert.Null(userEntity.description);
            Assert.False(userEntity.status);
            Assert.Null(userModel);
        }

        [Fact]
        public void convertUserEntityWithShortDescriptionToModel()
        {
            UserEntity userEntity = null;
            UserModel userModel = null;

            try {
                userEntity = new UserEntity();
                userEntity.id = 2345;
                userEntity.name = "name";
                userEntity.description = "xx";
                userModel = new UserModel(userEntity);
            } catch (Exception ex) {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo [description] deve possuir no mínimo 3 caracteres (Parameter 'description')", ex.Message);
            }

            Assert.NotNull(userEntity);
            Assert.Equal(2345, userEntity.id);
            Assert.NotNull(userEntity.name);
            Assert.Equal("name", userEntity.name);
            Assert.NotNull(userEntity.description);
            Assert.Equal("xx", userEntity.description);
            Assert.False(userEntity.status);
            Assert.Null(userModel);
        }

        [Fact]
        public void convertUserEntityWithNullDescriptionToModel()
        {
            UserEntity userEntity = null;
            UserModel userModel = null;

            try {
                userEntity = new UserEntity();
                userEntity.id = 23456;
                userEntity.name = "name";
                userEntity.description = null;
                userModel = new UserModel(userEntity);
            } catch (Exception ex) {
                Assert.Null(ex);
            }

            Assert.NotNull(userEntity);
            Assert.Equal(23456, userEntity.id);
            Assert.NotNull(userEntity.name);
            Assert.Equal("name", userEntity.name);
            Assert.Null(userEntity.description);
            Assert.False(userEntity.status);
            Assert.NotNull(userModel);
            Assert.Equal(23456, userModel.id);
            Assert.NotNull(userModel.name);
            Assert.Equal("name", userModel.name);
            Assert.Null(userModel.description);
            Assert.False(userModel.status);
        }

        [Fact]
        public void convertValidUserEntityToModel()
        {
            UserEntity userEntity = null;
            UserModel userModel = null;

            try {
                userEntity = new UserEntity();
                userEntity.id = long.MaxValue;
                userEntity.name = "name";
                userEntity.description = "description";
                userEntity.status = true;
                userModel = new UserModel(userEntity);
            } catch (Exception ex) {
                Assert.Null(ex);
            }

            Assert.NotNull(userEntity);
            Assert.Equal(long.MaxValue, userEntity.id);
            Assert.NotNull(userEntity.name);
            Assert.Equal("name", userEntity.name);
            Assert.NotNull(userEntity.description);
            Assert.Equal("description", userEntity.description);
            Assert.True(userEntity.status);
            Assert.NotNull(userModel);
            Assert.Equal(long.MaxValue, userModel.id);
            Assert.NotNull(userModel.name);
            Assert.Equal("name", userModel.name);
            Assert.NotNull(userModel.description);
            Assert.Equal("description", userModel.description);
            Assert.True(userModel.status);
        }
    }
}
