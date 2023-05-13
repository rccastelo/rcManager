using rcManagerSystemDomain.Entities;
using rcManagerSystemDomain.Models;
using System;
using Xunit;

namespace rcManagerTests.Domain.Models
{
    public class SystemModelTest
    {
        [Fact]
        public void convertNullSystemEntityToModel()
        {
            SystemEntity systemEntity = null;
            SystemModel systemModel = null;

            try
            {
                systemModel = new SystemModel(systemEntity);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("[System] não pode ser nulo (Parameter 'System')", ex.Message);
            }

            Assert.Null(systemEntity);
            Assert.Null(systemModel);
        }

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
                Assert.Equal("Campo [name] deve estar preenchido (Parameter 'name')", ex.Message);
            }

            Assert.NotNull(systemEntity);
            Assert.Equal(0, systemEntity.Id);
            Assert.Null(systemEntity.Name);
            Assert.Null(systemEntity.Description);
            Assert.False(systemEntity.Status);
            Assert.Null(systemModel);
        }

        [Fact]
        public void convertSystemEntityWithInvalidIdToModel()
        {
            SystemEntity systemEntity = null;
            SystemModel systemModel = null;

            try
            {
                systemEntity = new SystemEntity();
                systemEntity.Id = -1;
                systemModel = new SystemModel(systemEntity);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo [id] deve ser maior ou igual a zero (Parameter 'id')", ex.Message);
            }

            Assert.NotNull(systemEntity);
            Assert.Equal(-1, systemEntity.Id);
            Assert.Null(systemEntity.Name);
            Assert.Null(systemEntity.Description);
            Assert.False(systemEntity.Status);
            Assert.Null(systemModel);
        }

        [Fact]
        public void convertSystemEntityWithNullNameToModel()
        {
            SystemEntity systemEntity = null;
            SystemModel systemModel = null;

            try
            {
                systemEntity = new SystemEntity();
                systemEntity.Id = 1;
                systemEntity.Name = null;
                systemModel = new SystemModel(systemEntity);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo [name] deve estar preenchido (Parameter 'name')", ex.Message);
            }

            Assert.NotNull(systemEntity);
            Assert.Equal(1, systemEntity.Id);
            Assert.Null(systemEntity.Name);
            Assert.Null(systemEntity.Description);
            Assert.False(systemEntity.Status);
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
                systemEntity.Id = 1;
                systemEntity.Name = "    ";
                systemModel = new SystemModel(systemEntity);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo [name] deve estar preenchido (Parameter 'name')", ex.Message);
            }

            Assert.NotNull(systemEntity);
            Assert.Equal(1, systemEntity.Id);
            Assert.NotNull(systemEntity.Name);
            Assert.Equal("    ", systemEntity.Name);
            Assert.Null(systemEntity.Description);
            Assert.False(systemEntity.Status);
            Assert.Null(systemModel);
        }

        [Fact]
        public void convertSystemEntityWithShortNameToModel()
        {
            SystemEntity systemEntity = null;
            SystemModel systemModel = null;

            try
            {
                systemEntity = new SystemEntity();
                systemEntity.Id = 1;
                systemEntity.Name = "xx";
                systemModel = new SystemModel(systemEntity);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo [name] deve possuir no mínimo 3 caracteres (Parameter 'name')", ex.Message);
            }

            Assert.NotNull(systemEntity);
            Assert.Equal(1, systemEntity.Id);
            Assert.NotNull(systemEntity.Name);
            Assert.Equal("xx", systemEntity.Name);
            Assert.Null(systemEntity.Description);
            Assert.False(systemEntity.Status);
            Assert.Null(systemModel);
        }

        [Fact]
        public void convertSystemEntityWithShortDescriptionToModel()
        {
            SystemEntity systemEntity = null;
            SystemModel systemModel = null;

            try
            {
                systemEntity = new SystemEntity();
                systemEntity.Id = 2345;
                systemEntity.Name = "name";
                systemEntity.Description = "xx";
                systemModel = new SystemModel(systemEntity);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
                Assert.IsType<ArgumentException>(ex);
                Assert.Equal("Campo [description] deve possuir no mínimo 3 caracteres (Parameter 'description')", ex.Message);
            }

            Assert.NotNull(systemEntity);
            Assert.Equal(2345, systemEntity.Id);
            Assert.NotNull(systemEntity.Name);
            Assert.Equal("name", systemEntity.Name);
            Assert.NotNull(systemEntity.Description);
            Assert.Equal("xx", systemEntity.Description);
            Assert.False(systemEntity.Status);
            Assert.Null(systemModel);
        }

        [Fact]
        public void convertSystemEntityWithNullDescriptionToModel()
        {
            SystemEntity systemEntity = null;
            SystemModel systemModel = null;

            try
            {
                systemEntity = new SystemEntity();
                systemEntity.Id = 23456;
                systemEntity.Name = "name";
                systemEntity.Description = null;
                systemModel = new SystemModel(systemEntity);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }

            Assert.NotNull(systemEntity);
            Assert.Equal(23456, systemEntity.Id);
            Assert.NotNull(systemEntity.Name);
            Assert.Equal("name", systemEntity.Name);
            Assert.Null(systemEntity.Description);
            Assert.False(systemEntity.Status);
            Assert.NotNull(systemModel);
            Assert.Equal(23456, systemModel.Entity.Id);
            Assert.NotNull(systemModel.Entity.Name);
            Assert.Equal("name", systemModel.Entity.Name);
            Assert.Null(systemModel.Entity.Description);
            Assert.False(systemModel.Entity.Status);
        }

        [Fact]
        public void convertValidSystemEntityToModel()
        {
            SystemEntity systemEntity = null;
            SystemModel systemModel = null;

            try
            {
                systemEntity = new SystemEntity();
                systemEntity.Id = long.MaxValue;
                systemEntity.Name = "name";
                systemEntity.Description = "description";
                systemEntity.Status = true;
                systemModel = new SystemModel(systemEntity);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }

            Assert.NotNull(systemEntity);
            Assert.Equal(long.MaxValue, systemEntity.Id);
            Assert.NotNull(systemEntity.Name);
            Assert.Equal("name", systemEntity.Name);
            Assert.NotNull(systemEntity.Description);
            Assert.Equal("description", systemEntity.Description);
            Assert.True(systemEntity.Status);
            Assert.NotNull(systemModel);
            Assert.Equal(long.MaxValue, systemModel.Entity.Id);
            Assert.NotNull(systemModel.Entity.Name);
            Assert.Equal("name", systemModel.Entity.Name);
            Assert.NotNull(systemModel.Entity.Description);
            Assert.Equal("description", systemModel.Entity.Description);
            Assert.True(systemModel.Entity.Status);
        }
    }
}
