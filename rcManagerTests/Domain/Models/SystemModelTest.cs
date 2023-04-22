using rcManagerEntities.Entities;
using rcManagerModels.Models;
using System;
using Xunit;

namespace rcManagerTests.Domain.Models
{
    public class SystemModelTest
    {
        [Fact]
        public void convertEmptySystemEntityToModel()
        {
            SystemEntity systemEntity = null;
            SystemModel systemModel = null;

            try
            {
                systemEntity = new SystemEntity();
                systemModel = new SystemModel(systemEntity);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo name deve estar preenchido (Parameter 'name')", ex.Message);
            }

            Assert.NotNull(systemEntity);
            Assert.Null(systemModel);
            Assert.Equal(0, systemEntity.id);
            Assert.Null(systemEntity.name);
            Assert.Null(systemEntity.description);
            Assert.False(systemEntity.status);
        }

        [Fact]
        public void convertSystemEntityWithInvalidIdToModel()
        {
            SystemEntity systemEntity = null;
            SystemModel systemModel = null;

            try
            {
                systemEntity = new SystemEntity();
                systemEntity.id = -1;
                systemModel = new SystemModel(systemEntity);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo id deve ser maior ou igual a zero (Parameter 'id')", ex.Message);
            }

            Assert.NotNull(systemEntity);
            Assert.Equal(-1, systemEntity.id);
            Assert.Null(systemEntity.name);
            Assert.Null(systemEntity.description);
            Assert.False(systemEntity.status);
            Assert.Null(systemModel);
        }

        [Fact]
        public void convertSystemEntityWithInvalidNameToModel()
        {
            SystemEntity systemEntity = null;
            SystemModel systemModel = null;

            try
            {
                systemEntity = new SystemEntity();
                systemEntity.id = 1;
                systemEntity.name = "";
                systemModel = new SystemModel(systemEntity);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo name deve estar preenchido (Parameter 'name')", ex.Message);
            }

            Assert.NotNull(systemEntity);
            Assert.Equal(1, systemEntity.id);
            Assert.NotNull(systemEntity.name);
            Assert.Equal(String.Empty, systemEntity.name);
            Assert.Null(systemEntity.description);
            Assert.False(systemEntity.status);
            Assert.Null(systemModel);
        }

        [Fact]
        public void convertSystemEntityWithInvalidDescriptionToModel()
        {
            SystemEntity systemEntity = null;
            SystemModel systemModel = null;

            try
            {
                systemEntity = new SystemEntity();
                systemEntity.id = 2345;
                systemEntity.name = "name";
                systemEntity.description = "";
                systemModel = new SystemModel(systemEntity);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo description deve estar preenchido (Parameter 'description')", ex.Message);
            }

            Assert.NotNull(systemEntity);
            Assert.Equal(2345, systemEntity.id);
            Assert.NotNull(systemEntity.name);
            Assert.Equal("name", systemEntity.name);
            Assert.NotNull(systemEntity.description);
            Assert.Equal(String.Empty, systemEntity.description);
            Assert.False(systemEntity.status);
            Assert.Null(systemModel);
        }

        [Fact]
        public void convertValidSystemEntityToModel()
        {
            SystemEntity systemEntity = null;
            SystemModel systemModel = null;

            try
            {
                systemEntity = new SystemEntity();
                systemEntity.id = long.MaxValue;
                systemEntity.name = "name";
                systemEntity.description = "description";
                systemEntity.status = true;
                systemModel = new SystemModel(systemEntity);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }

            Assert.NotNull(systemEntity);
            Assert.Equal(long.MaxValue, systemEntity.id);
            Assert.NotNull(systemEntity.name);
            Assert.Equal("name", systemEntity.name);
            Assert.NotNull(systemEntity.description);
            Assert.Equal("description", systemEntity.description);
            Assert.True(systemEntity.status);

            Assert.NotNull(systemModel);
            Assert.Equal(long.MaxValue, systemModel.id);
            Assert.NotNull(systemModel.name);
            Assert.Equal("name", systemModel.name);
            Assert.NotNull(systemModel.description);
            Assert.Equal("description", systemModel.description);
            Assert.True(systemModel.status);
        }
    }
}
